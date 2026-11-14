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
    using System.Collections.Generic;
    using System.Linq;
    using Mafesoft.VimeoClient.Body;
    using Mafesoft.VimeoClient.Filter.User;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoMe.
    public partial class VimeoMe
    {
        #region [ ESSENTIALS ]

        /// <summary>
        /// This method edits the Vimeo account of the authenticated user.
        /// PATCH https://api.vimeo.com/me
        /// </summary>
        /// <param name="body"></param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<User>> EditTheUserAsync(UserEditParameters body, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                pars.Add("available_for_hire", body.AvailableForHire);
                pars.Add("bio", body.Bio);
                pars.Add("content_filter", body.ContentFilter);
                pars.Add("gender", body.Gender);
                pars.Add("link", body.Link);
                pars.Add("name", body.Name);
                pars.Add("password", body.Password);
                pars.Add("grid", body.Grid);
                pars.Add("masonry", body.Masonry);
                pars.Add("profile_preferences", body.ProfilePreferences);
                pars.Add("videos.privacy.add", body.VideosPrivacyAdd);
                pars.Add("videos.privacy.comments", body.VideosPrivacyComments);
                pars.Add("anybody", body.Anybody);
                pars.Add("contacts", body.Contacts);
                pars.Add("nobody", body.Nobody);
                pars.Add("videos.privacy.download", body.VideosPrivacyDownload);
                pars.Add("videos.privacy.embed", body.VideosPrivacyEmbed);
                pars.Add("whitelist", body.Whitelist);
                pars.Add("videos.privacy.view", body.VideosPrivacyView);
                pars.Add("disable", body.Disable);
                pars.Add("unlisted", body.Unlisted);
                pars.Add("users", body.Users);
            })
            .PatchAsync<User>(cancellationToken);

        /// <summary>
        /// This method returns the authenticated user.
        /// GET https://api.vimeo.com/me
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<User>> GetTheUserAsync(CancellationToken cancellationToken = default) => RootMeAuthorization()
            .GetAsync<User>(cancellationToken);

        #endregion

        #region [ FEEDS ]

        /// <summary>
        /// This method returns every video in the authenticated user's feed.
        /// GET https://api.vimeo.com/me/feed
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Activity>>> GetAllTheVideosInTheUserFeedAsync(CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/feed")
            .GetAsync<VimeoList<Activity>>(cancellationToken);

        /// <summary>
        /// This method returns every video in the authenticated user's feed.
        /// GET https://api.vimeo.com/me/feed
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="page"></param>
        /// <param name="per_page"></param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Activity>>> GetAllTheVideosInTheUserFeedWithPagingAsync(string offset, string page, string per_page, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/feed")
            .Parameter("offset", offset)
            .Parameter("page", page)
            .Parameter("per_page", per_page)
            .GetAsync<VimeoList<Activity>>(cancellationToken);

        #endregion

        #region [ FOLLOWERS ]

        /// <summary>
        /// This method determines whether the authenticated user is a follower of the specified user.
        /// GET https://api.vimeo.com/users/me/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id">The ID of the user to follow.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public Task<RestResult<string>> CheckIfTheUserIsFollowingAnotherUserAsync(int follow_user_id, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/following")
            .Command(follow_user_id)
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method causes the authenticated user to become the follower of multiple users. 
        /// In the body of the request, specify the list of users to follow asan array of URIs, 
        /// where user01_id, user02_id, user03_id, and so on, are the user IDs of the users in question:
        /// </summary>
        /// <returns></returns>
        public virtual Task<RestResult<string>> FollowAListOfUsersAsync(IList<User> users, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/following")
            .FormUrlEncoded(true, (p) =>
            {
                if (users != null)
                    p.Add("users[]", $"{string.Join(",", users.Select(u => u.Uri))}");
            })
            .PostAsync(cancellationToken);

        /// <summary>
        /// This method causes the authenticated user to become the follower of the specified user.
        /// PUT https://api.vimeo.com/me/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id">The ID of the user to follow.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>204 No Content	The user is now following the specified user.</returns>
        public virtual Task<RestResult<string>> FollowASpecificUserAsync(int follow_user_id, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/following")
            .Command(follow_user_id)
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method returns every follower of the authenticated user.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The followers of the authenticated user.</returns>
        public virtual Task<RestResult<Pagination<User>>> GetAllTheFollowersOfTheUserAsync(CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/followers")
            .GetAsync<Pagination<User>>(cancellationToken);

        /// <summary>
        /// This method returns every follower of the authenticated user.
        /// </summary>
        /// <param name="direction">
        /// The sort direction of the results.Option descriptions:
        ///     asc - Sort the results in ascending order.
        ///     desc - Sort the results in descending order.
        ///     asc
        ///     desc
        /// </param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results</param>
        /// <param name="sort">
        /// The way to sort the results.Option descriptions:
        ///     alphabetical - Sort the results alphabetically.
        ///     date - Sort the results by date followed.
        ///     alphabetical
        ///     date
        /// </param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> GetAllTheFollowersOfTheUserWithPagingAsync(UserDirection? direction,
            int? page,
            int? per_page,
            string query,
            UserSort? sort, CancellationToken cancellationToken = default)
        {
            var builder = RootMeAuthorization().Command("/followers");

            if (direction.HasValue)
            {
                builder = builder.Parameter("direction", direction);
            }

            if (page.HasValue)
            {
                builder = builder.Parameter("page", page);
            }

            if (per_page.HasValue)
            {
                builder = builder.Parameter("per_page", per_page);
            }

            if (!string.IsNullOrEmpty(query))
            {
                builder = builder.Parameter("query", query);
            }

            if (sort.HasValue)
            {
                builder = builder.Parameter("sort", sort);
            }

            return builder.GetAsync(cancellationToken);
        }

        /// <summary>
        /// This method returns every user that the authenticated user is following.
        /// GET https://api.vimeo.com/me/following
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public Task<RestResult<string>> GetAllTheUsersThatTheUserIsFollowingAsync(CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/following")
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method returns every follower of the authenticated user.
        /// </summary>
        /// <param name="direction">
        /// The sort direction of the results.Option descriptions:
        ///     asc - Sort the results in ascending order.
        ///     desc - Sort the results in descending order.
        ///     asc
        ///     desc
        /// </param>
        /// <param name="filter">
        /// The attribute by which to filter the results.Option descriptions:
        ///     online - Return users who are currently online.
        ///     online
        /// </param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results</param>
        /// <param name="sort">
        /// The way to sort the results.Option descriptions:
        ///     alphabetical - Sort the results alphabetically.
        ///     date - Sort the results by date followed.
        ///     alphabetical
        ///     date
        /// </param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> GetAllTheUsersThatTheUserIsFollowingAsync(UserDirection? direction,
            string filter,
            int? page,
            int? per_page,
            string query,
            UserSort? sort, CancellationToken cancellationToken = default)
        {
            var builder = RootMeAuthorization()
                .Command("/following");

            if (direction.HasValue)
            {
                builder = builder.Parameter("direction", direction);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                builder = builder.Parameter("filter", filter);
            }

            if (page.HasValue)
            {
                builder = builder.Parameter("page", page);
            }

            if (per_page.HasValue)
            {
                builder = builder.Parameter("per_page", per_page);
            }

            if (!string.IsNullOrEmpty(query))
            {
                builder = builder.Parameter("query", query);
            }

            if (sort.HasValue)
            {
                builder = builder.Parameter("sort", sort);
            }

            return builder.GetAsync(cancellationToken);
        }

        /// <summary>
        /// This method causes the authenticated user to stop following another user.
        /// DELETE https://api.vimeo.com/me/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id">The ID of the user to unfollow.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>204 No Content	The user is no longer following the specified user.</returns>
        public virtual Task<RestResult<string>> UnfollowAUserAsync(int follow_user_id, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/following")
            .Command(follow_user_id)
            .DeleteAsync(cancellationToken);

        #endregion

        #region [ PICTURES ]

        /// <summary>
        /// This method adds a portrait image to the authenticated user's Vimeo account. 
        /// Send the binary data of the image file to the location that you receivefrom the link field in the response. 
        /// For step-by-step instructions, seeWorking with Thumbnail Uploads.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> AddPictureToTheUserAccountAsync(byte[] image, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/pictures")
            .Payload(image)
            .PostAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method removes the specified portrait image from the authenticated user's Vimeo account.
        /// </summary>
        /// <param name="portraitset_id"></param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public Task<RestResult<string>> DeletePictureFromTheUserAccountAsync(int portraitset_id, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/pictures")
            .Command(portraitset_id)
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method edits the specified portrait image belonging to the authenticated user.
        /// </summary>
        /// <param name="portraitset_id"></param>
        /// <param name="active"></param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> EditPictureInTheUserAaccountAsync(int portraitset_id, bool active, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/pictures")
            .Command(portraitset_id)
            .Parameter("active", active)
            .PatchAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns a single portrait image belonging to the authenticated user.
        /// </summary>
        /// <param name="portraitset_id"></param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> GetSpecificPictureThatBelongsToTheUserAsync(int portraitset_id, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/pictures")
            .Command(portraitset_id)
            .GetAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns every portrait image belonging to the authenticated user.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllThePicturesThatBelongToTheUserAsync(CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/pictures")
            .GetAsync<Pagination<Picture>>(cancellationToken);

        #endregion

        #region [ WATCH HISTORY ]

        /// <summary>
        /// This method deletes the specified video from the authenticated user's watch history.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> DeleteSpecificVideoFromTheUserWatchHistoryAsync(int video_id, CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/watched")
            .Command("/videos")
            .Command(video_id)
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method deletes the entire watch history of the authenticated user.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> DeleteTheUserWatchHistoryAsync(CancellationToken cancellationToken = default) => RootMeAuthorization()
            .Command("/watched")
            .Command("/videos")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method returns every video on the authenticated user's watch history.
        /// NOTE: 
        ///     This endpoint is deprecated. Any request to it returns empty data with HTTP status code 200.
        /// </summary>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosThatAUserHasWatchedAsync(int? page = null, int? per_page = null, CancellationToken cancellationToken = default)
        {
            var root = RootMeAuthorization()
                .Command("/watched")
                .Command("/videos");

            if (page.HasValue)
            {
                root = root.Parameter("page", page);
            }

            if (per_page.HasValue)
            {
                root = root.Parameter("per_page", per_page);
            }

            return root.GetAsync<Pagination<Video>>(cancellationToken);
        }

        #endregion
    }
}
