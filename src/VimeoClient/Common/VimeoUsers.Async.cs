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
    using Mafesoft.VimeoClient.Body;
    using Mafesoft.VimeoClient.Filter.User;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoUsers.
    public partial class VimeoUsers
    {
        #region [ ESSENTIALS ]

        /// <summary>
        /// This method edits the Vimeo account of the authenticated user.
        /// PATCH https://api.vimeo.com/users/{user_id}
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public virtual Task<RestResult<User>> EditTheUserAsync(int user_id, UserEditParameters body) => RootUserAuthorization()
            .Command(user_id)
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
            .PatchAsync<User>();

        /// <summary>
        /// This method returns the authenticated user.
        /// GET https://api.vimeo.com/users/{user_id}
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual Task<RestResult<User>> GetTheUserAsync(int userId) => RootUserAuthorization()
          .Command(userId)
          .GetAsync<User>();

        #endregion

        #region [ FEEDS ]

        /// <summary>
        /// This method returns every video in the authenticated user's feed.
        /// GET https://api.vimeo.com/users/{user_id}/feed
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual Task<RestResult<Activity>> GetAllTheVideosInTheUserFeedAsync(int user_id) => RootUserAuthorization()
            .Command($"/{user_id}/feed")
            .GetAsync<Activity>();

        /// <summary>
        /// This method returns every video in the authenticated user's feed.
        /// GET https://api.vimeo.com/users/{user_id}/feed
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="offset"></param>
        /// <param name="page"></param>
        /// <param name="per_page"></param>
        /// <returns></returns>
        public virtual Task<RestResult<Activity>> GetAllTheVideosInTheUserFeedAsync(int user_id, string offset, string page, string per_page) => RootUserAuthorization()
            .Command($"/{user_id}/feed")
            .Parameter("offset", offset)
            .Parameter("page", page)
            .Parameter("per_page", per_page)
            .GetAsync<Activity>();

        #endregion

        #region [ FOLLOERS ]

        /// <summary>
        /// This method determines whether the authenticated user is a follower of the specified user.
        /// GET https://api.vimeo.com/users/{user_id}/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> CheckIfTheUserIsFollowingAnotherUserAsync(int follow_user_id, int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Command(follow_user_id)
            .GetAsync();

        /// <summary>
        /// This method causes the authenticated user to become the follower of multiple users. 
        /// In the body of the request, specify the list of users to follow asan array of URIs, 
        /// where user01_id, user02_id, user03_id, and so on, are the user IDs of the users in question:
        /// </summary>
        /// <returns></returns>
        public virtual Task<RestResult<string>> FollowAListOfUsersAsync(int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .PostAsync();

        /// <summary>
        /// This method causes the authenticated user to become the follower of the specified user.
        /// PUT https://api.vimeo.com/users/{user_id}/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> FollowASpecificUserAsync(int follow_user_id, int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Command(follow_user_id)
            .PutAsync();

        /// <summary>
        /// This method returns every follower of the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual Task<RestResult<User>> GetAllTheFollowersOfTheUserAsync(int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/followers")
            .GetAsync<User>();

        /// <summary>
        /// This method returns every follower of the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
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
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<User>>> GetAllTheFollowersOfTheUserWithPagingAsync(int user_id,
            UserDirection? direction,
            int? page,
            int? per_page,
            string query,
            UserSort? sort)
        {
            var builder = RootUserAuthorization()
                .Command(user_id)
                .Command("/followers");

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

            var result = await builder.GetAsync<Pagination<User>>().ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method returns every user that the authenticated user is following.
        /// GET https://api.vimeo.com/users/{user_id}/following
        /// </summary>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<User>>> GetAllTheUsersThatTheUserIsFollowingAsync(int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .GetAsync<Pagination<User>>();

        /// <summary>
        /// This method returns every follower of the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
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
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<User>>> GetAllTheUsersThatTheUserIsFollowingAsync(int user_id,
            UserDirection? direction,
            string filter,
            int? page,
            int? per_page,
            string query,
            UserSort? sort)
        {
            var builder = RootUserAuthorization()
                .Command(user_id)
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

            var result = await builder.GetAsync<Pagination<User>>().ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        /// <summary>
        /// This method causes the authenticated user to stop following another user.
        /// DELETE https://api.vimeo.com/users/{user_id}/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> UnfollowAUserAsync(int follow_user_id, int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Command(follow_user_id)
            .DeleteAsync();

        #endregion

        #region [ PICTURES ]

        /// <summary>
        /// This method adds a portrait image to the authenticated user's Vimeo account. 
        /// Send the binary data of the image file to the location that you receivefrom the link field in the response. 
        /// For step-by-step instructions, seeWorking with Thumbnail Uploads.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="image"></param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> AddPictureToTheUserAccountAsync(int user_id, byte[] image) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .Payload(image)
            .PostAsync<Picture>();

        /// <summary>
        /// This method removes the specified portrait image from the authenticated user's Vimeo account.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="portraitset_id"></param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> DeletePictureFromTheUserAccountAsync(int user_id, int portraitset_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .Command(portraitset_id)
            .DeleteAsync();

        /// <summary>
        /// This method edits the specified portrait image belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="portraitset_id"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> EditPictureInTheUserAaccountAsync(int user_id, int portraitset_id, bool active) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .Command(portraitset_id)
            .Parameter("active", active)
            .PatchAsync<Picture>();

        /// <summary>
        /// This method returns a single portrait image belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="portraitset_id"></param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> GetSpecificPictureThatBelongsToTheUserAsync(int user_id, int portraitset_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .Command(portraitset_id)
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns every portrait image belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllThePicturesThatBelongToTheUserAsync(int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .GetAsync<Pagination<Picture>>();

        #endregion

        #region [ LMS ]

        /// <summary>
        /// This method creates and returns a zipped proxy package of the course associated with the specified video,
        /// suitable for direct upload to a learning management system.
        /// GET https://api.vimeo.com/users/{user_id}/lms/download/{video_id}
        /// </summary>
        /// <param name="user_id">The ID of the team owner.</param>
        /// <param name="video_id">The ID of the course video.</param>
        /// <param name="standard">The LMS standard used to create the package: aicc, cmi5, scorm12, scorm2004_3rd, tincan.</param>
        /// <param name="course_title">The title of the course.</param>
        /// <param name="scoring_algorithm">The scoring algorithm for the course: passfail, percentage, quiz.</param>
        /// <param name="passing_score">The passing score for the course.</param>
        /// <param name="completion_threshold">The completion threshold for the course.</param>
        /// <returns>
        /// 200 OK	The zipped proxy package was created and returned (raw bytes of the zip file).
        /// </returns>
        public virtual Task<RestResult<byte[]>> DownloadAnLmsPackageForAVideoAsync(int user_id, int video_id,
            string standard = null,
            string course_title = null,
            string scoring_algorithm = null,
            double? passing_score = null,
            double? completion_threshold = null) => RootAuthorization()
            .Command($"/users/{user_id}/lms/download/{video_id}")
            .OptionalParameter("standard", standard)
            .OptionalParameter("course_title", course_title)
            .OptionalParameter("scoring_algorithm", scoring_algorithm)
            .OptionalParameter("passing_score", passing_score)
            .OptionalParameter("completion_threshold", completion_threshold)
            .GetAsync<byte[]>();

        #endregion

        #region [ SEARCH ]

        /// <summary>
        /// This method returns user search results.
        /// </summary>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual async Task<RestResult<Pagination<User>>> SearchForUsersAsync(UserDirection? direction = null, string query = null, UserSort? sort = null, int? page = null, int? per_page = null)
        {
            var root = RootUserAuthorization();

            if (direction != null)
            {
                root = root.Parameter("direction", direction);
            }
            if (!string.IsNullOrEmpty(query))
            {
                root = root.Parameter("query", query);
            }
            if (sort != null)
            {
                root = root.Parameter("sort", sort);
            }

            if (page > 0)
            {
                root = root.Parameter("page", page);
            }
            if (per_page > 0)
            {
                root = root.Parameter("per_page", per_page);
            }

            var result = await root.GetAsync<Pagination<User>>().ConfigureAwait(false);

            return result.WithNavigation(RootAuthorization);
        }

        #endregion
    }
}
