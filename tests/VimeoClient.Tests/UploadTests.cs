namespace Mafesoft.VimeoClient.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Mafesoft.VimeoClient.Body.Video;
    using Mafesoft.VimeoClient.Common;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    /// <summary>
    /// The tus upload helper (issue #14), against a fake tus server: create, PATCH chunks, HEAD to resume.
    /// </summary>
    public sealed class UploadTests : IDisposable
    {
        private const string UploadLink = "https://uploads.example.com/upload/abc";
        private const string UploadPath = "/upload/abc";

        private readonly int chunkSize = VimeoVideos.UploadChunkSize;
        private readonly int chunkRetries = VimeoVideos.UploadChunkRetries;

        public UploadTests()
        {
            VimeoVideos.UploadChunkSize = 10;
            VimeoVideos.UploadChunkRetries = 2;
        }

        public void Dispose()
        {
            VimeoVideos.UploadChunkSize = chunkSize;
            VimeoVideos.UploadChunkRetries = chunkRetries;
        }

        private static byte[] Data(int length) => Enumerable.Range(0, length).Select(i => (byte)i).ToArray();

        /// <summary>
        /// A tus server: PATCH appends the body at Upload-Offset, HEAD reports the offset. <see cref="Fail"/> decides,
        /// for each PATCH (by number), how many bytes are kept before answering 500 (null: no failure).
        /// </summary>
        private sealed class TusServer
        {
            public List<byte> Received { get; } = new();
            public long Length { get; set; }
            public int Patches { get; private set; }
            public int Heads { get; private set; }
            public Func<int, int?> Fail { get; set; } = _ => null;

            public void Install(FakeVimeo client, string createStatusJson = null, HttpStatusCode createStatus = HttpStatusCode.OK)
            {
                client.Handler.Respond("/me/videos", createStatusJson ?? $"{{\"uri\":\"/videos/7\",\"upload\":{{\"approach\":\"tus\",\"upload_link\":\"{UploadLink}\"}}}}", createStatus);
                client.Handler.RespondWith(r => r.RequestUri.AbsolutePath == UploadPath, Handle);
            }

            private HttpResponseMessage Handle(HttpRequestMessage request)
            {
                Assert.Equal("1.0.0", request.Headers.GetValues("Tus-Resumable").Single());
                if (request.Method == HttpMethod.Head)
                {
                    Heads++;
                    return FakeHttpHandler.Response(HttpStatusCode.OK, "", ("Upload-Offset", Received.Count.ToString()), ("Upload-Length", Length.ToString()));
                }

                Patches++;
                Assert.Equal("application/offset+octet-stream", request.Content.Headers.ContentType.MediaType);
                var offset = long.Parse(request.Headers.GetValues("Upload-Offset").Single());
                if (offset != Received.Count)
                {
                    return FakeHttpHandler.Response(HttpStatusCode.Conflict);
                }

                var body = request.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                if (Fail(Patches) is int kept)
                {
                    Received.AddRange(body.Take(kept));
                    return FakeHttpHandler.Response(HttpStatusCode.InternalServerError);
                }

                Received.AddRange(body);
                return FakeHttpHandler.Response(HttpStatusCode.NoContent, "", ("Upload-Offset", Received.Count.ToString()));
            }
        }

        private sealed class ListProgress : IProgress<long>
        {
            public List<long> Values { get; } = new();
            public void Report(long value) => Values.Add(value);
        }

        [Fact]
        public async Task Upload_CreatesTheVideoAndSendsTheChunks()
        {
            var client = new FakeVimeo();
            var server = new TusServer { Length = 25 };
            server.Install(client);
            var progress = new ListProgress();

            var result = await client.Videos.UploadAsync(new MemoryStream(Data(25)), new VideoUploadParameters { Name = "Demo" }, progress);

            Assert.True(result.IsCompleted, result.Exception?.Message);
            Assert.Null(result.Exception);
            Assert.Equal("/videos/7", result.Video.Uri);
            Assert.Equal(UploadLink, result.UploadLink);
            Assert.Equal(25, result.Offset);
            Assert.Equal(Data(25), server.Received.ToArray());
            Assert.Equal(3, server.Patches);
            Assert.Equal(new long[] { 10, 20, 25 }, progress.Values);

            var create = client.Handler.Requests.First();
            Assert.Equal(HttpMethod.Post, create.Method);
            Assert.Equal("tus", create.Json.GetProperty("upload").GetProperty("approach").GetString());
            Assert.Equal(25, create.Json.GetProperty("upload").GetProperty("size").GetInt64());
            Assert.Equal("Demo", create.Json.GetProperty("name").GetString());
        }

        [Fact]
        public async Task Upload_AfterAFailedChunk_ReadsTheOffsetAndContinues()
        {
            var client = new FakeVimeo();
            // The second PATCH keeps 3 bytes of its chunk and fails: Vimeo has 13 bytes.
            var server = new TusServer { Length = 25, Fail = patch => patch == 2 ? 3 : (int?)null };
            server.Install(client);

            var result = await client.Videos.UploadAsync(new MemoryStream(Data(25)));

            Assert.True(result.IsCompleted, result.Exception?.Message);
            Assert.Equal(Data(25), server.Received.ToArray());
            Assert.Equal(1, server.Heads);
        }

        [Fact]
        public async Task Upload_StopsAfterTheRetries_AndCanBeResumed()
        {
            var client = new FakeVimeo();
            var server = new TusServer { Length = 25, Fail = patch => patch >= 2 ? 0 : (int?)null };
            server.Install(client);
            var data = Data(25);

            var failed = await client.Videos.UploadAsync(new MemoryStream(data));

            Assert.False(failed.IsCompleted);
            Assert.Equal(10, failed.Offset);
            Assert.Equal(HttpStatusCode.InternalServerError, failed.StatusCode);
            Assert.NotNull(failed.Exception);
            Assert.Equal(1 + VimeoVideos.UploadChunkRetries, server.Patches - 1);

            server.Fail = _ => null;
            var resumed = await client.Videos.ResumeUploadAsync(failed.UploadLink, new MemoryStream(data));

            Assert.True(resumed.IsCompleted, resumed.Exception?.Message);
            Assert.Null(resumed.Creation);
            Assert.Equal(data, server.Received.ToArray());
        }

        [Fact]
        public async Task Resume_StartsFromTheOffsetOfVimeo()
        {
            var client = new FakeVimeo();
            var server = new TusServer { Length = 25 };
            server.Received.AddRange(Data(12));
            server.Install(client);
            var progress = new ListProgress();

            var result = await client.Videos.ResumeUploadAsync(UploadLink, new MemoryStream(Data(25)), progress);

            Assert.True(result.IsCompleted);
            Assert.Equal(Data(25), server.Received.ToArray());
            Assert.Equal(new long[] { 12, 22, 25 }, progress.Values);
            Assert.DoesNotContain(client.Handler.Requests, r => r.Path == "/me/videos");
        }

        [Fact]
        public async Task Resume_WithAnotherFileSize_Stops()
        {
            var client = new FakeVimeo();
            var server = new TusServer { Length = 99 };
            server.Install(client);

            var result = await client.Videos.ResumeUploadAsync(UploadLink, new MemoryStream(Data(25)));

            Assert.False(result.IsCompleted);
            Assert.IsType<InvalidOperationException>(result.Exception);
            Assert.Equal(0, server.Patches);
        }

        [Fact]
        public async Task Upload_WhenTheVideoIsNotCreated_SendsNothing()
        {
            var client = new FakeVimeo();
            var server = new TusServer { Length = 25 };
            server.Install(client, "{\"error\":\"no upload quota\"}", HttpStatusCode.Forbidden);

            var result = await client.Videos.UploadAsync(new MemoryStream(Data(25)));

            Assert.False(result.IsCompleted);
            Assert.Equal(HttpStatusCode.Forbidden, result.StatusCode);
            Assert.NotNull(result.Exception);
            Assert.Null(result.UploadLink);
            Assert.Equal(0, server.Patches);
        }

        [Fact]
        public async Task Upload_FromAFile_UsesTheFileNameAsName()
        {
            var path = Path.Combine(Path.GetTempPath(), "vimeo-upload-" + Guid.NewGuid().ToString("N") + ".mp4");
            File.WriteAllBytes(path, Data(15));
            try
            {
                var client = new FakeVimeo();
                var server = new TusServer { Length = 15 };
                server.Install(client);

                var result = await client.Videos.UploadAsync(path);

                Assert.True(result.IsCompleted);
                Assert.Equal(Data(15), server.Received.ToArray());
                Assert.Equal(Path.GetFileNameWithoutExtension(path), client.Handler.Requests.First().Json.GetProperty("name").GetString());
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public async Task Upload_Cancelled_ReportsTheCancellation()
        {
            var client = new FakeVimeo();
            var server = new TusServer { Length = 25 };
            server.Install(client);
            using var cancellation = new CancellationTokenSource();
            var progress = new CancelAfterFirst(cancellation);

            var result = await client.Videos.UploadAsync(new MemoryStream(Data(25)), progress: progress, cancellationToken: cancellation.Token);

            Assert.False(result.IsCompleted);
            Assert.IsAssignableFrom<OperationCanceledException>(result.Exception);
            Assert.Equal(10, result.Offset);
        }

        private sealed class CancelAfterFirst(CancellationTokenSource source) : IProgress<long>
        {
            public void Report(long value) => source.Cancel();
        }

        [Fact]
        public async Task Upload_RequiresASeekableStream()
        {
            var client = new FakeVimeo();
            await Assert.ThrowsAsync<ArgumentException>(() => client.Videos.UploadAsync(new NonSeekableStream()));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.Videos.UploadAsync((Stream)null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.Videos.ResumeUploadAsync(null, new MemoryStream()));
        }

        private sealed class NonSeekableStream : MemoryStream
        {
            public override bool CanSeek => false;
        }
    }
}
