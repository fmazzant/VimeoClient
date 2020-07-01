namespace VimeoClient
{
    /// <summary>
    /// 
    /// </summary>
    public static class VimeoScope
    {
        public const string PUBLIC = "public";//* Access public member data.
        public const string PRIVATE = "private";//†	Access private member data.
        public const string PURCHASED = "purchased";//   Access a member's Vimeo On Demand purchase history.
        public const string CREATE = "create";// Create new Vimeo resources like showcases, groups, channels, and portfolios.To create new videos, you need the upload scope.
        public const string EDIT = "edit";// Edit existing Vimeo resources, including videos.
        public const string DELETE = "delete";//  Delete existing Vimeo resources, including videos.
        public const string INTERACT = "interact";// Interact with Vimeo resources, such as liking a video or following a member.
        public const string PUBUPLOAD = "upload";// Upload videos.
        public const string PROMO_CODES = "promo_codes";// Add, remove, and review Vimeo On Demand promotions.
        public const string VIDEO_FILES = "video_files";// Access video files belonging to members with Vimeo Pro membership or higher.
    }

    public static class VimeoDirection
    {
        public const string ASC = "asc";//asc - Sort the results in ascending order.
        public const string DESC = "desc";//desc - Sort the results in descending order.
    }

    public static class VimeoSort
    {
        public const string ALPHABETICAL = "alphabetical";// - Sort the results alphabetically.
        public const string DATE = "date";// - Sort the results by creation date.
        public const string FOLLOWERS = "followers";// - Sort the results by number of followers.
        public const string RELEVANT = "relevant";// - Sort the results by relevance.
        public const string VIDEOS = "videos";// - Sort the results by number of videos.
    }
}