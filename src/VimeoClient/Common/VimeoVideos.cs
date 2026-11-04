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
    using System.Collections.Generic;
    using System.Linq;
    using VimeoClient.Body.Video;
    using VimeoClient.Filter.Video;
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// Videos
    /// https://developer.vimeo.com/api/reference/videos
    /// </summary>
    public class VimeoVideos
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
        public VimeoVideos(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoVideos(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        /// <summary>
        /// Builds a form url encoded key/value pair
        /// </summary>
        private static KeyValuePair<string, object> Pair(string key, object value) => new KeyValuePair<string, object>(key, value);

        #region [ Essentials ]

        /// <summary>
        /// This method checks whether the authenticated user owns the specified video.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The user owns the video.
        /// 404 Not Found	The user doesn't own the video.
        /// </returns>
        public virtual RestResult<Video> CheckIfTheUserOwnsAVideo(int user_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}")
            .Get<Video>();

        /// <summary>
        /// This method checks whether the authenticated user owns the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The user owns the video.
        /// 404 Not Found	The user doesn't own the video.
        /// </returns>
        public virtual RestResult<Video> CheckIfTheUserOwnsAVideo(int video_id) => RootAuthorization()
            .Command($"/me/videos/{video_id}")
            .Get<Video>();

        /// <summary>
        /// This method deletes the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public virtual RestResult DeleteVideo(int video_id) => RootAuthorization()
           .Command($"/videos/{video_id}")
           .Delete();

        /// <summary>
        /// This method edits the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body</param>
        /// <returns>
        /// 200 OK	The video was edited.
        /// 400 Bad Request	A parameter is invalid.
        /// 403 Forbidden	The authenticated user can't edit the video.
        /// </returns>
        public virtual RestResult<Video> EditAVideo(int video_id, VideoEditParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}")
            .JsonPayload(parameters)
            .Patch<Video>();

        /// <summary>
        /// This method returns a single video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>The video was returned.</returns>
        public virtual RestResult<Video> GetSpecificVideo(int video_id) => RootAuthorization()
            .Command($"/videos/{video_id}")
            .Get<Video>();

        /// <summary>
        /// This method returns every video in which the authenticated user has a credited appearance.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Video>> GetAllTheVideosInWhichTheUserAppears(int user_id,
            VideoDirection? direction = null,
            VideoFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/appearances")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("filter_embeddable", filter_embeddable)
            .GetPagination<Video>(RootAuthorization);

        /// <summary>
        /// This method returns every video in which the authenticated user has a credited appearance.
        /// </summary>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Video>> GetAllTheVideosInWhichTheUserAppears(VideoDirection? direction = null,
            VideoFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoSort? sort = null) => RootAuthorization()
            .Command($"/me/appearances")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("filter_embeddable", filter_embeddable)
            .GetPagination<Video>(RootAuthorization);

        /// <summary>
        /// This method returns all the videos that the authenticated user has uploaded.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="containing_uri">The page containing the video URI.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos.</param>
        /// <param name="filter_playable">Whether to filter the results by playable videos.</param>
        /// <param name="include_team_content">Whether to include the team members' content.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Video>> GetAllTheVideosThatTheUserHasUploaded(int user_id,
            string containing_uri = null,
            VideoDirection? direction = null,
            VideoFilter? filter = null,
            bool? filter_embeddable = null,
            bool? filter_playable = null,
            bool? include_team_content = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/videos")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("containing_uri", containing_uri)
            .OptionalParameter("filter_embeddable", filter_embeddable)
            .OptionalParameter("filter_playable", filter_playable)
            .OptionalParameter("include_team_content", include_team_content)
            .GetPagination<Video>(RootAuthorization);

        /// <summary>
        /// This method returns all the videos that the authenticated user has uploaded.
        /// </summary>
        /// <param name="containing_uri">The page containing the video URI.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos.</param>
        /// <param name="filter_playable">Whether to filter the results by playable videos.</param>
        /// <param name="include_team_content">Whether to include the team members' content.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Video>> GetAllTheVideosThatTheUserHasUploaded(string containing_uri = null,
            VideoDirection? direction = null,
            VideoFilter? filter = null,
            bool? filter_embeddable = null,
            bool? filter_playable = null,
            bool? include_team_content = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoSort? sort = null) => RootAuthorization()
            .Command($"/me/videos")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("containing_uri", containing_uri)
            .OptionalParameter("filter_embeddable", filter_embeddable)
            .OptionalParameter("filter_playable", filter_playable)
            .OptionalParameter("include_team_content", include_team_content)
            .GetPagination<Video>(RootAuthorization);

        /// <summary>
        /// This method returns the search results for the specified query.
        /// </summary>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="links">A comma-separated list of video URLs to find.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="uris">A comma-separated list of video URIs to find.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Video>> SearchForVideos(string query,
            VideoDirection? direction = null,
            VideoSearchFilter? filter = null,
            string links = null,
            int? page = null,
            int? per_page = null,
            VideoSort? sort = null,
            string uris = null) => RootAuthorization()
            .Command($"/videos")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("links", links)
            .OptionalParameter("uris", uris)
            .GetPagination<Video>(RootAuthorization);

        /// <summary>
        /// This method deletes one or more videos belonging to the specified user.
        /// The authenticated user must have permission to delete the videos.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="uris">The URIs of the videos to delete.</param>
        /// <param name="send_to_recently_deleted">When true, deleted videos use the Recently Deleted bucket (30-day retention).</param>
        /// <returns>
        /// 204 No Content	The videos were deleted.
        /// </returns>
        public virtual RestResult DeleteAUserVideos(int user_id, string[] uris, bool? send_to_recently_deleted = null) => RootAuthorization()
            .Command($"/users/{user_id}/videos")
            .OptionalParameter("uris", uris)
            .JsonPayload(new VimeoPayload().Set("send_to_recently_deleted", send_to_recently_deleted))
            .Delete();

        /// <summary>
        /// This method deletes one or more videos belonging to the authenticated user.
        /// </summary>
        /// <param name="uris">The URIs of the videos to delete.</param>
        /// <param name="send_to_recently_deleted">When true, deleted videos use the Recently Deleted bucket (30-day retention).</param>
        /// <returns>
        /// 204 No Content	The videos were deleted.
        /// </returns>
        public virtual RestResult MeDeleteAUserVideos(string[] uris, bool? send_to_recently_deleted = null) => RootAuthorization()
            .Command($"/me/videos")
            .OptionalParameter("uris", uris)
            .JsonPayload(new VimeoPayload().Set("send_to_recently_deleted", send_to_recently_deleted))
            .Delete();

        /// <summary>
        /// This method creates a copy of the specified video. Only the source's metadata and files are copied.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="name">The copied video name, up to 128 characters. By default, the source video name.</param>
        /// <returns>
        /// 201 Created	The copied video was created.
        /// </returns>
        public virtual RestResult<Video> CopyAVideo(int user_id, int video_id, string name = null) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}/copy")
            .JsonPayload(new VimeoPayload().Set("name", name))
            .Post<Video>();

        /// <summary>
        /// This method creates a copy of the specified video of the authenticated user.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="name">The copied video name, up to 128 characters. By default, the source video name.</param>
        /// <returns>
        /// 201 Created	The copied video was created.
        /// </returns>
        public virtual RestResult<Video> MeCopyAVideo(int video_id, string name = null) => RootAuthorization()
            .Command($"/me/videos/{video_id}/copy")
            .JsonPayload(new VimeoPayload().Set("name", name))
            .Post<Video>();

        /// <summary>
        /// This method sets, updates, or clears custom metadata values on a single video.
        /// A null value clears the field.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="fields">The values by field ID (see GET /teams/{user_id}/custom_metadata).</param>
        /// <returns>
        /// 200 OK	The updated custom metadata for the video.
        /// </returns>
        public virtual RestResult<List<CustomMetadataValue>> SetCustomMetadataValuesForAVideo(int video_id, IDictionary<long, string> fields) => RootAuthorization()
            .Command($"/videos/{video_id}/custom_metadata")
            .Payload(new Dictionary<string, object>
            {
                ["fields"] = fields.Select(f => new Dictionary<string, object> { ["field_id"] = f.Key, ["field_value"] = f.Value }).ToArray()
            })
            .Put<List<CustomMetadataValue>>();

        #endregion

        #region [ Content ratings ]

        /// <summary>
        /// This method returns every available content rating.
        /// </summary>
        /// <returns></returns>
        public virtual RestResult<VimeoList<ContentRating>> GetAllContentRatings() => RootAuthorization()
            .Command($"/contentratings")
            .Get<VimeoList<ContentRating>>();

        #endregion

        #region [ Creative Commons ]

        /// <summary>
        /// This method returns every available Creative Commons license.
        /// </summary>
        /// <returns></returns>
        public virtual RestResult<VimeoList<CreativeCommons>> GetAllCreativeCommonsLicenses() => RootAuthorization()
            .Command($"/creativecommons")
            .Get<VimeoList<CreativeCommons>>();

        #endregion

        #region [ Credits ]

        /// <summary>
        /// This method adds a credit for a user in the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: email, name, role and user_uri.</param>
        /// <returns>
        /// 201 Created	The credit was added.
        /// 400 Bad Request	A parameter is invalid.
        /// 403 Forbidden	The authenticated user can't add credits to the video.
        /// </returns>
        public virtual RestResult<Credit> CreditAUserInAVideo(int video_id, CreditParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/credits")
            .FormUrlEncoded(parameters)
            .Post<Credit>();

        /// <summary>
        /// This method deletes the specified credit from a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="credit_id">The ID of the credit.</param>
        /// <returns>
        /// 204 No Content	The credit was deleted.
        /// 403 Forbidden	The authenticated user can't delete the credit.
        /// </returns>
        public virtual RestResult DeleteTheCreditForAUserInAVideo(int video_id, int credit_id) => RootAuthorization()
            .Command($"/videos/{video_id}/credits/{credit_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified credit in a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="credit_id">The ID of the credit.</param>
        /// <param name="parameters">Body: name and role.</param>
        /// <returns></returns>
        public virtual RestResult<Credit> EditTheCreditForAUserInAVideo(int video_id, int credit_id, CreditParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/credits/{credit_id}")
            .FormUrlEncoded(parameters)
            .Patch<Credit>();

        /// <summary>
        /// This method returns a single credit in a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="credit_id">The ID of the credit.</param>
        /// <returns></returns>
        public virtual RestResult<Credit> GetASpecificCreditedUserInAVideo(int video_id, int credit_id) => RootAuthorization()
            .Command($"/videos/{video_id}/credits/{credit_id}")
            .Get<Credit>();

        /// <summary>
        /// This method returns every credit in the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Credit>> GetAllTheCreditedUsersInAVideo(int video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoCreditSort? sort = null) => RootAuthorization()
            .Command($"/videos/{video_id}/credits")
            .ListParameters(direction, null, page, per_page, query, sort)
            .GetPagination<Credit>(RootAuthorization);

        #endregion

        #region [ Embed privacy ]

        /// <summary>
        /// This method adds the specified domain to the whitelist of a video. The video's privacy.embed must be whitelist.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="domain">The domain to add.</param>
        /// <param name="allow_hd">Whether to permit HD embeds on this domain.</param>
        /// <returns>
        /// 204 No Content	The domain was added.
        /// 403 Forbidden	The authenticated user can't edit the video.
        /// </returns>
        public virtual RestResult AddADomainToAVideoWhitelist(int video_id, string domain, bool? allow_hd = null) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/domains/{domain}")
            .FormUrlEncoded(Pair("allow_hd", allow_hd))
            .Put();

        /// <summary>
        /// This method returns every domain on the whitelist of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Domain>> GetAllTheDomainsOnAVideoWhitelist(int video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/domains")
            .ListParameters(direction, null, page, per_page)
            .GetPagination<Domain>(RootAuthorization);

        /// <summary>
        /// This method removes the specified domain from the whitelist of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="domain">The domain to remove.</param>
        /// <returns>
        /// 204 No Content	The domain was removed.
        /// 403 Forbidden	The authenticated user can't edit the video.
        /// </returns>
        public virtual RestResult RemoveADomainFromAVideoWhitelist(int video_id, string domain) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/domains/{domain}")
            .Delete();

        #endregion

        #region [ Languages ]

        /// <summary>
        /// This method returns every available language.
        /// </summary>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <returns></returns>
        public virtual RestResult<VimeoList<Language>> GetAllLanguages(LanguageFilter? filter = null) => RootAuthorization()
            .Command($"/languages")
            .OptionalParameter("filter", filter)
            .Get<VimeoList<Language>>();

        #endregion

        #region [ Live M3U8 playback ]

        /// <summary>
        /// This method returns the M3U8 playback URL of a one-time live event.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video of the live event.</param>
        /// <returns></returns>
        public virtual RestResult<M3U8Playback> GetAnM3U8PlaybackUrlForAOneTimeLiveEvent(int user_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}/m3u8_playback")
            .Get<M3U8Playback>();

        /// <summary>
        /// This method returns the M3U8 playback URL of a one-time live event.
        /// </summary>
        /// <param name="video_id">The ID of the video of the live event.</param>
        /// <returns></returns>
        public virtual RestResult<M3U8Playback> GetAnM3U8PlaybackUrlForAOneTimeLiveEvent(int video_id) => RootAuthorization()
            .Command($"/me/videos/{video_id}/m3u8_playback")
            .Get<M3U8Playback>();

        #endregion

        #region [ Private videos ]

        /// <summary>
        /// This method returns every user who can view the specified private video. The video's privacy.view must be users.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<User>> GetAllTheUsersWhoCanViewAPrivateVideo(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/users")
            .ListParameters(null, null, page, per_page)
            .GetPagination<User>(RootAuthorization);

        /// <summary>
        /// This method gives multiple users permission to view the specified private video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="user_uris">The URIs of the users to permit.</param>
        /// <returns></returns>
        public virtual RestResult<VimeoList<User>> PermitAListOfUsersToAccessAPrivateVideo(int video_id, string[] user_uris) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/users")
            .Payload(user_uris.Select(uri => new Dictionary<string, string> { { "uri", uri } }).ToArray())
            .Put<VimeoList<User>>();

        /// <summary>
        /// This method gives a single user permission to view the specified private video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public virtual RestResult<User> PermitASpecificUserToAccessAPrivateVideo(int video_id, int user_id) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/users/{user_id}")
            .Put<User>();

        /// <summary>
        /// This method prevents a user from being able to view the specified private video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 204 No Content	The user's permission was removed.
        /// </returns>
        public virtual RestResult RestrictAUserFromViewingAPrivateVideo(int video_id, int user_id) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/users/{user_id}")
            .Delete();

        #endregion

        #region [ Recommendations ]

        /// <summary>
        /// This method returns related videos for a particular video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Video>> GetAllTheRelatedVideosOfAVideo(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/videos")
            .ListParameters(null, VideoRelatedFilter.related, page, per_page)
            .GetPagination<Video>(RootAuthorization);

        #endregion

        #region [ Showcases ]

        /// <summary>
        /// This method adds the specified video to, or removes it from, a list of showcases.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="add_to">The URIs of the showcases to which to add the video.</param>
        /// <param name="remove_from">The URIs of the showcases from which to remove the video.</param>
        /// <returns></returns>
        public virtual RestResult AddOrRemoveAVideoFromAListOfShowcases(int user_id, int video_id, string[] add_to = null, string[] remove_from = null) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}/albums")
            .Payload(new Dictionary<string, string[]>
            {
                { "add_to", add_to ?? new string[0] },
                { "remove_from", remove_from ?? new string[0] }
            })
            .Patch();

        /// <summary>
        /// This method adds the specified video to, or removes it from, a list of showcases.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="add_to">The URIs of the showcases to which to add the video.</param>
        /// <param name="remove_from">The URIs of the showcases from which to remove the video.</param>
        /// <returns></returns>
        public virtual RestResult AddOrRemoveAVideoFromAListOfShowcases(int video_id, string[] add_to = null, string[] remove_from = null) => RootAuthorization()
            .Command($"/videos/{video_id}/albums")
            .Payload(new Dictionary<string, string[]>
            {
                { "add_to", add_to ?? new string[0] },
                { "remove_from", remove_from ?? new string[0] }
            })
            .Patch();

        /// <summary>
        /// This method returns all the showcases that contain the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Album>> GetAllTheShowcasesThatContainAVideo(int video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/albums")
            .ListParameters(direction, null, page, per_page)
            .GetPagination<Album>(RootAuthorization);

        #endregion

        #region [ Tags ]

        /// <summary>
        /// This method adds multiple tags to the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="tags">The names of the tags to add.</param>
        /// <returns></returns>
        public virtual RestResult<VimeoList<Tag>> AddAListOfTagsToAVideo(int video_id, string[] tags) => RootAuthorization()
            .Command($"/videos/{video_id}/tags")
            .Payload(tags.Select(tag => new Dictionary<string, string> { { "name", tag } }).ToArray())
            .Put<VimeoList<Tag>>();

        /// <summary>
        /// This method adds a single tag to the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="word">The tag to add.</param>
        /// <returns></returns>
        public virtual RestResult<Tag> AddASpecificTagToAVideo(int video_id, string word) => RootAuthorization()
            .Command($"/videos/{video_id}/tags/{word}")
            .Put<Tag>();

        /// <summary>
        /// This method determines whether a particular tag has been added to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="word">The tag to check.</param>
        /// <returns>
        /// 200 OK	The tag has been added to the video.
        /// 404 Not Found	The tag hasn't been added to the video.
        /// </returns>
        public virtual RestResult<Tag> CheckIfATagHasBeenAddedToAVideo(int video_id, string word) => RootAuthorization()
            .Command($"/videos/{video_id}/tags/{word}")
            .Get<Tag>();

        /// <summary>
        /// This method returns every tag that has been added to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Tag>> GetAllTheTagsOfAVideo(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/tags")
            .ListParameters(null, null, page, per_page)
            .GetPagination<Tag>(RootAuthorization);

        /// <summary>
        /// This method returns every video that has the specified tag.
        /// </summary>
        /// <param name="word">The tag.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Video>> GetAllTheVideosWithASpecificTag(string word,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null,
            VideoTagSort? sort = null) => RootAuthorization()
            .Command($"/tags/{word}/videos")
            .ListParameters(direction, null, page, per_page, null, sort)
            .GetPagination<Video>(RootAuthorization);

        /// <summary>
        /// This method removes the specified tag from a video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="word">The tag to remove.</param>
        /// <returns>
        /// 204 No Content	The tag was removed.
        /// </returns>
        public virtual RestResult RemoveATagFromAVideo(int video_id, string word) => RootAuthorization()
            .Command($"/videos/{video_id}/tags/{word}")
            .Delete();

        #endregion

        #region [ Text tracks ]

        /// <summary>
        /// This method adds a text track to the specified video. Upload the file to the returned link afterwards.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: active, language, name and type.</param>
        /// <returns></returns>
        public virtual RestResult<TextTrack> AddATextTrackToAVideo(int video_id, TextTrackParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks")
            .FormUrlEncoded(parameters)
            .Post<TextTrack>();

        /// <summary>
        /// This method deletes the specified text track.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="texttrack_id">The ID of the text track.</param>
        /// <returns>
        /// 204 No Content	The text track was deleted.
        /// </returns>
        public virtual RestResult DeleteATextTrack(int video_id, int texttrack_id) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks/{texttrack_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified text track.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="texttrack_id">The ID of the text track.</param>
        /// <param name="parameters">Body: active, language, name and type.</param>
        /// <returns></returns>
        public virtual RestResult<TextTrack> EditATextTrack(int video_id, int texttrack_id, TextTrackParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks/{texttrack_id}")
            .FormUrlEncoded(parameters)
            .Patch<TextTrack>();

        /// <summary>
        /// This method returns a single text track.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="texttrack_id">The ID of the text track.</param>
        /// <returns></returns>
        public virtual RestResult<TextTrack> GetASpecificTextTrack(int video_id, int texttrack_id) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks/{texttrack_id}")
            .Get<TextTrack>();

        /// <summary>
        /// This method returns every text track of the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<TextTrack>> GetAllTheTextTracksOfAVideo(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks")
            .ListParameters(null, null, page, per_page)
            .GetPagination<TextTrack>(RootAuthorization);

        #endregion

        #region [ Thumbnails ]

        /// <summary>
        /// This method adds a thumbnail image to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: active and time.</param>
        /// <returns></returns>
        public virtual RestResult<Picture> AddAVideoThumbnail(int video_id, ThumbnailParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures")
            .FormUrlEncoded(parameters)
            .Post<Picture>();

        /// <summary>
        /// This method deletes the specified thumbnail image from a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="picture_id">The ID of the picture.</param>
        /// <returns>
        /// 204 No Content	The thumbnail was deleted.
        /// </returns>
        public virtual RestResult DeleteAVideoThumbnail(int video_id, int picture_id) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures/{picture_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified thumbnail image of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="picture_id">The ID of the picture.</param>
        /// <param name="parameters">Body: active.</param>
        /// <returns></returns>
        public virtual RestResult<Picture> EditAVideoThumbnail(int video_id, int picture_id, ThumbnailParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures/{picture_id}")
            .FormUrlEncoded(parameters)
            .Patch<Picture>();

        /// <summary>
        /// This method returns a single thumbnail image of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="picture_id">The ID of the picture.</param>
        /// <returns></returns>
        public virtual RestResult<Picture> GetASpecificVideoThumbnail(int video_id, int picture_id) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures/{picture_id}")
            .Get<Picture>();

        /// <summary>
        /// This method returns every thumbnail image of the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Picture>> GetAllTheThumbnailsOfAVideo(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures")
            .ListParameters(null, null, page, per_page)
            .GetPagination<Picture>(RootAuthorization);

        #endregion

        #region [ Uploads ]

        /// <summary>
        /// This method completes a streaming upload (deprecated approach). Use the complete_uri returned by the upload attempt.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="upload_id">The ID of the upload attempt.</param>
        /// <param name="signature">The crypto signature of the completed upload.</param>
        /// <param name="video_file_id">The ID of the uploaded file.</param>
        /// <returns>
        /// 201 Created	The upload was completed.
        /// </returns>
        public virtual RestResult CompleteAStreamingUpload(int user_id, int upload_id, string signature, int video_file_id) => RootAuthorization()
            .Command($"/users/{user_id}/uploads/{upload_id}")
            .Parameter("signature", signature)
            .Parameter("video_file_id", video_file_id)
            .Delete();

        /// <summary>
        /// This method completes a streaming upload (deprecated approach). Use the complete_uri returned by the upload attempt.
        /// </summary>
        /// <param name="upload_id">The ID of the upload attempt.</param>
        /// <param name="signature">The crypto signature of the completed upload.</param>
        /// <param name="video_file_id">The ID of the uploaded file.</param>
        /// <returns>
        /// 201 Created	The upload was completed.
        /// </returns>
        public virtual RestResult CompleteAStreamingUpload(int upload_id, string signature, int video_file_id) => RootAuthorization()
            .Command($"/me/uploads/{upload_id}")
            .Parameter("signature", signature)
            .Parameter("video_file_id", video_file_id)
            .Delete();

        /// <summary>
        /// This method returns the specified upload attempt.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="upload_id">The ID of the upload attempt.</param>
        /// <returns></returns>
        public virtual RestResult<UploadAttempt> GetAnUploadAttempt(int user_id, int upload_id) => RootAuthorization()
            .Command($"/users/{user_id}/uploads/{upload_id}")
            .Get<UploadAttempt>();

        /// <summary>
        /// This method returns the specified upload attempt.
        /// </summary>
        /// <param name="upload_id">The ID of the upload attempt.</param>
        /// <returns></returns>
        public virtual RestResult<UploadAttempt> GetAnUploadAttempt(int upload_id) => RootAuthorization()
            .Command($"/me/uploads/{upload_id}")
            .Get<UploadAttempt>();

        /// <summary>
        /// This method begins the video upload process (tus, post or pull approach).
        /// With tus, send the file to upload.upload_link of the returned video.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="parameters">Body: upload approach, size or link and the video's metadata.</param>
        /// <returns>
        /// 200 OK	The upload has started.
        /// 400 Bad Request	A parameter is invalid.
        /// 403 Forbidden	The authenticated user can't upload videos.
        /// </returns>
        public virtual RestResult<Video> UploadAVideo(int user_id, VideoUploadParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/videos")
            .JsonPayload(parameters)
            .Post<Video>();

        /// <summary>
        /// This method begins the video upload process (tus, post or pull approach).
        /// With tus, send the file to upload.upload_link of the returned video.
        /// </summary>
        /// <param name="parameters">Body: upload approach, size or link and the video's metadata.</param>
        /// <returns>
        /// 200 OK	The upload has started.
        /// 400 Bad Request	A parameter is invalid.
        /// 403 Forbidden	The authenticated user can't upload videos.
        /// </returns>
        public virtual RestResult<Video> UploadAVideo(VideoUploadParameters parameters) => RootAuthorization()
            .Command($"/me/videos")
            .JsonPayload(parameters)
            .Post<Video>();

        #endregion

        #region [ Versions ]

        /// <summary>
        /// This method adds a version to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: file_name and upload information.</param>
        /// <returns></returns>
        public virtual RestResult<VideoVersions> AddAVersionToAVideo(int video_id, VideoVersionParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/versions")
            .JsonPayload(parameters)
            .Post<VideoVersions>();

        /// <summary>
        /// This method deletes the specified video version.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <returns>
        /// 204 No Content	The version was deleted.
        /// </returns>
        public virtual RestResult DeleteAVideoVersion(int video_id, int version_id) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified video version.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <param name="parameters">Body: active.</param>
        /// <returns></returns>
        public virtual RestResult<VideoVersions> EditAVideoVersion(int video_id, int version_id, VideoVersionParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}")
            .JsonPayload(parameters)
            .Patch<VideoVersions>();

        /// <summary>
        /// This method returns a single video version.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <returns></returns>
        public virtual RestResult<VideoVersions> GetASpecificVideoVersion(int video_id, int version_id) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}")
            .Get<VideoVersions>();

        /// <summary>
        /// This method returns every version of the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<VideoVersions>> GetAllTheVersionsOfAVideo(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/versions")
            .ListParameters(null, null, page, per_page)
            .GetPagination<VideoVersions>(RootAuthorization);

        #endregion

        #region [ Video comments ]

        /// <summary>
        /// This method adds a reply to the specified video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <param name="text">The text of the reply.</param>
        /// <returns></returns>
        public virtual RestResult<Comment> AddAReplyToAVideoComment(int video_id, int comment_id, string text) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}/replies")
            .FormUrlEncoded(Pair("text", text))
            .Post<Comment>();

        /// <summary>
        /// This method adds a comment to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="text">The text of the comment.</param>
        /// <returns>
        /// 201 Created	The comment was added.
        /// 403 Forbidden	Comments are disabled for the video.
        /// </returns>
        public virtual RestResult<Comment> AddAVideoCommentToAVideo(int video_id, string text) => RootAuthorization()
            .Command($"/videos/{video_id}/comments")
            .FormUrlEncoded(Pair("text", text))
            .Post<Comment>();

        /// <summary>
        /// This method deletes the specified video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <returns>
        /// 204 No Content	The comment was deleted.
        /// </returns>
        public virtual RestResult DeleteAVideoComment(int video_id, int comment_id) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <param name="text">The new text of the comment.</param>
        /// <returns></returns>
        public virtual RestResult<Comment> EditAVideoComment(int video_id, int comment_id, string text) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}")
            .FormUrlEncoded(Pair("text", text))
            .Patch<Comment>();

        /// <summary>
        /// This method returns a single video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <returns></returns>
        public virtual RestResult<Comment> GetASpecificVideoComment(int video_id, int comment_id) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}")
            .Get<Comment>();

        /// <summary>
        /// This method returns every reply to the specified video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Comment>> GetAllTheRepliesToAVideoComment(int video_id, int comment_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}/replies")
            .ListParameters(null, null, page, per_page)
            .GetPagination<Comment>(RootAuthorization);

        /// <summary>
        /// This method returns every comment on the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<Comment>> GetAllTheVideoCommentsOnAVideo(int video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/comments")
            .ListParameters(direction, null, page, per_page)
            .GetPagination<Comment>(RootAuthorization);

        #endregion

        #region [ Moderation ]

        /// <summary>
        /// This method returns the reasons that content of the specified type can be reported for on Vimeo.
        /// </summary>
        /// <param name="content_type">The type of content: comment, file, user, video.</param>
        /// <returns>
        /// 200 OK	The list of reasons was returned.
        /// </returns>
        public virtual RestResult<ReportReasons> GetTheReasonsThatContentCanBeReported(ReportContentType content_type) => RootAuthorization()
            .Command($"/report/reasons")
            .OptionalParameter("content_type", content_type)
            .Get<ReportReasons>();

        /// <summary>
        /// This method returns a list of valid reasons for reporting inappropriate videos on Vimeo.
        /// </summary>
        /// <returns>
        /// 200 OK	The list of reasons was returned.
        /// </returns>
        public virtual RestResult<ReportReasons> GetTheReasonsThatVideosCanBeReported() => RootAuthorization()
            .Command($"/report/video_report_reasons")
            .Get<ReportReasons>();

        #endregion
    }
}
