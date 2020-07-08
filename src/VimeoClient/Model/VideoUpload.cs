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

namespace VimeoClient.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The upload information for this video.
    /// </summary>
    public class VideoUpload
    {
        /// <summary>
        /// The approach for uploading the video.
        /// </summary>
        [JsonPropertyName("approach")]
        public string Approach { get; set; }

        /// <summary>
        /// The URI for completing the upload.
        /// </summary>
        [JsonPropertyName("complete_uri")]
        public string CompleteUri { get; set; }

        /// <summary>
        /// The HTML form for uploading a video through the post approach.
        /// </summary>
        [JsonPropertyName("form")]
        public string Form { get; set; }

        /// <summary>
        /// The link of the video to capture through the pull approach.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The redirect URL for the upload app.
        /// </summary>
        [JsonPropertyName("redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The file size in bytes of the uploaded video.
        /// </summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }

        /// <summary>
        /// The status code for the availability of the uploaded video:
        /// Option descriptions:
        ///     complete - The upload is complete.
        ///     error - The upload ended with an error.
        ///     in_progress - The upload is underway.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The link for sending video file data.
        /// </summary>
        [JsonPropertyName("upload_link")]
        public string UploadLink { get; set; }
    }
}