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

namespace VimeoClient.Filter.Channel
{
    /// <summary>
    /// Description direction String  The sort direction of the results.Option descriptions:
    /// 	asc - Sort the results in ascending order.
    /// 	desc - Sort the results in descending order.
    /// </summary>
    public enum ChannelDirection
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
    /// The attribute by which to filter the results.Option descriptions:
    ///     moderated - Return moderated channels.
    /// </summary>
    public enum ChannelFilter
    {
        /// <summary>
        /// Return moderated channels
        /// </summary>
        featured,

        /// <summary>
        /// Return embeddable videos
        /// </summary>
        embeddable
    }

    /// <summary>
    /// The attribute by which to filter the results
    /// </summary>
    public enum ChannelFollowersOfAChannelFilter
    {
        /// <summary>
        /// Return moderators
        /// </summary>
        moderators
    }

    /// <summary>
    /// The way to sort the results
    /// </summary>
    public enum ChannelSortGetAllChannel
    {
        /// <summary>
        /// Sort the results alphabetically
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the resutls by creation date
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by number of followers
        /// </summary>
        followers,

        /// <summary>
        /// Sort the results by relevance.This option is available for search queries only
        /// </summary>
        relevant,

        /// <summary>
        /// Sort the results by number of videos
        /// </summary>
        videos,

    }

    /// <summary>
    /// The way to sort the results
    /// </summary>
    public enum ChannelSortGetAllVideos
    {
        /// <summary>
        /// Sort the results alphabetically
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by number of comments
        /// </summary>
        comments,

        /// <summary>
        /// Sort the results by creation date
        /// </summary>
        date,

        /// <summary>
        /// Use the default sorting method.
        /// </summary>
        default_,

        /// <summary>
        /// Sort the results by duration.
        /// </summary>
        duration,

        /// <summary>
        /// Sort the results by number of likes.
        /// </summary>
        likes,

        /// <summary>
        /// Sort the results as the user has arranged them.
        /// </summary>
        manual,

        /// <summary>
        /// Sort the results by last modification.
        /// </summary>
        modified_time,

        /// <summary>
        /// Sort the results by number of plays.
        /// </summary>
        plays,
    }

    /// <summary>
    /// The way to sort the results.Option descriptions:
    /// 	alphabetical - Sort the results alphabetically.
    /// 	date - Sort the results by creation date.
    /// 	followers - Sort the results by number of followers.
    /// 	videos - Sort the results by number of videos.
    /// </summary>
    public enum ChannelSortGetAllChannelSubscribe
    {
        /// <summary>
        /// alphabetical - Sort the results alphabetically
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by creation date
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by number of followers
        /// </summary>
        followers,

        /// <summary>
        /// Sort the results by number of videos
        /// </summary>
        videos
    }

    /// <summary>
    /// The way to sort the results.Option descriptions:
    /// 	alphabetical - Sort the results alphabetically.
    /// 	date - Sort the results by creation date.
    /// </summary>
    public enum ChannelSortAllModerators
    {
        /// <summary>
        /// alphabetical - Sort the results alphabetically
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by creation date
        /// </summary>
        date
    }
}