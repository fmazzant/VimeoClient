namespace VimeoClient
{
    /// <summary>
    /// The way to sort the results.Option descriptions:
    ///     alphabetical - Sort the results alphabetically.
    ///     date - Sort the results by creation date.
    ///     followers - Sort the results by number of followers.
    ///     relevant - Sort the results by relevance.
    ///     videos - Sort the results by number of videos.
    /// </summary>
    public static class VimeoSort
    {
        public const string ALPHABETICAL = "alphabetical";// - Sort the results alphabetically.
        public const string DATE = "date";// - Sort the results by creation date.
        public const string FOLLOWERS = "followers";// - Sort the results by number of followers.
        public const string RELEVANT = "relevant";// - Sort the results by relevance.
        public const string VIDEOS = "videos";// - Sort the results by number of videos.
    }
}