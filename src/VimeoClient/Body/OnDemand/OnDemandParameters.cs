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

namespace VimeoClient.Body.OnDemand
{
    using System.Collections.Generic;

    /// <summary>
    /// The type of the On Demand page.
    /// </summary>
    public enum OnDemandPageType
    {
        /// <summary>
        /// The On Demand page is for a film.
        /// </summary>
        film,

        /// <summary>
        /// The On Demand page is for a series.
        /// </summary>
        series
    }

    /// <summary>
    /// The content rating of the On Demand page.
    /// </summary>
    public enum OnDemandContentRating
    {
        /// <summary>
        /// The page contains depictions of drug or alcohol use.
        /// </summary>
        drugs,

        /// <summary>
        /// The page contains profanity or sexually suggestive content.
        /// </summary>
        language,

        /// <summary>
        /// The page contains nudity.
        /// </summary>
        nudity,

        /// <summary>
        /// The page is suitable for all audiences.
        /// </summary>
        safe,

        /// <summary>
        /// The page hasn't been rated.
        /// </summary>
        unrated,

        /// <summary>
        /// The page contains violence.
        /// </summary>
        violence
    }

    /// <summary>
    /// The rental period of the On Demand page (sent as "24 hour", "1 week"...).
    /// </summary>
    public enum OnDemandRentPeriod
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
        /// 30 days
        /// </summary>
        _30_day,

        /// <summary>
        /// 1 week
        /// </summary>
        _1_week,

        /// <summary>
        /// 3 months
        /// </summary>
        _3_month,

        /// <summary>
        /// 1 year
        /// </summary>
        _1_year
    }

    /// <summary>
    /// The price option (buy, rent or subscription) of an On Demand page.
    /// </summary>
    public class OnDemandPriceOption
    {
        /// <summary>
        /// Whether the option is active.
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// Whether the videos can be downloaded (buy only).
        /// </summary>
        public bool? Download { get; set; }

        /// <summary>
        /// The rental period (rent only).
        /// </summary>
        public OnDemandRentPeriod? Period { get; set; }

        /// <summary>
        /// The price by currency code: AUD, CAD, CHF, DKK, EUR, GBP, JPY, KRW, NOK, PLN, SEK, USD.
        /// </summary>
        public Dictionary<string, double> Price { get; set; }
            = new Dictionary<string, double>();

        /// <summary>
        /// Writes the option into the payload at the specified path
        /// </summary>
        /// <param name="payload">The payload</param>
        /// <param name="path">The dotted path, for instance buy or episodes.rent</param>
        internal void WriteTo(VimeoPayload payload, string path) => payload
            .Set($"{path}.active", Active)
            .Set($"{path}.download", Download)
            .Set($"{path}.period", Period.HasValue ? VimeoRestBuilderExtensions.ToVimeoValue(Period).Replace('_', ' ') : null)
            .SetPrices($"{path}.price", Price?.Count > 0 ? Price : null);
    }
}
