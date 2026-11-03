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
    /// The portfolio representation consists of the following fields.
    /// https://developer.vimeo.com/api/reference/portfolios
    /// </summary>
    public class Portfolio : VimeoIdentity
    {
        /// <summary>
        /// The time in ISO 8601 format when the portfolio was created.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// The description of the portfolio.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The URL to access the portfolio in a browser.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Metadata about the portfolio.
        /// </summary>
        [JsonPropertyName("metadata")]
        public PortfolioMetadata Metadata { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the portfolio was last modified.
        /// </summary>
        [JsonPropertyName("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// The display name of the portfolio.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The default video sort order of the portfolio
        /// (alphabetical, clips, date, likes, manual, modified, plays).
        /// </summary>
        [JsonPropertyName("sort")]
        public string Sort { get; set; }
    }

    /// <summary>
    /// Metadata about the portfolio.
    /// </summary>
    public class PortfolioMetadata
    {
        /// <summary>
        /// A collection of information that is connected to this resource.
        /// </summary>
        [JsonPropertyName("connections")]
        public PortfolioConnection Connections { get; set; }
    }

    /// <summary>
    /// A collection of information that is connected to this resource.
    /// </summary>
    public class PortfolioConnection
    {
        /// <summary>
        /// Information about the videos contained within this portfolio.
        /// </summary>
        [JsonPropertyName("videos")]
        public GenericRelatedEntity Videos { get; set; }
    }
}
