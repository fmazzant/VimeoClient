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
    using System.Text.Json.Serialization;

    /// <summary>
    /// The embed preset representation consists of the following fields.
    /// </summary>
    public class Presets : VimeoIdentity
    {
        /// <summary>
        /// The preset's metadata.
        /// </summary>
        [JsonPropertyName("metadata")]
        public PresetsMetadata Metadata { get; set; }

        /// <summary>
        /// The display name of the preset group.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The contents of the presets group.
        /// </summary>
        [JsonPropertyName("settings")]
        public PresetsSettings Settings { get; set; }

        /// <summary>
        /// The owner of the preset.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    /// <summary>
    /// The preset's metadata.
    /// </summary>
    public class PresetsMetadata
    {
        /// <summary>
        /// The connections of the preset (videos).
        /// </summary>
        [JsonPropertyName("connections")]
        public Dictionary<string, GenericRelatedEntity> Connections { get; set; }
    }

    /// <summary>
    /// The contents of the presets group.
    /// </summary>
    public class PresetsSettings
    {
        /// <summary>
        /// The buttons of the embeddable player.
        /// </summary>
        [JsonPropertyName("buttons")]
        public PresetsButtons Buttons { get; set; }

        /// <summary>
        /// The logos of the embeddable player.
        /// </summary>
        [JsonPropertyName("logos")]
        public PresetsLogos Logos { get; set; }

        /// <summary>
        /// The outro of the embeddable player.
        /// </summary>
        [JsonPropertyName("outro")]
        public PresetsOutro Outro { get; set; }
    }

    /// <summary>
    /// The buttons of a preset.
    /// </summary>
    public class PresetsButtons
    {
        /// <summary>
        /// Whether the Embed button appears.
        /// </summary>
        [JsonPropertyName("embed")]
        public bool? Embed { get; set; }

        /// <summary>
        /// Whether the HD button appears.
        /// </summary>
        [JsonPropertyName("hd")]
        public bool? Hd { get; set; }

        /// <summary>
        /// Whether the Like button appears.
        /// </summary>
        [JsonPropertyName("like")]
        public bool? Like { get; set; }

        /// <summary>
        /// Whether the Share button appears.
        /// </summary>
        [JsonPropertyName("share")]
        public bool? Share { get; set; }

        /// <summary>
        /// Whether the Vote button appears.
        /// </summary>
        [JsonPropertyName("vote")]
        public bool? Vote { get; set; }

        /// <summary>
        /// Whether the Watch Later button appears.
        /// </summary>
        [JsonPropertyName("watchlater")]
        public bool? WatchLater { get; set; }
    }

    /// <summary>
    /// The logos of a preset.
    /// </summary>
    public class PresetsLogos
    {
        /// <summary>
        /// Whether the custom logo appears.
        /// </summary>
        [JsonPropertyName("custom")]
        public bool? Custom { get; set; }

        /// <summary>
        /// Whether the custom logo is always visible.
        /// </summary>
        [JsonPropertyName("sticky_custom")]
        public bool? StickyCustom { get; set; }

        /// <summary>
        /// Whether the Vimeo logo appears.
        /// </summary>
        [JsonPropertyName("vimeo")]
        public bool? Vimeo { get; set; }
    }

    /// <summary>
    /// The outro of a preset.
    /// </summary>
    public class PresetsOutro
    {
        /// <summary>
        /// The clips of the outro (comma-separated video IDs).
        /// </summary>
        [JsonPropertyName("clips")]
        public string Clips { get; set; }

        /// <summary>
        /// The outro link.
        /// </summary>
        [JsonPropertyName("link")]
        public PresetsOutroLink Link { get; set; }

        /// <summary>
        /// The outro text.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// The type of the outro: beginning, link, no idea, text, threevideos, videos.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The videos of the outro.
        /// </summary>
        [JsonPropertyName("videos")]
        public string Videos { get; set; }
    }

    /// <summary>
    /// The link of a preset outro.
    /// </summary>
    public class PresetsOutroLink
    {
        /// <summary>
        /// The name of the link.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The URL of the link.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
