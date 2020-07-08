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
    using System.IO;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The channel representation consists of the following fields.
    /// </summary>
    public class Channel:VimeoIdentity
    {
        /// <summary>
        /// The active icon for the category.
        /// </summary>
        [JsonPropertyName("categories")]
        public Category[] Categories { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the channel was created.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// A brief explanation of the channel's content.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The banner that appears by default at the top of the channel page.
        /// </summary>
        [JsonPropertyName("header")]
        public Picture Header { get; set; }

        /// <summary>
        /// The URL to access the channel in a browser.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Metadata about the channel.
        /// </summary>
        [JsonPropertyName("metadata")]
        public ChannelMetadata Metadata { get; set; }

        /// <summary>
        /// The channel resource key.
        /// </summary>
        [JsonPropertyName("resource_key")]
        public string ResourceKey { get; set; }

        /// <summary>
        /// An array of all tags assigned to the channel.
        /// </summary>
        [JsonPropertyName("tags")]
        public Tag[] Tags { get; set; }

        /// <summary>
        /// The Vimeo user who owns the channel.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}