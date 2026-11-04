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
    /// Alternate Audio Track (Vimeo schema: alternate-audio-track).
    /// </summary>
    public class AudioTrack
    {
        /// <summary>
        /// Whether the audio track is enabled.
        /// </summary>
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// The downloads that are available for the audio track.
        /// </summary>
        [JsonPropertyName("download")]
        public AudioTrackDownloadItem[] Download { get; set; }

        /// <summary>
        /// The language of the audio track.
        /// </summary>
        [JsonPropertyName("language")]
        public AudioTrackLanguage Language { get; set; }

        /// <summary>
        /// The origin of the audio track.
        /// </summary>
        [JsonPropertyName("provenance")]
        public string Provenance { get; set; }

        /// <summary>
        /// The quota parameters for the audio tracks available for this version.
        /// </summary>
        [JsonPropertyName("quota")]
        public AudioTrackQuota Quota { get; set; }

        /// <summary>
        /// The transcode information for the audio track.
        /// </summary>
        [JsonPropertyName("transcode")]
        public AudioTrackTranscode Transcode { get; set; }

        /// <summary>
        /// The type of audio track.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The upload information for the audio track.
        /// </summary>
        [JsonPropertyName("upload")]
        public JsonElement? Upload { get; set; }

        /// <summary>
        /// The audio track's canonical relative URI.
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
    /// The transcode information for the audio track.
    /// </summary>
    public class AudioTrackTranscode
    {
        /// <summary>
        /// The transcode status of the audio track.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// The quota parameters for the audio tracks available for this version.
    /// </summary>
    public class AudioTrackQuota
    {
        /// <summary>
        /// The number of audio tracks availible for this version.
        /// </summary>
        [JsonPropertyName("free")]
        public double? Free { get; set; }

        /// <summary>
        /// Whether the current version has reached its maximum quota for audio tracks.
        /// </summary>
        [JsonPropertyName("has_reached_quota")]
        public bool? HasReachedQuota { get; set; }

        /// <summary>
        /// The maximum number of audio tracks that the user can upload per version based on their subscription tier.
        /// </summary>
        [JsonPropertyName("max")]
        public double? Max { get; set; }

        /// <summary>
        /// The number of audio tracks used for this version.
        /// </summary>
        [JsonPropertyName("used")]
        public double? Used { get; set; }
    }

    /// <summary>
    /// The language of the audio track.
    /// </summary>
    public class AudioTrackLanguage
    {
        /// <summary>
        /// The standard ISO 639-1 code for the language.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The name of the language.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// AudioTrackDownloadItem
    /// </summary>
    public class AudioTrackDownloadItem
    {
        /// <summary>
        /// The time in ISO 8601 format when the audio track link expires.
        /// </summary>
        [JsonPropertyName("expires")]
        public string Expires { get; set; }

        /// <summary>
        /// The file extension of the audio file.
        /// </summary>
        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        /// <summary>
        /// The URL of the audio track download.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The rendition of the audio track.
        /// </summary>
        [JsonPropertyName("rendition")]
        public string Rendition { get; set; }
    }
}
