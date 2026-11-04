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
    /// An item of a folder: a video, a subfolder, a live event, a showcase or a file.
    /// Only the property that matches <see cref="Type"/> is set.
    /// </summary>
    public class ProjectItem
    {
        /// <summary>
        /// The project item type: file, folder, live_event, showcase, video.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the item was shared.
        /// </summary>
        [JsonPropertyName("shared_date")]
        public string SharedDate { get; set; }

        /// <summary>
        /// The project item file.
        /// </summary>
        [JsonPropertyName("file")]
        public VimeoFile File { get; set; }

        /// <summary>
        /// The project item folder.
        /// </summary>
        [JsonPropertyName("folder")]
        public Project Folder { get; set; }

        /// <summary>
        /// The project item event.
        /// </summary>
        [JsonPropertyName("live_event")]
        public LiveEventRecurring LiveEvent { get; set; }

        /// <summary>
        /// The project item showcase.
        /// </summary>
        [JsonPropertyName("showcase")]
        public Album Showcase { get; set; }

        /// <summary>
        /// The project item video.
        /// </summary>
        [JsonPropertyName("video")]
        public Video Video { get; set; }

        /// <summary>
        /// The item's metadata.
        /// </summary>
        [JsonPropertyName("metadata")]
        public Dictionary<string, JsonElement> Metadata { get; set; }
    }
}
