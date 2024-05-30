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

namespace VimeoClient.Filter.OnDemand
{
    /// <summary>
    /// The sort direction of the results.
    /// 	asc - Sort the results in ascending order.
    /// 	desc - Sort the results in descending order.
    /// </summary>
    public enum OnDemandDirection
    {
        /// <summary>
        /// Sort the results in ascending order
        /// </summary>
        asc,

        /// <summary>
        /// Sort the results in descending order
        /// </summary>
        desc
    }

    /// <summary>
    /// The type of the page to return.
    /// 	film - The page type is a film.
    /// 	series - The page type is a series.
    /// </summary>
    public enum OnDemandFilter
    {
        /// <summary>
        /// The page type is a film.
        /// </summary>
        film,

        /// <summary>
        /// The page type is a series.
        /// </summary>
        series
    }

    /// <summary>
    /// The way to sort the results.
    /// 	added - Sort the results by most recently added page.
    /// 	alphabetical - Sort the results alphabetically.
    /// 	date - Sort the results by date.
    /// 	modified_time - Sort the results by time of page modification.
    /// 	name - Sort the results by page name.
    /// 	publish.time - Sort the results by time of page publishing.
    /// 	rating - Sort the results by content rating.
    /// </summary>
    public enum OnDemandSortGetAllChannel
    {
        /// <summary>
        /// Sort the results by most recently added page.
        /// </summary>
        added,

        /// <summary>
        /// Sort the results alphabetically.
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by date.
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by time of page modification.
        /// </summary>
        modified_time,

        /// <summary>
        /// Sort the results by page name.
        /// </summary>
        name,

        /// <summary>
        /// Sort the results by time of page publishing.
        /// </summary>
        publish_time,

        /// <summary>
        /// Sort the results by content rating.
        /// </summary>
        rating,
    }
}
