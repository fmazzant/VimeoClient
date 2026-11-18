/// <summary>
/// 
/// The MIT License (MIT)
/// 
/// Copyright (c) 2020 Federico Mazzanti
/// 
/// Permission is hereby granted, free of charge, to any person
/// obtaining a copy of this software and associated documentation
/// files (the "Software"), to deal in the Software without
/// restriction, including without limitation the rights to use,
/// copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the
/// Software is furnished to do so, subject to the following
/// conditions:
/// 
/// The above copyright notice and this permission notice shall be
/// included in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
/// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
/// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
/// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
/// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
/// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
/// OTHER DEALINGS IN THE SOFTWARE.
/// 
/// </summary>

namespace Mafesoft.VimeoClient.Common
{
    using Mafesoft.RestClient;
    using Mafesoft.VimeoClient.Body.Video;
    using Mafesoft.VimeoClient.Model;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The result of <see cref="VimeoVideos.UploadAsync(Stream, VideoUploadParameters, IProgress{long}, CancellationToken)"/>
    /// and <see cref="VimeoVideos.ResumeUploadAsync(string, Stream, IProgress{long}, CancellationToken)"/>.
    /// </summary>
    public sealed class VimeoUploadResult
    {
        /// <summary>
        /// The result of the request that created the video (POST /me/videos); null for a resumed upload.
        /// </summary>
        public RestResult<Video>? Creation { get; internal set; }

        /// <summary>
        /// The created video (its uri, link and upload object); null if it could not be created, or for a resumed upload.
        /// </summary>
        public Video? Video => Creation?.Content;

        /// <summary>
        /// The tus upload link: pass it to <see cref="VimeoVideos.ResumeUploadAsync(string, Stream, IProgress{long}, CancellationToken)"/>
        /// to continue an upload that did not complete.
        /// </summary>
        public string? UploadLink { get; internal set; }

        /// <summary>
        /// The size of the file, in bytes.
        /// </summary>
        public long Size { get; internal set; }

        /// <summary>
        /// The bytes received by Vimeo so far.
        /// </summary>
        public long Offset { get; internal set; }

        /// <summary>
        /// Whether Vimeo received the whole file. Vimeo then transcodes the video: see <c>transcode.status</c> of the video.
        /// </summary>
        public bool IsCompleted => UploadLink != null && Exception == null && Offset >= Size;

        /// <summary>
        /// The status code of the last failed request (creation, chunk or offset), or null.
        /// </summary>
        public HttpStatusCode? StatusCode { get; internal set; }

        /// <summary>
        /// Why the upload did not complete, or null.
        /// </summary>
        public Exception? Exception { get; internal set; }
    }

    /// <summary>
    /// Video upload with the resumable tus approach (issue #14): https://developer.vimeo.com/api/upload/videos
    /// </summary>
    public partial class VimeoVideos
    {
        private const string TusVersion = "1.0.0";
        private const string OffsetContentType = "application/offset+octet-stream";

        /// <summary>
        /// The size of each PATCH request of the tus upload. 8 MB by default.
        /// </summary>
        public static int UploadChunkSize { get; set; } = 8 * 1024 * 1024;

        /// <summary>
        /// How many times in a row a failed chunk is sent again (after reading the offset from Vimeo) before the upload
        /// stops. 3 by default.
        /// </summary>
        public static int UploadChunkRetries { get; set; } = 3;

