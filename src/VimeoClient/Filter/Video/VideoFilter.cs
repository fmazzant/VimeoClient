﻿/// <summary>
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

namespace VimeoClient.Filter.Video
{
    /// <summary>
    /// The sort direction of the results
    /// </summary>
    public enum VideoDirection
    {
        /// <summary>
        /// Sort the results in ascending order.
        /// </summary>
        asc,

        /// <summary>
        /// Sort the results in descending order.
        /// </summary>
        desc,
    }

    /// <summary>
    /// The attribute by which to filter the results
    /// </summary>
    public enum VideoFilter
    {
        /// <summary>
        /// Return embeddable video
        /// </summary>
        embeddable
    }

    /// <summary>
    /// The way to sort the results
    /// </summary>
    public enum VideoSort
    {
        /// <summary>
        /// Sort the results alphabetically.
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by number of comments.
        /// </summary>
        comments,

        /// <summary>
        ///Sort the results by creation date.
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by duration.
        /// </summary>
        duration,

        /// <summary>
        /// Sort the results by number of likes.
        /// </summary>
        likes,

        /// <summary>
        /// Sort the results by number of plays.
        /// </summary>
        plays
    }
}
