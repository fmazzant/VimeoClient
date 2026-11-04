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
    /// Trimmed Video (Vimeo schema: trimmed-video).
    /// </summary>
    public class TrimmedVideo
    {
        /// <summary>
        /// The ID of the video. _This field is deprecated._
        /// </summary>
        [JsonPropertyName("clip_id")]
        public long? ClipId { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the trim was created.
        /// </summary>
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// The most recent version of the trimmed video. _This field is deprecated._
        /// </summary>
        [JsonPropertyName("created_version_id")]
        public string CreatedVersionId { get; set; }

        /// <summary>
        /// The end of the trim from the last trim, in seconds.
        /// </summary>
        [JsonPropertyName("end")]
        public string End { get; set; }

        /// <summary>
        /// Whether the transcoding jobs for the video file have finished. _This field is deprecated._
        /// </summary>
        [JsonPropertyName("is_clip_finished_transcoding")]
        public bool? IsClipFinishedTranscoding { get; set; }

        /// <summary>
        /// -
        /// </summary>
        [JsonPropertyName("metadata")]
        public TrimmedVideoMetadata Metadata { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the trim policy was last modified.
        /// </summary>
        [JsonPropertyName("modified_on")]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// The video version that is the source of the trimmed video. _This field is deprecated._
        /// </summary>
        [JsonPropertyName("root_version_id")]
        public string RootVersionId { get; set; }

        /// <summary>
        /// The start of the trim from the last trim, in seconds.
        /// </summary>
        [JsonPropertyName("start")]
        public string Start { get; set; }

        /// <summary>
        /// The URI of the player or the trim service. _This field is deprecated._
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The quality of the root version video file.
        /// </summary>
        [JsonPropertyName("version_quality")]
        public string VersionQuality { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// TrimmedVideoMetadata
    /// </summary>
    public class TrimmedVideoMetadata
    {
        /// <summary>
        /// -
        /// </summary>
        [JsonPropertyName("connections")]
        public TrimmedVideoMetadataConnections Connections { get; set; }
    }

    /// <summary>
    /// TrimmedVideoMetadataConnections
    /// </summary>
    public class TrimmedVideoMetadataConnections
    {
        /// <summary>
        /// Information about the video version that is created from the trim operation.
        /// </summary>
        [JsonPropertyName("created_version")]
        public TrimmedVideoMetadataConnectionsCreatedVersion CreatedVersion { get; set; }

        /// <summary>
        /// Information about the video version that is the source of the trimmed video.
        /// </summary>
        [JsonPropertyName("root_version")]
        public TrimmedVideoMetadataConnectionsRootVersion RootVersion { get; set; }

        /// <summary>
        /// Information about the video associated with the trim.
        /// </summary>
        [JsonPropertyName("video")]
        public TrimmedVideoMetadataConnectionsVideo Video { get; set; }
    }

    /// <summary>
    /// Information about the video associated with the trim.
    /// </summary>
    public class TrimmedVideoMetadataConnectionsVideo
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

    /// <summary>
    /// Information about the video version that is the source of the trimmed video.
    /// </summary>
    public class TrimmedVideoMetadataConnectionsRootVersion
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

    /// <summary>
    /// Information about the video version that is created from the trim operation.
    /// </summary>
    public class TrimmedVideoMetadataConnectionsCreatedVersion
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
