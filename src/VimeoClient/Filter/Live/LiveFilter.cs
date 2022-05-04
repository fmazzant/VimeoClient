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

namespace VimeoClient.Filter.Live
{
    /// <summary>
    /// The sort direction of the results.
    /// </summary>
    public enum LiveDirection
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
    /// The attribute by which to filter the results.
    /// </summary>
    public enum LiveFilter
    {
        /// <summary>
        /// Show only events without any folder.
        /// </summary>
        not_in_folder
    }

    /// <summary>
    /// The way to sort the results
    /// </summary>
    public enum LiveSort
    {
        /// <summary>
        /// Sort the results alphabetically
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by creation date.
        /// </summary>
        date
    }

    /// <summary>
    /// The type of event to return.
    /// </summary>
    public enum LiveType
    {
        /// <summary>
        /// Return all events.
        /// </summary>
        all,

        /// <summary>
        /// Return one-time events only.
        /// </summary>
        one_time,

        /// <summary>
        /// Return recurring events only.
        /// </summary>
        recurring
    }
}
