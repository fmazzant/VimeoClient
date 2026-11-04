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

namespace Mafesoft.VimeoClient.Body.OnDemand
{
    using System.Collections.Generic;

    /// <summary>
    /// The type of access that the promotion grants.
    /// </summary>
    public enum OnDemandPromotionAccessType
    {
        /// <summary>
        /// The promotion grants the default access.
        /// </summary>
        @default,

        /// <summary>
        /// The promotion grants VIP access.
        /// </summary>
        vip
    }

    /// <summary>
    /// The type of discount of the promotion.
    /// </summary>
    public enum OnDemandPromotionDiscountType
    {
        /// <summary>
        /// The promotion is free.
        /// </summary>
        free,

        /// <summary>
        /// The promotion is a percentage off.
        /// </summary>
        percent
    }

    /// <summary>
    /// The product that the promotion is for.
    /// </summary>
    public enum OnDemandPromotionProductType
    {
        /// <summary>
        /// Any product.
        /// </summary>
        any,

        /// <summary>
        /// Purchase of the page.
        /// </summary>
        buy,

        /// <summary>
        /// Purchase of an episode.
        /// </summary>
        buy_episode,

        /// <summary>
        /// Rental of the page.
        /// </summary>
        rent,

        /// <summary>
        /// Rental of an episode.
        /// </summary>
        rent_episode,

        /// <summary>
        /// Subscription.
        /// </summary>
        subscribe
    }

    /// <summary>
    /// The streaming period of the promotion (sent as 1_week, 24_hour...).
    /// </summary>
    public enum OnDemandPromotionStreamPeriod
    {
        /// <summary>
        /// 24 hours
        /// </summary>
        _24_hour,

        /// <summary>
        /// 48 hours
        /// </summary>
        _48_hour,

        /// <summary>
        /// 72 hours
        /// </summary>
        _72_hour,

        /// <summary>
        /// 1 week
        /// </summary>
        _1_week,

        /// <summary>
        /// 30 days
        /// </summary>
        _30_day,

        /// <summary>
        /// 3 months
        /// </summary>
        _3_month,

        /// <summary>
        /// 6 months
        /// </summary>
        _6_month,

        /// <summary>
        /// 1 year
        /// </summary>
        _1_year
    }

    /// <summary>
    /// The type of the promotion.
    /// </summary>
    public enum OnDemandPromotionType
    {
        /// <summary>
        /// A batch of codes.
        /// </summary>
        batch,

        /// <summary>
        /// A single code used many times.
        /// </summary>
        single
    }

    /// <summary>
    /// The body to add a promotion to an On Demand page.
    /// Required: Download, StreamPeriod, Total, Type.
    /// </summary>
    public class AddAPromotionToAnOnDemandPageBody : IEditParameters, IPayloadParameters
    {
        /// <summary>
        /// The type of access that the promotion grants.
        /// </summary>
        public OnDemandPromotionAccessType? AccessType { get; set; }

        /// <summary>
        /// The promotion code (single promotions only).
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The type of discount.
        /// </summary>
        public OnDemandPromotionDiscountType? DiscountType { get; set; }

        /// <summary>
        /// Whether the promotion includes the download. Required.
        /// </summary>
        public bool Download { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the promotion ends.
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// The description of the promotion.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The percentage of the discount (when DiscountType is percent).
        /// </summary>
        public int? PercentOff { get; set; }

        /// <summary>
        /// The product that the promotion is for.
        /// </summary>
        public OnDemandPromotionProductType? ProductType { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the promotion starts.
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// The streaming period of the promotion. Required.
        /// </summary>
        public OnDemandPromotionStreamPeriod StreamPeriod { get; set; }

        /// <summary>
        /// The total number of times that the promotion can be used. Required.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// The type of the promotion. Required.
        /// </summary>
        public OnDemandPromotionType Type { get; set; }

        /// <summary>
        /// Builds the JSON body
        /// </summary>
        /// <returns></returns>
        public VimeoPayload ToPayload() => new VimeoPayload()
            .Set("access_type", AccessType)
            .Set("code", Code)
            .Set("discount_type", DiscountType)
            .Set("download", Download)
            .Set("end_time", EndTime)
            .Set("label", Label)
            .Set("percent_off", PercentOff)
            .Set("product_type", ProductType)
            .Set("start_time", StartTime)
            .Set("stream_period", StreamPeriod)
            .Set("total", Total)
            .Set("type", Type);

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable() => ToPayload().Flatten();
    }
}
