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
    /// The Rent interaction for an On Demand video.
    /// </summary>
    public class VideoMetadataInteractionRent
    {
        /// <summary>
        /// The currency code for the current user's region.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Formatted price to display to rent an On Demand video.
        /// </summary>
        [JsonPropertyName("display_price")]
        public string DisplayPrice { get; set; }

        /// <summary>
        /// Whether the video has DRM.
        /// </summary>
        [JsonPropertyName("drm")]
        public bool DRM { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the rental period for the video expires.
        /// </summary>
        [JsonPropertyName("expires_time")]
        public bool ExpiresTime { get; set; }

        /// <summary>
        /// The URL to rent the On Demand video on Vimeo.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The numeric value of the price for buying the On Demand video.
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the On Demand video was rented.
        /// </summary>
        [JsonPropertyName("purchase_time")]
        public string PurchaseTime { get; set; }

        /// <summary>
        /// The user's streaming access to this On Demand video:
        /// Option descriptions:
        ///     available - The video is available for streaming.
        ///     purchased - The user has purchased the video.
        ///     restricted - The user isn't permitted to stream the video.
        ///     unavailable - The video isn't available for streaming.
        /// </summary>
        [JsonPropertyName("stream")]
        public string Stream { get; set; }

        /// <summary>
        /// The product URI to rent the On Demand video.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}