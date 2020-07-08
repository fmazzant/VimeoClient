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
    using System.Dynamic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The video representation consists of the following fields.
    /// </summary>
    public class Video
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
        ///  The resource key string of the video.
        /// </summary>
        [JsonPropertyName("resource_key")]
        public string ResourceKey { get; set; }

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
        /// The video's canonical relative URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

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

    /// <summary>
    /// The context of the video's subscription, if this video is part of a subscription.
    /// </summary>
    public class VideoContext
    {
        /// <summary>
        /// The contextual action:
        /// Option descriptions:
        ///     Added to - An Added To action.
        ///     Appearance by - An Appearance By action.
        ///     Liked by - A Liked By action.
        ///     Uploaded by - An Unloaded By action.
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }

        /// <summary>
        /// The contextual resource: a user, group, or channel representation, or an object of a tag.
        /// </summary>
        [JsonPropertyName("resource")]
        public VideoContextResource Resource { get; set; }
    }

    /// <summary>
    /// The contextual resource: a user, group, or channel representation, or an object of a tag.
    /// </summary>
    public class VideoContextResource
    {
        /// <summary>
        /// The contextual resource type.
        /// </summary>
        [JsonPropertyName("resource_type")]
        public string ResourceType { get; set; }
    }

    /// <summary>
    /// The video's metadata.
    /// </summary>
    public class VideoMetadata
    {
        /// <summary>
        /// A list of resource URIs related to the video.
        /// </summary>
        [JsonPropertyName("connections")]
        public VideoMetadataConnection Connections { get; set; }

        /// <summary>
        ///  A list of resource URIs related to the video.
        /// </summary>
        [JsonPropertyName("interactions")]
        public VideoMetadataInteractions Interactions { get; set; }
    }

    /// <summary>
    /// A list of resource URIs related to the video.
    /// </summary>
    public class VideoMetadataConnection
    {
        /// <summary>
        /// Information about the albums that contain this video. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("albums")]
        public GenericRelatedEntity albums { get; set; }

        /// <summary>
        /// Information about the albums to which this video may be added. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("available_albums")]
        public GenericRelatedEntity available_albums { get; set; }

        /// <summary>
        /// Information about the channels to which this video may be added. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("available_channels")]
        public GenericRelatedEntity available_channels { get; set; }

        /// <summary>
        /// Information about the comments
        /// </summary>
        [JsonPropertyName("comments")]
        public GenericRelatedEntity comments { get; set; }

        /// <summary>
        /// Information about the users credited in this video.
        /// </summary>
        [JsonPropertyName("credits")]
        public GenericRelatedEntity credits { get; set; }

        /// <summary>
        /// Information about the users who have liked this video.
        /// </summary>
        [JsonPropertyName("likes")]
        public GenericRelatedEntity likes { get; set; }

        /// <summary>
        /// Information about this video's ondemand data.
        /// </summary>
        [JsonPropertyName("ondemand")]
        public GenericRelatedEntity ondemand { get; set; }

        /// <summary>
        /// Information about this video's thumbnails.
        /// </summary>
        [JsonPropertyName("pictures")]
        public GenericRelatedEntity pictures { get; set; }

        /// <summary>
        /// The DRM playback status connection for this video.
        /// </summary>
        [JsonPropertyName("playback")]
        public GenericRelatedEntity playback { get; set; }

        /// <summary>
        /// Information about the user's publish to social history for this video.
        /// </summary>
        [JsonPropertyName("publish_to_social")]
        public GenericRelatedEntity publish_to_social { get; set; }

        /// <summary>
        ///  The recommendations for this video.
        /// </summary>
        [JsonPropertyName("recommendations")]
        public GenericRelatedEntity recommendations { get; set; }

        /// <summary>
        /// Related content for this video.
        /// </summary>
        [JsonPropertyName("related")]
        public GenericRelatedEntity related { get; set; }

        /// <summary>
        /// Information about the video's season.
        /// </summary>
        [JsonPropertyName("season")]
        public GenericRelatedEntity season { get; set; }

        /// <summary>
        /// Information about this video's text tracks.
        /// </summary>
        [JsonPropertyName("texttracks")]
        public GenericRelatedEntity texttracks { get; set; }

        /// <summary>
        /// Information about this video's VOD trailer.
        /// </summary>
        [JsonPropertyName("trailer")]
        public GenericRelatedEntity trailer { get; set; }

        /// <summary>
        ///  Information about the user privacy of this video, if the video privacy is users.
        /// </summary>
        [JsonPropertyName("users_with_access")]
        public GenericRelatedEntity users_with_access { get; set; }

        /// <summary>
        /// Information about the versions of this video.
        /// </summary>
        [JsonPropertyName("versions")]
        public GenericRelatedEntity versions { get; set; }
    }

    /// <summary>
    /// A list of resource URIs related to the video.
    /// </summary>
    public class VideoMetadataInteractions
    {

    }

    /// <summary>
    /// The video's privacy setting.
    /// </summary>
    public class VideoPrivacy
    {
        //        privacy.add Boolean
        //Whether the video can be added to collections.
        //    privacy.comments    String
        //Who can comment on the video:
        //Option descriptions:
        //anybody - Anyone can comment on the video.
        //contacts - Only contacts can comment on the video.
        //nobody - No one can comment on the video.
        //    privacy.download Boolean
        //The video's download permission setting.
        //    privacy.embed String
        //The video's embed permission setting:
        //Option descriptions:
        //private - The video is private.
        //public - Anyone can embed the video.
        //    privacy.view String
        //The general privacy setting for the video:
        //Option descriptions:
        //anybody - Anyone can view the video.
        //contacts - Only contacts can view the video.
        //disable - Hide from vimeo
        //nobody - No one besides the owner can view the video.
        //password - Anyone with the video's password can view the video.
        //unlisted - Not searchable from vimeo.com
        //users - Only people with a Vimeo account can view the video.
    }

    /// <summary>
    /// 360 spatial data.
    /// </summary>
    public class VideoSpatial
    {
        //        spatial.director_timeline Array	
        //360 director timeline.
        //  spatial.director_timeline.pitch Number
        //The director timeline pitch, from -90 (minimum) to 90 (maximum).
        //  spatial.director_timeline.roll Number
        //The director timeline roll.
        //  spatial.director_timeline.time_code Number
        //The director timeline time code.
        //  spatial.director_timeline.yaw Number
        //The director timeline yaw, from 0 (minimum) to 360 (maximum).
        //  spatial.field_of_view Number
        //The 360 field of view, from 30 (minimum) to 90 (maximum). The default is 50.
        //  spatial.projection String
        //The 360 spatial projection:
        //Option descriptions:
        //cubical - The spatial projection is cubical.
        //cylindrical - The spatial projection is cylindrical.
        //dome - The spatial projection is dome-shaped.
        //equirectangular - The spatial projection is equirectangular.
        //pyramid - The spatial projection is pyramid-shaped.
        //  spatial.stereo_format String
        //The 360 stereo format:
        //Option descriptions:
        //left-right - The stereo format is left-right.
        //mono - The audio is monaural.
    }

    /// <summary>
    /// A collection of stats associated with this video.
    /// </summary>
    public class VideoState
    {
        //        stats.plays Number
        //The current total number of times that the video has been played.
    }

    /// <summary>
    /// The transcode information for a video upload.
    /// </summary>
    public class VideoTranscode
    {
        //        transcode.status String
        //Status code for this video's availability.
    }

    /// <summary>
    /// The upload information for this video.
    /// </summary>
    public class VideoUpload
    {
        //    upload.approach String
        //The approach for uploading the video.
        //    upload.complete_uri String
        //The URI for completing the upload.
        //    upload.form String
        //The HTML form for uploading a video through the post approach.
        //    upload.link String
        //The link of the video to capture through the pull approach.
        //    upload.redirect_url String
        //The redirect URL for the upload app.
        //    upload.size Number
        //The file size in bytes of the uploaded video.
        //    upload.status String
        //The status code for the availability of the uploaded video:
        //Option descriptions:
        //complete - The upload is complete.
        //error - The upload ended with an error.
        //in_progress - The upload is underway.
        //    upload.upload_link String
        //The link for sending video file data.
    }
}