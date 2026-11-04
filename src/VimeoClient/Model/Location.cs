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
    /// The location details of a user.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The parsed city.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// The parsed country.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// The ISO 3166-1 alpha-2 code of the country.
        /// </summary>
        [JsonPropertyName("country_iso_code")]
        public string CountryIsoCode { get; set; }

        /// <summary>
        /// The formatted address.
        /// </summary>
        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// The latitude.
        /// </summary>
        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// The longitude.
        /// </summary>
        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// The parsed neighborhood.
        /// </summary>
        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// The parsed state.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// The ISO code of the state.
        /// </summary>
        [JsonPropertyName("state_iso_code")]
        public string StateIsoCode { get; set; }

        /// <summary>
        /// The parsed sub-locality.
        /// </summary>
        [JsonPropertyName("sub_locality")]
        public string SubLocality { get; set; }
    }
}
