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
        featured
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
}