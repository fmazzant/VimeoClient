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
    /// Metadata about the group.
    /// </summary>
    public class GroupMetadata
    {
        /// <summary>
        /// A collection of information that is connected to this resource
        /// </summary>
        [JsonPropertyName("connections")]
        public GroupConnection Connections { get; set; }

        /// <summary>
        /// User actions that have involved the group. This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("interactions")]
        public GroupInteractions Interactions { get; set; }
    }

    /// <summary>
    /// A collection of information that is connected to this resource
    /// </summary>
    public class GroupConnection
    {
        /// <summary>
        /// Information about the members or moderators of the group.
        /// </summary>
        [JsonPropertyName("users")]
        public GroupConnectionUsersEntity Users { get; set; }

        /// <summary>
        ///  Information about the videos contained within the group.
        /// </summary>
        [JsonPropertyName("videos")]
        public GroupConnectionVideosEntity Videos { get; set; }
    }

    /// <summary>
    /// Information about the members or moderators of the group.
    /// </summary>
    public class GroupConnectionUsersEntity : GenericRelatedEntity { }

    /// <summary>
    ///  Information about the videos contained within the group.
    /// </summary>
    public class GroupConnectionVideosEntity : GenericRelatedEntity { }

    /// <summary>
    /// User actions that have involved the group. This data requires a bearer token with the private scope.
    /// </summary>
    public class GroupInteractions
    {
        /// <summary>
        /// An action indicating that someone has joined the group. This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("join")]
        public GroupInteractionsJoin Join { get; set; }
    }

    /// <summary>
    /// An action indicating that someone has joined the group. This data requires a bearer token with the private scope.
    /// </summary>
    public class GroupInteractionsJoin
    {
        /// <summary>
        /// Whether the authenticated user has followed the group.This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("added")]
        public bool Added { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the authenticated user joined the group.This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("added_time")]
        public string AddedTime { get; set; }

        /// <summary>
        /// The authenticated user's title. If not applicable, this field takes the null value. This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Whether the authenticated user is a moderator or subscriber.This data requires a bearer token with the private scope.
        /// Option descriptions:
        ///     member - The authenticated user is a member.
        ///     moderator - The authenticated user is a moderator.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The URI for following the group.
        /// PUT to this URI to follow the group, or DELETE to this URI to unfollow the group.
        /// This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}