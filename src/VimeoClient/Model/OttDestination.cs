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
    /// OTT Destination (Vimeo schema: ott-destination).
    /// </summary>
    public class OttDestination
    {
        /// <summary>
        /// The OTT destination's canonical relative URI.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the OTT channel.
        /// </summary>
        [JsonPropertyName("ott_channel_id")]
        public long? OttChannelId { get; set; }

        /// <summary>
        /// The name of the OTT channel.
        /// </summary>
        [JsonPropertyName("ott_channel_name")]
        public string OttChannelName { get; set; }

        /// <summary>
        /// The subdomain of the OTT channel.
        /// </summary>
        [JsonPropertyName("ott_channel_subdomain")]
        public string OttChannelSubdomain { get; set; }

        /// <summary>
        /// The ID of the OTT event.
        /// </summary>
        [JsonPropertyName("ott_event_id")]
        public long? OttEventId { get; set; }

        /// <summary>
        /// The ID of the current recurring event.
        /// </summary>
        [JsonPropertyName("recurring_live_event_id")]
        public long? RecurringLiveEventId { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }
}
