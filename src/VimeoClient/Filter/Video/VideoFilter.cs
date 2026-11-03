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
        /// Return videos uploaded by the current app.
        /// </summary>
        app_only,

        /// <summary>
        /// Return embeddable video
        /// </summary>
        embeddable,

        /// <summary>
        /// Return featured videos.
        /// </summary>
        featured,

        /// <summary>
        /// Return live videos.
        /// </summary>
        live,

        /// <summary>
        /// Return videos that aren't live.
        /// </summary>
        no_live,

        /// <summary>
        /// Return playable videos.
        /// </summary>
        playable,

        /// <summary>
        /// Return screen recorded videos.
        /// </summary>
        screen_recorded,
    }

    /// <summary>
    /// The attribute by which to filter the results of a video search.
    /// </summary>
    public enum VideoSearchFilter
    {
        /// <summary>
        /// Return videos under a Creative Commons license.
        /// </summary>
        CC,

        /// <summary>
        /// Return videos by category.
        /// </summary>
        categories,

        /// <summary>
        /// Return videos by duration.
        /// </summary>
        duration,

        /// <summary>
        /// Return videos by number of likes.
        /// </summary>
        minimum_likes,

        /// <summary>
        /// Return trending videos.
        /// </summary>
        trending,

        /// <summary>
        /// Return videos by upload date.
        /// </summary>
        upload_date,
    }

    /// <summary>
    /// The attribute by which to filter the related videos.
    /// </summary>
    public enum VideoRelatedFilter
    {
        /// <summary>
        /// Return related videos.
        /// </summary>
        related
    }

    /// <summary>
    /// The way to sort the credits.
    /// </summary>
    public enum VideoCreditSort
    {
        /// <summary>
        /// Sort the results by date.
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by name.
        /// </summary>
        name,
    }

    /// <summary>
    /// The attribute by which to filter the languages.
    /// </summary>
    public enum LanguageFilter
    {
        /// <summary>
        /// Return languages that can be used for text tracks.
        /// </summary>
        texttracks
    }

    /// <summary>
    /// The way to sort the videos with a tag.
    /// </summary>
    public enum VideoTagSort
    {
        /// <summary>
        /// Sort the results by created time.
        /// </summary>
        created_time,

        /// <summary>
        /// Sort the results by duration.
        /// </summary>
        duration,

        /// <summary>
        /// Sort the results by name.
        /// </summary>
        name,
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
        plays,

        /// <summary>
        /// Use the default sort order.
        /// </summary>
        @default,

        /// <summary>
        /// Sort the results by the date of the last user action.
        /// </summary>
        last_user_action_event_date,

        /// <summary>
        /// Sort the results by time of modification.
        /// </summary>
        modified_time,

        /// <summary>
        /// Sort the results by relevance (search only).
        /// </summary>
        relevant,
    }
}
