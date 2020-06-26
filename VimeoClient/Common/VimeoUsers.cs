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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public RestResult<string> GetUser(int userId) => RootUserAuthorization()
          .Command(userId)
          .Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public RestResult<string> GetFeedByUserId(int user_id) => RootUserAuthorization()
            .Command($"/{user_id}/feed")
            .Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="offset"></param>
        /// <param name="page"></param>
        /// <param name="per_page"></param>
        /// <returns></returns>
        public RestResult<string> GetFeedByUserId(int user_id, string offset, string page, string per_page) => RootUserAuthorization()
            .Command($"/{user_id}/feed")
            .Parameter("offset", offset)
            .Parameter("page", page)
            .Parameter("per_page", per_page)
            .Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public RestResult<string> Patch(int user_id, UserBody body) => RootUserAuthorization()
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
    }
}