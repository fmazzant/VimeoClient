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

namespace VimeoClient.Common
{
    using RestClient;
    using RestClient.Generic;
    using VimeoClient.Filter.Category;
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// Categories on Vimeo are sets of videos for particular genres (like comedy) or other characteristics (like being experimental). 
    /// All the videos in these sets have been hand-chosen by Vimeo staff, 
    /// but you can bring your videos to our attention by recommending them for up to two main categories and one subcategory. 
    /// See our Help Center for more details.
    /// https://developer.vimeo.com/api/reference/categories
    /// </summary>
    public class VimeoCategories
    {
        /// <summary>
        /// Vimeo Properties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// Vimeo
        /// </summary>
        public Vimeo Vimeo { get; private set; }

        /// <summary>
        /// Root Authorization
        /// </summary>
        public RestBuilder RootAuthorization() => Vimeo.RootAuthorization();

        /// <summary>
        /// Create a new instance of VimeoCategories class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoCategories(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance of VimeoCategories class
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoCategories(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]

        /// <summary>
        /// This method returns the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns>
        /// 200 OK	The category was returned.
        /// 404 Not Found   No such category exists.
        /// </returns>
        public RestResult<Category> GetASpecificCategory(string category) => RootAuthorization()
            .Command($"/categories/{category}")
            .Get<Category>();

        /// <summary>
        /// This method returns every available category.
        /// </summary>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="sort">The way to sort the results.
        ///     last_video_featured_time
        ///     name
        ///  </param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<Pagination<Category>> GetAllCategories(CategoryDirection? direction = null,
            CategorySortAllCategory? sort = null,
            int? page = null,
            int? per_page = null)
        {
            var root = RootAuthorization().Command("/categories");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (sort.HasValue)
            {
                root = root.Parameter("sort", direction);
            }

            if (page.HasValue)
            {
                root = root.Parameter("page", page);
            }
            if (per_page.HasValue)
            {
                root = root.Parameter("per_page", per_page);
            }

            var result = root.Get<Pagination<Category>>();

            if (result?.Content?.Paging != null && result?.Content?.Paging.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Category>>();
            }

            if (result?.Content?.Paging != null && result?.Content?.Paging.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Category>>();
            }
            return result;
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
        /// <returns>
        /// 200 OK	        The channels were returned.
        /// 404 Not Found   No such category exists.
        /// </returns>
        public RestResult<Pagination<Channel>> GetAllTheChannelsInACategory(string category,
            CategoryDirection? direction = null,
            string query = null,
            CategorySortAllChannel? sort = null,
            int? page = null,
            int? per_page = null)
        {
            var root = RootAuthorization()
                .Command($"/categories/{category}/channels");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (!string.IsNullOrEmpty(query))
            {
                root = root.Parameter("query", query);
            }
            if (sort.HasValue)
            {
                root = root.Parameter("sort", direction);
            }

            if (page.HasValue)
            {
                root = root.Parameter("page", page);
            }
            if (per_page.HasValue)
            {
                root = root.Parameter("per_page", per_page);
            }

            var result = root.Get<Pagination<Channel>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Channel>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Channel>>();
            }

            return result;
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
        public RestResult<Pagination<Group>> GetAllTheGroupsInACategory(string category,
            CategoryDirection? direction = null,
            string query = null,
            CategorySortAllGroup? sort = null,
            int? page = null,
            int? per_page = null)
        {
            var root = RootAuthorization()
                .Command($"/categories/{category}/groups");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (!string.IsNullOrEmpty(query))
            {
                root = root.Parameter("query", query);
            }
            if (sort.HasValue)
            {
                root = root.Parameter("sort", direction);
            }

            if (page.HasValue)
            {
                root = root.Parameter("page", page);
            }
            if (per_page.HasValue)
            {
                root = root.Parameter("per_page", per_page);
            }

            var result = root.Get<Pagination<Group>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Group>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Group>>();
            }

            return result;
        }

        #endregion

        #region [ Users ]

