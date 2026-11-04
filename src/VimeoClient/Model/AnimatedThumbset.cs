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
    using System.Text.Json.Serialization;

    /// <summary>
    /// A set of animated thumbnails of a video.
    /// </summary>
    public class AnimatedThumbset : VimeoIdentity
    {
        /// <summary>
        /// The URI of the video from which the set of animated thumbnails was created.
        /// </summary>
        [JsonPropertyName("clip_uri")]
        public string ClipUri { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the GIF was created.
        /// </summary>
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// All the animated thumbnails in the set.
        /// </summary>
        [JsonPropertyName("sizes")]
        public AnimatedThumbnail[] Sizes { get; set; }

        /// <summary>
        /// The availability of the animated thumbnails: cancelled, completed, failed, started.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// An animated thumbnail.
    /// </summary>
    public class AnimatedThumbnail
    {
        /// <summary>
        /// The duration of the animated thumbnail in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public double Duration { get; set; }

        /// <summary>
        /// The file format of the animated thumbnail.
        /// </summary>
        [JsonPropertyName("file_format")]
        public string FileFormat { get; set; }

        /// <summary>
        /// The file size of the animated thumbnail in bytes.
        /// </summary>
        [JsonPropertyName("file_size")]
        public long FileSize { get; set; }

        /// <summary>
        /// The height of the animated thumbnail in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        /// Whether the animated thumbnail can be downloaded.
        /// </summary>
        [JsonPropertyName("is_downloadable")]
        public bool IsDownloadable { get; set; }

        /// <summary>
        /// The URL of the animated thumbnail file.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The URL of the animated thumbnail file with a play button overlay.
        /// </summary>
        [JsonPropertyName("link_with_play_button")]
        public string LinkWithPlayButton { get; set; }

        /// <summary>
        /// The profile ID of the animated thumbnail.
        /// </summary>
        [JsonPropertyName("profile_id")]
        public string ProfileId { get; set; }

        /// <summary>
        /// The time in the video, in seconds, corresponding to the start of the animation.
        /// </summary>
        [JsonPropertyName("start_time")]
        public double StartTime { get; set; }

        /// <summary>
        /// The ID of the animated thumbnail.
        /// </summary>
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// The width of the animated thumbnail in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}
