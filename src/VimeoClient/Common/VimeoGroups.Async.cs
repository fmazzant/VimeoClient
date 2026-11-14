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
    using System;
    using Mafesoft.VimeoClient.Filter.Group;
    using Mafesoft.VimeoClient.Filter.User;
    using Mafesoft.VimeoClient.Filter.Video;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoGroups.
    public partial class VimeoGroups
    {
        #region [ Essentials ]

        /// <summary>
        /// This method creates a new group
        /// </summary>
        /// <param name="name">The name of the group.</param>
        /// <param name="description">The description of the group.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The group was created.
        /// 400 Bad Request A parameter is invalid.
        /// 403 Forbidden The authenticated user can't create groups.
        /// </returns>
        public virtual Task<RestResult<Group>> CreateAGroupAsync(string name, string description, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command("/groups")
            .FormUrlEncoded(true, (p) =>
            {
                p.Add("name", name);
                p.Add("description", description);
            })
            .PostAsync<Group>(cancellationToken);

        /// <summary>
        /// This method deletes the specified group. The authenticated user must be the owner of the group.
        /// </summary>
        /// <param name="group_id">group_id</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The group was deleted.
        /// 403 Forbidden The authenticated user can't delete the group.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAGroupAsync(int group_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/groups/{group_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method returns the specified group
        /// </summary>
        /// <param name="group_id">group_id</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The group was returned.
        /// </returns>
        public virtual Task<RestResult<Group>> GetASpecificGroupAsync(int group_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/groups/{group_id}")
            .GetAsync<Group>(cancellationToken);

        /// <summary>
        /// This method returns every available group.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The groups were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Group>>> GetAllGroupsAsync(GroupDirection? direction = null,
            string filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            GroupSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/groups")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .GetPaginationAsync<Group>(RootAuthorization, cancellationToken);

        #endregion

        #region [ Subscriptions ]

        /// <summary>
        /// This method adds the authenticated user to the specified group.
        /// </summary>
        /// <param name="user_id">Number  The ID of the user.</param>
        /// <param name="group_id">Number  The ID of the group.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user joined the group.
        /// 403 Forbidden   The authenticated user can't join the group. 
        ///     Possible reasons are that the group isn't public or that its privacy setting is members.
        /// </returns>
        public virtual Task<RestResult<string>> AddTheUserToAGroupAsync(int user_id, int group_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/groups/{group_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method adds the authenticated user to the specified group.
        /// </summary>
        /// <param name="group_id">Number  The ID of the group.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user joined the group.
        /// 403 Forbidden   The authenticated user can't join the group. 
        ///     Possible reasons are that the group isn't public or that its privacy setting is members.
        /// </returns>
        public virtual Task<RestResult<string>> AddTheUserToAGroupAsync(int group_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/groups/{group_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method removes the authenticated user from the specified group. 
        /// The authenticated user can't be the owner of the group; assign a new owner through a PATCH request first.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="group_id">The ID of the group.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user was removed from the group.
        /// 403 Forbidden	The authenticated user can't leave the group.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveTheUserFromAGroupAsync(int user_id, int group_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/groups/{group_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method removes the authenticated user from the specified group. 
        /// The authenticated user can't be the owner of the group; assign a new owner through a PATCH request first.
        /// </summary>
        /// <param name="group_id">The ID of the group.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user was removed from the group.
        /// 403 Forbidden	The authenticated user can't leave the group.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveTheUserFromAGroupAsync(int group_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/groups/{group_id}")
            .DeleteAsync(cancellationToken);

        #endregion

        #region [ Users ]

        /// <summary>
        /// This method determines whether the authenticated user belongs to the specified group.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="group_id">The ID of the group.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user belongs to the group.
        /// 404 Not Found	No such group exists.
        ///                 The authenticated user isn't a member of the group.
        /// </returns>
        public virtual Task<RestResult<string>> CheckIfAUserHasJoinedAGroupAsync(int user_id, int group_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/groups/{group_id}")
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method determines whether the authenticated user belongs to the specified group.
        /// </summary>
        /// <param name="group_id">The ID of the group.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user belongs to the group.
        /// 404 Not Found	No such group exists.
        ///                 The authenticated user isn't a member of the group.
        /// </returns>
        public virtual Task<RestResult<string>> CheckIfAUserHasJoinedAGroupAsync(int group_id, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/me/groups/{group_id}")
           .GetAsync(cancellationToken);

        /// <summary>
        /// This method returns every group to which the authenticated user belongs.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The groups were returned
        /// </returns>
        public virtual async Task<RestResult<Pagination<Group>>> GetAllTheGroupsThatTheUserHasJoinedAsync(int user_id, GroupDirection? direction = null,
            string filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            GroupSort? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/users/{user_id}/groups")
                .Parameter((p) =>
                {
                    if (direction.HasValue)
                    {
                        p.Add(new RestParameter { Key = "direction", Value = direction });
                    }
                    if (filter != null)
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
                    if (query != null)
                    {
                        p.Add(new RestParameter { Key = "query", Value = query });
                    }
                    if (sort.HasValue)
                    {
                        p.Add(new RestParameter { Key = "sort", Value = sort });
                    }
                });

            var result = await root.GetAsync<Pagination<Group>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method returns every group to which the authenticated user belongs.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The groups were returned
        /// </returns>
        public virtual async Task<RestResult<Pagination<Group>>> GetAllTheGroupsThatTheUserHasJoinedAsync(GroupDirection? direction = null,
            GroupFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            GroupSort? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/me/groups")
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
                    if (query != null)
                    {
                        p.Add(new RestParameter { Key = "query", Value = query });
                    }
                    if (sort.HasValue)
                    {
                        p.Add(new RestParameter { Key = "sort", Value = sort });
                    }
                });

            var result = await root.GetAsync<Pagination<Group>>(cancellationToken).ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method returns every user who belongs to the specified group.
        /// </summary>
        /// <param name="group_id">The ID of the group.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The members were returned.
        /// 404 Not Found   No such group exists.
        /// </returns>
        public virtual async Task<RestResult<Pagination<User>>> GetAllTheMembersOfAGroupAsync(int group_id, UserDirection? direction = null,
            UserFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            UserSort? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
               .Command($"/groups/{group_id}/users")
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

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method adds a video to the specified group. The authenticated user must be the owner of the group.
        /// </summary>
        /// <param name="group_id">The ID of the group.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// HTTP Status	Explanation
        /// 200 OK The video was added.
        /// 202 Accepted The video is in pending status.
        /// 403 Forbidden
        ///     The video is already in the group.
        ///     The authenticated user can't add videos to the group.
        /// </returns>
        public virtual Task<RestResult<Video>> AddAVideoToAGroupAsync(int group_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/groups/{group_id}/videos/{video_id}")
            .PutAsync<Video>(cancellationToken);

        /// <summary>
        /// This method returns every group to which the authenticated user can add or remove the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The groups were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Group>>> GetAllTheGroupsToWhichTheUserCanAddOrRemoveASpecificVideoAsync(int video_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/videos/{video_id}/available_groups")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<Group>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns a single video from the specified group. You can use this method to determine whether the video belongs to the group.
        /// </summary>
        /// <param name="group_id">The ID of the group.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The video was returned.
        /// 404 Not Found	No such video or group exists.
        /// </returns>
        public virtual Task<RestResult<Video>> GetASpecificVideoInAGroupAsync(int group_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/groups/{group_id}/videos/{video_id}")
           .GetAsync<Video>(cancellationToken);

        /// <summary>
        /// This method returns every video from the specified group.
        /// </summary>
        /// <param name="group_id">The ID of the group.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false). 
        /// This parameter is required only when filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<Video>>> GetAllTheVideosInAGroupAsync(int group_id, VideoDirection? direction = null,
           VideoFilter? filter = null,
           bool? filter_embeddable = null,
           int? page = null,
           int? per_page = null,
           string query = null,
           VideoSort? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
               .Command($"/groups/{group_id}/videos")
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
                   if (filter_embeddable.HasValue)
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
        /// This method removes a video from the specified group. The authenticated user must be the owner of the group.
        /// </summary>
        /// <param name="group_id">The ID of the group.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> RemoveAVideoFromAGroupAsync(int group_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/groups/{group_id}/videos/{video_id}")
            .DeleteAsync(cancellationToken);

        #endregion
    }
}
