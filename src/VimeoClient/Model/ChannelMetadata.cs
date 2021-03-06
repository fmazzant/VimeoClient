﻿/// <summary>
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
    /// Metadata about the channel.
    /// </summary>
    public class ChannelMetadata
    {
        /// <summary>
        /// A collection of information that is connected to this resource
        /// </summary>
        [JsonPropertyName("connections")]
        public ChannelConnection Connections { get; set; }

        /// <summary>
        /// A list of resource URIs related to the channel.
        /// </summary>
        [JsonPropertyName("interactions")]
        public ChannelInteractions Interactions { get; set; }
    }

    /// <summary>
    ///  A collection of information that is connected to this resource
    /// </summary>
    public class ChannelConnection
    {
        /// <summary>
        /// Information provided to channel moderators about which users they have specifically permitted to access this private channel.
        ///	This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("privacy_users")]
        public ChannelConnectionPrivacyUsersEntity PrivacyUsers { get; set; }

        /// <summary>
        /// Information about the users following or moderating this channel.
        /// </summary>
        [JsonPropertyName("users")]
        public ChannelConnectionUsersEntity Users { get; set; }

        /// <summary>
        ///  Information about the videos that belong to this channel.
        /// </summary>
        [JsonPropertyName("videos")]
        public ChannelConnectionVideosEntity videos { get; set; }
    }

    /// <summary>
    /// Information provided to channel moderators about which users they have specifically permitted to access this private channel.
    ///	This data requires a bearer token with the private scope.
    /// </summary>
    public class ChannelConnectionPrivacyUsersEntity : GenericRelatedEntity { }

    /// <summary>
    /// Information about the users following or moderating this channel.
    /// </summary>
    public class ChannelConnectionUsersEntity : GenericRelatedEntity { }

    /// <summary>
    ///  Information about the videos that belong to this channel.
    /// </summary>
    public class ChannelConnectionVideosEntity : GenericRelatedEntity { }

    /// <summary>
    /// A list of resource URIs related to the channel.
    /// </summary>
    public class ChannelInteractions
    {
        /// <summary>
        /// An action indicating that the authenticated user is the owner of the channel and may therefore add other users as channel moderators. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("add_moderators")]
        public ChannelInteractions AddModerators { get; set; }

        /// <summary>
        /// When a channel appears in the context of adding or removing a video from it (/videos/{video_id}/available_channels), 
        /// include information about adding or removing the video. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("add_to")]
        public ChannelInteractionsAddToEntity AddTo { get; set; }

        /// <summary>
        /// An action indicating if the authenticated user has followed this channel. This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("follow")]
        public ChannelInteractionsFollowEntity Follow { get; set; }

        /// <summary>
        /// An action indicating that the authenticated user is a moderator of the channel and may therefore add or remove videos from the channel. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("moderate_videos")]
        public ChannelInteractionsModerateVideosEntity ModerateVideos { get; set; }
    }

    /// <summary>
    /// An action indicating that the authenticated user is the owner of the channel and may therefore add other users as channel moderators. 
    /// This data requires a bearer token with the private scope.
    /// </summary>
    public class ChannelInteractionsAddModeratorsEntity
    {
        /// <summary>
        /// An array of HTTP methods permitted on this URI.
        /// </summary>
        [JsonPropertyName("options")]
        public string[] Options { get; set; }

        /// <summary>
        /// The API URI that resolves to the connection data.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// When a channel appears in the context of adding or removing a video from it (/videos/{video_id}/available_channels), 
    /// include information about adding or removing the video. 
    /// This data requires a bearer token with the private scope.
    /// </summary>
    public class ChannelInteractionsAddToEntity
    {
        /// <summary>
        /// An array of HTTP methods permitted on this URI.
        /// </summary>
        [JsonPropertyName("options")]
        public string[] Options { get; set; }

        /// <summary>
        /// The API URI that resolves to the connection data.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// An action indicating if the authenticated user has followed this channel. This data requires a bearer token with the private scope.
    /// </summary>
    public class ChannelInteractionsFollowEntity
    {
        /// <summary>
        /// Whether the authenticated user has followed this channel.This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("added")]
        public bool Added { get; set; }

        /// <summary>
        /// The time in ISO 8601 format that the user followed this channel, or the null value if the user hasn't followed the channel. 
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("added_time")]
        public string AddedTime { get; set; }

        /// <summary>
        /// Whether the authenticated user is a moderator or subscriber. This data requires a bearer token with the private scope.
        /// Option descriptions:
        ///     - moderator     The authenticated user is a moderator.
        ///     - subscriber    The authenticated user is a subscriber.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The URI for following or unfollowing this channel.PUT to this URI to follow the channel, or DELETE to this URI to unfollow the channel.
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// An action indicating that the authenticated user is a moderator of the channel and may therefore add or remove videos from the channel. 
    /// This data requires a bearer token with the private scope.
    /// </summary>
    public class ChannelInteractionsModerateVideosEntity
    {
        /// <summary>
        /// An array of HTTP methods permitted on this URI.
        /// </summary>
        [JsonPropertyName("options")]
        public string[] Options { get; set; }

        /// <summary>
        /// The API URI that resolves to the connection data.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}