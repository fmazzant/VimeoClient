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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Mafesoft.VimeoClient.Body.Channel;
    using Mafesoft.VimeoClient.Body.Video;
    using Mafesoft.VimeoClient.Filter.Channel;
    using Mafesoft.VimeoClient.Filter.Video;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoChannels.
    public partial class VimeoChannels
    {
        #region [ Essential ]

        /// <summary>
        /// This method creates a new channel.
        /// </summary>
        /// <param name="obj">
        /// The channel to create: the name of the channel, its description and the privacy level of the channel.
        /// Privacy option descriptions:
        ///     anybody - Anyone can access the channel.
        ///     moderators - Only moderators can access the channel.
        ///     user - Only moderators and designated users can access the channel.
        /// </param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        ///     200 OK	The channel was created.
        ///     400 Bad Request A parameter is invalid.
        ///     403 Forbidden The authenticated user can't create channels.
        /// </returns>
        public virtual Task<RestResult<Channel>> CreateAChannelAsync(ChannelEditParameters obj, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                foreach (var item in obj.ToEnumerable())
                {
                    if (item.Value != null)
                    {
                        pars.Add(item.Key, item.Value);
                    }
                }
            })
            .PostAsync<Channel>(cancellationToken);

        /// <summary>
        /// This method deletes the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The channel was deleted.
        /// 403 Forbidden The authenticated user doesn't own this channel.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAChannelAsync(string channel_id, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method edits the specified channel.
        /// </summary>
        /// <param name="channel_id"> The ID of the channel.</param>
        /// <param name="obj">The channel.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The channel was edited.
        /// 400 Bad Request A parameter is invalid.
        /// </returns>
        public virtual Task<RestResult<Channel>> EditAChannelAsync(string channel_id, ChannelEditParameters obj, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}")
             .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                foreach (var item in obj.ToEnumerable())
                {
                    pars.Add(item.Key, item.Value);
                }
            })
            .PatchAsync<Channel>(cancellationToken);

        /// <summary>
        /// This method returns a single channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Channel>> GetASpecificChannelAsync(string channel_id, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}")
            .GetAsync<Channel>(cancellationToken);

        /// <summary>
        /// This method returns all available channels.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<Channel>>> GetAllChannelsAsync(ChannelDirection? direction,
            ChannelFilter? filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllChannel? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command("/channels");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (filter.HasValue)
            {
                root = root.Parameter("filter", filter);
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

        /// <summary>
        /// This method returns all the channels to which the specified user subscribes.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<Channel>>> GetAllTheChannelsToWhichAUserSubscribesAsync(string user_id,
            ChannelDirection? direction,
            ChannelFilter? filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllChannelSubscribe? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/users/{user_id}/channels");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (filter.HasValue)
            {
                root = root.Parameter("filter", filter);
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

        /// <summary>
        /// This method returns all the channels to which the specified user subscribes.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<Channel>>> GetAllTheChannelsToWhichAUserSubscribesAsync(ChannelDirection? direction,
            ChannelFilter? filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllChannelSubscribe? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/me/channels");

            if (direction.HasValue)
            {
                root = root.Parameter("direction", direction);
            }
            if (filter.HasValue)
            {
                root = root.Parameter("filter", filter);
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

        #region [Categories ]

        /// <summary>
        /// This method adds the specified channel to multiple categories
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="channels">The array of category URIs to add.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The channel was added to the categories.
        /// 400 Bad Request 
        ///     Error code 2204: You exceeded the maximum number of channel categories.
        ///     Error code 2205: There was no request body, or the request body is malformed.
        /// 401 Unauthorized Error code 8003: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't add categories to the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public virtual Task<RestResult<string>> AddAChannelToAListOfCategoriesAsync(string channel_id, Category[] channels, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/categories")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) =>
            {
                foreach (Category cat in channels)
                {
                    p.Add("channels[]", "");
                }
            })
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method adds the specified channel to a single category. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The channel was added to the category.
        /// 400 Bad Request Error code 2204: You exceeded the maximum number of channel categories.
        /// 401 Unauthorized Error code 8003: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the channel or isn't a channel moderator.
        /// 404 Not Found   No such channel or category exists.
        /// </returns>
        public virtual Task<RestResult<string>> AddAChannelToASpecificCategoryAsync(string category, string channel_id, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/categories/{category}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method returns every category to which the specified channel belongs.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The categories were returned.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public virtual Task<RestResult<VimeoList<Category>>> GetAllTheCategoriesToWhichAChannelBelongsAsync(string channel_id, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/categories")
            .GetAsync<VimeoList<Category>>(cancellationToken);

        /// <summary>
        /// This method removes a channel from the specified category. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> RemoveAChannelFromACategoryAsync(string category, string channel_id, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/categories/{category}")
            .DeleteAsync(cancellationToken);

        #endregion

        #region [ Moderators ]

        /// <summary>
        /// This method adds multiple users as moderators to the specified channel. 
        /// The authenticated user must be a follower of a requested user to add this person as a channel moderator.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_uri">The URI of a user to add as a moderator.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The moderators were added.
        /// 400 Bad Request Error code 2908: The list contains more than 100 users.
        /// 403 Forbidden The authenticated user doesn't own the channel, a requested user is already a moderator of the channel, or the authenticated user doesn't follow a requested user.
        /// 404 Not Found   No such channel exists, or no such user exists.
        /// </returns>
        public virtual Task<RestResult<string>> AddAListOfModeratorsToAChannelAsync(string channel_id, string user_uri, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) => p.Add("user_uri", user_uri))
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method adds a single user as a moderator to the specified channel. 
        /// The authenticated user must be a follower of the requested user to add them as a channel moderator.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> AddASpecificModeratorToAChannelAsync(string channel_id, string user_id, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method returns a single moderator of the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<User>> GetASpecificModeratorOfAChannelAsync(string channel_id, string user_id, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .GetAsync<User>(cancellationToken);

        /// <summary>
        /// This method returns every moderator of the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The moderators of the channel, one page at a time.</returns>
        public virtual Task<RestResult<Pagination<User>>> GetAllTheModeratorsOfAChannelAsync(string channel_id,
            ChannelDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortAllModerators? sort = null, CancellationToken cancellationToken = default)
            => RootAuthorization()
               .Command($"/channels/{channel_id}/moderators")
               .Parameter((p) =>
               {
                   if (direction.HasValue)
                   {
                       p.Add(new RestParameter { Key = "direction", Value = direction });
                   }

                   if (!string.IsNullOrEmpty(query))
                   {
                       p.Add(new RestParameter { Key = "query", Value = query });
                   }

                   if (sort.HasValue)
                   {
                       p.Add(new RestParameter { Key = "sort", Value = sort });
                   }

                   if (page.HasValue)
                   {
                       p.Add(new RestParameter { Key = "page", Value = page });
                   }

                   if (per_page.HasValue)
                   {
                       p.Add(new RestParameter { Key = "per_page", Value = per_page });
                   }
               })
            .GetAsync<Pagination<User>>(cancellationToken);

        /// <summary>
        /// This method removes multiple moderators from the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_uri">The URI of a user to remove as a moderator.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The moderators were removed.
        /// 403 Forbidden The authenticated user doesn't own the channel, a requested user isn't a moderator of the channel, or a requested user is the owner of the channel.
        /// 404 Not Found   No such channel exists, or no such user exists.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveAListOfModeratorsFromAChannelAsync(string channel_id, string user_uri, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) =>
            {
                p.Add("user_uri", user_uri);
            })
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method removes a single moderator from the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The moderator was removed.
        /// 403 Forbidden The authenticated user doesn't own the channel, the requested user isn't a moderator of the channel, or the requested user is the owner of the channel.
        /// 404 Not Found   No such channel exists, or no such user exists.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveASpecificModeratorFromAChannelAsync(string channel_id, int user_id, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method replaces the current list of channel moderators with a new list. 
        /// The authenticated user must be the owner of the channel and a follower of each requested user to add them as a channel moderator.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_uri">The URI of the user to add as a moderator.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<User>> ReplaceTheModeratorsOfAChannelAsync(string channel_id, string user_uri, CancellationToken cancellationToken = default)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) => p.Add("user_uri", user_uri))
            .PatchAsync<User>(cancellationToken);

        #endregion

        #region [ Private channel members ]

        /// <summary>
        /// This method returns all the users who have access to the specified private channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">	The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<User>>> GetAllTheUsersWhoCanAccessAPrivateChannelAsync(string channel_id,
            ChannelDirection? direction = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/privacy/users")
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
            })
            .GetAsync<Pagination<User>>(cancellationToken);

        /// <summary>
        /// This method gives multiple users access to the specified private channel. The authenticated user must be the owner of the channel
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="users">The array of either the user URIs or the user IDs to permit to access the private channel.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<User>>> PermitAListOfUsersToAccessAPrivateChannelAsync(int channel_id, User[] users, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/privacy/users")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) =>
            {
                foreach (User u in users)
                {
                    p.Add("users[]", "");
                }
            })
            .PutAsync<VimeoList<User>>(cancellationToken);

        /// <summary>
        /// This method gives a single user access to the specified private channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<User>> PermitASpecificUserToAccessAPrivateChannelAsync(string channel_id, string user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/privacy/users/{user_id}")
            .PutAsync<User>(cancellationToken);

        /// <summary>
        /// This method prevents a single user from being able to access the specified private channel. 
        /// The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user can't acceess the private channel.
        /// 401 Unauthorized Error code 8003: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the channel.
        /// </returns>
        public virtual Task<RestResult<string>> RestrictAUserFromAccessingAPrivateChannelAsync(string channel_id, string user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/privacy/users/{user_id}")
            .DeleteAsync(cancellationToken);

        #endregion

        #region [ Subscriptions and subscribers ]

        /// <summary>
        /// This method determines whether the specified user is a follower of a particular channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user follows the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public virtual Task<RestResult<string>> CheckIfAUserFollowsAChannelAsync(string channel_id, string user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/channels/{channel_id}")
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method determines whether the specified user is a follower of a particular channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> CheckIfAUserFollowsAChannelAsync(string channel_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/channels/{channel_id}")
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method returns every follower of the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<User>>> GetAllTheFollowersOfAChannelAsync(string channel_id,
            ChannelFollowersOfAChannelFilter filter,
            ChannelDirection? direction,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortAllModerators? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/users")
            .Parameter((p) =>
            {
                p.Add(new RestParameter { Key = "filter", Value = filter });

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

                if (!string.IsNullOrEmpty(query))
                {
                    p.Add(new RestParameter { Key = "query", Value = query });
                }

                if (sort.HasValue)
                {
                    p.Add(new RestParameter { Key = "sort", Value = sort });
                }
            })
            .GetAsync<Pagination<User>>(cancellationToken);

        /// <summary>
        /// This method subscribes the authenticated user to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="user_id">The ID of the user</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user is subscribed to the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public virtual Task<RestResult<string>> SubscribeTheUserToASpecificChannelAsync(string channel_id, string user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/channels/{channel_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method subscribes the authenticated user to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user is unsubscribed from the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public virtual Task<RestResult<string>> SubscribeTheUserToASpecificChannelAsync(string channel_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/channels/{channel_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method unsubscribes the authenticated user from the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="user_id">The ID of the user</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user is unsubscribed from the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public virtual Task<RestResult<string>> UnsubscribeTheUserFromASpecificChannelAsync(string channel_id, string user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/channels/{channel_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method unsubscribes the authenticated user from the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The user is unsubscribed from the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public virtual Task<RestResult<string>> UnsubscribeTheUserFromASpecificChannelAsync(string channel_id, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/me/channels/{channel_id}")
           .DeleteAsync(cancellationToken);

        #endregion

        #region [ Tags ]

        /// <summary>
        /// This method adds multiple tags to the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">channel_id</param>
        /// <param name="tags">An array of tags to assign.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Tag>>> AddAListOfTagsToAChannelAsync(string channel_id, Tag[] tags, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/tags")
            .FormUrlEncoded(true, (p) =>
            {
                foreach (var item in tags)
                {
                    p.Add("tags[]", item.Name);
                }
            })
            .PutAsync<VimeoList<Tag>>(cancellationToken);

        /// <summary>
        /// This method adds a single tag to the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel </param>
        /// <param name="word">The word to use as the tag. </param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Tag>> AddASpecificTagToAChannelAsync(string channel_id, string word, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/tags/{word}")
           .PutAsync<Tag>(cancellationToken);

        /// <summary>
        /// This method determines whether a tag has been added to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="word">The word to use as the tag.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The tag has been added to the channel.
        /// 400 Bad Request No such tag exists.
        /// 404 Not Found   Error code 5000: The tag exists, but the channel isn't tagged by it.
        /// </returns>
        public virtual Task<RestResult<string>> CheckIfATagHasBeenAddedToAChannelAsync(string channel_id, string word, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/tags/{word}")
           .GetAsync(cancellationToken);

        /// <summary>
        /// This method returns every tag that has been added to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Tag>>> GetAllTheTagsThatHaveBeenAddedToAChannelAsync(string channel_id, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/tags")
           .GetAsync<VimeoList<Tag>>(cancellationToken);

        /// <summary>
        /// This method removes a single tag from the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="word">The word to use as the tag</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The tag was removed.
        /// 400 Bad Request The tag is invalid, or a parameter is invalid.
        /// 401 Unauthorized Error code 8003: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't remove tags from this channel.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveATagFromAChannelAsync(string channel_id, string word, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/tags/{word}")
           .DeleteAsync(cancellationToken);

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method adds multiple videos to the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_uri">
        /// A member of an array representing the URIs of the videos to add.
        /// For each member in the array, use the format {"video_uri":"x"} where x is a video URI. 
        /// For more information on batch requests like this, 
        /// see Using Common Formats and Parameters.
        /// </param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The videos were added.
        /// 403 Forbidden The authenticated user can't add videos to the channel, or a video can't be added to the channel.
        /// 404 Not Found   No such channel or user exist.
        /// </returns>
        public virtual Task<RestResult<string>> AddAListOfVideosToAChannelAsync(string channel_id, Video[] video_uri, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/videos")
            .FormUrlEncoded(true, (p) =>
            {
                foreach (var item in video_uri)
                {
                    p.Add("video_uri", item.Uri);
                }
            })
           .PutAsync(cancellationToken);

        /// <summary>
        /// This method adds a single video to the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// 403 Forbidden The video can't be added to a channel, or the authenticated user can't add videos to this channel.
        /// 404 Not Found   No such channel or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> AddASpecificVideoToAChannelAsync(string channel_id, string video_id, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/videos/{video_id}")
           .PutAsync(cancellationToken);

        /// <summary>
        /// This method returns a single video in the specified channel. You can use it to determine whether the video is in the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">	The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Video>> GetASpecificVideoInAChannelAsync(string channel_id, string video_id, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/videos/{video_id}")
           .GetAsync<Video>(cancellationToken);

        /// <summary>
        /// This method returns every channel to which the authenticated user can add or remove the specified video. 
        /// The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Channel>>> GetAllTheChannelsToWhichTheUserCanAddOrRemoveASpecificVideoAsync(string video_id, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/videos/{video_id}/available_channels")
           .GetAsync<VimeoList<Channel>>(cancellationToken);

        /// <summary>
        /// This method returns every video in the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="containing_uri">The page containing the video URI.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false). Required only if filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The videos of the channel, one page at a time.</returns>
        public virtual async Task<RestResult<Pagination<Video>>> GetAllTheVideosInAChannelAsync(string channel_id,
            string containing_uri = null,
            ChannelDirection? direction = null,
            ChannelFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllVideos? sort = null, CancellationToken cancellationToken = default)
        {
            var root = RootAuthorization()
                .Command($"/channels/{channel_id}/videos")
                .Parameter((p) =>
                {
                    if (containing_uri != null)
                    {
                        p.Add(new RestParameter { Key = "containing_uri", Value = containing_uri });
                    }
                    if (direction.HasValue)
                    {
                        p.Add(new RestParameter { Key = "direction", Value = direction });
                    }
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
        /// This method removes multiple videos from the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_uri">The URI of a video to remove.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The videos were removed.
        /// 403 Forbidden The authenticated user can't remove videos from this channel, or a video can't be removed from the channel.
        /// 404 Not Found   No such channel or user exists.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveAListOfVideosFromAChannelAsync(string channel_id, string video_uri, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/videos")
           .FormUrlEncoded(true, (p) => p.Add("video_uri", video_uri))
           .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method removes a single video from the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was removed.
        /// 403 Forbidden The authenticated user can't remove videos from this channel, or the video can't be removed from the channel.
        /// 404 Not Found   No such channel or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveASpecificVideoFromAChannelAsync(string channel_id, string video_id, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/channels/{channel_id}/videos/{video_id}")
           .DeleteAsync(cancellationToken);

        #endregion

        #region [ Channel videos: comments, credits, thumbnails, privacy, text tracks ]

        /// <summary>
        /// This method returns every comment on the specified video in a channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The comments were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Comment>>> GetAllTheCommentsOnAChannelVideoAsync(string channel_id, string video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/comments")
            .ListParameters(direction, null, page, per_page)
            .GetPaginationAsync<Comment>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method adds a comment to the specified video in a channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="text">The text of the comment.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The comment was added.
        /// 401 Unauthorized	The authenticated user can't comment on the video.
        /// 403 Forbidden	Comments are disabled for the video.
        /// </returns>
        public virtual Task<RestResult<Comment>> AddACommentToAChannelVideoAsync(string channel_id, string video_id, string text, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/comments")
            .FormUrlEncoded(new KeyValuePair<string, object>("text", text))
            .PostAsync<Comment>(cancellationToken);

        /// <summary>
        /// This method returns every credited user in the specified video in a channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The credits were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Credit>>> GetAllTheCreditedUsersInAChannelVideoAsync(string channel_id, string video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoCreditSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/credits")
            .ListParameters(direction, null, page, per_page, query, sort)
            .GetPaginationAsync<Credit>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method adds a credit for a user in the specified video in a channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: email, name, role and user_uri.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The credit was added.
        /// 400 Bad Request	A parameter is invalid.
        /// 403 Forbidden	The authenticated user can't add credits to the video.
        /// </returns>
        public virtual Task<RestResult<Credit>> CreditAUserInAChannelVideoAsync(string channel_id, string video_id, CreditParameters parameters, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/credits")
            .FormUrlEncoded(parameters)
            .PostAsync<Credit>(cancellationToken);

        /// <summary>
        /// This method returns every thumbnail image of the specified video in a channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The thumbnails were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllTheThumbnailsOfAChannelVideoAsync(string channel_id, string video_id,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/pictures")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<Picture>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method adds a thumbnail image to the specified video in a channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: active and time.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The thumbnail was added.
        /// </returns>
        public virtual Task<RestResult<Picture>> AddAThumbnailToAChannelVideoAsync(string channel_id, string video_id, ThumbnailParameters parameters, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/pictures")
            .FormUrlEncoded(parameters)
            .PostAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns every user who can view the specified private video in a channel. The video's privacy.view must be users.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The users were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<User>>> GetAllTheUsersWhoCanViewAPrivateChannelVideoAsync(string channel_id, string video_id,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/privacy/users")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<User>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method gives multiple users permission to view the specified private video in a channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="user_uris">The URIs of the users to permit.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The users were permitted.
        /// </returns>
        public virtual Task<RestResult<VimeoList<User>>> PermitAListOfUsersToViewAPrivateChannelVideoAsync(string channel_id, string video_id, string[] user_uris, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/privacy/users")
            .Payload(user_uris.Select(uri => new Dictionary<string, string> { { "uri", uri } }).ToArray())
            .PutAsync<VimeoList<User>>(cancellationToken);

        /// <summary>
        /// This method returns every text track of the specified video in a channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The text tracks were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<TextTrack>>> GetAllTheTextTracksOfAChannelVideoAsync(string channel_id, string video_id,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/texttracks")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<TextTrack>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method adds a text track to the specified video in a channel. Upload the file to the returned link afterwards.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: active, language, name and type.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The text track was added.
        /// </returns>
        public virtual Task<RestResult<TextTrack>> AddATextTrackToAChannelVideoAsync(string channel_id, string video_id, TextTrackParameters parameters, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/texttracks")
            .FormUrlEncoded(parameters)
            .PostAsync<TextTrack>(cancellationToken);

        #endregion

        #region [ Overloads with int video_id ]

        /// <inheritdoc cref="AddASpecificVideoToAChannel(string, string)"/>
        public virtual Task<RestResult<string>> AddASpecificVideoToAChannelAsync(string channel_id, int video_id, CancellationToken cancellationToken = default)
            => AddASpecificVideoToAChannelAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), cancellationToken: cancellationToken);

        /// <inheritdoc cref="GetASpecificVideoInAChannel(string, string)"/>
        public virtual Task<RestResult<Video>> GetASpecificVideoInAChannelAsync(string channel_id, int video_id, CancellationToken cancellationToken = default)
            => GetASpecificVideoInAChannelAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), cancellationToken: cancellationToken);

        /// <inheritdoc cref="GetAllTheChannelsToWhichTheUserCanAddOrRemoveASpecificVideo(string)"/>
        public virtual Task<RestResult<VimeoList<Channel>>> GetAllTheChannelsToWhichTheUserCanAddOrRemoveASpecificVideoAsync(int video_id, CancellationToken cancellationToken = default)
            => GetAllTheChannelsToWhichTheUserCanAddOrRemoveASpecificVideoAsync(video_id.ToString(CultureInfo.InvariantCulture), cancellationToken: cancellationToken);

        /// <inheritdoc cref="RemoveASpecificVideoFromAChannel(string, string)"/>
        public virtual Task<RestResult<string>> RemoveASpecificVideoFromAChannelAsync(string channel_id, int video_id, CancellationToken cancellationToken = default)
            => RemoveASpecificVideoFromAChannelAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), cancellationToken: cancellationToken);

        /// <inheritdoc cref="GetAllTheCommentsOnAChannelVideo(string, string, VideoDirection?, int?, int?)"/>
        public virtual Task<RestResult<Pagination<Comment>>> GetAllTheCommentsOnAChannelVideoAsync(string channel_id, int video_id, VideoDirection? direction = null, int? page = null, int? per_page = null, CancellationToken cancellationToken = default)
            => GetAllTheCommentsOnAChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), direction, page, per_page, cancellationToken: cancellationToken);

        /// <inheritdoc cref="AddACommentToAChannelVideo(string, string, string)"/>
        public virtual Task<RestResult<Comment>> AddACommentToAChannelVideoAsync(string channel_id, int video_id, string text, CancellationToken cancellationToken = default)
            => AddACommentToAChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), text, cancellationToken: cancellationToken);

        /// <inheritdoc cref="GetAllTheCreditedUsersInAChannelVideo(string, string, VideoDirection?, int?, int?, string, VideoCreditSort?)"/>
        public virtual Task<RestResult<Pagination<Credit>>> GetAllTheCreditedUsersInAChannelVideoAsync(string channel_id, int video_id, VideoDirection? direction = null, int? page = null, int? per_page = null, string query = null, VideoCreditSort? sort = null, CancellationToken cancellationToken = default)
            => GetAllTheCreditedUsersInAChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), direction, page, per_page, query, sort, cancellationToken: cancellationToken);

        /// <inheritdoc cref="CreditAUserInAChannelVideo(string, string, CreditParameters)"/>
        public virtual Task<RestResult<Credit>> CreditAUserInAChannelVideoAsync(string channel_id, int video_id, CreditParameters parameters, CancellationToken cancellationToken = default)
            => CreditAUserInAChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), parameters, cancellationToken: cancellationToken);

        /// <inheritdoc cref="GetAllTheThumbnailsOfAChannelVideo(string, string, int?, int?)"/>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllTheThumbnailsOfAChannelVideoAsync(string channel_id, int video_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default)
            => GetAllTheThumbnailsOfAChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), page, per_page, cancellationToken: cancellationToken);

        /// <inheritdoc cref="AddAThumbnailToAChannelVideo(string, string, ThumbnailParameters)"/>
        public virtual Task<RestResult<Picture>> AddAThumbnailToAChannelVideoAsync(string channel_id, int video_id, ThumbnailParameters parameters, CancellationToken cancellationToken = default)
            => AddAThumbnailToAChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), parameters, cancellationToken: cancellationToken);

        /// <inheritdoc cref="GetAllTheUsersWhoCanViewAPrivateChannelVideo(string, string, int?, int?)"/>
        public virtual Task<RestResult<Pagination<User>>> GetAllTheUsersWhoCanViewAPrivateChannelVideoAsync(string channel_id, int video_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default)
            => GetAllTheUsersWhoCanViewAPrivateChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), page, per_page, cancellationToken: cancellationToken);

        /// <inheritdoc cref="PermitAListOfUsersToViewAPrivateChannelVideo(string, string, string[])"/>
        public virtual Task<RestResult<VimeoList<User>>> PermitAListOfUsersToViewAPrivateChannelVideoAsync(string channel_id, int video_id, string[] user_uris, CancellationToken cancellationToken = default)
            => PermitAListOfUsersToViewAPrivateChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), user_uris, cancellationToken: cancellationToken);

        /// <inheritdoc cref="GetAllTheTextTracksOfAChannelVideo(string, string, int?, int?)"/>
        public virtual Task<RestResult<Pagination<TextTrack>>> GetAllTheTextTracksOfAChannelVideoAsync(string channel_id, int video_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default)
            => GetAllTheTextTracksOfAChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), page, per_page, cancellationToken: cancellationToken);

        /// <inheritdoc cref="AddATextTrackToAChannelVideo(string, string, TextTrackParameters)"/>
        public virtual Task<RestResult<TextTrack>> AddATextTrackToAChannelVideoAsync(string channel_id, int video_id, TextTrackParameters parameters, CancellationToken cancellationToken = default)
            => AddATextTrackToAChannelVideoAsync(channel_id, video_id.ToString(CultureInfo.InvariantCulture), parameters, cancellationToken: cancellationToken);

        #endregion
    }
}
