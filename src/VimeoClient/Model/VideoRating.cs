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
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The type of the rating widget that the viewers use to rate a video.
    /// </summary>
    public enum VideoRatingType
    {
        /// <summary>
        /// Thumbs up / thumbs down.
        /// </summary>
        thumbs,

        /// <summary>
        /// From 1 to 5 stars.
        /// </summary>
        stars
    }

    /// <summary>
    /// The rating settings of a video: whether the viewers can rate the video, and how.
    /// Not to be confused with the content rating (<see cref="ContentRating"/>), the content classification of the video.
    /// </summary>
    public class VideoRatingSettings
    {
        /// <summary>
        /// Whether the rating widget is enabled on the video.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// The type of the rating widget: thumbs or stars.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// The summary of the ratings that the viewers gave to a video.
    /// </summary>
    public class VideoRatings
    {
        /// <summary>
        /// The type of the rating widget: thumbs or stars.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The total number of ratings.
        /// </summary>
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        /// <summary>
        /// The average rating, from 1 to 5 (stars).
        /// </summary>
        [JsonPropertyName("average")]
        public double? Average { get; set; }

        /// <summary>
        /// The number of thumbs up (thumbs).
        /// </summary>
        [JsonPropertyName("thumbs_up")]
        public int? ThumbsUp { get; set; }

        /// <summary>
        /// The number of thumbs down (thumbs).
        /// </summary>
        [JsonPropertyName("thumbs_down")]
        public int? ThumbsDown { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }
}
