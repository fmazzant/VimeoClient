using RestClient;
using RestClient.Generic;

namespace VimeoClient.Common
{
    /// <summary>
    /// Categories on Vimeo are sets of videos for particular genres (like comedy) or other characteristics (like being experimental). 
    /// All the videos in these sets have been hand-chosen by Vimeo staff, 
    /// but you can bring your videos to our attention by recommending them for up to two main categories and one subcategory. 
    /// See our Help Center for more details.
    /// </summary>
    public class VimeoCategories
    {
        /// <summary>
        /// Vimeo Properties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// Root Authorization
        /// </summary>
        public RestBuilder RootAuthorization { get; private set; }

        public RestBuilder RootAuthorizationCategories() => RootAuthorization
            .Command("/categories");

        /// <summary>
        /// Create a new instance of VimeoCategories class
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="rootAuthorization"></param>
        public VimeoCategories(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essentials ]

        /// <summary>
        /// This method returns the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns></returns>
        public RestResult<string> GetASpecificCategory(string category) => RootAuthorizationCategories()
            .Command(category)
            .Get();

        /// <summary>
        /// This method returns every available category.
        /// </summary>
        /// <param name="direction">The sort direction of the results.Option descriptions:
        ///     asc - Sort the results in ascending order.
        ///     desc - Sort the results in descending order.</param>
        /// <param name="sort">The way to sort the results.
        ///     last_video_featured_time
        ///     name
        ///    Use: VimeoCategory.VimeoCategorySort
        ///  </param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<string> GetAllCategories(string direction = null, string sort = null, int? page = null, int? per_page = null)
        {
            var root = RootAuthorizationCategories();

            if (!string.IsNullOrEmpty(direction))
            {
                root = root.Parameter("direction", direction);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                root = root.Parameter("sort", direction);
            }

            if (page > 0)
            {
                root = root.Parameter("page", page);
            }
            if (per_page > 0)
            {
                root = root.Parameter("per_page", per_page);
            }

            return root.Get();
        }

        #endregion

        #region [ Channels ]

        #endregion

        #region [ Groups ]

        #endregion

        #region [ Users ]

        #endregion

        #region [ Videos ]

        #endregion

        /// <summary>
        /// The way to sort the results
        /// </summary>
        public static class VimeoCategorySort
        {
            public const string last_video_featured_time = "last_video_featured_time";
            public const string name = "name";

        }
    }
}