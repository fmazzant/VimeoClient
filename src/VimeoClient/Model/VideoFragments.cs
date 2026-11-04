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
    /// Fragments (Vimeo schema: fragments).
    /// </summary>
    public class VideoFragments
    {
        /// <summary>
        /// The time in ISO 8601 format when the fragment was created.
        /// </summary>
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// Metadata about the fragments.
        /// </summary>
        [JsonPropertyName("metadata")]
        public VideoFragmentsMetadata Metadata { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the fragment was last updated.
        /// </summary>
        [JsonPropertyName("modified_on")]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// The time in milliseconds of the fragment's _inpoint_, or the time from the start of the video that marks the beginning of the fragment.
        /// </summary>
        [JsonPropertyName("timecode")]
        public double? Timecode { get; set; }

        /// <summary>
        /// The URI of the video fragment.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// Metadata about the fragments.
    /// </summary>
    public class VideoFragmentsMetadata
    {
        /// <summary>
        /// A collection of information that is connected to this resource.
        /// </summary>
        [JsonPropertyName("connections")]
        public VideoFragmentsMetadataConnections Connections { get; set; }
    }

    /// <summary>
    /// A collection of information that is connected to this resource.
    /// </summary>
    public class VideoFragmentsMetadataConnections
    {
        /// <summary>
        /// Information about the videos that belong to this channel.
        /// </summary>
        [JsonPropertyName("clip")]
        public VideoFragmentsMetadataConnectionsClip Clip { get; set; }
    }

    /// <summary>
    /// Information about the videos that belong to this channel.
    /// </summary>
    public class VideoFragmentsMetadataConnectionsClip
    {
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
