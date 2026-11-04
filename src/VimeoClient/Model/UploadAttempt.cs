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

namespace Mafesoft.VimeoClient.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The upload attempt representation consists of the following fields.
    /// </summary>
    public class UploadAttempt : VimeoIdentity
    {
        /// <summary>
        /// The video to upload.
        /// </summary>
        [JsonPropertyName("clip")]
        public Video Clip { get; set; }

        /// <summary>
        /// The completion URI of the upload (streaming approach).
        /// </summary>
        [JsonPropertyName("complete_uri")]
        public string CompleteUri { get; set; }

        /// <summary>
        /// The HTML upload form (post approach).
        /// </summary>
        [JsonPropertyName("form")]
        public string Form { get; set; }

        /// <summary>
        /// The upload ticket ID.
        /// </summary>
        [JsonPropertyName("ticket_id")]
        public string TicketId { get; set; }

        /// <summary>
        /// The link of the upload.
        /// </summary>
        [JsonPropertyName("upload_link")]
        public string UploadLink { get; set; }

        /// <summary>
        /// The owner of the uploaded video.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
