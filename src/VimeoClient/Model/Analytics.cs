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
    /// The analytics representation: the metrics of a group of results
    /// (by country, device type, embed domain, total or video) over a time interval.
    /// </summary>
    public class Analytics
    {
        /// <summary>
        /// The average percent watched of the corresponding Vimeo content.
        /// </summary>
        [JsonPropertyName("average_percent_watched")]
        public double? AveragePercentWatched { get; set; }

        /// <summary>
        /// The average time watched in seconds of the corresponding Vimeo content.
        /// </summary>
        [JsonPropertyName("average_time_watched")]
        public double? AverageTimeWatched { get; set; }

        /// <summary>
        /// The country (when the dimension is country).
        /// </summary>
        [JsonPropertyName("country")]
        public AnalyticsCountry Country { get; set; }

        /// <summary>
        /// The type of device (when the dimension is device_type).
        /// </summary>
        [JsonPropertyName("device_type")]
        public string DeviceType { get; set; }

        /// <summary>
        /// The number of downloads of the corresponding Vimeo content.
        /// </summary>
        [JsonPropertyName("downloads")]
        public double? Downloads { get; set; }

        /// <summary>
        /// The domain name of the website (when the dimension is embed_domain).
        /// </summary>
        [JsonPropertyName("embed_domain")]
        public string EmbedDomain { get; set; }

        /// <summary>
        /// The end time of the time interval in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// The number of finishes of the corresponding Vimeo content.
        /// </summary>
        [JsonPropertyName("finishes")]
        public double? Finishes { get; set; }

        /// <summary>
        /// The number of impressions of the corresponding Vimeo content.
        /// </summary>
        [JsonPropertyName("impressions")]
        public double? Impressions { get; set; }

        /// <summary>
        /// The metadata of the result: the associated video (when the dimension is video).
        /// </summary>
        [JsonPropertyName("metadata")]
        public AnalyticsMetadata Metadata { get; set; }

        /// <summary>
        /// The start time of the time interval in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// The total time watched in seconds of the corresponding Vimeo content.
        /// </summary>
        [JsonPropertyName("total_time_watched")]
        public double? TotalTimeWatched { get; set; }

        /// <summary>
        /// The number of unique impressions of the corresponding Vimeo content.
        /// </summary>
        [JsonPropertyName("unique_impressions")]
        public double? UniqueImpressions { get; set; }

        /// <summary>
        /// The number of unique viewers of the corresponding Vimeo content.
        /// </summary>
        [JsonPropertyName("unique_viewers")]
        public double? UniqueViewers { get; set; }

        /// <summary>
        /// The number of views of the corresponding Vimeo content.
        /// </summary>
        [JsonPropertyName("views")]
        public double? Views { get; set; }
    }

    /// <summary>
    /// The country of an analytics result.
    /// </summary>
    public class AnalyticsCountry
    {
        /// <summary>
        /// The country code in ISO-3166 format.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The name of the country.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// The metadata of an analytics result.
    /// </summary>
    public class AnalyticsMetadata
    {
        /// <summary>
        /// The connections of the result.
        /// </summary>
        [JsonPropertyName("connections")]
        public AnalyticsMetadataConnections Connections { get; set; }
    }

    /// <summary>
    /// The connections of an analytics result.
    /// </summary>
    public class AnalyticsMetadataConnections
    {
        /// <summary>
        /// The associated video. This data requires a bearer token with the private scope.
        /// </summary>
        [JsonPropertyName("video")]
        public AnalyticsVideo Video { get; set; }
    }

    /// <summary>
    /// The video associated with an analytics result. This data requires a bearer token with the private scope.
    /// </summary>
    public class AnalyticsVideo
    {
        /// <summary>
        /// The time in ISO 8601 format when the video was created.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// The duration of the associated video.
        /// </summary>
        [JsonPropertyName("duration")]
        public double? Duration { get; set; }

        /// <summary>
        /// The link to the video management page.
        /// </summary>
        [JsonPropertyName("manage_link")]
        public string ManageLink { get; set; }

        /// <summary>
        /// An array of HTTP methods permitted on this URI.
        /// </summary>
        [JsonPropertyName("options")]
        public string[] Options { get; set; }

        /// <summary>
        /// The title of the associated video.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The API URI that resolves to the connection data.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}
