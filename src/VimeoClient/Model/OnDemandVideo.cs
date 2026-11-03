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
    /// A video that belongs to an On Demand page: the video representation plus the On Demand information.
    /// </summary>
    public class OnDemandVideo : Video
    {
        /// <summary>
        /// The On Demand information of the video.
        /// </summary>
        [JsonPropertyName("ondemand")]
        public OnDemandVideoInfo OnDemand { get; set; }
    }

    /// <summary>
    /// The On Demand information of a video.
    /// </summary>
    public class OnDemandVideoInfo
    {
        /// <summary>
        /// Information about purchasing the video.
        /// </summary>
        [JsonPropertyName("buy")]
        public OnDemandPurchaseOption Buy { get; set; }

        /// <summary>
        /// The description of the video.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The position of the video in the page or season.
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// Information about renting the video.
        /// </summary>
        [JsonPropertyName("rent")]
        public OnDemandPurchaseOption Rent { get; set; }

        /// <summary>
        /// The season that contains the video.
        /// </summary>
        [JsonPropertyName("season")]
        public OnDemandSeason Season { get; set; }

        /// <summary>
        /// The type of the video: extra, main or trailer.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
