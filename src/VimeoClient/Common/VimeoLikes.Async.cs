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
    using Mafesoft.VimeoClient.Filter.User;
    using Mafesoft.VimeoClient.Filter.Video;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoLikes.
    public partial class VimeoLikes
    {
        #region [ Essential ]

        /// <summary>
        /// This method causes the authenticated user to unlike the specified video.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was unliked.
        /// 403 Forbidden The authenticated user can't like videos.
        /// </returns>
        public virtual Task<RestResult<string>> CauseAUserToUnlikeAVideoAsync(int user_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/likes/{video_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method causes the authenticated user to unlike the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was unliked.
        /// 403 Forbidden The authenticated user can't like videos.
        /// </returns>
        public virtual Task<RestResult<string>> CauseAUserToUnlikeAVideoAsync(int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/likes/{video_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method causes the authenticated user to like the specified video. The user can't like their own video.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was liked.
        /// 400 Bad Request The authenticated user owns the video and can't like it.
        /// 403 Forbidden The authenticated user can't like videos.
        /// </returns>
        public virtual Task<RestResult<string>> CauseAUserToLikeAVideoAsync(int user_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/likes/{video_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method causes the authenticated user to like the specified video. The user can't like their own video.
        /// </summary>
        /// <param name="video_id">The ID of the video</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was liked.
        /// 400 Bad Request The authenticated user owns the video and can't like it.
        /// 403 Forbidden The authenticated user can't like videos.
        /// </returns>
        public virtual Task<RestResult<string>> CauseAUserToLikeAVideoAsync(int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/likes/{video_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method checks if the authenticated user has liked the specified video.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user has liked the video.
        /// 404 Not Found   The user hasn't liked the video.
        /// </returns>
        public virtual Task<RestResult<string>> CheckIfTheUserHasLikedAVideAsync(int user_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/likes/{video_id}")
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method checks if the authenticated user has liked the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user has liked the video.
        /// 404 Not Found   The user hasn't liked the video.
        /// </returns>
        public virtual Task<RestResult<string>> CheckIfTheUserHasLikedAVideAsync(int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/likes/{video_id}")
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method returns every user who has liked the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The users were returned.
        /// </returns>
        public virtual async Task<RestResult<Pagination<User>>> GetAllTheUsersWhoHaveLikedAVideoAsync(int video_id, UserDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            UserSort? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/videos/{video_id}/likes")
                .Parameter((p) =>
                {
                    if (direction.HasValue)
                    {
                        p.Add(new RestParameter { Key = "direction", Value = direction });
                    }
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                    if (query != null)
                    {
                        p.Add(new RestParameter { Key = "query", Value = query });
                    }
                    if (sort.HasValue)
                    {
                        p.Add(new RestParameter { Key = "sort", Value = sort });
                    }
                });

            var result = await root.GetAsync<Pagination<User>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method returns every user who has liked the specified video.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The users were returned.
        /// </returns>
        public virtual async Task<RestResult<Pagination<User>>> GetAllTheUsersWhoHaveLikedAVideoAsync(int channel_id, int video_id, UserDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            UserSort? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/channels/{channel_id}/videos/{video_id}/likes")
                .Parameter((p) =>
                {
                    if (direction.HasValue)
                    {
                        p.Add(new RestParameter { Key = "direction", Value = direction });
                    }
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                    if (query != null)
                    {
                        p.Add(new RestParameter { Key = "query", Value = query });
                    }
                    if (sort.HasValue)
                    {
                        p.Add(new RestParameter { Key = "sort", Value = sort });
                    }
                });

            var result = await root.GetAsync<Pagination<User>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method returns every user who has liked the specified video on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The users were returned.
        /// </returns>
        public virtual async Task<RestResult<Pagination<User>>> GetAllTheUsersWhoHaveLikedAVideoOnAnOnDemandPageAsync(int ondemand_id, UserDirection? direction = null,
            UserFilter? filter = null,
            int? page = null,
            int? per_page = null,
            UserSort? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/ondemand/pages/{ondemand_id}/likes")
                .Parameter((p) =>
                {
                    if (direction.HasValue)
                    {
                        p.Add(new RestParameter { Key = "direction", Value = direction });
                    }
                    if (filter.HasValue)
                    {
                        p.Add(new RestParameter { Key = "filter", Value = filter });
                    }
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                    if (sort.HasValue)
                    {
                        p.Add(new RestParameter { Key = "sort", Value = sort });
                    }
                });

            var result = await root.GetAsync<Pagination<User>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method returns every video that the authenticated user has liked.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false). 
        /// This parameter is required only when filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// </returns>
        public virtual async Task<RestResult<Pagination<Video>>> GetAllTheVideosThatAUserHasLikedAsync(int user_id,
           VideoFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoSort? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/users/{user_id}/likes")
                .Parameter((p) =>
                {
                    if (filter.HasValue)
                    {
                        p.Add(new RestParameter { Key = "filter", Value = filter });
                    }
                    if (filter_embeddable == true)
                    {
                        p.Add(new RestParameter { Key = "filter_embeddable", Value = filter_embeddable });
                    }
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                    if (query != null)
                    {
                        p.Add(new RestParameter { Key = "query", Value = query });
                    }
                    if (sort.HasValue)
                    {
                        p.Add(new RestParameter { Key = "sort", Value = sort });
                    }
                });

            var result = await root.GetAsync<Pagination<Video>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method returns every video that the authenticated user has liked.
        /// </summary>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false). 
        /// This parameter is required only when filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// </returns>
        public virtual async Task<RestResult<Pagination<Video>>> GetAllTheVideosThatAUserHasLikedAsync(
            VideoFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoSort? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/me/likes")
                .Parameter((p) =>
                {
                    if (filter.HasValue)
                    {
                        p.Add(new RestParameter { Key = "filter", Value = filter });
                    }
                    if (filter_embeddable == true)
                    {
                        p.Add(new RestParameter { Key = "filter_embeddable", Value = filter_embeddable });
                    }
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                    if (query != null)
                    {
                        p.Add(new RestParameter { Key = "query", Value = query });
                    }
                    if (sort.HasValue)
                    {
                        p.Add(new RestParameter { Key = "sort", Value = sort });
                    }
                });

            var result = await root.GetAsync<Pagination<Video>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        #endregion
    }
}
