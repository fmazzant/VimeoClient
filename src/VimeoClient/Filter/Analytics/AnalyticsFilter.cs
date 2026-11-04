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

namespace Mafesoft.VimeoClient.Filter.Analytics
{
    /// <summary>
    /// The data dimension by which to group the analytics results.
    /// </summary>
    public enum AnalyticsDimension
    {
        /// <summary>
        /// Group the results by country.
        /// </summary>
        country,

        /// <summary>
        /// Group the results by device type.
        /// </summary>
        device_type,

        /// <summary>
        /// Group the results by embed domain.
        /// </summary>
        embed_domain,

        /// <summary>
        /// Group the results by the time range provided.
        /// </summary>
        total,

        /// <summary>
        /// Group the results by video.
        /// </summary>
        video
    }

    /// <summary>
    /// The sort direction of the analytics results.
    /// </summary>
    public enum AnalyticsDirection
    {
        /// <summary>
        /// Sort the results in ascending order.
        /// </summary>
        asc,

        /// <summary>
        /// Sort the results in descending order.
        /// </summary>
        desc
    }

    /// <summary>
    /// The way to sort the analytics results.
    /// </summary>
    public enum AnalyticsSort
    {
        /// <summary>
        /// Sort the results by mean percentage played.
        /// </summary>
        average_percent_watched,

        /// <summary>
        /// Sort the results by mean seconds played.
        /// </summary>
        average_time_watched,

        /// <summary>
        /// Sort the results by the number of comments.
        /// </summary>
        comments,

        /// <summary>
        /// Sort the results by country.
        /// </summary>
        country,

        /// <summary>
        /// Sort the results by the values of both the dimension and time_interval fields.
        /// </summary>
        @default,

        /// <summary>
        /// Sort the results by device type.
        /// </summary>
        device_type,

        /// <summary>
        /// Sort the results by the number of downloads.
        /// </summary>
        downloads,

        /// <summary>
        /// Sort the results by embed domain.
        /// </summary>
        embed_domain,

        /// <summary>
        /// Sort the results by the number of complete plays.
        /// </summary>
        finishes,

        /// <summary>
        /// Sort the results by the number of impressions.
        /// </summary>
        impressions,

        /// <summary>
        /// Sort the results by the number of likes.
        /// </summary>
        like,

        /// <summary>
        /// Sort the results by the value of the start_date field. Available only when time_interval is not none.
        /// </summary>
        time,

        /// <summary>
        /// Sort the results by total seconds played.
        /// </summary>
        total_time_watched,

        /// <summary>
        /// Sort the results by unique impressions.
        /// </summary>
        unique_impressions,

        /// <summary>
        /// Sort the results by unique viewers.
        /// </summary>
        unique_viewers,

        /// <summary>
        /// Sort the results by video ID.
        /// </summary>
        video,

        /// <summary>
        /// Sort the results by the number of views.
        /// </summary>
        views
    }

    /// <summary>
    /// The interval by which to aggregate the analytics data. The default value is none.
    /// </summary>
    public enum AnalyticsTimeInterval
    {
        /// <summary>
        /// Aggregate the results by day.
        /// </summary>
        day,

        /// <summary>
        /// Aggregate the results by month.
        /// </summary>
        month,

        /// <summary>
        /// The results are not aggregated by time interval.
        /// </summary>
        none,

        /// <summary>
        /// Aggregate the results by week.
        /// </summary>
        week,

        /// <summary>
        /// Aggregate the results by year.
        /// </summary>
        year
    }
}
