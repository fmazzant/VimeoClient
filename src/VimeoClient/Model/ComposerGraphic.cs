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
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Composer Graphics (Vimeo schema: composer-graphics).
    /// </summary>
    public class ComposerGraphic
    {
        /// <summary>
        /// The timestamp in milliseconds since the Unix epoch when the item was created.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public double? CreatedAt { get; set; }

        /// <summary>
        /// The unique identifier of the graphic item.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of the graphic item. The value of this field is always `agoraMedia` for this object.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The timestamp in milliseconds since the Unix epoch when the item was last updated.
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public double? UpdatedAt { get; set; }

        /// <summary>
        /// The length of the video in seconds.
        /// </summary>
        [JsonPropertyName("videoDuration")]
        public double? VideoDuration { get; set; }

        /// <summary>
        /// The unique identifier of the video resource.
        /// </summary>
        [JsonPropertyName("videoId")]
        public double? VideoId { get; set; }

        /// <summary>
        /// The URL to the standard-resolution video thumbnail image.
        /// </summary>
        [JsonPropertyName("videoThumb")]
        public string VideoThumb { get; set; }

        /// <summary>
        /// The URL to the high-resolution video thumbnail image.
        /// </summary>
        [JsonPropertyName("videoThumbFullSize")]
        public string VideoThumbFullSize { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }
}