        /// <summary>
        /// Uploads a video file with the resumable tus approach: creates the video, sends the file in chunks
        /// (PATCH with Upload-Offset) and, after an error, reads the offset received by Vimeo (HEAD) and continues from there.
        /// </summary>
        /// <param name="filePath">The video file.</param>
        /// <param name="parameters">The metadata of the video (name, description, privacy, folder); the approach and the size are set by the method. Without a name, the file name is used.</param>
        /// <param name="progress">Reports the bytes received by Vimeo after every chunk (optional).</param>
        /// <param name="cancellationToken">The token to cancel the upload; resume it later with <see cref="ResumeUploadAsync(string, Stream, IProgress{long}, CancellationToken)"/>.</param>
        /// <returns>The created video and the state of the upload. It does not throw for HTTP errors: see <see cref="VimeoUploadResult.IsCompleted"/> and <see cref="VimeoUploadResult.Exception"/>.</returns>
        public virtual async Task<VimeoUploadResult> UploadAsync(string filePath, VideoUploadParameters? parameters = null, IProgress<long>? progress = null, CancellationToken cancellationToken = default)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 81920, useAsync: true))
            {
                parameters = parameters ?? new VideoUploadParameters();
                if (string.IsNullOrEmpty(parameters.Name))
                {
                    parameters.Name = Path.GetFileNameWithoutExtension(filePath);
                }
                return await UploadAsync(stream, parameters, progress, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads a video with the resumable tus approach: creates the video (POST /me/videos), sends the stream in chunks
        /// (PATCH with Upload-Offset) and, after an error, reads the offset received by Vimeo (HEAD) and continues from there.
        /// </summary>
        /// <param name="stream">The video, from its current position to the end. It must be seekable (a file or a memory stream).</param>
        /// <param name="parameters">The metadata of the video (name, description, privacy, folder); the approach and the size are set by the method.</param>
        /// <param name="progress">Reports the bytes received by Vimeo after every chunk (optional).</param>
        /// <param name="cancellationToken">The token to cancel the upload; resume it later with <see cref="ResumeUploadAsync(string, Stream, IProgress{long}, CancellationToken)"/>.</param>
        /// <returns>The created video and the state of the upload. It does not throw for HTTP errors: see <see cref="VimeoUploadResult.IsCompleted"/> and <see cref="VimeoUploadResult.Exception"/>.</returns>
        public virtual async Task<VimeoUploadResult> UploadAsync(Stream stream, VideoUploadParameters? parameters = null, IProgress<long>? progress = null, CancellationToken cancellationToken = default)
        {
            CheckUploadStream(stream);

            var start = stream.Position;
            var size = stream.Length - start;
            parameters = parameters ?? new VideoUploadParameters();
            parameters.Approach = VideoUploadApproach.tus;
            parameters.Size = size;

            var result = new VimeoUploadResult { Size = size };
            result.Creation = await UploadAVideoAsync(parameters, cancellationToken).ConfigureAwait(false);
            var uploadLink = result.Video?.Upload?.UploadLink;
            if (!result.Creation.IsSuccessStatusCode || uploadLink == null || uploadLink.Length == 0)
            {
                result.StatusCode = result.Creation.Response != null ? result.Creation.StatusCode : (HttpStatusCode?)null;
                result.Exception = result.Creation.Exception
                    ?? new InvalidOperationException($"The video could not be created for a tus upload ({(int)result.Creation.StatusCode} {result.Creation.ReasonPhrase}).");
                return result;
            }

            result.UploadLink = uploadLink;
            await SendChunksAsync(result, stream, start, progress, readOffsetFirst: false, cancellationToken).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Continues a tus upload that did not complete: reads from Vimeo the bytes already received (HEAD) and sends the rest.
        /// </summary>
        /// <param name="uploadLink">The upload link of the video (<see cref="VimeoUploadResult.UploadLink"/>, or <c>upload.upload_link</c> of the video).</param>
        /// <param name="stream">The same video, positioned at its first byte. It must be seekable.</param>
        /// <param name="progress">Reports the bytes received by Vimeo after every chunk (optional).</param>
        /// <param name="cancellationToken">The token to cancel the upload.</param>
        /// <returns>The state of the upload. It does not throw for HTTP errors: see <see cref="VimeoUploadResult.IsCompleted"/> and <see cref="VimeoUploadResult.Exception"/>.</returns>
        public virtual async Task<VimeoUploadResult> ResumeUploadAsync(string uploadLink, Stream stream, IProgress<long>? progress = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(uploadLink)) throw new ArgumentNullException(nameof(uploadLink));
            CheckUploadStream(stream);

            var start = stream.Position;
            var result = new VimeoUploadResult { UploadLink = uploadLink, Size = stream.Length - start };
            await SendChunksAsync(result, stream, start, progress, readOffsetFirst: true, cancellationToken).ConfigureAwait(false);
            return result;
        }

        private static void CheckUploadStream(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!stream.CanRead || !stream.CanSeek)
            {
                throw new ArgumentException("The stream must be readable and seekable (a file or a memory stream): a tus upload resumes from the offset received by Vimeo.", nameof(stream));
            }
        }

        private async Task SendChunksAsync(VimeoUploadResult result, Stream stream, long start, IProgress<long>? progress, bool readOffsetFirst, CancellationToken cancellationToken)
        {
            var client = Vimeo.UploadHttpClient;
            var buffer = new byte[(int)Math.Max(1, Math.Min(Math.Max(1, UploadChunkSize), result.Size))];
            var failures = 0;
            var readOffset = readOffsetFirst;

            try
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (readOffset)
                    {
                        var offset = await ReadUploadOffsetAsync(client, result, cancellationToken).ConfigureAwait(false);
                        if (offset == null)
                        {
                            return;
                        }
                        result.Offset = offset.Value;
                        progress?.Report(result.Offset);
                        readOffset = false;
                    }

                    if (result.Offset >= result.Size)
                    {
                        result.Exception = null;
                        result.StatusCode = null;
                        return;
                    }

                    stream.Position = start + result.Offset;
                    var count = await ReadChunkAsync(stream, buffer, (int)Math.Min(buffer.Length, result.Size - result.Offset), cancellationToken).ConfigureAwait(false);

                    try
                    {
                        using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), result.UploadLink))
                        {
                            request.Headers.Add("Tus-Resumable", TusVersion);
                            request.Headers.Add("Upload-Offset", result.Offset.ToString(CultureInfo.InvariantCulture));
                            request.Content = new ByteArrayContent(buffer, 0, count);
                            request.Content.Headers.ContentType = new MediaTypeHeaderValue(OffsetContentType);

                            using (var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false))
                            {
                                if (response.IsSuccessStatusCode && ReadLongHeader(response, "Upload-Offset") is long received)
                                {
                                    result.Offset = received;
                                    progress?.Report(result.Offset);
                                    failures = 0;
                                    continue;
                                }

                                result.StatusCode = response.StatusCode;
                                result.Exception = new HttpRequestException($"The tus upload failed at offset {result.Offset} ({(int)response.StatusCode} {response.ReasonPhrase}).");
                            }
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        result.Exception = ex;
                    }
                    catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
                    {
                        result.Exception = ex; // timeout of the HttpClient
                    }

                    // The chunk failed: ask Vimeo how much it received, then continue from there.
                    if (++failures > UploadChunkRetries)
                    {
                        return;
                    }
                    readOffset = true;
                }
            }
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                result.Exception = ex;
            }
        }

        private static async Task<int> ReadChunkAsync(Stream stream, byte[] buffer, int count, CancellationToken cancellationToken)
        {
            var read = 0;
            while (read < count)
            {
                var n = await stream.ReadAsync(buffer, read, count - read, cancellationToken).ConfigureAwait(false);
                if (n == 0)
                {
                    throw new EndOfStreamException("The stream ended before the size of the upload.");
                }
                read += n;
            }
            return read;
        }

        // HEAD on the upload link: the bytes received by Vimeo (Upload-Offset); null when the request fails.
        private static async Task<long?> ReadUploadOffsetAsync(HttpClient client, VimeoUploadResult result, CancellationToken cancellationToken)
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Head, result.UploadLink))
                {
                    request.Headers.Add("Tus-Resumable", TusVersion);
                    using (var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false))
                    {
                        if (response.IsSuccessStatusCode && ReadLongHeader(response, "Upload-Offset") is long offset)
                        {
                            if (ReadLongHeader(response, "Upload-Length") is long length && length != result.Size)
                            {
                                result.Exception = new InvalidOperationException($"The upload link expects {length} bytes, the stream has {result.Size}.");
                                return null;
                            }
                            return offset;
                        }

                        result.StatusCode = response.StatusCode;
                        result.Exception = new HttpRequestException($"The offset of the tus upload could not be read ({(int)response.StatusCode} {response.ReasonPhrase}).");
                        return null;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                result.Exception = ex;
                return null;
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                result.Exception = ex;
                return null;
            }
        }

        private static long? ReadLongHeader(HttpResponseMessage response, string header) =>
            response.Headers.TryGetValues(header, out var values)
            && long.TryParse(values.FirstOrDefault(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var value)
                ? value
                : (long?)null;
    }
}
