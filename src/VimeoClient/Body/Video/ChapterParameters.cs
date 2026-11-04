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

namespace Mafesoft.VimeoClient.Body.Video
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The body to add or edit a chapter of a video.
    /// </summary>
    public class ChapterParameters : IEditParameters, IPayloadParameters
    {
        /// <summary>
        /// The title of the chapter.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The timecode of the chapter in seconds from the start of the video.
        /// </summary>
        [JsonPropertyName("timecode")]
        public double? Timecode { get; set; }

        /// <summary>
        /// The URI of the chapter's active thumbnail.
        /// </summary>
        [JsonPropertyName("active_thumbnail_uri")]
        public string ActiveThumbnailUri { get; set; }

        /// <summary>
        /// The URIs of the thumbnails associated with the chapter (only to add a chapter).
        /// </summary>
        [JsonPropertyName("thumbnail_uris")]
        public string[] ThumbnailUris { get; set; }

        /// <summary>
        /// Builds the JSON body: only the values that are set are sent.
        /// </summary>
        /// <returns></returns>
        public VimeoPayload ToPayload() => VimeoPayload.FromObject(this);

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable() => ToPayload().Flatten();
    }
}
