﻿/// <summary>
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
    /// Information about whether the authenticated user has liked this video.
    /// </summary>
    public class VideoMetadataInteractionLike
    {
        /// <summary>
        /// Whether the user has liked the video.
        /// </summary>
        [JsonPropertyName("added")]
        public bool Added { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the user liked the video.
        /// </summary>
        [JsonPropertyName("added_time")]
        public string AddedTime { get; set; }

        /// <summary>
        /// An array of HTTP methods permitted on this URI.
        /// </summary>
        [JsonPropertyName("options")]
        public string[] Options { get; set; }

        /// <summary>
        /// The API URI that resolves to the connection data.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}