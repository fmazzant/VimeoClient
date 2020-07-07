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
    using VimeoClient.Body.Channel;
    using VimeoClient.Filter.Channel;
    using VimeoClient.Model;

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
        /// </param>
        /// <param name="description"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public RestResult<string> CreateAChannel(ChannelEditParameters obj)
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
            .Post();

        /// <summary>
        /// This method deletes the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns></returns>
        public RestResult<string> DeleteAChannel(int channel_id) 
            => RootAuthorization()
            .Command($"/channels/{channel_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified channel.
        /// </summary>
        /// <param name="channel_id"> The ID of the channel.</param>
        /// <param name="obj">The channel.</param>
        /// <returns></returns>
        public RestResult<string> EditAChannel(int channel_id, ChannelEditParameters obj) 
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
            .Patch();

        /// <summary>
        /// This method returns a single channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns></returns>
        public RestResult<string> GetASpecificChannel(int channel_id) 
            => RootAuthorization()
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
        public RestResult<string> AddAChannelToAListOfCategories(int channel_id, Category[] channels) 
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
        /// <returns></returns>
        public RestResult<string> AddAChannelToASpecificCategory(string category, int channel_id) 
            => RootAuthorization()
            .Command($"/channels/{channel_id}/categories/{category}")
            .Put();

        /// <summary>
        /// This method returns every category to which the specified channel belongs.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheCategoriesToWhichAChannelBelongs(int channel_id) 
            => RootAuthorization()
            .Command($"/channels/{channel_id}/categories")
            .Get();

        /// <summary>
        /// This method removes a channel from the specified category. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> RemoveAChannelFromACategory(string category, int channel_id) 
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
        /// <returns></returns>
        public RestResult<string> AddAListOfModeratorsToAChannel(int channel_id, string user_uri) 
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
        public RestResult<string> AddASpecificModeratorToAChannel(int channel_id, int user_id) 
            => RootAuthorization()
            .Command($"/channels/{channel_id}/moderators/{user_id}")
            .Put();

        /// <summary>
        /// This method returns a single moderator of the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns></returns>
        public RestResult<string> GetASpecificModeratorOfAChannel(int channel_id, int user_id) 
            => RootAuthorization()
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
            .Get();

        /// <summary>
        /// This method removes multiple moderators from the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_uri">The URI of a user to remove as a moderator.</param>
        /// <returns></returns>
        public RestResult<string> RemoveAListOfModeratorsFromAChannel(int channel_id, string user_uri) 
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
        /// <returns></returns>
        public RestResult<string> RemoveASpecificModeratorFromAChannel(int channel_id, int user_id) 
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
        public RestResult<string> ReplaceTheModeratorsOfAChannel(int channel_id, string user_uri) 
            => RootAuthorization()
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
            .Get();

        /// <summary>
        /// This method gives multiple users access to the specified private channel. The authenticated user must be the owner of the channel
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="users">The array of either the user URIs or the user IDs to permit to access the private channel.</param>
        /// <returns></returns>
        public RestResult<string> PermitAListOfUsersToAccessAPrivateChannel(int channel_id, User[] users) => RootAuthorization()
            .Command($"/channels/{channel_id}/privacy/users")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((p) =>
            {
                foreach (User u in users)
                {
                    p.Add("users[]", "");
                }
            })
            .Put();

        /// <summary>
        /// This method gives a single user access to the specified private channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<string> PermitASpecificUserToAccessAPrivateChannel(int channel_id, int user_id) => RootAuthorization()
            .Command($"/channels/{channel_id}/privacy/users/{user_id}")
            .Put();

        /// <summary>
        /// This method prevents a single user from being able to access the specified private channel. 
        /// The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<string> RestrictAUserFromAccessingAPrivateChannel(int channel_id, int user_id) => RootAuthorization()
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
        public RestResult<string> CheckIfAUserFollowsAChannel(int channel_id, int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/channels/{channel_id}")
            .Get();

        /// <summary>
        /// This method determines whether the specified user is a follower of a particular channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> CheckIfAUserFollowsAChannel(int channel_id) => RootAuthorization()
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
        public RestResult<string> GetAllTheFollowersOfAChannel(int channel_id,
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
            .Get();

        /// <summary>
        /// This method subscribes the authenticated user to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns></returns>
        public RestResult<string> SubscribeTheUserToASpecificChannel(int channel_id, int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/channels/{channel_id}")
            .Put();

        /// <summary>
        /// This method subscribes the authenticated user to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns></returns>
        public RestResult<string> SubscribeTheUserToASpecificChannel(int channel_id) => RootAuthorization()
            .Command($"/me/channels/{channel_id}")
            .Put();

        /// <summary>
        /// This method unsubscribes the authenticated user from the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="user_id">The ID of the user</param>
        /// <returns></returns>
        public RestResult<string> UnsubscribeTheUserFromASpecificChannel(int channel_id, int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/channels/{channel_id}")
            .Delete();

        /// <summary>
        /// This method unsubscribes the authenticated user from the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <returns></returns>
        public RestResult<string> UnsubscribeTheUserFromASpecificChannel(int channel_id) => RootAuthorization()
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
        public RestResult<string> AddAListOfTagsToAChannel(int channel_id, Tag[] tags) => throw new NotImplementedException();

        /// <summary>
        /// This method adds a single tag to the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel </param>
        /// <param name="word">The word to use as the tag. </param>
        /// <returns></returns>
        public RestResult<string> AddASpecificTagToAChannel(int channel_id, string word) => throw new NotImplementedException();

        /// <summary>
        /// This method determines whether a tag has been added to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="word">The word to use as the tag.</param>
        /// <returns></returns>
        public RestResult<string> CheckIfATagHasBeenAddedToAChannel(int channel_id, string word) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every tag that has been added to the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheTagsThatHaveBeenAddedToAChannel(int channel_id) => throw new NotImplementedException();

        /// <summary>
        /// This method removes a single tag from the specified channel. The authenticated user must be the owner of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel</param>
        /// <param name="word">The word to use as the tag</param>
        /// <returns></returns>
        public RestResult<string> RemoveATagFromAChannel(int channel_id, string word) => throw new NotImplementedException();

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
        /// <returns></returns>
        public RestResult<string> AddAListOfVideosToAChannel(int channel_id, Video[] tags) => throw new NotImplementedException();

        /// <summary>
        /// This method adds a single video to the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public RestResult<string> AddASpecificVideoToAChannel(int channel_id, int video_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns a single video in the specified channel. You can use it to determine whether the video is in the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">	The ID of the video.</param>
        /// <returns></returns>
        public RestResult<string> GetASpecificVideoInAChannel(int channel_id, int video_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every channel to which the authenticated user can add or remove the specified video. 
        /// The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheChannelsToWhichTheUserCanAddOrRemoveASpecificVideo(int video_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every video in the specified channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <returns></returns>
        public RestResult<string> GetAllTheVideosInAChannel(int channel_id,
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
        public RestResult<string> RemoveAListOfVideosFromAChannel(int channel_id, string video_uri) => throw new NotImplementedException();

        /// <summary>
        /// This method removes a single video from the specified channel. The authenticated user must be a moderator of the channel.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public RestResult<string> RemoveASpecificVideoFromAChannel(int channel_id, int video_id) => throw new NotImplementedException();

        #endregion
    }
}