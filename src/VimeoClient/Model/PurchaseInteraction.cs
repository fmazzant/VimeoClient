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
    /// The purchase interaction representation consists of the following fields.
    /// </summary>
    public class PurchaseInteraction
    {
        /// <summary>
        /// Information on purchasing this video.
        /// </summary>
        [JsonPropertyName("buy")]
        public PurchaseInteractionDrm Buy { get; set; }

        /// <summary>
        /// Information on renting this video.
        /// </summary>
        [JsonPropertyName("rent")]
        public PurchaseInteractionDrm Rent { get; set; }

        /// <summary>
        /// Information on subscribing to this video.
        /// </summary>
        [JsonPropertyName("subscribe")]
        public PurchaseInteractionSubscribe Subscribe { get; set; }
    }

    /// <summary>
    /// The DRM information of a purchase or rental.
    /// </summary>
    public class PurchaseInteractionDrm
    {
        /// <summary>
        /// Whether the On Demand video has DRM.
        /// </summary>
        [JsonPropertyName("drm")]
        public bool? Drm { get; set; }
    }

    /// <summary>
    /// Information on subscribing to a video.
    /// </summary>
    public class PurchaseInteractionSubscribe : PurchaseInteractionDrm
    {
        /// <summary>
        /// The time in ISO 8601 format when the On Demand video will expire.
        /// </summary>
        [JsonPropertyName("expires_time")]
        public string ExpiresTime { get; set; }

        /// <summary>
        /// The URL to purchase this On Demand subscription on Vimeo.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the On Demand was purchased.
        /// </summary>
        [JsonPropertyName("purchase_time")]
        public string PurchaseTime { get; set; }

        /// <summary>
        /// The user's streaming access to this On Demand subscription: available, purchased, restricted, unavailable.
        /// </summary>
        [JsonPropertyName("stream")]
        public string Stream { get; set; }

        /// <summary>
        /// The On Demand subscription's product URI.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}