        /// <summary>
        /// This method causes the authenticated user to follow the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 204 No Content	The user is following the category.
        /// </returns>
        public RestResult CauseTheUserToFollowASpecificCategory(int category, int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/categories/{category}")
            .Put();

        /// <summary>
        /// This method causes the authenticated user to follow the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns></returns>
        public RestResult CauseTheUserToFollowASpecificCategory(int category) => RootAuthorization()
           .Command($"/me/categories/{category}")
           .Put();

        /// <summary>
        /// This method causes the authenticated user to stop following the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 204 No Content	The user has stopped following the category.
        /// </returns>
        public RestResult CauseTheUserToStopFollowingACategory(int category, int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/categories/{category}")
            .Delete();

        /// <summary>
        /// This method causes the authenticated user to stop following the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns>
        /// 204 No Content	The user has stopped following the category.
        /// </returns>
        public RestResult CauseTheUserToStopFollowingACategory(int category) => RootAuthorization()
           .Command($"/me/categories/{category}")
           .Delete();

        /// <summary>
        /// This method determines whether the authenticated user follows the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 204 No Content	The user is following the category.
        /// </returns>
        public RestResult CheckIfTheUserFollowsACategory(string category, int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/categories/{category}")
            .Get();

        /// <summary>
        /// This method determines whether the authenticated user follows the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns>
        /// 204 No Content	The user is following the category.
        /// </returns>
        public RestResult CheckIfTheUserFollowsACategory(string category) => RootAuthorization()
            .Command($"/me/categories/{category}")
            .Get();

        /// <summary>
        /// This method returns every category that the authenticated user follows.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 200 OK	The categories were returned.
        /// 403 Forbidden Error code 3200: Only the authenticated user can access this information.
        /// </returns>
        public RestResult<Pagination<Category>> GetAllTheCategoriesThatTheUserFollows(int user_id,
            CategoryDirection? direction = null,
            CategorySortFollows? sort = null,
            int? page = null,
            int? per_page = null)
        {
            var root = RootAuthorization()
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

            var result = root.Get<Pagination<Category>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Category>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Category>>();
            }

            return result;
        }

        /// <summary>
        /// This method returns every category that the authenticated user follows.
        /// </summary>
        /// <returns></returns>
        public RestResult<Pagination<Category>> GetAllTheCategoriesThatTheUserFollows(CategoryDirection? direction = null,
            CategorySortFollows? sort = null,
            int? page = null,
            int? per_page = null)
        {
            var root = RootAuthorization()
                .Command($"/me/categories");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (sort.HasValue)
            {
                root = root.Parameter("sort", direction);
            }

            if (page.HasValue)
            {
                root = root.Parameter("page", page);
            }
            if (per_page.HasValue)
            {
                root = root.Parameter("per_page", per_page);
            }

            var result = root.Get<Pagination<Category>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Category>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Category>>();
            }

            return result;
        }
        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method returns a single video in the specified category. 
        /// You can use this method to determine whether the video belongs to the category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The video was returned.
        /// 404 Not Found   No such category exists, or the video doesn't belong to it.
        /// </returns>
        public RestResult<Video> GetASpecificVideoInACategory(string category, int video_id) => RootAuthorization()
            .Command($"/categories/{category}/videos/{video_id}")
            .Get<Video>();

        /// <summary>
        /// This method returns every category that contains the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public RestResult<VimeoList<Category>> GetAllTheCategoriesToWhichAVideoBelongs(int video_id) => RootAuthorization()
            .Command($"/videos/{video_id}/categories")
            .Get<VimeoList<Category>>();

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
        public RestResult<Pagination<Video>> GetAllTheVideosInACategory(string category,
            CategoryDirection? direction = null,
            CategoryFilter? filter = null,
            bool? filter_embeddable = null,
            CategorySort? sort = null,
            int? page = null,
            int? per_page = null)
        {
            var root = RootAuthorization()
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

            var result = root.Get<Pagination<Video>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Video>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Video>>();
            }

            return result;
        }

        /// <summary>
        /// This method suggests up to two categories and one subcategory for the specified video. 
        /// The authenticated user must be the owner of the video. 
        /// Vimeo makes the final determination about whether the video belongs in these categories.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="category">An array of the names of the desired categories.</param>
        /// <returns>
        /// 201 Created	The categories were suggested.
        /// 403 Forbidden The authenticated user doesn't own this video.
        /// 404 Not Found   No such video exists, or no such category exists.
        /// </returns>
        public RestResult<Category> SuggestCategoriesForAVideo(int video_id, string[] categories) => RootAuthorization()
            .Command($"/videos/{video_id}/categories")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                foreach (var cat in categories)
                {
                    pars.Add("category[]", cat);
                }
            })
            .Put<Category>();

        #endregion
    }
}