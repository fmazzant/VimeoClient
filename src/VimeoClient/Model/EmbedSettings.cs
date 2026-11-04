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
    /// The embed settings representation consists of the following fields.
    /// All the values are nullable: the class is used both in responses and in request bodies.
    /// </summary>
    public class EmbedSettings
    {
        /// <summary>
        /// Whether AirPlay is enabled in the embeddable player.
        /// </summary>
        [JsonPropertyName("airplay")]
        public bool? Airplay { get; set; }

        /// <summary>
        /// Whether multiple audio tracks can appear in the embeddable player.
        /// </summary>
        [JsonPropertyName("audio_tracks")]
        public bool? AudioTracks { get; set; }

        /// <summary>
        /// A collection of information about the buttons that appear on the interface of the embeddable player.
        /// </summary>
        [JsonPropertyName("buttons")]
        public EmbedButtons Buttons { get; set; }

        /// <summary>
        /// Whether clicking the closed-captions button reveals the caption-language menu.
        /// </summary>
        [JsonPropertyName("cc_track_menu")]
        public bool? CcTrackMenu { get; set; }

        /// <summary>
        /// Whether chapters are enabled in the embeddable player.
        /// </summary>
        [JsonPropertyName("chapters")]
        public bool? Chapters { get; set; }

        /// <summary>
        /// Whether the Chromecast button appears in the embeddable player.
        /// </summary>
        [JsonPropertyName("chromecast")]
        public bool? Chromecast { get; set; }

        /// <summary>
        /// Whether closed captions are enabled in the embeddable player.
        /// </summary>
        [JsonPropertyName("closed_captions")]
        public bool? ClosedCaptions { get; set; }

        /// <summary>
        /// The primary player color, which controls the color of the progress bar, buttons, and more.
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; }

        /// <summary>
        /// The four player colors.
        /// </summary>
        [JsonPropertyName("colors")]
        public EmbedColors Colors { get; set; }

        /// <summary>
        /// The end screen of the embeddable player.
        /// </summary>
        [JsonPropertyName("end_screen")]
        public EmbedEndScreen EndScreen { get; set; }

        /// <summary>
        /// The play button's settings.
        /// </summary>
        [JsonPropertyName("play_button")]
        public EmbedPlayButton PlayButton { get; set; }

        /// <summary>
        /// Whether to show the quality selector in the embeddable player.
        /// </summary>
        [JsonPropertyName("quality_selector")]
        public bool? QualitySelector { get; set; }

        /// <summary>
        /// Whether users can skip forward in the embeddable player.
        /// </summary>
        [JsonPropertyName("skipping_forward")]
        public bool? SkippingForward { get; set; }

        /// <summary>
        /// Whether the transcript controls appear in the embeddable player.
        /// </summary>
        [JsonPropertyName("transcript")]
        public bool? Transcript { get; set; }

        /// <summary>
        /// A collection of information about the logo in the corner of the embeddable player.
        /// </summary>
        [JsonPropertyName("logos")]
        public EmbedLogos Logos { get; set; }

        /// <summary>
        /// Whether the playbar appears in the embeddable player.
        /// </summary>
        [JsonPropertyName("playbar")]
        public bool? Playbar { get; set; }

        /// <summary>
        /// Whether the speed controls appear in the embeddable player.
        /// </summary>
        [JsonPropertyName("speed")]
        public bool? Speed { get; set; }

        /// <summary>
        /// A collection of information relating to the embeddable player's title bar.
        /// </summary>
        [JsonPropertyName("title")]
        public EmbedTitle Title { get; set; }

        /// <summary>
        /// The URI of the embed preset.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Whether the volume controls appear in the embeddable player.
        /// </summary>
        [JsonPropertyName("volume")]
        public bool? Volume { get; set; }
    }

    /// <summary>
    /// The buttons that appear on the interface of the embeddable player.
    /// </summary>
    public class EmbedButtons
    {
        /// <summary>
        /// Whether the Embed button appears.
        /// </summary>
        [JsonPropertyName("embed")]
        public bool? Embed { get; set; }

        /// <summary>
        /// Whether the Fullscreen button appears.
        /// </summary>
        [JsonPropertyName("fullscreen")]
        public bool? Fullscreen { get; set; }

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
        /// Whether the Scaling button appears.
        /// </summary>
        [JsonPropertyName("scaling")]
        public bool? Scaling { get; set; }

        /// <summary>
        /// Whether the Share button appears.
        /// </summary>
        [JsonPropertyName("share")]
        public bool? Share { get; set; }

        /// <summary>
        /// Whether the Watch Later button appears.
        /// </summary>
        [JsonPropertyName("watchlater")]
        public bool? WatchLater { get; set; }
    }

    /// <summary>
    /// The logos in the corner of the embeddable player.
    /// </summary>
    public class EmbedLogos
    {
        /// <summary>
        /// The custom logo.
        /// </summary>
        [JsonPropertyName("custom")]
        public EmbedCustomLogo Custom { get; set; }

        /// <summary>
        /// Whether the Vimeo logo appears.
        /// </summary>
        [JsonPropertyName("vimeo")]
        public bool? Vimeo { get; set; }
    }

    /// <summary>
    /// The custom logo of the embeddable player.
    /// </summary>
    public class EmbedCustomLogo
    {
        /// <summary>
        /// Whether the custom logo appears.
        /// </summary>
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// The URL that loads when the user clicks the custom logo.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Whether the custom logo is always visible.
        /// </summary>
        [JsonPropertyName("sticky")]
        public bool? Sticky { get; set; }

        /// <summary>
        /// The URL of the custom logo image.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// The four player colors.
    /// </summary>
    public class EmbedColors
    {
        /// <summary>
        /// The first player color: progress bar and buttons.
        /// </summary>
        [JsonPropertyName("color_one")]
        public string ColorOne { get; set; }

        /// <summary>
        /// The second player color: player accent.
        /// </summary>
        [JsonPropertyName("color_two")]
        public string ColorTwo { get; set; }

        /// <summary>
        /// The third player color: text and icons.
        /// </summary>
        [JsonPropertyName("color_three")]
        public string ColorThree { get; set; }

        /// <summary>
        /// The fourth player color: player background.
        /// </summary>
        [JsonPropertyName("color_four")]
        public string ColorFour { get; set; }
    }

    /// <summary>
    /// The end screen of the embeddable player.
    /// </summary>
    public class EmbedEndScreen
    {
        /// <summary>
        /// The end screen type: beginning, custom, email, empty, image, link, loop, nothing, share, text, threevideos, thumbnail, videos.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// The play button of the embeddable player.
    /// </summary>
    public class EmbedPlayButton
    {
        /// <summary>
        /// The position of the play button: auto, bottom, center.
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; }
    }

    /// <summary>
    /// The title bar of the embeddable player: each value is hide, show or user.
    /// </summary>
    public class EmbedTitle
    {
        /// <summary>
        /// How the embeddable player handles the video title.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// How the embeddable player handles the video owner's information.
        /// </summary>
        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// How the embeddable player handles the video owner's portrait.
        /// </summary>
        [JsonPropertyName("portrait")]
        public string Portrait { get; set; }
    }
}
