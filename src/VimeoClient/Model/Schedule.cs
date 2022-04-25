
using System.Text.Json.Serialization;
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
    /// <summary>
    /// The event is live on a weekly basis.
    /// </summary>
    public enum ScheduleType
    {
        /// <summary>
        /// The event is live on a weekly basis.
        /// </summary>
        single,

        /// <summary>
        /// The event is live on a weekly basis.
        /// </summary>
        weekly
    }

    /// <summary>
    /// Information about the time or times that the live event is expected to be live.
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// The ISO 8601 time on which the live event is expected to be live, with the zero UTC offset Z. This parameter is required when schedule.type is weekly.
        /// </summary>
        [JsonPropertyName("daily_time")]
        public string daily_time { get; set; }

        /// <summary>
        /// The ISO 8601 time on which the live event is expected to be live, with support for different time offsets. This parameter is required when schedule.type is single.
        /// </summary>
        [JsonPropertyName("start_time")]
        public string start_time { get; set; }

        /// <summary>
        /// How often the live event is expected to be live.
        /// single - The event is live one time only.
        /// weekly - The event is live on a weekly basis.
        /// </summary>
        [JsonPropertyName("type")]
        public ScheduleType ScheduleType { get; set; }

        /// <summary>
        /// A non-empty array of weekdays on which the live event is expected to be live. Weekdays can range from 1 to 7, where 1 is Monday and 7 is Sunday. This parameter is required when schedule.type is weekly.
        /// </summary>
        [JsonPropertyName("weekdays")]
        public int[] weekdays { get; set; }

        /// <summary>
        /// The description of the next video to be streamed to the live event.
        /// </summary>
        [JsonPropertyName("stream_description")]
        public string stream_description { get; set; }
    }
}