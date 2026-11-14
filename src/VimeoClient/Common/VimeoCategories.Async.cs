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

namespace Mafesoft.VimeoClient.Common
{
    using Mafesoft.RestClient;
    using System.Globalization;
    using Mafesoft.VimeoClient.Filter.Category;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoCategories.
    public partial class VimeoCategories
    {
        #region [ Essentials ]

        /// <summary>
        /// This method returns the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The category was returned.
        /// 404 Not Found   No such category exists.
        /// </returns>
        public virtual Task<RestResult<Category>> GetASpecificCategoryAsync(string category, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/categories/{category}")
            .GetAsync<Category>(cancellationToken);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<Category>>> GetAllCategoriesAsync(CategoryDirection? direction = null,
            CategorySortAllCategory? sort = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization().Command("/categories");

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

            var result = await root.GetAsync<Pagination<Category>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	        The channels were returned.
        /// 404 Not Found   No such category exists.
        /// </returns>
        public virtual async Task<RestResult<Pagination<Channel>>> GetAllTheChannelsInACategoryAsync(string category,
            CategoryDirection? direction = null,
            string query = null,
            CategorySortAllChannel? sort = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default)
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

            var result = await root.GetAsync<Pagination<Channel>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<Group>>> GetAllTheGroupsInACategoryAsync(string category,
            CategoryDirection? direction = null,
            string query = null,
            CategorySortAllGroup? sort = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default)
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

            var result = await root.GetAsync<Pagination<Group>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        #endregion

        #region [ Users ]

        /// <summary>
        /// This method causes the authenticated user to follow the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user is following the category.
        /// </returns>
        public virtual Task<RestResult<string>> CauseTheUserToFollowASpecificCategoryAsync(int category, string user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/categories/{category}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method causes the authenticated user to follow the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> CauseTheUserToFollowASpecificCategoryAsync(string category, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/me/categories/{category}")
           .PutAsync(cancellationToken);

        /// <summary>
        /// This method causes the authenticated user to stop following the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user has stopped following the category.
        /// </returns>
        public virtual Task<RestResult<string>> CauseTheUserToStopFollowingACategoryAsync(string category, string user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/categories/{category}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method causes the authenticated user to stop following the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user has stopped following the category.
        /// </returns>
        public virtual Task<RestResult<string>> CauseTheUserToStopFollowingACategoryAsync(string category, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/me/categories/{category}")
           .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method determines whether the authenticated user follows the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user is following the category.
        /// </returns>
        public virtual Task<RestResult<string>> CheckIfTheUserFollowsACategoryAsync(string category, string user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/categories/{category}")
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method determines whether the authenticated user follows the specified category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user is following the category.
        /// </returns>
        public virtual Task<RestResult<string>> CheckIfTheUserFollowsACategoryAsync(string category, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/categories/{category}")
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method returns every category that the authenticated user follows.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The categories were returned.
        /// 403 Forbidden Error code 3200: Only the authenticated user can access this information.
        /// </returns>
        public virtual async Task<RestResult<Pagination<Category>>> GetAllTheCategoriesThatTheUserFollowsAsync(string user_id,
            CategoryDirection? direction = null,
            CategorySortFollows? sort = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default)
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

            var result = await root.GetAsync<Pagination<Category>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method returns every category that the authenticated user follows.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<Category>>> GetAllTheCategoriesThatTheUserFollowsAsync(CategoryDirection? direction = null,
            CategorySortFollows? sort = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/me/categories");

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

            var result = await root.GetAsync<Pagination<Category>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method returns a single video in the specified category. 
        /// You can use this method to determine whether the video belongs to the category.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The video was returned.
        /// 404 Not Found   No such category exists, or the video doesn't belong to it.
        /// </returns>
        public virtual Task<RestResult<Video>> GetASpecificVideoInACategoryAsync(string category, string video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/categories/{category}/videos/{video_id}")
            .GetAsync<Video>(cancellationToken);

        /// <summary>
        /// This method returns every category that contains the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Category>>> GetAllTheCategoriesToWhichAVideoBelongsAsync(string video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/videos/{video_id}/categories")
            .GetAsync<VimeoList<Category>>(cancellationToken);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// 404 Not Found   No such category exists.
        /// </returns>
        public virtual async Task<RestResult<Pagination<Video>>> GetAllTheVideosInACategoryAsync(string category,
            CategoryDirection? direction = null,
            CategoryFilter? filter = null,
            bool? filter_embeddable = null,
            CategorySort? sort = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/categories/{category}/videos");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (sort.HasValue)
            {
                root = root.Parameter("sort", sort);
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

            var result = await root.GetAsync<Pagination<Video>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method suggests up to two categories and one subcategory for the specified video. 
        /// The authenticated user must be the owner of the video. 
        /// Vimeo makes the final determination about whether the video belongs in these categories.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="categories">An array of the names of the desired categories.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The categories were suggested.
        /// 403 Forbidden The authenticated user doesn't own this video.
        /// 404 Not Found   No such video exists, or no such category exists.
        /// </returns>
        public virtual Task<RestResult<Category>> SuggestCategoriesForAVideoAsync(string video_id, string[] categories, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/videos/{video_id}/categories")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                foreach (var cat in categories)
                {
                    pars.Add("category[]", cat);
                }
            })
            .PutAsync<Category>(cancellationToken);

        #endregion

        #region [ Overloads with int video_id ]

        /// <inheritdoc cref="GetASpecificVideoInACategory(string, string)"/>
        public virtual Task<RestResult<Video>> GetASpecificVideoInACategoryAsync(string category, int video_id, CancellationToken cancellationToken = default)
            => GetASpecificVideoInACategoryAsync(category, video_id.ToString(CultureInfo.InvariantCulture), cancellationToken: cancellationToken);

        /// <inheritdoc cref="GetAllTheCategoriesToWhichAVideoBelongs(string)"/>
        public virtual Task<RestResult<VimeoList<Category>>> GetAllTheCategoriesToWhichAVideoBelongsAsync(int video_id, CancellationToken cancellationToken = default)
            => GetAllTheCategoriesToWhichAVideoBelongsAsync(video_id.ToString(CultureInfo.InvariantCulture), cancellationToken: cancellationToken);

        /// <inheritdoc cref="SuggestCategoriesForAVideo(string, string[])"/>
        public virtual Task<RestResult<Category>> SuggestCategoriesForAVideoAsync(int video_id, string[] categories, CancellationToken cancellationToken = default)
            => SuggestCategoriesForAVideoAsync(video_id.ToString(CultureInfo.InvariantCulture), categories, cancellationToken: cancellationToken);

        #endregion
    }
}
