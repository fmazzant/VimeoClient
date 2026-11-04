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
    using System.Linq;

    /// <summary>
    /// The body to create an On Demand page.
    /// Required: Type, Name, Description, ContentRating.
    /// </summary>
    public class CreateAnOnDemandPageBody : IEditParameters, IPayloadParameters
    {
        /// <summary>
        /// The type of the On Demand page. Required.
        /// </summary>
        public OnDemandPageType Type { get; set; }

        /// <summary>
        /// The name of the On Demand page. Required.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the On Demand page. Required.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The content ratings of the On Demand page. Required.
        /// </summary>
        public List<OnDemandContentRating> ContentRating { get; set; }
            = new List<OnDemandContentRating>();

        /// <summary>
        /// The custom string to use in the Vimeo URL of the On Demand page.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// The custom domain of the On Demand page.
        /// </summary>
        public string DomainLink { get; set; }

        /// <summary>
        /// The accepted currencies: AUD, CAD, CHF, DKK, EUR, GBP, JPY, KRW, NOK, PLN, SEK, USD.
        /// </summary>
        public List<string> AcceptedCurrencies { get; set; }

        /// <summary>
        /// The purchase option of the page.
        /// </summary>
        public OnDemandPriceOption Buy { get; set; }

        /// <summary>
        /// The rental option of the page.
        /// </summary>
        public OnDemandPriceOption Rent { get; set; }

        /// <summary>
        /// The purchase option of the episodes (series only).
        /// </summary>
        public OnDemandPriceOption EpisodesBuy { get; set; }

        /// <summary>
        /// The rental option of the episodes (series only).
        /// </summary>
        public OnDemandPriceOption EpisodesRent { get; set; }

        /// <summary>
        /// The monthly subscription option of the page.
        /// </summary>
        public OnDemandPriceOption SubscriptionMonthly { get; set; }

        /// <summary>
        /// Builds the JSON body
        /// </summary>
        /// <returns></returns>
        public VimeoPayload ToPayload()
        {
            var payload = new VimeoPayload()
                .Set("type", Type)
                .Set("name", Name)
                .Set("description", Description)
                .Set("content_rating", ContentRating?.Select(x => x.ToString()).ToArray())
                .Set("link", Link)
                .Set("domain_link", DomainLink)
                .Set("accepted_currencies", AcceptedCurrencies?.ToArray());

            Buy?.WriteTo(payload, "buy");
            Rent?.WriteTo(payload, "rent");
            EpisodesBuy?.WriteTo(payload, "episodes.buy");
            EpisodesRent?.WriteTo(payload, "episodes.rent");
            SubscriptionMonthly?.WriteTo(payload, "subscription.monthly");

            return payload;
        }

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable() => ToPayload().Flatten();
    }
}
