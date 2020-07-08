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
    public class VideoMetadataInteractions
    {
        /// <summary>
        /// When a video is referenced by an album URI, if the user is a moderator of the album, 
        /// include information about adding or removing the video from the album.
        /// </summary>
        [JsonPropertyName("album")]
        public VideoMetadataInteractionAlbum Album { get; set; }

        /// <summary>
        /// The Buy interaction for a On Demand video.
        /// </summary>
        [JsonPropertyName("buy")]
        public VideoMetadataInteractionBuy Buy { get; set; }

        /// <summary>
        /// When a video is referenced by a channel URI, if the user is a moderator of the channel, 
        /// include information about removing the video from the channel.
        /// </summary>
        [JsonPropertyName("channel")]
        public VideoMetadataInteractionChannel Channel { get; set; }

        /// <summary>
        /// Information about whether the authenticated user has liked this video.
        /// </summary>
        [JsonPropertyName("like")]
        public VideoMetadataInteractionLike Like { get; set; }

        /// <summary>
        /// The Rent interaction for an On Demand video.
        /// </summary>
        [JsonPropertyName("rent")]
        public VideoMetadataInteractionRent Rent { get; set; }

        /// <summary>
        /// Information about where and how to report a video.
        /// </summary>
        [JsonPropertyName("report")]
        public VideoMetadataInteractionReport Report { get; set; }

        /// <summary>
        /// Subscription information for an On Demand video.
        /// </summary>
        [JsonPropertyName("subscribe")]
        public VideoMetadataInteractionSubscribe Subscribe { get; set; }

        /// <summary>
        /// Information about removing this video from the user's list of watched videos.
        /// </summary>
        [JsonPropertyName("watched")]
        public VideoMetadataInteractionWatched Watched { get; set; }

        /// <summary>
        /// Information about whether this video appears on the authenticated user's Watch Later list.
        /// </summary>
        [JsonPropertyName("watchlater")]
        public VideoMetadataInteractionWachlater Watchlater { get; set; }
    }
}