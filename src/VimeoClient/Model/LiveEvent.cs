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
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The live event representation consists of the following fields.
    /// The fields not mapped by the library are available in <see cref="AdditionalData"/>.
    /// </summary>
    public class LiveEvent : VimeoIdentity
    {
        /// <summary>
        /// Whether the title for the next video in the live event is generated automatically.
        /// </summary>
        [JsonPropertyName("automatically_title_stream")]
        public bool? AutomaticallyTitleStream { get; set; }

        /// <summary>
        /// Whether the live chat is enabled on the Vimeo event page.
        /// </summary>
        [JsonPropertyName("chat_enabled")]
        public bool? ChatEnabled { get; set; }

        /// <summary>
        /// The content ratings of the live event.
        /// </summary>
        [JsonPropertyName("content_rating")]
        public string[] ContentRating { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the live event was created.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// Whether the viewers can seek back in the live stream (DVR).
        /// </summary>
        [JsonPropertyName("dvr")]
        public bool? Dvr { get; set; }

        /// <summary>
        /// The embed settings of the live event.
        /// </summary>
        [JsonPropertyName("embed")]
        public EmbedSettings Embed { get; set; }

        /// <summary>
        /// The latest video of the live event.
        /// </summary>
        [JsonPropertyName("head_clip")]
        public Video HeadClip { get; set; }

        /// <summary>
        /// The URL to access the live event on Vimeo.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Whether the live event uses low latency.
        /// </summary>
        [JsonPropertyName("low_latency")]
        public bool? LowLatency { get; set; }

        /// <summary>
        /// The metadata of the live event.
        /// </summary>
        [JsonPropertyName("metadata")]
        public OnDemandMetadata Metadata { get; set; }

        /// <summary>
        /// The active thumbnail of the live event.
        /// </summary>
        [JsonPropertyName("pictures")]
        public Picture Pictures { get; set; }

        /// <summary>
        /// The order in which the videos of the live event appear within the event's playlist.
        /// </summary>
        [JsonPropertyName("playlist_sort")]
        public string PlaylistSort { get; set; }

        /// <summary>
        /// The RTMP link of the live event.
        /// </summary>
        [JsonPropertyName("rtmp_link")]
        public string RtmpLink { get; set; }

        /// <summary>
        /// The RTMPS link of the live event.
        /// </summary>
        [JsonPropertyName("rtmps_link")]
        public string RtmpsLink { get; set; }

        /// <summary>
        /// Information about the time or times that the live event is expected to be live.
        /// </summary>
        [JsonPropertyName("schedule")]
        public Schedule Schedule { get; set; }

        /// <summary>
        /// The description of the next video in the live event.
        /// </summary>
        [JsonPropertyName("stream_description")]
        public string StreamDescription { get; set; }

        /// <summary>
        /// The stream key of the live event.
        /// </summary>
        [JsonPropertyName("stream_key")]
        public string StreamKey { get; set; }

        /// <summary>
        /// The password of the live event, when the privacy is password.
        /// </summary>
        [JsonPropertyName("stream_password")]
        public string StreamPassword { get; set; }

        /// <summary>
        /// The privacy of the videos of the live event.
        /// </summary>
        [JsonPropertyName("stream_privacy")]
        public LiveEventStreamPrivacy StreamPrivacy { get; set; }

        /// <summary>
        /// The title of the next video in the live event.
        /// </summary>
        [JsonPropertyName("stream_title")]
        public string StreamTitle { get; set; }

        /// <summary>
        /// The time zone of the live event.
        /// </summary>
        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// The title of the live event.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The owner of the live event.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// The privacy of the videos of the live event.
    /// </summary>
    public class LiveEventStreamPrivacy
    {
        /// <summary>
        /// Who can embed the videos: public, private, whitelist.
        /// </summary>
        [JsonPropertyName("embed")]
        public string Embed { get; set; }

        /// <summary>
        /// Who can view the videos: anybody, contacts, disable, nobody, password, unlisted, users.
        /// </summary>
        [JsonPropertyName("view")]
        public string View { get; set; }
    }
}
