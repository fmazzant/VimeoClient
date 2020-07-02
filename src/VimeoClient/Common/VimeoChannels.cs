namespace VimeoClient.Common
{
    using RestClient;
    using RestClient.Generic;
    using System;
    using VimeoClient.Filter.Channel;
    using VimeoClient.Body.Channel;
    using VimeoClient.Response;

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

        #region [Categories]

        public RestResult<string> AddAChannelToAListOfCategories(int channel_id, Channel[] channels) => throw new NotImplementedException();
        public RestResult<string> AddAChannelToASpecificCategory(string category, int channel_id) => throw new NotImplementedException();
        public RestResult<string> GetAllTheCategoriesToWhichAChannelBelongs(int channel_id) => throw new NotImplementedException();
        public RestResult<string> RemoveAChannelFromACategory(string category, int channel_id) => throw new NotImplementedException();

        #endregion

        #region [ Moderators]

        public RestResult<string> AddAListOfModeratorsToAChannel() => throw new NotImplementedException();
        public RestResult<string> AddASpecificModeratorToAChannel() => throw new NotImplementedException();
        public RestResult<string> GetASpecificModeratorOfAChannel() => throw new NotImplementedException();
        public RestResult<string> GetAllTheModeratorsOfAChannel() => throw new NotImplementedException();
        public RestResult<string> RemoveAListOfModeratorsFromAChannel() => throw new NotImplementedException();
        public RestResult<string> RemoveASpecificModeratorFromAChannel() => throw new NotImplementedException();
        public RestResult<string> ReplaceTheModeratorsOfAChannel() => throw new NotImplementedException();

        #endregion

        #region [ Private channel members]

        public RestResult<string> GetAllTheUsersWhoCanAccessAPrivateChannel() => throw new NotImplementedException();
        public RestResult<string> PermitAListOfUsersToAccessAPrivateChannel() => throw new NotImplementedException();
        public RestResult<string> PermitASpecificUserToAccessAPrivateChannel() => throw new NotImplementedException();
        public RestResult<string> RestrictAUserFromAccessingAPrivateChannel() => throw new NotImplementedException();

        #endregion

        #region [ Subscriptions and subscribers]

        public RestResult<string> CheckIfAUserFollowsAChannel() => throw new NotImplementedException();
        public RestResult<string> GetAllTheFollowersOfAChannel() => throw new NotImplementedException();
        public RestResult<string> SubscribeTheUserToASpecificChannel() => throw new NotImplementedException();
        public RestResult<string> UnsubscribeTheUserFromASpecificChannel() => throw new NotImplementedException();

        #endregion

        #region [ Tags]

        public RestResult<string> AddAListOfTagsToAChannel() => throw new NotImplementedException();
        public RestResult<string> AddASpecificTagToAChannel() => throw new NotImplementedException();
        public RestResult<string> CheckIfATagHasBeenAddedToAChannel() => throw new NotImplementedException();
        public RestResult<string> GetAllTheTagsThatHaveBeenAddedToAChannel() => throw new NotImplementedException();
        public RestResult<string> RemoveATagFromAChannel() => throw new NotImplementedException();

        #endregion

        #region [ Videos]

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