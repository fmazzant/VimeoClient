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
    /// The video representation consists of the following fields.
    /// </summary>
    public class Video : VimeoIdentity
    {
        /// <summary>
        /// The categories to which this video belongs.
        /// </summary>
        [JsonPropertyName("categories")]
        public Category[] Categories { get; set; }

        /// <summary>
        /// The content ratings of this video.
        /// </summary>
        [JsonPropertyName("content_rating")]
        public string[] ContentRating { get; set; }

        /// <summary>
        /// The context of the video's subscription, if this video is part of a subscription.
        /// </summary>
        [JsonPropertyName("context")]
        public VideoContext Context { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the video was created.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// A brief explanation of the video's content.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The video's duration in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Information about embedding this video.
        /// </summary>
        [JsonPropertyName("embed")]
        public EmbedSettings Embed { get; set; }

        /// <summary>
        /// The video's height in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        /// The video's primary language.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the user last modified the video.
        /// </summary>
        [JsonPropertyName("last_user_action_event_date")]
        public string LastUserActionEventDate { get; set; }

        /// <summary>
        /// The Creative Commons license used for the video:
        /// Option descriptions:
        ///     by - Attribution
        ///     by-nc - Attribution Non-Commercial
        ///     by-nc-nd - Attribution Non-Commercial No Derivatives
        ///     by-nc-sa - Attribution Non-Commercial Share Alike
        ///     by-nd - Attribution No Derivatives
        ///     by-sa - Attribution Share Alike
        ///     cc0 - Public Domain Dedication
        /// </summary>
        [JsonPropertyName("license")]
        public string License { get; set; }

        /// <summary>
        /// The link to the video.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The video's metadata.
        /// </summary>
        [JsonPropertyName("metadata")]
        public VideoMetadata Metadata { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the video metadata was last modified.
        /// </summary>
        [JsonPropertyName("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// The video's title.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Information about the folder that contains this video.
        /// </summary>
        [JsonPropertyName("parent_folder")]
        public Project ParentFolder { get; set; }

        /// <summary>
        /// The privacy-enabled password to watch this video.Only users can see their own video passwords. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// The active picture for this video.
        /// </summary>
        [JsonPropertyName("pictures")]
        public Picture Pictures { get; set; }

        /// <summary>
        /// The video's privacy setting.
        /// </summary>
        [JsonPropertyName("privacy")]
        public VideoPrivacy Privacy { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the video was released.
        /// </summary>
        [JsonPropertyName("release_time")]
        public string ReleaseTime { get; set; }

        /// <summary>
        /// 360 spatial data.
        /// </summary>
        [JsonPropertyName("spatial")]
        public VideoSpatial Spatial { get; set; }

        /// <summary>
        /// A collection of stats associated with this video.
        /// </summary>
        [JsonPropertyName("state")]
        public VideoState State { get; set; }

        /// <summary>
        /// The status code for the availability of the video. This field is deprecated in favor of upload and transcode.
        /// Option descriptions:
        ///     available - The video is available.
        ///     quota_exceeded - The user's quota is exceeded with this video.
        ///     total_cap_exceeded - The user has exceeded their total cap with this video.
        ///     transcode_starting - Transcoding is beginning for the video.
        ///     transcoding - Transcoding is underway for the video.
        ///     transcoding_error - There was an error in transcoding the video.
        ///     unavailable - The video is unavailable.
        ///     uploading - The video is being uploaded.
        ///     uploading_error - There was an error in uploading the video.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// An array of all tags assigned to this video.
        /// </summary>
        [JsonPropertyName("tags")]
        public Tag[] Tags { get; set; }

        /// <summary>
        /// The transcode information for a video upload.
        /// </summary>
        [JsonPropertyName("transcode")]
        public VideoTranscode Transcode { get; set; }

        /// <summary>
        /// The type of the video.
        /// Option descriptions:
        ///     live - The video is or was a live event.
        ///     stock - The video is a Vimeo Stock video.
        ///     video - The video is a standard Vimeo video.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The upload information for this video.
        /// </summary>
        [JsonPropertyName("upload")]
        public VideoUpload Upload { get; set; }

        /// <summary>
        /// The video owner.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }

        /// <summary>
        /// The video's width in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}