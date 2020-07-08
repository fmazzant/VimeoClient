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
    using System;
    using System.Collections.Generic;
    using VimeoClient.Body.Channel;
    using VimeoClient.Filter.Channel;
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// Use channels to organize videos by theme or some other grouping. 
    /// You can incorporate your own videos as well as videos from other Vimeo members on any channel that you create. 
    /// Vimeo Basic subscribers get one channel, while paid Vimeo members can have an unlimited number. 
    /// See our Help Center for more details.
    /// https://developer.vimeo.com/api/reference/channels
    /// </summary>
    public class VimeoChannels
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
        public VimeoChannels(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoChannels(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essential ]

        /// <summary>
        /// This method creates a new channel.
        /// </summary>
        /// <param name="name">The name of the channel.</param>
        /// <param name="privacy">
        /// The privacy level of the channel.
        /// Option descriptions:
        ///     anybody - Anyone can access the channel.
        ///     moderators - Only moderators can access the channel.
        ///     user - Only moderators and designated users can access the channel.
        /// <returns>
        ///     200 OK	The channel was created.
        ///     400 Bad Request A parameter is invalid.
        ///     403 Forbidden The authenticated user can't create channels.
        /// </returns>
        public RestResult<Channel> CreateAChannel(ChannelEditParameters obj)
            => RootAuthorization()
            .Command($"/channels")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                foreach (var item in obj.ToEnumerable())
                {
                    pars.Add(item.Key, item.Value);
                }
            })
            .Post<Channel>();

        /// <summary>
        /// This method deletes the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns>
        /// 204 No Content	The channel was deleted.
        /// 403 Forbidden The authenticated user doesn't own this channel.
        /// </returns>
        public RestResult DeleteAChannel(string channel_id)
            => RootAuthorization()
            .Command($"/channels/{channel_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified channel.
        /// </summary>
        /// <param name="channel_id"> The ID of the channel.</param>
        /// <param name="obj">The channel.</param>
        /// <returns>
        /// 200 OK	The channel was edited.
        /// 400 Bad Request A parameter is invalid.
        /// </returns>
        public RestResult<Channel> EditAChannel(string channel_id, ChannelEditParameters obj)
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
            .Patch<Channel>();

        /// <summary>
        /// This method returns a single channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns></returns>
        public RestResult<Channel> GetASpecificChannel(string channel_id)
            => RootAuthorization()
            .Command($"/channels/{channel_id}")
            .Get<Channel>();

        /// <summary>
        /// This method returns all available channels.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <returns></returns>
        public RestResult<Pagination<Channel>> GetAllChannels(ChannelDirection? direction,
            ChannelFilter? filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllChannel? sort = null)
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
        /// <returns></returns>
        public RestResult<Pagination<Channel>> GetAllTheChannelsToWhichAUserSubscribes(string user_id,
            ChannelDirection? direction,
            ChannelFilter? filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllChannelSubscribe? sort = null)
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

        /// <summary>
        /// This method returns all the channels to which the specified user subscribes.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <returns></returns>
        public RestResult<Pagination<Channel>> GetAllTheChannelsToWhichAUserSubscribes(ChannelDirection? direction,
            ChannelFilter? filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllChannelSubscribe? sort = null)
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

        #region [Categories ]

        /// <summary>
        /// This method adds the specified channel to multiple categories
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="channels">The array of category URIs to add.</param>
        /// <returns>
        /// 204 No Content	The channel was added to the categories.
        /// 400 Bad Request 
        ///     Error code 2204: You exceeded the maximum number of channel categories.
        ///     Error code 2205: There was no request body, or the request body is malformed.
        /// 401 Unauthorized Error code 8003: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't add categories to the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public RestResult AddAChannelToAListOfCategories(string channel_id, Category[] channels)
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
            .Put();

        /// <summary>
        /// This method adds the specified channel to a single category. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns>
        /// 204 No Content	The channel was added to the category.
        /// 400 Bad Request Error code 2204: You exceeded the maximum number of channel categories.
        /// 401 Unauthorized Error code 8003: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the channel or isn't a channel moderator.
        /// 404 Not Found   No such channel or category exists.
        /// </returns>
        public RestResult AddAChannelToASpecificCategory(string category, string channel_id)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/categories/{category}")
            .Put();

        /// <summary>
        /// This method returns every category to which the specified channel belongs.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns>
        /// 200 OK	The categories were returned.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public RestResult<VimeoList<Category>> GetAllTheCategoriesToWhichAChannelBelongs(string channel_id)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/categories")
            .Get<VimeoList<Category>>();

        /// <summary>
        /// This method removes a channel from the specified category. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> RemoveAChannelFromACategory(string category, string channel_id)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/categories/{category}")
            .Delete();

        #endregion

        #region [ Moderators ]

        /// <summary>
        /// This method adds multiple users as moderators to the specified channel. 
        /// The authenticated user must be a follower of a requested user to add this person as a channel moderator.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_uri">The URI of a user to add as a moderator.</param>
        /// <returns>
        /// 200 OK	The moderators were added.
        /// 400 Bad Request Error code 2908: The list contains more than 100 users.
        /// 403 Forbidden The authenticated user doesn't own the channel, a requested user is already a moderator of the channel, or the authenticated user doesn't follow a requested user.
        /// 404 Not Found   No such channel exists, or no such user exists.
        /// </returns>
        public RestResult AddAListOfModeratorsToAChannel(string channel_id, string user_uri)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) => p.Add("user_uri", user_uri))
            .Put();

        /// <summary>
        /// This method adds a single user as a moderator to the specified channel. 
        /// The authenticated user must be a follower of the requested user to add them as a channel moderator.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns></returns>
        public RestResult AddASpecificModeratorToAChannel(string channel_id, string user_id)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .Put();

        /// <summary>
        /// This method returns a single moderator of the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns></returns>
        public RestResult<User> GetASpecificModeratorOfAChannel(string channel_id, string user_id)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .Get<User>();

        /// <summary>
        /// This method returns every moderator of the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<Pagination<User>> GetAllTheModeratorsOfAChannel(string channel_id,
            ChannelDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortAllModerators? sort = null)
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
            .Get<Pagination<User>>();

        /// <summary>
        /// This method removes multiple moderators from the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_uri">The URI of a user to remove as a moderator.</param>
        /// <returns>
        /// 204 No Content	The moderators were removed.
        /// 403 Forbidden The authenticated user doesn't own the channel, a requested user isn't a moderator of the channel, or a requested user is the owner of the channel.
        /// 404 Not Found   No such channel exists, or no such user exists.
        /// </returns>
        public RestResult RemoveAListOfModeratorsFromAChannel(string channel_id, string user_uri)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) =>
            {
                p.Add("user_uri", user_uri);
            })
            .Delete();

        /// <summary>
        /// This method removes a single moderator from the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 204 No Content	The moderator was removed.
        /// 403 Forbidden The authenticated user doesn't own the channel, the requested user isn't a moderator of the channel, or the requested user is the owner of the channel.
        /// 404 Not Found   No such channel exists, or no such user exists.
        /// </returns>
        public RestResult RemoveASpecificModeratorFromAChannel(string channel_id, int user_id)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .Delete();

        /// <summary>
        /// This method replaces the current list of channel moderators with a new list. 
        /// The authenticated user must be the owner of the channel and a follower of each requested user to add them as a channel moderator.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_uri">The URI of the user to add as a moderator.</param>
        /// <returns></returns>
        public RestResult<User> ReplaceTheModeratorsOfAChannel(string channel_id, string user_uri)
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) => p.Add("user_uri", user_uri))
            .Patch<User>();

        #endregion

        #region [ Private channel members ]

        /// <summary>
        /// This method returns all the users who have access to the specified private channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">	The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<Pagination<User>> GetAllTheUsersWhoCanAccessAPrivateChannel(string channel_id,
            ChannelDirection? direction = null,
            int? page = null,
            int? per_page = null) => RootAuthorization()
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
            .Get<Pagination<User>>();

        /// <summary>
        /// This method gives multiple users access to the specified private channel. The authenticated user must be the owner of the channel
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="users">The array of either the user URIs or the user IDs to permit to access the private channel.</param>
        /// <returns></returns>
        public RestResult<VimeoList<User>> PermitAListOfUsersToAccessAPrivateChannel(int channel_id, User[] users) => RootAuthorization()
            .Command($"/channels/{channel_id}/privacy/users")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) =>
            {
                foreach (User u in users)
                {
                    p.Add("users[]", "");
                }
            })
            .Put<VimeoList<User>>();

        /// <summary>
        /// This method gives a single user access to the specified private channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<User> PermitASpecificUserToAccessAPrivateChannel(string channel_id, string user_id) => RootAuthorization()
            .Command($"/channels/{channel_id}/privacy/users/{user_id}")
            .Put<User>();

        /// <summary>
        /// This method prevents a single user from being able to access the specified private channel. 
        /// The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 204 No Content	The user can't acceess the private channel.
        /// 401 Unauthorized Error code 8003: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the channel.
        /// </returns>
        public RestResult RestrictAUserFromAccessingAPrivateChannel(string channel_id, string user_id) => RootAuthorization()
            .Command($"/channels/{channel_id}/privacy/users/{user_id}")
            .Delete();

        #endregion

        #region [ Subscriptions and subscribers ]

        /// <summary>
        /// This method determines whether the specified user is a follower of a particular channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns>
        /// 204 No Content	The user follows the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public RestResult CheckIfAUserFollowsAChannel(string channel_id, string user_id) => RootAuthorization()
            .Command($"/users/{user_id}/channels/{channel_id}")
            .Get();

        /// <summary>
        /// This method determines whether the specified user is a follower of a particular channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult CheckIfAUserFollowsAChannel(string channel_id) => RootAuthorization()
            .Command($"/me/channels/{channel_id}")
            .Get();

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
        /// <returns></returns>
        public RestResult<Pagination<User>> GetAllTheFollowersOfAChannel(string channel_id,
            ChannelFollowersOfAChannelFilter filter,
            ChannelDirection? direction,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortAllModerators? sort = null) => RootAuthorization()
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
            .Get<Pagination<User>>();

        /// <summary>
        /// This method subscribes the authenticated user to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns>
        /// 204 No Content	The user is subscribed to the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public RestResult SubscribeTheUserToASpecificChannel(string channel_id, string user_id) => RootAuthorization()
            .Command($"/users/{user_id}/channels/{channel_id}")
            .Put();

        /// <summary>
        /// This method subscribes the authenticated user to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns>
        /// 204 No Content	The user is unsubscribed from the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public RestResult SubscribeTheUserToASpecificChannel(string channel_id) => RootAuthorization()
            .Command($"/me/channels/{channel_id}")
            .Put();

        /// <summary>
        /// This method unsubscribes the authenticated user from the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns>
        /// 204 No Content	The user is unsubscribed from the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public RestResult UnsubscribeTheUserFromASpecificChannel(string channel_id, string user_id) => RootAuthorization()
            .Command($"/users/{user_id}/channels/{channel_id}")
            .Delete();

        /// <summary>
        /// This method unsubscribes the authenticated user from the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns>
        /// 204 No Content	The user is unsubscribed from the channel.
        /// 404 Not Found   No such channel exists.
        /// </returns>
        public RestResult UnsubscribeTheUserFromASpecificChannel(string channel_id) => RootAuthorization()
           .Command($"/me/channels/{channel_id}")
           .Delete();

        #endregion

        #region [ Tags ]

        /// <summary>
        /// This method adds multiple tags to the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">channel_id</param>
        /// <param name="tags">An array of tags to assign.</param>
        /// <returns></returns>
        public RestResult<VimeoList<Tag>> AddAListOfTagsToAChannel(string channel_id, Tag[] tags) => throw new NotImplementedException();

        /// <summary>
        /// This method adds a single tag to the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel </param>
        /// <param name="word">The word to use as the tag. </param>
        /// <returns></returns>
        public RestResult<Tag> AddASpecificTagToAChannel(string channel_id, string word) => throw new NotImplementedException();

        /// <summary>
        /// This method determines whether a tag has been added to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="word">The word to use as the tag.</param>
        /// <returns>
        /// 204 No Content	The tag has been added to the channel.
        /// 400 Bad Request No such tag exists.
        /// 404 Not Found   Error code 5000: The tag exists, but the channel isn't tagged by it.
        /// </returns>
        public RestResult CheckIfATagHasBeenAddedToAChannel(string channel_id, string word) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every tag that has been added to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<VimeoList<Tag>> GetAllTheTagsThatHaveBeenAddedToAChannel(string channel_id) => throw new NotImplementedException();

        /// <summary>
        /// This method removes a single tag from the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="word">The word to use as the tag</param>
        /// <returns>
        /// 204 No Content	The tag was removed.
        /// 400 Bad Request The tag is invalid, or a parameter is invalid.
        /// 401 Unauthorized Error code 8003: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't remove tags from this channel.
        /// </returns>
        public RestResult<string> RemoveATagFromAChannel(string channel_id, string word) => throw new NotImplementedException();

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method adds multiple videos to the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="tags">
        /// A member of an array representing the URIs of the videos to add. 
        /// For each member in the array, use the format {"video_uri":"x"} where x is a video URI. 
        /// For more information on batch requests like this, 
        /// see Using Common Formats and Parameters.
        /// </param>
        /// <returns>
        /// 200 OK	The videos were added.
        /// 403 Forbidden The authenticated user can't add videos to the channel, or a video can't be added to the channel.
        /// 404 Not Found   No such channel or user exist.
        /// </returns>
        public RestResult AddAListOfVideosToAChannel(string channel_id, Video[] tags) => throw new NotImplementedException();

        /// <summary>
        /// This method adds a single video to the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// 403 Forbidden The video can't be added to a channel, or the authenticated user can't add videos to this channel.
        /// 404 Not Found   No such channel or video exists.
        /// </returns>
        public RestResult AddASpecificVideoToAChannel(string channel_id, string video_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns a single video in the specified channel. You can use it to determine whether the video is in the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">	The ID of the video.</param>
        /// <returns></returns>
        public RestResult<Video> GetASpecificVideoInAChannel(string channel_id, string video_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every channel to which the authenticated user can add or remove the specified video. 
        /// The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public RestResult<VimeoList<Channel>> GetAllTheChannelsToWhichTheUserCanAddOrRemoveASpecificVideo(string video_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every video in the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<Pagination<Video>> GetAllTheVideosInAChannel(string channel_id,
            string containing_uri = null,
            ChannelDirection? direction = null,
            ChannelFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllVideos? sort = null) => throw new NotImplementedException();

        /// <summary>
        /// This method removes multiple videos from the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_uri">The URI of a video to remove.</param>
        /// <returns></returns>
        public RestResult RemoveAListOfVideosFromAChannel(string channel_id, string video_uri) => throw new NotImplementedException();

        /// <summary>
        /// This method removes a single video from the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public RestResult RemoveASpecificVideoFromAChannel(string channel_id, string video_id) => throw new NotImplementedException();

        #endregion
    }
}