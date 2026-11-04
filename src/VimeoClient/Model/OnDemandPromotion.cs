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
    using System.Text.Json.Serialization;

    /// <summary>
    /// The On Demand promotion representation consists of the following fields.
    /// </summary>
    public class OnDemandPromotion : VimeoIdentity
    {
        /// <summary>
        /// The type of access that this promotion grants.
        /// </summary>
        [JsonPropertyName("access_type")]
        public string AccessType { get; set; }

        /// <summary>
        /// The promotion code (single use promotions).
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The amount of the discount.
        /// </summary>
        [JsonPropertyName("discount_amount")]
        public double? DiscountAmount { get; set; }

        /// <summary>
        /// The percentage of the discount.
        /// </summary>
        [JsonPropertyName("discount_percentage")]
        public double? DiscountPercentage { get; set; }

        /// <summary>
        /// The type of discount: dollars, free or percent.
        /// </summary>
        [JsonPropertyName("discount_type")]
        public string DiscountType { get; set; }

        /// <summary>
        /// Whether the promotion includes the download.
        /// </summary>
        [JsonPropertyName("download")]
        public bool Download { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the promotion ends.
        /// </summary>
        [JsonPropertyName("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// The product that the promotion is for: buy, rent or subscribe.
        /// </summary>
        [JsonPropertyName("product_type")]
        public string ProductType { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the promotion starts.
        /// </summary>
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// The total number of times that the promotion can be used.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// The type of the promotion: batch or single.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
