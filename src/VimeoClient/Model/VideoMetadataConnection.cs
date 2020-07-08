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
    /// A list of resource URIs related to the video.
    /// </summary>
    public class VideoMetadataConnection
    {
        /// <summary>
        /// Information about the albums that contain this video. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("albums")]
        public GenericRelatedEntity Albums { get; set; }

        /// <summary>
        /// Information about the albums to which this video may be added. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("available_albums")]
        public GenericRelatedEntity AvailableAlbums { get; set; }

        /// <summary>
        /// Information about the channels to which this video may be added. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("available_channels")]
        public GenericRelatedEntity AvailableChannels { get; set; }

        /// <summary>
        /// Information about the comments
        /// </summary>
        [JsonPropertyName("comments")]
        public GenericRelatedEntity Comments { get; set; }

        /// <summary>
        /// Information about the users credited in this video.
        /// </summary>
        [JsonPropertyName("credits")]
        public GenericRelatedEntity Credits { get; set; }

        /// <summary>
        /// Information about the users who have liked this video.
        /// </summary>
        [JsonPropertyName("likes")]
        public GenericRelatedEntity Likes { get; set; }

        /// <summary>
        /// Information about this video's ondemand data.
        /// </summary>
        [JsonPropertyName("ondemand")]
        public GenericRelatedEntity OnDemand { get; set; }

        /// <summary>
        /// Information about this video's thumbnails.
        /// </summary>
        [JsonPropertyName("pictures")]
        public GenericRelatedEntity Pictures { get; set; }

        /// <summary>
        /// The DRM playback status connection for this video.
        /// </summary>
        [JsonPropertyName("playback")]
        public GenericRelatedEntity Playback { get; set; }

        /// <summary>
        /// Information about the user's publish to social history for this video.
        /// </summary>
        [JsonPropertyName("publish_to_social")]
        public GenericRelatedEntity PublishToSocial { get; set; }

        /// <summary>
        ///  The recommendations for this video.
        /// </summary>
        [JsonPropertyName("recommendations")]
        public GenericRelatedEntity Recommendations { get; set; }

        /// <summary>
        /// Related content for this video.
        /// </summary>
        [JsonPropertyName("related")]
        public GenericRelatedEntity Related { get; set; }

        /// <summary>
        /// Information about the video's season.
        /// </summary>
        [JsonPropertyName("season")]
        public GenericRelatedEntity Season { get; set; }

        /// <summary>
        /// Information about this video's text tracks.
        /// </summary>
        [JsonPropertyName("texttracks")]
        public GenericRelatedEntity TextTracks { get; set; }

        /// <summary>
        /// Information about this video's VOD trailer.
        /// </summary>
        [JsonPropertyName("trailer")]
        public GenericRelatedEntity Trailer { get; set; }

        /// <summary>
        ///  Information about the user privacy of this video, if the video privacy is users.
        /// </summary>
        [JsonPropertyName("users_with_access")]
        public GenericRelatedEntity UsersWithAccess { get; set; }

        /// <summary>
        /// Information about the versions of this video.
        /// </summary>
        [JsonPropertyName("versions")]
        public GenericRelatedEntity Versions { get; set; }
    }
}