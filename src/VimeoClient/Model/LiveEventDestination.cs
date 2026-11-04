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
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event Destination (Vimeo schema: event-destination).
    /// </summary>
    public class LiveEventDestination
    {
        /// <summary>
        /// The name of the destination target, whether a page, profile name, or the like.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The ID of the destination.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Whether the destination is enabled.
        /// </summary>
        [JsonPropertyName("is_enabled")]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// The ID of the live video.
        /// </summary>
        [JsonPropertyName("live_clip_id")]
        public long? LiveClipId { get; set; }

        /// <summary>
        /// Metadata about the event destination.
        /// </summary>
        [JsonPropertyName("metadata")]
        public LiveEventDestinationMetadata Metadata { get; set; }

        /// <summary>
        /// The privacy setting of the destination.
        /// </summary>
        [JsonPropertyName("privacy")]
        public string Privacy { get; set; }

        /// <summary>
        /// The broadcast ID of the destination service.
        /// </summary>
        [JsonPropertyName("provider_broadcast_id")]
        public string ProviderBroadcastId { get; set; }

        /// <summary>
        /// The destination ID of the destination service.
        /// </summary>
        [JsonPropertyName("provider_destination_id")]
        public string ProviderDestinationId { get; set; }

        /// <summary>
        /// The user ID of the destination service.
        /// </summary>
        [JsonPropertyName("provider_user_id")]
        public string ProviderUserId { get; set; }

        /// <summary>
        /// The ID of the scheduled live video.
        /// </summary>
        [JsonPropertyName("provider_video_id")]
        public string ProviderVideoId { get; set; }

        /// <summary>
        /// The time in Unix timestamp format when live streaming is scheduled to start.
        /// </summary>
        [JsonPropertyName("scheduled_at")]
        public double? ScheduledAt { get; set; }

        /// <summary>
        /// The name of the destination service.
        /// </summary>
        [JsonPropertyName("service_name")]
        public string ServiceName { get; set; }

        /// <summary>
        /// The status of the destination.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// The message that describes the state of the destination.
        /// </summary>
        [JsonPropertyName("state_message")]
        public string StateMessage { get; set; }

        /// <summary>
        /// The stream key for the simulcast destination.
        /// </summary>
        [JsonPropertyName("stream_key")]
        public string StreamKey { get; set; }

        /// <summary>
        /// The RTMP URL to stream to.
        /// </summary>
        [JsonPropertyName("stream_url")]
        public string StreamUrl { get; set; }

        /// <summary>
        /// The type of the simulcast destination.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The name of the destination's owner.
        /// </summary>
        [JsonPropertyName("user_display_name")]
        public string UserDisplayName { get; set; }

        /// <summary>
        /// The ID of the destination's owner.
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// Metadata about the event destination.
    /// </summary>
    public class LiveEventDestinationMetadata
    {
        /// <summary>
        /// Information about the connection status of the destination's user.
        /// </summary>
        [JsonPropertyName("connection_status")]
        public JsonElement? ConnectionStatus { get; set; }

        /// <summary>
        /// A list of resource URIs related to the event destination.
        /// </summary>
        [JsonPropertyName("interactions")]
        public LiveEventDestinationMetadataInteractions Interactions { get; set; }
    }

    /// <summary>
    /// A list of resource URIs related to the event destination.
    /// </summary>
    public class LiveEventDestinationMetadataInteractions
    {
        /// <summary>
        /// Information about where and how to edit an item.
        /// </summary>
        [JsonPropertyName("edit")]
        public LiveEventDestinationMetadataInteractionsEdit Edit { get; set; }
    }

    /// <summary>
    /// Information about where and how to edit an item.
    /// </summary>
    public class LiveEventDestinationMetadataInteractionsEdit
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
