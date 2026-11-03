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
    /// The type of the video in the On Demand page.
    /// </summary>
    public enum OnDemandVideoType
    {
        /// <summary>
        /// The video is an extra.
        /// </summary>
        extra,

        /// <summary>
        /// The video is a main video.
        /// </summary>
        main,

        /// <summary>
        /// The video is the trailer.
        /// </summary>
        trailer
    }

    /// <summary>
    /// The body to add a video to an On Demand page.
    /// Required: Type.
    /// </summary>
    public class AddAVideoToAnOnDemandPageBody : IEditParameters, IPayloadParameters
    {
        /// <summary>
        /// The type of the video. Required.
        /// </summary>
        public OnDemandVideoType Type { get; set; }

        /// <summary>
        /// The position of the video in the page.
        /// </summary>
        public int? Position { get; set; }

        /// <summary>
        /// The release year of the video.
        /// </summary>
        public int? ReleaseYear { get; set; }

        /// <summary>
        /// The purchase price by currency code.
        /// </summary>
        public Dictionary<string, double> BuyPrice { get; set; }

        /// <summary>
        /// The rental price by currency code.
        /// </summary>
        public Dictionary<string, double> RentPrice { get; set; }

        /// <summary>
        /// Builds the JSON body
        /// </summary>
        /// <returns></returns>
        public VimeoPayload ToPayload() => new VimeoPayload()
            .Set("type", Type)
            .Set("position", Position)
            .Set("release_year", ReleaseYear)
            .SetPrices("buy.price", BuyPrice)
            .SetPrices("rent.price", RentPrice);

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable() => ToPayload().Flatten();
    }
}
