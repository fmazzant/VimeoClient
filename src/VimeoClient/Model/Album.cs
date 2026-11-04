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
    /// The showcase (album) representation consists of the following fields.
    /// </summary>
    public class Album : VimeoIdentity
    {
        /// <summary>
        /// Whether to allow continuous play of the videos in the showcase.
        /// </summary>
        [JsonPropertyName("allow_continuous_play")]
        public bool AllowContinuousPlay { get; set; }

        /// <summary>
        /// Whether to allow downloads of the videos in the showcase.
        /// </summary>
        [JsonPropertyName("allow_downloads")]
        public bool AllowDownloads { get; set; }

        /// <summary>
        /// Whether to allow sharing of the videos in the showcase.
        /// </summary>
        [JsonPropertyName("allow_share")]
        public bool AllowShare { get; set; }

        /// <summary>
        /// The hexadecimal code for the color of the player buttons and showcase controls.
        /// </summary>
        [JsonPropertyName("brand_color")]
        public string BrandColor { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the showcase was created.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// The custom logo of the showcase.
        /// </summary>
        [JsonPropertyName("custom_logo")]
        public Picture CustomLogo { get; set; }

        /// <summary>
        /// The description of the showcase.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The custom domain of the showcase.
        /// </summary>
        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// Whether the user has a certified custom domain.
        /// </summary>
        [JsonPropertyName("domain_certificate_state")]
        public string DomainCertificateState { get; set; }

        /// <summary>
        /// The total duration in seconds of all the videos in the showcase.
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// The embed settings of the showcase.
        /// </summary>
        [JsonPropertyName("embed")]
        public EmbedSettings Embed { get; set; }

        /// <summary>
        /// Whether to hide Vimeo navigation when displaying the showcase.
        /// </summary>
        [JsonPropertyName("hide_nav")]
        public bool HideNav { get; set; }

        /// <summary>
        /// Whether the upcoming live event is hidden in the showcase.
        /// </summary>
        [JsonPropertyName("hide_upcoming")]
        public bool HideUpcoming { get; set; }

        /// <summary>
        /// Whether the Vimeo logo is hidden in the showcase.
        /// </summary>
        [JsonPropertyName("hide_vimeo_logo")]
        public bool HideVimeoLogo { get; set; }

        /// <summary>
        /// The type of layout for presenting the showcase: grid or player.
        /// </summary>
        [JsonPropertyName("layout")]
        public string Layout { get; set; }

        /// <summary>
        /// The URL to access the showcase.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Metadata about the showcase.
        /// </summary>
        [JsonPropertyName("metadata")]
        public AlbumMetadata Metadata { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the showcase was last modified.
        /// </summary>
        [JsonPropertyName("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// The display name of the showcase.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The active image for the showcase.
        /// </summary>
        [JsonPropertyName("pictures")]
        public Picture Pictures { get; set; }

        /// <summary>
        /// The privacy settings of the showcase.
        /// </summary>
        [JsonPropertyName("privacy")]
        public AlbumPrivacy Privacy { get; set; }

        /// <summary>
        /// Whether showcase videos use the review mode URL.
        /// </summary>
        [JsonPropertyName("review_mode")]
        public bool ReviewMode { get; set; }

        /// <summary>
        /// The default sort order of the videos as they appear in the showcase.
        /// </summary>
        [JsonPropertyName("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// The color theme of the showcase: dark or standard.
        /// </summary>
        [JsonPropertyName("theme")]
        public string Theme { get; set; }

        /// <summary>
        /// The custom Vimeo URL of the showcase.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Whether the user has opted in to use a custom domain for the showcase.
        /// </summary>
        [JsonPropertyName("use_custom_domain")]
        public bool UseCustomDomain { get; set; }

        /// <summary>
        /// The owner of the showcase.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }

        /// <summary>
        /// The showcase identity
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{base.ToString()} - Name: {Name}";
    }

    /// <summary>
    /// The privacy settings of the showcase.
    /// </summary>
    public class AlbumPrivacy
    {
        /// <summary>
        /// The privacy-enabled password to see this showcase. Present only when privacy.view is password.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// Who can view the showcase: anybody, embed_only, nobody, password, team or unlisted.
        /// </summary>
        [JsonPropertyName("view")]
        public string View { get; set; }
    }
}
