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

namespace Mafesoft.VimeoClient.Common
{
    using RestClient;
    using System;
    using System.Globalization;
    using Mafesoft.VimeoClient.Filter.Analytics;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;

    /// <summary>
    /// Analytics: the metrics (views, impressions, finishes, time watched...) of the user's content.
    /// The Analytics API requires an Enterprise plan and must be enabled for the API app by Vimeo support.
    /// https://developer.vimeo.com/api/reference/users#analytics
    /// </summary>
    public class VimeoAnalytics
    {
        /// <summary>
        /// Vimeo Properties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// Vimeo
        /// </summary>
        public Vimeo Vimeo { get; private set; }

        /// <summary>
        /// Root Authorization
        /// </summary>
        public RestBuilder RootAuthorization() => Vimeo.RootAuthorization();

        /// <summary>
        /// Create a new instance of VimeoAnalytics class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoAnalytics(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoAnalytics(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Analytics ]

        /// <summary>
        /// This method returns analytic metrics for the authenticated user.
        /// GET https://api.vimeo.com/me/analytics
        /// </summary>
        /// <param name="dimension">The data dimension by which to group the results.</param>
        /// <param name="from">The start date of the range of results (sent in ISO 8601 format).</param>
        /// <param name="to">The end date of the range of results (sent in ISO 8601 format).</param>
        /// <param name="time_interval">The interval by which to aggregate the data. The default value is none.</param>
        /// <param name="filter_content">The video, folder, or event URIs to filter on.</param>
        /// <param name="filter_countries">The country codes in ISO-3166 format to filter on.</param>
        /// <param name="filter_device_types">The device types to filter on.</param>
        /// <param name="filter_embed_domains">The domain names to filter on.</param>
        /// <param name="filter_streaming_types">The streaming types to filter on.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The maximum number of items returned, up to a limit of 1000. The default value is 50.</param>
        /// <returns>
        /// 200 OK	The analytics were returned.
        /// </returns>
        public virtual RestResult<Pagination<Analytics>> GetAnalyticsForTheAuthenticatedUser(
            AnalyticsDimension dimension,
            DateTime from,
            DateTime to,
            AnalyticsTimeInterval? time_interval = null,
            string[] filter_content = null,
            string[] filter_countries = null,
            string[] filter_device_types = null,
            string[] filter_embed_domains = null,
            string[] filter_streaming_types = null,
            AnalyticsDirection? direction = null,
            AnalyticsSort? sort = null,
            int? page = null,
            int? per_page = null) => AnalyticsParameters(RootAuthorization().Command("/me/analytics"),
                dimension, from, to, time_interval,
                filter_content, filter_countries, filter_device_types, filter_embed_domains, filter_streaming_types,
                direction, sort, page, per_page)
            .GetPagination<Analytics>(RootAuthorization);

        /// <summary>
        /// This method returns analytic metrics for the specified user.
        /// GET https://api.vimeo.com/users/{user_id}/analytics
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="dimension">The data dimension by which to group the results.</param>
        /// <param name="from">The start date of the range of results (sent in ISO 8601 format).</param>
        /// <param name="to">The end date of the range of results (sent in ISO 8601 format).</param>
        /// <param name="time_interval">The interval by which to aggregate the data. The default value is none.</param>
        /// <param name="filter_content">The video, folder, or event URIs to filter on.</param>
        /// <param name="filter_countries">The country codes in ISO-3166 format to filter on.</param>
        /// <param name="filter_device_types">The device types to filter on.</param>
        /// <param name="filter_embed_domains">The domain names to filter on.</param>
        /// <param name="filter_streaming_types">The streaming types to filter on.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The maximum number of items returned, up to a limit of 1000. The default value is 50.</param>
        /// <returns>
        /// 200 OK	The analytics were returned.
        /// </returns>
        public virtual RestResult<Pagination<Analytics>> GetAnalyticsForAUser(
            string user_id,
            AnalyticsDimension dimension,
            DateTime from,
            DateTime to,
            AnalyticsTimeInterval? time_interval = null,
            string[] filter_content = null,
            string[] filter_countries = null,
            string[] filter_device_types = null,
            string[] filter_embed_domains = null,
            string[] filter_streaming_types = null,
            AnalyticsDirection? direction = null,
            AnalyticsSort? sort = null,
            int? page = null,
            int? per_page = null) => AnalyticsParameters(RootAuthorization().Command($"/users/{user_id}/analytics"),
                dimension, from, to, time_interval,
                filter_content, filter_countries, filter_device_types, filter_embed_domains, filter_streaming_types,
                direction, sort, page, per_page)
            .GetPagination<Analytics>(RootAuthorization);

        #endregion

        /// <summary>
        /// Adds the analytics query parameters.
        /// </summary>
        protected virtual RestBuilder AnalyticsParameters(RestBuilder root,
            AnalyticsDimension dimension,
            DateTime from,
            DateTime to,
            AnalyticsTimeInterval? time_interval,
            string[] filter_content,
            string[] filter_countries,
            string[] filter_device_types,
            string[] filter_embed_domains,
            string[] filter_streaming_types,
            AnalyticsDirection? direction,
            AnalyticsSort? sort,
            int? page,
            int? per_page) => root
            .OptionalParameter("dimension", dimension)
            .OptionalParameter("from", ToIso8601(from))
            .OptionalParameter("to", ToIso8601(to))
            .OptionalParameter("time_interval", time_interval)
            .OptionalParameter("filter_content", filter_content)
            .OptionalParameter("filter_countries", filter_countries)
            .OptionalParameter("filter_device_types", filter_device_types)
            .OptionalParameter("filter_embed_domains", filter_embed_domains)
            .OptionalParameter("filter_streaming_types", filter_streaming_types)
            .ListParameters(direction, null, page, per_page, null, sort);

        /// <summary>
        /// Converts a date to the ISO 8601 format: yyyy-MM-ddTHH:mm:ss plus the UTC offset when the kind is known.
        /// </summary>
        private static string ToIso8601(DateTime date)
            => date.ToString("yyyy-MM-dd'T'HH:mm:ssK", CultureInfo.InvariantCulture);
    }
}
