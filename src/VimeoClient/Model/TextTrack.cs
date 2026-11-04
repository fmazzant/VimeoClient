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
    /// The text track representation consists of the following fields.
    /// </summary>
    public class TextTrack : VimeoIdentity
    {
        /// <summary>
        /// Whether this text track is active.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The read-only display language.
        /// </summary>
        [JsonPropertyName("display_language")]
        public string DisplayLanguage { get; set; }

        /// <summary>
        /// The SRT download URL for HLS.
        /// </summary>
        [JsonPropertyName("hls_link")]
        public string HlsLink { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the HLS read-only link expires.
        /// </summary>
        [JsonPropertyName("hls_link_expires_time")]
        public string HlsLinkExpiresTime { get; set; }

        /// <summary>
        /// The language code for this text track.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// The read-only URL of the text track file, intended for use with HLS playback.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the read-only link expires.
        /// </summary>
        [JsonPropertyName("link_expires_time")]
        public string LinkExpiresTime { get; set; }

        /// <summary>
        /// The descriptive label of this text track.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The type of the text track: captions, chapters, descriptions, metadata, subtitles.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
