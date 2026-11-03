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
    /// The video version representation consists of the following fields.
    /// </summary>
    public class VideoVersions : VimeoIdentity
    {
        /// <summary>
        /// Whether this video version is the currently active one.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the video version was created.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// The duration of the video version in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// The file name of the video version.
        /// </summary>
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// The size in bytes of the video version file.
        /// </summary>
        [JsonPropertyName("filesize")]
        public long Filesize { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the video version was last modified.
        /// </summary>
        [JsonPropertyName("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// The active picture of the video version.
        /// </summary>
        [JsonPropertyName("pictures")]
        public Picture Pictures { get; set; }

        /// <summary>
        /// The upload information for this version.
        /// </summary>
        [JsonPropertyName("upload")]
        public VideoUpload Upload { get; set; }
    }
}
