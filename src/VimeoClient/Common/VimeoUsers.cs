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
    using VimeoClient.Body;
    using VimeoClient.Filter.User;
    using VimeoClient.Model;

    /// <summary>
    /// These are the most common methods for working with users.
    /// https://developer.vimeo.com/api/reference/users
    /// </summary>
    public class VimeoUsers
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
        public VimeoUsers(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoUsers(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        /// <summary>
        /// Root User Authorization
        /// </summary>
        /// <returns></returns>
        protected RestBuilder RootUserAuthorization() => RootAuthorization().Command("/users");

        #region [ ESSENTIALS ]

        /// <summary>
        /// This method edits the Vimeo account of the authenticated user.
        /// PATCH https://api.vimeo.com/users/{user_id}
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public virtual RestResult<string> EditTheUser(int user_id, UserEditParameters body) => RootUserAuthorization()
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
            .Patch();

        /// <summary>
        /// This method returns the authenticated user.
        /// GET https://api.vimeo.com/users/{user_id}
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public virtual RestResult<User> GetTheUser(int userId) => RootUserAuthorization()
          .Command(userId)
          .Get<User>();
        #endregion

        #region [ FEEDS ]

        /// <summary>
        /// This method returns every video in the authenticated user's feed.
        /// GET https://api.vimeo.com/users/{user_id}/feed
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual RestResult<string> GetAllTheVideosInTheUserFeed(int user_id) => RootUserAuthorization()
            .Command($"/{user_id}/feed")
            .Get();

        /// <summary>
        /// This method returns every video in the authenticated user's feed.
        /// GET https://api.vimeo.com/users/{user_id}/feed
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="offset"></param>
        /// <param name="page"></param>
        /// <param name="per_page"></param>
        /// <returns></returns>
        public virtual RestResult<string> GetAllTheVideosInTheUserFeed(int user_id, string offset, string page, string per_page) => RootUserAuthorization()
            .Command($"/{user_id}/feed")
            .Parameter("offset", offset)
            .Parameter("page", page)
            .Parameter("per_page", per_page)
            .Get();
        #endregion

        #region[ FOLLOERS ]

        /// <summary>
        /// This method determines whether the authenticated user is a follower of the specified user.
        /// GET https://api.vimeo.com/users/{user_id}/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual RestResult<string> CheckIfTheUserIsFollowingAnotherUser(int follow_user_id, int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Command(follow_user_id)
            .Get();

        /// <summary>
        /// This method causes the authenticated user to become the follower of multiple users. 
        /// In the body of the request, specify the list of users to follow asan array of URIs, 
        /// where user01_id, user02_id, user03_id, and so on, are the user IDs of the users in question:
        /// </summary>
        /// <returns></returns>
        public virtual RestResult<string> FollowAListOfUsers(int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Post();

        /// <summary>
        /// This method causes the authenticated user to become the follower of the specified user.
        /// PUT https://api.vimeo.com/users/{user_id}/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual RestResult<string> FollowASpecificUser(int follow_user_id, int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Command(follow_user_id)
            .Put();

        /// <summary>
        /// This method returns every follower of the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual RestResult<string> GetAllTheFollowersOfTheUser(int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/followers")
            .Get();

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
        /// <returns></returns>
        public virtual RestResult<string> GetAllTheFollowersOfTheUserWithPaging(int user_id,
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

            return builder.Get();
        }


        /// <summary>
        /// This method returns every user that the authenticated user is following.
        /// GET https://api.vimeo.com/users/{user_id}/following
        /// </summary>
        /// <returns></returns>
        public virtual RestResult<string> GetAllTheUsersThatTheUserIsFollowing(int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Get();

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
        /// <returns></returns>
        public virtual RestResult<string> GetAllTheUsersThatTheUserIsFollowing(int user_id,
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

            return builder.Get();
        }

        /// <summary>
        /// This method causes the authenticated user to stop following another user.
        /// DELETE https://api.vimeo.com/users/{user_id}/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public virtual RestResult<string> UnfollowAUser(int follow_user_id, int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Command(follow_user_id)
            .Delete();

        #endregion

        #region [ PICTURES ]

        /// <summary>
        /// This method adds a portrait image to the authenticated user's Vimeo account. 
        /// Send the binary data of the image file to the location that you receivefrom the link field in the response. 
        /// For step-by-step instructions, seeWorking with Thumbnail Uploads.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public virtual RestResult<string> AddPictureToTheUserAccount(int user_id, byte[] image) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .Payload(image)
            .Post();


        /// <summary>
        /// This method removes the specified portrait image from the authenticated user's Vimeo account.
        /// </summary>
        /// <param name="portraitset_id"></param>
        /// <returns></returns>
        public virtual RestResult<string> DeletePictureFromTheUserAccount(int user_id, int portraitset_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .Command(portraitset_id)
            .Delete();

        /// <summary>
        /// This method edits the specified portrait image belonging to the authenticated user.
        /// </summary>
        /// <param name="portraitset_id"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public virtual RestResult<string> EditPictureInTheUserAaccount(int user_id, int portraitset_id, bool active) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .Command(portraitset_id)
            .Parameter("active", active)
            .Patch();

        /// <summary>
        /// This method returns a single portrait image belonging to the authenticated user.
        /// </summary>
        /// <param name="portraitset_id"></param>
        /// <returns></returns>
        public virtual RestResult<string> GetSpecificPictureThatBelongsToTheUser(int user_id, int portraitset_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .Command(portraitset_id)
            .Get();

        /// <summary>
        /// This method returns every portrait image belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public virtual RestResult<string> GetAllThePicturesThatBelongToTheUser(int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/pictures")
            .Get();

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
        public virtual RestResult<string> SearchForUsers(UserDirection? direction = null, string query = null, UserSort? sort = null, int? page = null, int? per_page = null)
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
                root = root.Parameter("sort", direction);
            }

            if (page > 0)
            {
                root = root.Parameter("page", page);
            }
            if (per_page > 0)
            {
                root = root.Parameter("per_page", per_page);
            }

            return root.Get();
        }

        #endregion
    }
}