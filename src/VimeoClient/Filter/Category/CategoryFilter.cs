namespace VimeoClient.Filter.Category
{
    /// <summary>
    /// Description direction String  The sort direction of the results.Option descriptions:
    /// 	asc - Sort the results in ascending order.
    /// 	desc - Sort the results in descending order.
    /// </summary>
    public enum CategoryDirection
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
    /// The way to sort the results
    /// </summary>
    public enum CategorySort
    {
        /// <summary>
        /// Sort the results alphabetically.
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by number of comments
        /// </summary>
        comments,

        /// <summary>
        /// Sort the results by date
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by duration
        /// </summary>
        duration,

        /// <summary>
        /// Sort the results by featured status
        /// </summary>
        featured,

        /// <summary>
        /// Sort the results by number of likes
        /// </summary>
        likes,

        /// <summary>
        /// Sort the results by number of plays
        /// </summary>
        plays,

        /// <summary>
        /// Sort the results by relevance
        /// </summary>
        relevant,
    }

    /// <summary>
    /// The way to sort the results
    /// </summary>
    public enum CategorySortFollows
    {
        /// <summary>
        /// Sort the results alphabetically
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by date
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by name
        /// </summary>
        name
    }

    /// <summary>
    /// The way to sort the results
    /// </summary>
    public enum CategorySortAllCategory
    {
        /// <summary>
        /// 
        /// </summary>
        last_video_featured_time,

        /// <summary>
        /// 
        /// </summary>
        name
    }

    /// <summary>
    /// The way to sort the results
    /// </summary>
    public enum CategorySortAllChannel
    {
        /// <summary>
        /// Sort the results alphabetically
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by date
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
    /// The way to sort the results
    /// </summary>
    public enum CategorySortAllGroup
    {
        /// <summary>
        /// Sort the results alphabetically
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by date
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by number of members
        /// </summary>
        members,

        /// <summary>
        /// Sort the results by number of videos
        /// </summary>
        videos
    }

    /// <summary>
    /// The attribute by which to filter the results
    /// </summary>
    public enum CategoryFilter
    {
        /// <summary>
        /// Return featured videos
        /// </summary>
        conditional_featured,

        /// <summary>
        /// Return embeddable videos
        /// </summary>
        embeddable,
    }
}
