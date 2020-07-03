namespace VimeoClient.Common
{
    using RestClient;
    using RestClient.Generic;
    using System;
    using VimeoClient.Filter.Channel;
    using VimeoClient.Body.Channel;
    using VimeoClient.Response;
    using System.Collections.Generic;

    /// <summary>
    /// Use channels to organize videos by theme or some other grouping. 
    /// You can incorporate your own videos as well as videos from other Vimeo members on any channel that you create. 
    /// Vimeo Basic subscribers get one channel, while paid Vimeo members can have an unlimited number. 
    /// See our Help Center for more details.
    /// </summary>
    public class VimeoChannels
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
        /// Create an instance of VimeoChannels
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="rootAuthorization"></param>
        public VimeoChannels(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
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
        /// </param>
        /// <param name="description"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public RestResult<string> CreateAChannel(ChannelEditParameters obj)
            => RootAuthorization
            .Command($"/channels")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                foreach (var item in obj.ToEnumerable())
                    pars.Add(item.Key, item.Value);
            })
            .Post();

        /// <summary>
        /// This method deletes the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns></returns>
        public RestResult<string> DeleteAChannel(int channel_id) => RootAuthorization
            .Command($"/channels/{channel_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified channel.
        /// </summary>
        /// <param name="channel_id"> The ID of the channel.</param>
        /// <param name="obj">The channel.</param>
        /// <returns></returns>
        public RestResult<string> EditAChannel(int channel_id, ChannelEditParameters obj) => RootAuthorization
            .Command($"/channels/{channel_id}")
             .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                foreach (var item in obj.ToEnumerable())
                    pars.Add(item.Key, item.Value);
            })
            .Patch();

        /// <summary>
        /// This method returns a single channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns></returns>
        public RestResult<string> GetASpecificChannel(int channel_id) => RootAuthorization
            .Command($"/channels/{channel_id}")
            .Get();

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
        public RestResult<string> GetAllChannels(ChannelDirection? direction,
            ChannelFilter? filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllChannel? sort = null)
        {
            var root = RootAuthorization
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

            return root.Get();
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
        public RestResult<string> GetAllTheChannelsToWhichAUserSubscribes(int user_id,
            ChannelDirection? direction,
            ChannelFilter? filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllChannelSubscribe? sort = null)
        {
            var root = RootAuthorization
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

            return root.Get();
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
        public RestResult<string> GetAllTheChannelsToWhichAUserSubscribes(ChannelDirection? direction,
            ChannelFilter? filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortGetAllChannelSubscribe? sort = null)
        {
            var root = RootAuthorization
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

            return root.Get();
        }

        #endregion

        #region [Categories ]

        /// <summary>
        /// This method adds the specified channel to multiple categories
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="channels">The array of category URIs to add.</param>
        /// <returns></returns>
        public RestResult<string> AddAChannelToAListOfCategories(int channel_id, Category[] channels) => RootAuthorization
            .Command($"/channels/{channel_id}/categories")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) =>
            {
                foreach (Category cat in channels)
                    p.Add("channels[]", "");
            })
            .Put();

        /// <summary>
        /// This method adds the specified channel to a single category. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> AddAChannelToASpecificCategory(string category, int channel_id) => RootAuthorization
            .Command($"/channels/{channel_id}/categories/{category}")
            .Put();

        /// <summary>
        /// This method returns every category to which the specified channel belongs.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheCategoriesToWhichAChannelBelongs(int channel_id) => RootAuthorization
            .Command($"/channels/{channel_id}/categories")
            .Get();

        /// <summary>
        /// This method removes a channel from the specified category. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> RemoveAChannelFromACategory(string category, int channel_id) => RootAuthorization
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
        /// <returns></returns>
        public RestResult<string> AddAListOfModeratorsToAChannel(int channel_id, string user_uri) => RootAuthorization
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
        public RestResult<string> AddASpecificModeratorToAChannel(int channel_id, int user_id) => RootAuthorization
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .Put();

        /// <summary>
        /// This method returns a single moderator of the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns></returns>
        public RestResult<string> GetASpecificModeratorOfAChannel(int channel_id, int user_id) => RootAuthorization
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .Get();

        /// <summary>
        /// This method returns every moderator of the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheModeratorsOfAChannel(int channel_id,
            ChannelDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSortAllModerators? sort = null) => RootAuthorization
               .Command($"/channels/{channel_id}/moderators")
               .Parameter((p) =>
               {
                   if (direction.HasValue) p.Add(new RestParameter { Key = "direction", Value = direction });
                   if (!string.IsNullOrEmpty(query)) p.Add(new RestParameter { Key = "query", Value = query });
                   if (sort.HasValue) p.Add(new RestParameter { Key = "sort", Value = sort });
                   if (page.HasValue) p.Add(new RestParameter { Key = "page", Value = page });
                   if (per_page.HasValue) p.Add(new RestParameter { Key = "per_page", Value = per_page });
               })
            .Get();

        /// <summary>
        /// This method removes multiple moderators from the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_uri">The URI of a user to remove as a moderator.</param>
        /// <returns></returns>
        public RestResult<string> RemoveAListOfModeratorsFromAChannel(int channel_id, string user_uri) => RootAuthorization
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
        /// <returns></returns>
        public RestResult<string> RemoveASpecificModeratorFromAChannel(int channel_id, int user_id) => RootAuthorization
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .Delete();

        /// <summary>
        /// This method replaces the current list of channel moderators with a new list. 
        /// The authenticated user must be the owner of the channel and a follower of each requested user to add them as a channel moderator.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_uri">The URI of the user to add as a moderator.</param>
        /// <returns></returns>
        public RestResult<string> ReplaceTheModeratorsOfAChannel(int channel_id, string user_uri) => RootAuthorization
            .Command($"/channels/{channel_id}/moderators")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) => p.Add("user_uri", user_uri))
            .Patch();

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
        public RestResult<string> GetAllTheUsersWhoCanAccessAPrivateChannel(int channel_id,
            ChannelDirection? direction = null,
            int? page = null,
            int? per_page = null) => RootAuthorization
            .Command($"/channels/{channel_id}/privacy/users")
            .Parameter((p) =>
            {
                if (direction.HasValue) p.Add(new RestParameter { Key = "direction", Value = direction });
                if (page.HasValue) p.Add(new RestParameter { Key = "page", Value = page });
                if (per_page.HasValue) p.Add(new RestParameter { Key = "per_page", Value = per_page });
            })
            .Get();

        /// <summary>
        /// This method gives multiple users access to the specified private channel. The authenticated user must be the owner of the channel
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="users">The array of either the user URIs or the user IDs to permit to access the private channel.</param>
        /// <returns></returns>
        public RestResult<string> PermitAListOfUsersToAccessAPrivateChannel(int channel_id, User[] users) => RootAuthorization
            .Command($"/channels/{channel_id}/privacy/users")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) =>
            {
                foreach (User u in users)
                    p.Add("users[]", "");
            })
            .Put();

        /// <summary>
        /// This method gives a single user access to the specified private channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<string> PermitASpecificUserToAccessAPrivateChannel(int channel_id, int user_id) => RootAuthorization
            .Command($"/channels/{channel_id}/privacy/users/{user_id}")
            .Put();

        /// <summary>
        /// This method prevents a single user from being able to access the specified private channel. 
        /// The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<string> RestrictAUserFromAccessingAPrivateChannel(int channel_id, int user_id) => RootAuthorization
            .Command($"/channels/{channel_id}/privacy/users/{user_id}")
            .Delete();

        #endregion

        #region [ Subscriptions and subscribers ]

        /// <summary>
        /// This method determines whether the specified user is a follower of a particular channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns></returns>
        public RestResult<string> CheckIfAUserFollowsAChannel(int channel_id, int user_id) => RootAuthorization
            .Command($"/users/{user_id}/channels/{channel_id}")
            .Get();

        /// <summary>
        /// This method determines whether the specified user is a follower of a particular channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> CheckIfAUserFollowsAChannel(int channel_id) => RootAuthorization
            .Command($"/me/channels/{channel_id}")
            .Get();

        public RestResult<string> GetAllTheFollowersOfAChannel(int channel_id) => throw new NotImplementedException();

        /// <summary>
        /// This method subscribes the authenticated user to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns></returns>
        public RestResult<string> SubscribeTheUserToASpecificChannel(int channel_id, int user_id) => RootAuthorization
            .Command($"/users/{user_id}/channels/{channel_id}")
            .Put();

        /// <summary>
        /// This method subscribes the authenticated user to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns></returns>
        public RestResult<string> SubscribeTheUserToASpecificChannel(int channel_id) => RootAuthorization
            .Command($"/me/channels/{channel_id}")
            .Put();

        /// <summary>
        /// This method unsubscribes the authenticated user from the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns></returns>
        public RestResult<string> UnsubscribeTheUserFromASpecificChannel(int channel_id, int user_id) => RootAuthorization
            .Command($"/users/{user_id}/channels/{channel_id}")
            .Delete();

        /// <summary>
        /// This method unsubscribes the authenticated user from the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns></returns>
        public RestResult<string> UnsubscribeTheUserFromASpecificChannel(int channel_id) => RootAuthorization
           .Command($"/me/channels/{channel_id}")
           .Delete();

        #endregion

        #region [ Tags ]

        public RestResult<string> AddAListOfTagsToAChannel() => throw new NotImplementedException();
        public RestResult<string> AddASpecificTagToAChannel() => throw new NotImplementedException();
        public RestResult<string> CheckIfATagHasBeenAddedToAChannel() => throw new NotImplementedException();
        public RestResult<string> GetAllTheTagsThatHaveBeenAddedToAChannel() => throw new NotImplementedException();
        public RestResult<string> RemoveATagFromAChannel() => throw new NotImplementedException();

        #endregion

        #region [ Videos ]

        public RestResult<string> AddAListOfVideosToAChannel() => throw new NotImplementedException();
        public RestResult<string> AddASpecificVideoToAChannel() => throw new NotImplementedException();
        public RestResult<string> GetASpecificVideoInAChannel() => throw new NotImplementedException();
        public RestResult<string> GetAllTheChannelsToWhichTheUserCanAddOrRemoveASpecificVideo() => throw new NotImplementedException();
        public RestResult<string> GetAllTheVideosInAChannel() => throw new NotImplementedException();
        public RestResult<string> RemoveAListOfVideosFromAChannel() => throw new NotImplementedException();
        public RestResult<string> RemoveASpecificVideoFromAChannel() => throw new NotImplementedException();

        #endregion
    }
}