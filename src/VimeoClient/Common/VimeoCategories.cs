using RestClient;
using RestClient.Generic;
using VimeoClient.Filter.Category;

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
        public RestResult<string> GetASpecificCategory(string category) => RootAuthorization
            .Command($"/categories/{category}")
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
        ///  </param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<string> GetAllCategories(CategoryDirection? direction = null, string sort = null, int? page = null, int? per_page = null)
        {
            var root = RootAuthorization.Command("/categories");

            if (direction.HasValue)
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

        /// <summary>
        /// This method returns every channel that belongs to the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="direction">The sort direction of the results.Option descriptions: VimeoDirection static class</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.Option descriptions: VimeoSort static class</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheChannelsInACategory(string category, string direction = null, string query = null, string sort = null, int? page = null, int? per_page = null)
        {
            var root = RootAuthorization
                .Command($"/categories/{category}/channels");

            if (!string.IsNullOrEmpty(direction))
            {
                root = root.Parameter("direction", direction);
            }
            if (!string.IsNullOrEmpty(query))
            {
                root = root.Parameter("query", query);
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

        #region [ Groups ]

        /// <summary>
        /// This method returns every group that belongs to the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="direction">The sort direction of the results.Option descriptions: VimeoDirection static class</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.Option descriptions: VimeoSort static class</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheGroupsInACategory(string category, string direction = null, string query = null, string sort = null, int? page = null, int? per_page = null)
        {
            var root = RootAuthorization
                .Command($"/categories/{category}/groups");

            if (!string.IsNullOrEmpty(direction))
            {
                root = root.Parameter("direction", direction);
            }
            if (!string.IsNullOrEmpty(query))
            {
                root = root.Parameter("query", query);
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

        #region [ Users ]

        /// <summary>
        /// This method causes the authenticated user to follow the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<string> CauseTheUserToFollowASpecificCategory(int category, int user_id) => RootAuthorization
            .Command($"/users/{user_id}/categories/{category}")
            .Put();

        /// <summary>
        /// This method causes the authenticated user to follow the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns></returns>
        public RestResult<string> CauseTheUserToFollowASpecificCategory(int category) => RootAuthorization
           .Command($"/me/categories/{category}")
           .Put();

        /// <summary>
        /// This method determines whether the authenticated user follows the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<string> CheckIfTheUserFollowsACategory(string category, int user_id) => RootAuthorization
            .Command($"/users/{user_id}/categories/{category}")
            .Get();

        /// <summary>
        /// This method determines whether the authenticated user follows the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns></returns>
        public RestResult<string> CheckIfTheUserFollowsACategory(string category) => RootAuthorization
            .Command($"/me/categories/{category}")
            .Get();

        /// <summary>
        /// This method returns every category that the authenticated user follows.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheCategoriesThatTheUserFollows(int user_id,
            CategoryDirection? direction = null,
            CategorySortFollows? sort = null,
            int? page = null,
            int? per_page = null)
        {
            var root = RootAuthorization
                .Command($"/users/{user_id}/categories");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (sort.HasValue)
            {
                root = root.Parameter("sort", sort);
            }

            if (page.HasValue)
            {
                root = root.Parameter("page", page);
            }
            if (per_page.HasValue)
            {
                root = root.Parameter("per_page", per_page);
            }

            return root.Get();
        }

        /// <summary>
        /// This method returns every category that the authenticated user follows.
        /// </summary>
        /// <returns></returns>
        public RestResult<string> GetAllTheCategoriesThatTheUserFollows(string direction = null, string sort = null, int? page = null, int? per_page = null)
        {
            var root = RootAuthorization
                .Command($"/me/categories");

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

        #region [ Videos ]

        /// <summary>
        /// This method returns a single video in the specified category. 
        /// You can use this method to determine whether the video belongs to the category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public RestResult<string> GetASpecificVideoInACategory(string category, int video_id) => RootAuthorization
            .Command($"/categories/{category}/videos/{video_id}")
            .Get();

        /// <summary>
        /// This method returns every category that contains the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheCategoriesToWhichAVideoBelongs(int video_id) => RootAuthorization
            .Command($"/videos/{video_id}/categories")
            .Get();

        /// <summary>
        /// This method returns every video that belongs to the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="direction">The sort direction of the results.Option descriptions:
        ///     asc - Sort the results in ascending order.
        ///     desc - Sort the results in descending order.</param>
        /// <param name="filter">The attribute by which to filter the results.Option descriptions:
        ///     conditional_featured - Return featured videos.
        ///     embeddable - Return embeddable videos.</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false). This parameter is required only when filter is embeddable.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheVideosInACategory(string category,
            CategoryDirection? direction = null,
            CategoryFilter? filter = null,
            bool? filter_embeddable = null,
            CategorySort? sort = null,
            int? page = null,
            int? per_page = null)
        {
            var root = RootAuthorization
                .Command($"/categories/{category}/videos");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (sort.HasValue)
            {
                root = root.Parameter("sort", direction);
            }

            if (filter.HasValue)
            {
                root = root.Parameter("filter", filter);
            }

            root = root.Parameter("filter_embeddable", (filter_embeddable ?? false).ToString());

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

        /// <summary>
        /// This method suggests up to two categories and one subcategory for the specified video. 
        /// The authenticated user must be the owner of the video. 
        /// Vimeo makes the final determination about whether the video belongs in these categories.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="category">An array of the names of the desired categories.</param>
        /// <returns></returns>
        public RestResult<string> SuggestCategoriesForAVideo(int video_id, string[] categories) => RootAuthorization
            .Command($"/videos/{video_id}/categories")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                foreach (var cat in categories)
                    pars.Add("category[]", cat);
            })
            .Put();

        #endregion


    }
}