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
namespace VimeoClient.Body.Live
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using VimeoClient.Model;

    /// <summary>
    /// The order in which the videos of the live event appear within the event's playlist.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlaylistSort
    {
        /// <summary>
        /// The most recently added videos appear first.
        /// </summary>
        added_first,

        /// <summary>
        /// The most recently added videos appear last.
        /// </summary>
        added_last,

        /// <summary>
        /// The videos appear in alphabetical order.
        /// </summary>
        alphabetical,

        /// <summary>
        /// The videos appear in the order in which the user has arranged them.
        /// </summary>
        arranged,

        /// <summary>
        /// The videos appear in order of number of comments.
        /// </summary>
        comments,

        /// <summary>
        /// The videos appear in order of duration.
        /// </summary>
        duration,

        /// <summary>
        /// The videos appear in order of number of likes.
        /// </summary>
        likes,

        /// <summary>
        /// The newest videos appear first.
        /// </summary>
        newest,

        /// <summary>
        /// The oldest videos appear first.
        /// </summary>
        oldest,

        /// <summary>
        /// The videos appear in order of number of plays.
        /// </summary>
        plays,
    }

    /// <summary>
    /// The live edit object.
    /// </summary>
    public class LiveParameters : IEditParameters, IPayloadParameters
    {
        /// <summary>
        /// The title of the live event. Required to create a live event.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The title of the next video in the live event.
        /// </summary>
        [JsonPropertyName("stream_title")]
        public string StreamTitle { get; set; }

        /// <summary>
        /// The description of the next video in the live event.
        /// </summary>
        [JsonPropertyName("stream_description")]
        public string StreamDescription { get; set; }

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
        /// The time zone of the live event.
        /// </summary>
        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Whether the viewers can seek back in the live stream (DVR).
        /// </summary>
        [JsonPropertyName("dvr")]
        public bool? Dvr { get; set; }

        /// <summary>
        /// Whether the live event uses low latency.
        /// </summary>
        [JsonPropertyName("low_latency")]
        public bool? LowLatency { get; set; }

        /// <summary>
        /// Whether the title for the next video in the live event is generated based on the time of the stream and the title field of the event.
        /// </summary>
        [JsonPropertyName("automatically_title_stream")]
        public bool? AutomaticallyTitleStream { get; set; }

        /// <summary>
        /// Whether to display the live chat client on the Vimeo event page.
        /// </summary>
        [JsonPropertyName("chat_enabled")]
        public bool? ChatEnabled { get; set; }

        /// <summary>
        /// A list of values describing the content in this event (drugs, language, nudity, safe, unrated, violence).
        /// To return the list of all possible content rating values, use the /contentratings endpoint.
        /// </summary>
        [JsonPropertyName("content_rating")]
        public string[] ContentRating { get; set; }

        /// <summary>
        /// The embed settings of the live event and the videos generated by streaming to this event.
        /// </summary>
        [JsonPropertyName("embed")]
        public EmbedSettings Embed { get; set; }

        /// <summary>
        /// The order in which the videos of the live event appear within the event's playlist.
        /// </summary>
        [JsonPropertyName("playlist_sort")]
        public PlaylistSort? PlaylistSort { get; set; }

        /// <summary>
        /// The URI of the recurring live event's folder.
        /// </summary>
        [JsonPropertyName("folder_uri")]
        public string FolderUri { get; set; }

        /// <summary>
        /// Information about the time or times that the live event is expected to be live.
        /// </summary>
        [JsonPropertyName("schedule")]
        public Schedule Schedule { get; set; }


        /// <summary>
        /// Builds the JSON body: only the values that are set are sent.
        /// </summary>
        /// <returns></returns>
        public VimeoPayload ToPayload() => VimeoPayload.FromObject(this);

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable() => ToPayload().Flatten();
    }
}