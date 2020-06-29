namespace VimeoClient.Common
{
    using RestClient;
    using RestClient.Generic;
    using VimeoClient.Bodies;
    using VimeoClient.Response;

    /// <summary>
    /// These are the most common methods for working with users.
    /// </summary>
    public class VimeoUsers : Vimeo
    {
        //https://developer.vimeo.com/api/reference/users

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        public VimeoUsers(VimeoProperties properties)
           : base(properties) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected RestBuilder RootUserAuthorization() => RootAuthorization().Command("/users");

        #region[ESSENTIALS]

        /// <summary>
        /// This method edits the Vimeo account of the authenticated user.
        /// PATCH https://api.vimeo.com/users/{user_id}
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public RestResult<string> EditTheUser(int user_id, UserBody body) => RootUserAuthorization()
            .Command(user_id)
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                pars.Add("available_for_hire", body.available_for_hire);
                pars.Add("bio", body.bio);
                pars.Add("content_filter", body.content_filter);
                pars.Add("gender", body.gender);
                pars.Add("link", body.link);
                pars.Add("name", body.name);
                pars.Add("password", body.password);
                pars.Add("grid", body.grid);
                pars.Add("masonry", body.masonry);
                pars.Add("profile_preferences", body.profile_preferences);
                pars.Add("videos.privacy.add", body.videos_privacy_add);
                pars.Add("videos.privacy.comments", body.videos_privacy_comments);
                pars.Add("anybody", body.anybody);
                pars.Add("contacts", body.contacts);
                pars.Add("nobody", body.nobody);
                pars.Add("videos.privacy.download", body.videos_privacy_download);
                pars.Add("videos.privacy.embed", body.videos_privacy_embed);
                pars.Add("whitelist", body.whitelist);
                pars.Add("videos.privacy.view", body.videos_privacy_view);
                pars.Add("disable", body.disable);
                pars.Add("unlisted", body.unlisted);
                pars.Add("users", body.users);
            })
            .Patch();

        /// <summary>
        /// This method returns the authenticated user.
        /// GET https://api.vimeo.com/users/{user_id}
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public RestResult<string> GetTheUser(int userId) => RootUserAuthorization()
          .Command(userId)
          .Get();
        #endregion

        #region[FEEDS]

        /// <summary>
        /// This method returns every video in the authenticated user's feed.
        /// GET https://api.vimeo.com/users/{user_id}/feed
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public RestResult<string> GetAllTheVideosInTheUserFeed(int user_id) => RootUserAuthorization()
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
        public RestResult<string> GetAllTheVideosInTheUserFeed(int user_id, string offset, string page, string per_page) => RootUserAuthorization()
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
        public RestResult<string> CheckIfTheUserIsFollowingAnotherUser(int follow_user_id, int user_id) => RootUserAuthorization()
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
        public RestResult<string> FollowAListOfUsers(int user_id) => RootUserAuthorization()
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
        public RestResult<string> FollowASpecificUser(int follow_user_id, int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Command(follow_user_id)
            .Put();

        /// <summary>
        /// This method returns every follower of the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public RestResult<string> GetAllTheFollowersOfTheUser(int user_id) => RootUserAuthorization()
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
        public RestResult<string> GetAllTheFollowersOfTheUserWithPaging(int user_id, string direction, int page, int per_page, string query, string sort)
        {
            var builder = RootUserAuthorization()
                .Command(user_id)
                .Command("/followers");

            if (!string.IsNullOrEmpty(direction))
                builder = builder.Parameter("direction", direction);

            if (page > 0)
                builder = builder.Parameter("page", page);

            if (per_page > 0)
                builder = builder.Parameter("per_page", per_page);

            if (!string.IsNullOrEmpty(query))
                builder = builder.Parameter("query", query);

            if (!string.IsNullOrEmpty(sort))
                builder = builder.Parameter("sort", sort);

            return builder.Get();
        }


        /// <summary>
        /// This method returns every user that the authenticated user is following.
        /// GET https://api.vimeo.com/users/{user_id}/following
        /// </summary>
        /// <returns></returns>
        public RestResult<string> GetAllTheUsersThatTheUserIsFollowing(int user_id) => RootUserAuthorization()
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
        public RestResult<string> GetAllTheUsersThatTheUserIsFollowing(int user_id, string direction, string filter, int page, int per_page, string query, string sort)
        {
            var builder = RootUserAuthorization()
                .Command(user_id)
                .Command("/following");

            if (!string.IsNullOrEmpty(direction))
                builder = builder.Parameter("direction", direction);

            if (!string.IsNullOrEmpty(filter))
                builder = builder.Parameter("filter", filter);

            if (page > 0)
                builder = builder.Parameter("page", page);

            if (per_page > 0)
                builder = builder.Parameter("per_page", per_page);

            if (!string.IsNullOrEmpty(query))
                builder = builder.Parameter("query", query);

            if (!string.IsNullOrEmpty(sort))
                builder = builder.Parameter("sort", sort);

            return builder.Get();
        }

        /// <summary>
        /// This method causes the authenticated user to stop following another user.
        /// DELETE https://api.vimeo.com/users/{user_id}/following/{follow_user_id}
        /// </summary>
        /// <param name="follow_user_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public RestResult<string> UnfollowAUser(int follow_user_id, int user_id) => RootUserAuthorization()
            .Command(user_id)
            .Command("/following")
            .Command(follow_user_id)
            .Delete();

        #endregion
    }
}