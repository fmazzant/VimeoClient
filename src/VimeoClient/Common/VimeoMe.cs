namespace VimeoClient.Common
{
    using RestClient;
    using RestClient.Generic;
    using VimeoClient.Bodies;

    /// <summary>
    /// 
    /// </summary>
    public class VimeoMe : Vimeo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        public VimeoMe(VimeoProperties properties)
            : base(properties) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected RestBuilder RootMeAuthorization() => RootAuthorization().Command("/me");

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RestResult<string> Get() => RootMeAuthorization()
            .Get();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RestResult<string> GetFeed() => RootMeAuthorization()
            .Command("/feed")
            .Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="page"></param>
        /// <param name="per_page"></param>
        /// <returns></returns>
        public RestResult<string> GetFeedWithPaging(string offset, string page, string per_page) => RootAuthorization()
            .Command("/me/feed")
            .Parameter("offset", offset)
            .Parameter("page", page)
            .Parameter("per_page", per_page)
            .Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public RestResult<string> Patch(UserBody body) => RootMeAuthorization()
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