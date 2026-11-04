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
    /// The picture representation consists of the following fields.
    /// </summary>
    public class Picture : VimeoIdentity
    {
        /// <summary>
        /// Whether this picture is the active picture for its parent resource.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The upload URL for the picture. This field appears only when the picture is created.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The base link of the picture.
        /// </summary>
        [JsonPropertyName("base_link")]
        public string BaseLink { get; set; }

        /// <summary>
        /// Whether the picture is the default picture of the resource.
        /// </summary>
        [JsonPropertyName("default_picture")]
        public bool DefaultPicture { get; set; }

        /// <summary>
        /// An array containing reference information about all available image files.
        /// </summary>
        [JsonPropertyName("sizes")]
        public Size[] Sizes { get; set; }

        /// <summary>
        /// The type of the picture: caution, custom or default.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
