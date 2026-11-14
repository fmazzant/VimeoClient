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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using Mafesoft.VimeoClient.Body.Video;
    using Mafesoft.VimeoClient.Filter.Video;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoVideos.
    public partial class VimeoVideos
    {
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
        public virtual Task<RestResult<Video>> CheckIfTheUserOwnsAVideoAsync(int user_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}")
            .GetAsync<Video>();

        /// <summary>
        /// This method checks whether the authenticated user owns the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The user owns the video.
        /// 404 Not Found	The user doesn't own the video.
        /// </returns>
        public virtual Task<RestResult<Video>> CheckIfTheUserOwnsAVideoAsync(int video_id) => RootAuthorization()
            .Command($"/me/videos/{video_id}")
            .GetAsync<Video>();

        /// <summary>
        /// This method deletes the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> DeleteVideoAsync(int video_id) => RootAuthorization()
           .Command($"/videos/{video_id}")
           .DeleteAsync();

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
        public virtual Task<RestResult<Video>> EditAVideoAsync(int video_id, VideoEditParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}")
            .JsonPayload(parameters)
            .PatchAsync<Video>();

        /// <summary>
        /// This method returns a single video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>The video was returned.</returns>
        public virtual Task<RestResult<Video>> GetSpecificVideoAsync(int video_id) => RootAuthorization()
            .Command($"/videos/{video_id}")
            .GetAsync<Video>();

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
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosInWhichTheUserAppearsAsync(int user_id,
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
            .GetPaginationAsync<Video>(RootAuthorization);

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
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosInWhichTheUserAppearsAsync(VideoDirection? direction = null,
            VideoFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoSort? sort = null) => RootAuthorization()
            .Command($"/me/appearances")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("filter_embeddable", filter_embeddable)
            .GetPaginationAsync<Video>(RootAuthorization);

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
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosThatTheUserHasUploadedAsync(int user_id,
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
            .GetPaginationAsync<Video>(RootAuthorization);

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
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosThatTheUserHasUploadedAsync(string containing_uri = null,
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
            .GetPaginationAsync<Video>(RootAuthorization);

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
        public virtual Task<RestResult<Pagination<Video>>> SearchForVideosAsync(string query,
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
            .GetPaginationAsync<Video>(RootAuthorization);

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
        public virtual Task<RestResult<string>> DeleteAUserVideosAsync(int user_id, string[] uris, bool? send_to_recently_deleted = null) => RootAuthorization()
            .Command($"/users/{user_id}/videos")
            .OptionalParameter("uris", uris)
            .JsonPayload(new VimeoPayload().Set("send_to_recently_deleted", send_to_recently_deleted))
            .DeleteAsync();

        /// <summary>
        /// This method deletes one or more videos belonging to the authenticated user.
        /// </summary>
        /// <param name="uris">The URIs of the videos to delete.</param>
        /// <param name="send_to_recently_deleted">When true, deleted videos use the Recently Deleted bucket (30-day retention).</param>
        /// <returns>
        /// 204 No Content	The videos were deleted.
        /// </returns>
        public virtual Task<RestResult<string>> MeDeleteAUserVideosAsync(string[] uris, bool? send_to_recently_deleted = null) => RootAuthorization()
            .Command($"/me/videos")
            .OptionalParameter("uris", uris)
            .JsonPayload(new VimeoPayload().Set("send_to_recently_deleted", send_to_recently_deleted))
            .DeleteAsync();

        /// <summary>
        /// This method creates a copy of the specified video. Only the source's metadata and files are copied.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="name">The copied video name, up to 128 characters. By default, the source video name.</param>
        /// <returns>
        /// 201 Created	The copied video was created.
        /// </returns>
        public virtual Task<RestResult<Video>> CopyAVideoAsync(int user_id, int video_id, string name = null) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}/copy")
            .JsonPayload(new VimeoPayload().Set("name", name))
            .PostAsync<Video>();

        /// <summary>
        /// This method creates a copy of the specified video of the authenticated user.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="name">The copied video name, up to 128 characters. By default, the source video name.</param>
        /// <returns>
        /// 201 Created	The copied video was created.
        /// </returns>
        public virtual Task<RestResult<Video>> MeCopyAVideoAsync(int video_id, string name = null) => RootAuthorization()
            .Command($"/me/videos/{video_id}/copy")
            .JsonPayload(new VimeoPayload().Set("name", name))
            .PostAsync<Video>();

        /// <summary>
        /// This method sets, updates, or clears custom metadata values on a single video.
        /// A null value clears the field.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="fields">The values by field ID (see GET /teams/{user_id}/custom_metadata).</param>
        /// <returns>
        /// 200 OK	The updated custom metadata for the video.
        /// </returns>
        public virtual Task<RestResult<List<CustomMetadataValue>>> SetCustomMetadataValuesForAVideoAsync(int video_id, IDictionary<long, string> fields) => RootAuthorization()
            .Command($"/videos/{video_id}/custom_metadata")
            .Payload(new Dictionary<string, object>
            {
                ["fields"] = fields.Select(f => new Dictionary<string, object> { ["field_id"] = f.Key, ["field_value"] = f.Value }).ToArray()
            })
            .PutAsync<List<CustomMetadataValue>>();

        #endregion

        #region [ Content ratings ]

        /// <summary>
        /// This method returns every available content rating.
        /// </summary>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<ContentRating>>> GetAllContentRatingsAsync() => RootAuthorization()
            .Command($"/contentratings")
            .GetAsync<VimeoList<ContentRating>>();

        #endregion

        #region [ Creative Commons ]

        /// <summary>
        /// This method returns every available Creative Commons license.
        /// </summary>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<CreativeCommons>>> GetAllCreativeCommonsLicensesAsync() => RootAuthorization()
            .Command($"/creativecommons")
            .GetAsync<VimeoList<CreativeCommons>>();

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
        public virtual Task<RestResult<Credit>> CreditAUserInAVideoAsync(int video_id, CreditParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/credits")
            .FormUrlEncoded(parameters)
            .PostAsync<Credit>();

        /// <summary>
        /// This method deletes the specified credit from a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="credit_id">The ID of the credit.</param>
        /// <returns>
        /// 204 No Content	The credit was deleted.
        /// 403 Forbidden	The authenticated user can't delete the credit.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteTheCreditForAUserInAVideoAsync(int video_id, int credit_id) => RootAuthorization()
            .Command($"/videos/{video_id}/credits/{credit_id}")
            .DeleteAsync();

        /// <summary>
        /// This method edits the specified credit in a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="credit_id">The ID of the credit.</param>
        /// <param name="parameters">Body: name and role.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Credit>> EditTheCreditForAUserInAVideoAsync(int video_id, int credit_id, CreditParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/credits/{credit_id}")
            .FormUrlEncoded(parameters)
            .PatchAsync<Credit>();

        /// <summary>
        /// This method returns a single credit in a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="credit_id">The ID of the credit.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Credit>> GetASpecificCreditedUserInAVideoAsync(int video_id, int credit_id) => RootAuthorization()
            .Command($"/videos/{video_id}/credits/{credit_id}")
            .GetAsync<Credit>();

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
        public virtual Task<RestResult<Pagination<Credit>>> GetAllTheCreditedUsersInAVideoAsync(int video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoCreditSort? sort = null) => RootAuthorization()
            .Command($"/videos/{video_id}/credits")
            .ListParameters(direction, null, page, per_page, query, sort)
            .GetPaginationAsync<Credit>(RootAuthorization);

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
        public virtual Task<RestResult<string>> AddADomainToAVideoWhitelistAsync(int video_id, string domain, bool? allow_hd = null) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/domains/{domain}")
            .FormUrlEncoded(Pair("allow_hd", allow_hd))
            .PutAsync();

        /// <summary>
        /// This method returns every domain on the whitelist of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Domain>>> GetAllTheDomainsOnAVideoWhitelistAsync(int video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/domains")
            .ListParameters(direction, null, page, per_page)
            .GetPaginationAsync<Domain>(RootAuthorization);

        /// <summary>
        /// This method removes the specified domain from the whitelist of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="domain">The domain to remove.</param>
        /// <returns>
        /// 204 No Content	The domain was removed.
        /// 403 Forbidden	The authenticated user can't edit the video.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveADomainFromAVideoWhitelistAsync(int video_id, string domain) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/domains/{domain}")
            .DeleteAsync();

        #endregion

        #region [ Languages ]

        /// <summary>
        /// This method returns every available language.
        /// </summary>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Language>>> GetAllLanguagesAsync(LanguageFilter? filter = null) => RootAuthorization()
            .Command($"/languages")
            .OptionalParameter("filter", filter)
            .GetAsync<VimeoList<Language>>();

        #endregion

        #region [ Live M3U8 playback ]

        /// <summary>
        /// This method returns the M3U8 playback URL of a one-time live event.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video of the live event.</param>
        /// <returns></returns>
        public virtual Task<RestResult<M3U8Playback>> GetAnM3U8PlaybackUrlForAOneTimeLiveEventAsync(int user_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}/m3u8_playback")
            .GetAsync<M3U8Playback>();

        /// <summary>
        /// This method returns the M3U8 playback URL of a one-time live event.
        /// </summary>
        /// <param name="video_id">The ID of the video of the live event.</param>
        /// <returns></returns>
        public virtual Task<RestResult<M3U8Playback>> GetAnM3U8PlaybackUrlForAOneTimeLiveEventAsync(int video_id) => RootAuthorization()
            .Command($"/me/videos/{video_id}/m3u8_playback")
            .GetAsync<M3U8Playback>();

        #endregion

        #region [ Private videos ]

        /// <summary>
        /// This method returns every user who can view the specified private video. The video's privacy.view must be users.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<User>>> GetAllTheUsersWhoCanViewAPrivateVideoAsync(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/users")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<User>(RootAuthorization);

        /// <summary>
        /// This method gives multiple users permission to view the specified private video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="user_uris">The URIs of the users to permit.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<User>>> PermitAListOfUsersToAccessAPrivateVideoAsync(int video_id, string[] user_uris) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/users")
            .Payload(user_uris.Select(uri => new Dictionary<string, string> { { "uri", uri } }).ToArray())
            .PutAsync<VimeoList<User>>();

        /// <summary>
        /// This method gives a single user permission to view the specified private video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public virtual Task<RestResult<User>> PermitASpecificUserToAccessAPrivateVideoAsync(int video_id, int user_id) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/users/{user_id}")
            .PutAsync<User>();

        /// <summary>
        /// This method prevents a user from being able to view the specified private video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 204 No Content	The user's permission was removed.
        /// </returns>
        public virtual Task<RestResult<string>> RestrictAUserFromViewingAPrivateVideoAsync(int video_id, int user_id) => RootAuthorization()
            .Command($"/videos/{video_id}/privacy/users/{user_id}")
            .DeleteAsync();

        #endregion

        #region [ Recommendations ]

        /// <summary>
        /// This method returns related videos for a particular video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheRelatedVideosOfAVideoAsync(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/videos")
            .ListParameters(null, VideoRelatedFilter.related, page, per_page)
            .GetPaginationAsync<Video>(RootAuthorization);

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
        public virtual Task<RestResult<string>> AddOrRemoveAVideoFromAListOfShowcasesAsync(int user_id, int video_id, string[] add_to = null, string[] remove_from = null) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}/albums")
            .Payload(new Dictionary<string, string[]>
            {
                { "add_to", add_to ?? new string[0] },
                { "remove_from", remove_from ?? new string[0] }
            })
            .PatchAsync();

        /// <summary>
        /// This method adds the specified video to, or removes it from, a list of showcases.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="add_to">The URIs of the showcases to which to add the video.</param>
        /// <param name="remove_from">The URIs of the showcases from which to remove the video.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> AddOrRemoveAVideoFromAListOfShowcasesAsync(int video_id, string[] add_to = null, string[] remove_from = null) => RootAuthorization()
            .Command($"/videos/{video_id}/albums")
            .Payload(new Dictionary<string, string[]>
            {
                { "add_to", add_to ?? new string[0] },
                { "remove_from", remove_from ?? new string[0] }
            })
            .PatchAsync();

        /// <summary>
        /// This method returns all the showcases that contain the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Album>>> GetAllTheShowcasesThatContainAVideoAsync(int video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/albums")
            .ListParameters(direction, null, page, per_page)
            .GetPaginationAsync<Album>(RootAuthorization);

        #endregion

        #region [ Tags ]

        /// <summary>
        /// This method adds multiple tags to the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="tags">The names of the tags to add.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Tag>>> AddAListOfTagsToAVideoAsync(int video_id, string[] tags) => RootAuthorization()
            .Command($"/videos/{video_id}/tags")
            .Payload(tags.Select(tag => new Dictionary<string, string> { { "name", tag } }).ToArray())
            .PutAsync<VimeoList<Tag>>();

        /// <summary>
        /// This method adds a single tag to the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="word">The tag to add.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Tag>> AddASpecificTagToAVideoAsync(int video_id, string word) => RootAuthorization()
            .Command($"/videos/{video_id}/tags/{word}")
            .PutAsync<Tag>();

        /// <summary>
        /// This method determines whether a particular tag has been added to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="word">The tag to check.</param>
        /// <returns>
        /// 200 OK	The tag has been added to the video.
        /// 404 Not Found	The tag hasn't been added to the video.
        /// </returns>
        public virtual Task<RestResult<Tag>> CheckIfATagHasBeenAddedToAVideoAsync(int video_id, string word) => RootAuthorization()
            .Command($"/videos/{video_id}/tags/{word}")
            .GetAsync<Tag>();

        /// <summary>
        /// This method returns every tag that has been added to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Tag>>> GetAllTheTagsOfAVideoAsync(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/tags")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<Tag>(RootAuthorization);

        /// <summary>
        /// This method returns every video that has the specified tag.
        /// </summary>
        /// <param name="word">The tag.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosWithASpecificTagAsync(string word,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null,
            VideoTagSort? sort = null) => RootAuthorization()
            .Command($"/tags/{word}/videos")
            .ListParameters(direction, null, page, per_page, null, sort)
            .GetPaginationAsync<Video>(RootAuthorization);

        /// <summary>
        /// This method removes the specified tag from a video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="word">The tag to remove.</param>
        /// <returns>
        /// 204 No Content	The tag was removed.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveATagFromAVideoAsync(int video_id, string word) => RootAuthorization()
            .Command($"/videos/{video_id}/tags/{word}")
            .DeleteAsync();

        #endregion

        #region [ Text tracks ]

        /// <summary>
        /// This method adds a text track to the specified video. Upload the file to the returned link afterwards.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: active, language, name and type.</param>
        /// <returns></returns>
        public virtual Task<RestResult<TextTrack>> AddATextTrackToAVideoAsync(int video_id, TextTrackParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks")
            .FormUrlEncoded(parameters)
            .PostAsync<TextTrack>();

        /// <summary>
        /// This method deletes the specified text track.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="texttrack_id">The ID of the text track.</param>
        /// <returns>
        /// 204 No Content	The text track was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteATextTrackAsync(int video_id, int texttrack_id) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks/{texttrack_id}")
            .DeleteAsync();

        /// <summary>
        /// This method edits the specified text track.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="texttrack_id">The ID of the text track.</param>
        /// <param name="parameters">Body: active, language, name and type.</param>
        /// <returns></returns>
        public virtual Task<RestResult<TextTrack>> EditATextTrackAsync(int video_id, int texttrack_id, TextTrackParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks/{texttrack_id}")
            .FormUrlEncoded(parameters)
            .PatchAsync<TextTrack>();

        /// <summary>
        /// This method returns a single text track.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="texttrack_id">The ID of the text track.</param>
        /// <returns></returns>
        public virtual Task<RestResult<TextTrack>> GetASpecificTextTrackAsync(int video_id, int texttrack_id) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks/{texttrack_id}")
            .GetAsync<TextTrack>();

        /// <summary>
        /// This method returns every text track of the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<TextTrack>>> GetAllTheTextTracksOfAVideoAsync(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/texttracks")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<TextTrack>(RootAuthorization);

        #endregion

        #region [ Thumbnails ]

        /// <summary>
        /// This method adds a thumbnail image to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: active and time.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> AddAVideoThumbnailAsync(int video_id, ThumbnailParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures")
            .FormUrlEncoded(parameters)
            .PostAsync<Picture>();

        /// <summary>
        /// This method deletes the specified thumbnail image from a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="picture_id">The ID of the picture.</param>
        /// <returns>
        /// 204 No Content	The thumbnail was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAVideoThumbnailAsync(int video_id, int picture_id) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures/{picture_id}")
            .DeleteAsync();

        /// <summary>
        /// This method edits the specified thumbnail image of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="picture_id">The ID of the picture.</param>
        /// <param name="parameters">Body: active.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> EditAVideoThumbnailAsync(int video_id, int picture_id, ThumbnailParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures/{picture_id}")
            .FormUrlEncoded(parameters)
            .PatchAsync<Picture>();

        /// <summary>
        /// This method returns a single thumbnail image of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="picture_id">The ID of the picture.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> GetASpecificVideoThumbnailAsync(int video_id, int picture_id) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures/{picture_id}")
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns every thumbnail image of the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllTheThumbnailsOfAVideoAsync(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/pictures")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<Picture>(RootAuthorization);

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
        public virtual Task<RestResult<string>> CompleteAStreamingUploadAsync(int user_id, int upload_id, string signature, int video_file_id) => RootAuthorization()
            .Command($"/users/{user_id}/uploads/{upload_id}")
            .Parameter("signature", signature)
            .Parameter("video_file_id", video_file_id)
            .DeleteAsync();

        /// <summary>
        /// This method completes a streaming upload (deprecated approach). Use the complete_uri returned by the upload attempt.
        /// </summary>
        /// <param name="upload_id">The ID of the upload attempt.</param>
        /// <param name="signature">The crypto signature of the completed upload.</param>
        /// <param name="video_file_id">The ID of the uploaded file.</param>
        /// <returns>
        /// 201 Created	The upload was completed.
        /// </returns>
        public virtual Task<RestResult<string>> CompleteAStreamingUploadAsync(int upload_id, string signature, int video_file_id) => RootAuthorization()
            .Command($"/me/uploads/{upload_id}")
            .Parameter("signature", signature)
            .Parameter("video_file_id", video_file_id)
            .DeleteAsync();

        /// <summary>
        /// This method returns the specified upload attempt.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="upload_id">The ID of the upload attempt.</param>
        /// <returns></returns>
        public virtual Task<RestResult<UploadAttempt>> GetAnUploadAttemptAsync(int user_id, int upload_id) => RootAuthorization()
            .Command($"/users/{user_id}/uploads/{upload_id}")
            .GetAsync<UploadAttempt>();

        /// <summary>
        /// This method returns the specified upload attempt.
        /// </summary>
        /// <param name="upload_id">The ID of the upload attempt.</param>
        /// <returns></returns>
        public virtual Task<RestResult<UploadAttempt>> GetAnUploadAttemptAsync(int upload_id) => RootAuthorization()
            .Command($"/me/uploads/{upload_id}")
            .GetAsync<UploadAttempt>();

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
        public virtual Task<RestResult<Video>> UploadAVideoAsync(int user_id, VideoUploadParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/videos")
            .JsonPayload(parameters)
            .PostAsync<Video>();

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
        public virtual Task<RestResult<Video>> UploadAVideoAsync(VideoUploadParameters parameters) => RootAuthorization()
            .Command($"/me/videos")
            .JsonPayload(parameters)
            .PostAsync<Video>();

        #endregion

        #region [ Versions ]

        /// <summary>
        /// This method adds a version to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">Body: file_name and upload information.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VideoVersions>> AddAVersionToAVideoAsync(int video_id, VideoVersionParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/versions")
            .JsonPayload(parameters)
            .PostAsync<VideoVersions>();

        /// <summary>
        /// This method deletes the specified video version.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <returns>
        /// 204 No Content	The version was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAVideoVersionAsync(int video_id, int version_id) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}")
            .DeleteAsync();

        /// <summary>
        /// This method edits the specified video version.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <param name="parameters">Body: active.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VideoVersions>> EditAVideoVersionAsync(int video_id, int version_id, VideoVersionParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}")
            .JsonPayload(parameters)
            .PatchAsync<VideoVersions>();

        /// <summary>
        /// This method returns a single video version.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VideoVersions>> GetASpecificVideoVersionAsync(int video_id, int version_id) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}")
            .GetAsync<VideoVersions>();

        /// <summary>
        /// This method returns every version of the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<VideoVersions>>> GetAllTheVersionsOfAVideoAsync(int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/versions")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<VideoVersions>(RootAuthorization);

        #endregion

        #region [ Video comments ]

        /// <summary>
        /// This method adds a reply to the specified video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <param name="text">The text of the reply.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Comment>> AddAReplyToAVideoCommentAsync(int video_id, int comment_id, string text) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}/replies")
            .FormUrlEncoded(Pair("text", text))
            .PostAsync<Comment>();

        /// <summary>
        /// This method adds a comment to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="text">The text of the comment.</param>
        /// <returns>
        /// 201 Created	The comment was added.
        /// 403 Forbidden	Comments are disabled for the video.
        /// </returns>
        public virtual Task<RestResult<Comment>> AddAVideoCommentToAVideoAsync(int video_id, string text) => RootAuthorization()
            .Command($"/videos/{video_id}/comments")
            .FormUrlEncoded(Pair("text", text))
            .PostAsync<Comment>();

        /// <summary>
        /// This method deletes the specified video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <returns>
        /// 204 No Content	The comment was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAVideoCommentAsync(int video_id, int comment_id) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}")
            .DeleteAsync();

        /// <summary>
        /// This method edits the specified video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <param name="text">The new text of the comment.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Comment>> EditAVideoCommentAsync(int video_id, int comment_id, string text) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}")
            .FormUrlEncoded(Pair("text", text))
            .PatchAsync<Comment>();

        /// <summary>
        /// This method returns a single video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Comment>> GetASpecificVideoCommentAsync(int video_id, int comment_id) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}")
            .GetAsync<Comment>();

        /// <summary>
        /// This method returns every reply to the specified video comment.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="comment_id">The ID of the comment.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Comment>>> GetAllTheRepliesToAVideoCommentAsync(int video_id, int comment_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/comments/{comment_id}/replies")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<Comment>(RootAuthorization);

        /// <summary>
        /// This method returns every comment on the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Comment>>> GetAllTheVideoCommentsOnAVideoAsync(int video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/comments")
            .ListParameters(direction, null, page, per_page)
            .GetPaginationAsync<Comment>(RootAuthorization);

        #endregion

        #region [ Chapters ]

        /// <summary>
        /// This method returns every chapter of the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The chapters were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Chapter>>> GetAllTheChaptersOfAVideoAsync(int video_id, int? page = null, int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<Chapter>(RootAuthorization);

        /// <summary>
        /// This method adds a chapter to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="parameters">The chapter: title and timecode.</param>
        /// <returns>
        /// 201 Created	The chapter was added.
        /// </returns>
        public virtual Task<RestResult<Chapter>> AddAChapterToAVideoAsync(int video_id, ChapterParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters")
            .JsonPayload(parameters)
            .PostAsync<Chapter>();

        /// <summary>
        /// This method returns a single chapter of the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="chapter_id">The ID of the chapter.</param>
        /// <returns>
        /// 200 OK	The chapter was returned.
        /// </returns>
        public virtual Task<RestResult<Chapter>> GetASpecificChapterAsync(int video_id, int chapter_id) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/{chapter_id}")
            .GetAsync<Chapter>();

        /// <summary>
        /// This method edits the specified chapter of a video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="chapter_id">The ID of the chapter.</param>
        /// <param name="parameters">The fields to edit: title, timecode, active thumbnail.</param>
        /// <returns>
        /// 200 OK	The chapter was edited.
        /// </returns>
        public virtual Task<RestResult<Chapter>> EditAChapterAsync(int video_id, int chapter_id, ChapterParameters parameters) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/{chapter_id}")
            .JsonPayload(parameters)
            .PatchAsync<Chapter>();

        /// <summary>
        /// This method deletes the specified chapter from a video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="chapter_id">The ID of the chapter.</param>
        /// <returns>
        /// 204 No Content	The chapter was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAChapterAsync(int video_id, int chapter_id) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/{chapter_id}")
            .DeleteAsync();

        /// <summary>
        /// This method generates either an upload link (without timecode) or a timecode-based thumbnail for an unsaved video chapter.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="timecode">The timecode in seconds of the frame to use, or null to get an upload link.</param>
        /// <returns>
        /// 200 OK	The upload link or chapter thumbnail was generated.
        /// </returns>
        public virtual Task<RestResult<Picture>> GenerateAThumbnailForAnUnsavedVideoChapterAsync(int video_id, double? timecode = null) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/temporary/pictures")
            .JsonPayload(new VimeoPayload().Set("timecode", timecode))
            .PostAsync<Picture>();

        /// <summary>
        /// This method returns the specified thumbnail associated with an unsaved video chapter.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="uid">The ID of the thumbnail.</param>
        /// <returns>
        /// 200 OK	The chapter thumbnail was returned.
        /// </returns>
        public virtual Task<RestResult<Picture>> GetAThumbnailOfAnUnsavedVideoChapterAsync(int video_id, string uid) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/temporary/pictures/{uid}")
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns every thumbnail associated with the specified saved video chapter.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="chapter_id">The ID of the chapter.</param>
        /// <returns>
        /// 200 OK	The chapter thumbnails were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllTheThumbnailsOfAVideoChapterAsync(int video_id, int chapter_id) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/{chapter_id}/pictures")
            .GetPaginationAsync<Picture>(RootAuthorization);

        /// <summary>
        /// This method generates either an upload link (without timecode) or a timecode-based thumbnail for the specified saved video chapter.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="chapter_id">The ID of the chapter.</param>
        /// <param name="timecode">The timecode in seconds of the frame to use, or null to get an upload link.</param>
        /// <returns>
        /// 200 OK	The chapter thumbnail or upload link was generated.
        /// </returns>
        public virtual Task<RestResult<Picture>> GenerateAThumbnailForAVideoChapterAsync(int video_id, int chapter_id, double? timecode = null) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/{chapter_id}/pictures")
            .JsonPayload(new VimeoPayload().Set("timecode", timecode))
            .PostAsync<Picture>();

        /// <summary>
        /// This method returns the specified thumbnail associated with a saved video chapter.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="chapter_id">The ID of the chapter.</param>
        /// <param name="uid">The ID of the thumbnail.</param>
        /// <returns>
        /// 200 OK	The chapter thumbnail was returned.
        /// </returns>
        public virtual Task<RestResult<Picture>> GetAThumbnailOfAVideoChapterAsync(int video_id, int chapter_id, string uid) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/{chapter_id}/pictures/{uid}")
            .GetAsync<Picture>();

        /// <summary>
        /// This method sets the specified chapter thumbnail as active.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="chapter_id">The ID of the chapter.</param>
        /// <param name="uid">The ID of the thumbnail.</param>
        /// <param name="active">Whether to set the chapter thumbnail as active.</param>
        /// <returns>
        /// 200 OK	The chapter thumbnail was set as active.
        /// </returns>
        public virtual Task<RestResult<Picture>> SetAChapterThumbnailAsActiveAsync(int video_id, int chapter_id, string uid, bool active = true) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/{chapter_id}/pictures/{uid}")
            .JsonPayload(new VimeoPayload().Set("active", active))
            .PatchAsync<Picture>();

        /// <summary>
        /// This method deletes the specified chapter thumbnail from a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="chapter_id">The ID of the chapter.</param>
        /// <param name="uid">The ID of the thumbnail.</param>
        /// <returns>
        /// 204 No Content	The chapter thumbnail was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAChapterThumbnailAsync(int video_id, int chapter_id, string uid) => RootAuthorization()
            .Command($"/videos/{video_id}/chapters/{chapter_id}/pictures/{uid}")
            .DeleteAsync();

        #endregion

        #region [ Animated thumbnails ]

        /// <summary>
        /// This method returns all the sets of animated thumbnails associated with the specified video.
        /// The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The sets of animated thumbnails were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<AnimatedThumbset>>> GetAllTheAnimatedThumbnailsOfAVideoAsync(int video_id, int? page = null, int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/animated_thumbsets")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<AnimatedThumbset>(RootAuthorization);

        /// <summary>
        /// This method creates a set of animated thumbnails for the specified video. A video can have up to four sets.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="duration">The duration of the animation in seconds. The maximum value is 6.</param>
        /// <param name="start_time">The time in seconds corresponding to the start of the animation.</param>
        /// <returns>
        /// 200 OK	The set of animated thumbnails was created.
        /// </returns>
        public virtual Task<RestResult<AnimatedThumbset>> CreateASetOfAnimatedThumbnailsForAVideoAsync(int video_id, double duration, double? start_time = null) => RootAuthorization()
            .Command($"/videos/{video_id}/animated_thumbsets")
            .JsonPayload(new VimeoPayload().Set("duration", duration).Set("start_time", start_time))
            .PostAsync<AnimatedThumbset>();

        /// <summary>
        /// This method returns a particular set of animated thumbnails associated with the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="picture_id">The ID of the set of animated thumbnails.</param>
        /// <returns>
        /// 200 OK	The set of animated thumbnails was returned.
        /// </returns>
        public virtual Task<RestResult<AnimatedThumbset>> GetASpecificSetOfAnimatedThumbnailsAsync(int video_id, string picture_id) => RootAuthorization()
            .Command($"/videos/{video_id}/animated_thumbsets/{picture_id}")
            .GetAsync<AnimatedThumbset>();

        /// <summary>
        /// This method returns the status of a particular set of animated thumbnails: whether the thumbnails are ready.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="picture_id">The ID of the set of animated thumbnails.</param>
        /// <returns>
        /// 200 OK	The status of the set of animated thumbnails was returned.
        /// </returns>
        public virtual Task<RestResult<AnimatedThumbset>> GetTheStatusOfASetOfAnimatedThumbnailsAsync(int video_id, string picture_id) => RootAuthorization()
            .Command($"/videos/{video_id}/animated_thumbsets/{picture_id}/status")
            .GetAsync<AnimatedThumbset>();

        /// <summary>
        /// This method deletes a set of animated thumbnails for the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="picture_id">The ID of the set of animated thumbnails.</param>
        /// <returns>
        /// 204 No Content	The set of animated thumbnails was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteASetOfAnimatedThumbnailsForAVideoAsync(int video_id, string picture_id) => RootAuthorization()
            .Command($"/videos/{video_id}/animated_thumbsets/{picture_id}")
            .DeleteAsync();

        #endregion

        #region [ AI ]

        /// <summary>
        /// This method returns the list of supported languages for AI features.
        /// </summary>
        /// <param name="type">The AI feature: dubbing, subtitling, transcription.</param>
        /// <param name="dubbing_api_version">The dubbing backend (dubbing only).</param>
        /// <returns>
        /// 200 OK	The list of supported languages.
        /// </returns>
        public virtual Task<RestResult<List<AiLanguage>>> GetSupportedLanguagesForAIFeaturesAsync(AiLanguageType? type = null, AiDubbingApiVersion? dubbing_api_version = null) => RootAuthorization()
            .Command($"/videos/ai/languages")
            .OptionalParameter("type", type)
            .OptionalParameter("dubbing_api_version", dubbing_api_version)
            .GetAsync<List<AiLanguage>>();

        /// <summary>
        /// This method returns pre-generated questions and answers about a video.
        /// A 202 status code means that the video is still being prepared: retry after a few seconds.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="language">The language of the questions and answers.</param>
        /// <returns>
        /// 200 OK	The suggested questions and answers.
        /// </returns>
        public virtual Task<RestResult<AiResponse<AiQuestion[]>>> GetSuggestedQuestionsForAVideoAsync(int video_id, string language = null) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/ask")
            .OptionalParameter("language", language)
            .GetAsync<AiResponse<AiQuestion[]>>();

        /// <summary>
        /// This method asks a question about a video and returns an AI-generated answer with relevant quotes.
        /// A 202 status code means that the video is still being prepared: retry after a few seconds.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="question">The question about the video content. Maximum 500 characters.</param>
        /// <param name="language">The language of the answer.</param>
        /// <returns>
        /// 200 OK	The AI-generated answer.
        /// </returns>
        public virtual Task<RestResult<AiResponse<AiQuestion>>> AskAQuestionAboutAVideoAsync(int video_id, string question, string language = null) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/ask")
            .JsonPayload(new VimeoPayload().Set("question", question).Set("language", language))
            .PostAsync<AiResponse<AiQuestion>>();

        /// <summary>
        /// This method returns AI-generated metadata for the specified video: title, description and tags.
        /// A 202 status code means that the video is still being prepared: retry after a few seconds.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The AI-generated metadata.
        /// </returns>
        public virtual Task<RestResult<AiResponse<AiMetadata>>> GetAIGeneratedVideoMetadataAsync(int video_id) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/metadata")
            .GetAsync<AiResponse<AiMetadata>>();

        /// <summary>
        /// This method edits transcript segments on the specified text track and regenerates the dependent translations.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="texttrack_id">The ID of the text track.</param>
        /// <param name="segments">The segments to edit.</param>
        /// <returns>
        /// 200 OK	The result of the edit.
        /// </returns>
        public virtual Task<RestResult<AiTextTrackEdit>> EditTextTrackSegmentsAsync(int video_id, int texttrack_id, IEnumerable<AiTextTrackSegment> segments) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/texttracks/{texttrack_id}")
            .JsonPayload(new VimeoPayload().Set("segments", segments.Select(VimeoPayload.FromObject).ToArray()))
            .PatchAsync<AiTextTrackEdit>();

        /// <summary>
        /// This method returns the current AI transcription status for a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The transcription status was returned.
        /// </returns>
        public virtual Task<RestResult<AiStatus>> GetAITranscriptionStatusForAVideoAsync(int video_id) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/transcribe")
            .GetAsync<AiStatus>();

        /// <summary>
        /// This method generates a transcript from the video's audio using AI speech-to-text.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="language">The BCP 47 language code; when omitted, the language is auto-detected.</param>
        /// <returns>
        /// 202 Accepted	The transcription job was queued.
        /// </returns>
        public virtual Task<RestResult<AiStatus>> StartAITranscriptionForAVideoAsync(int video_id, string language = null) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/transcribe")
            .JsonPayload(new VimeoPayload().Set("language", language))
            .PostAsync<AiStatus>();

        /// <summary>
        /// This method returns the audio dubbing jobs of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="language">The language of the job to return.</param>
        /// <returns>
        /// 200 OK	The dubbing status was returned.
        /// </returns>
        public virtual Task<RestResult<AiResponse<AiTranslationJob[]>>> GetAIDubbingStatusForAVideoAsync(int video_id, string language = null) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/translate/dubbing")
            .OptionalParameter("language", language)
            .GetAsync<AiResponse<AiTranslationJob[]>>();

        /// <summary>
        /// This method starts an AI audio dubbing job for a video.
        /// By calling this endpoint you confirm that you have the rights to dub the content.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="language">The target language (see GetSupportedLanguagesForAIFeatures with dubbing).</param>
        /// <param name="accent">The accent of the dubbed audio.</param>
        /// <param name="dubbing_api_version">The dubbing backend: v1 (default) or v2.</param>
        /// <returns>
        /// 202 Accepted	The dubbing job was queued.
        /// </returns>
        public virtual Task<RestResult<AiStatus>> StartAIAudioDubbingForAVideoAsync(int video_id, string language, string accent = null, AiDubbingApiVersion? dubbing_api_version = null) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/translate/dubbing")
            .JsonPayload(new VimeoPayload().Set("language", language).Set("accent", accent).Set("dubbing_api_version", dubbing_api_version))
            .PostAsync<AiStatus>();

        /// <summary>
        /// This method returns the subtitle translation jobs of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="language">The language of the job to return.</param>
        /// <returns>
        /// 200 OK	The subtitle translation status was returned.
        /// </returns>
        public virtual Task<RestResult<AiResponse<AiTranslationJob[]>>> GetAISubtitleTranslationStatusForAVideoAsync(int video_id, string language = null) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/translate/subtitles")
            .OptionalParameter("language", language)
            .GetAsync<AiResponse<AiTranslationJob[]>>();

        /// <summary>
        /// This method starts an AI subtitle translation job for a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="language">The target language (see GetSupportedLanguagesForAIFeatures with subtitling).</param>
        /// <param name="texttrack_id">The ID of the source text track; when omitted, the default transcript is used.</param>
        /// <returns>
        /// 202 Accepted	The subtitle translation job was queued.
        /// </returns>
        public virtual Task<RestResult<AiStatus>> StartAISubtitleTranslationForAVideoAsync(int video_id, string language, int? texttrack_id = null) => RootAuthorization()
            .Command($"/videos/{video_id}/ai/translate/subtitles")
            .JsonPayload(new VimeoPayload().Set("language", language).Set("texttrack_id", texttrack_id))
            .PostAsync<AiStatus>();

        #endregion

        #region [ Version details: audio tracks, downloads, thumbnail, text tracks ]

        /// <summary>
        /// This method returns every version of the specified video in a channel. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="channel_id">The ID of the channel.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The versions were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<VideoVersions>>> GetAllTheVersionsOfAChannelVideoAsync(string channel_id, int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/channels/{channel_id}/videos/{video_id}/versions")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<VideoVersions>(RootAuthorization);

        /// <summary>
        /// This method returns all audio tracks that are associated with the specified video version.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <returns>
        /// 200 OK	The audio tracks were returned.
        /// </returns>
        public virtual Task<RestResult<VimeoList<AudioTrack>>> GetAllTheAudioTracksOfAVideoVersionAsync(int video_id, int version_id) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}/audiotracks")
            .GetAsync<VimeoList<AudioTrack>>();

        /// <summary>
        /// This method creates a new audio track for a video version. Upload the audio file to the returned upload link afterwards.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <param name="upload_approach">The upload approach: post, pull or tus.</param>
        /// <param name="upload_size">The size of the audio file in bytes (tus approach).</param>
        /// <param name="upload_link">The URL of the audio file (pull approach).</param>
        /// <param name="upload_redirect_url">The redirect URL (post approach).</param>
        /// <param name="language_code">The language of the audio track, for example en-US.</param>
        /// <param name="type">The type of audio track: commentary, descriptive or main.</param>
        /// <param name="provenance">The origin of the audio track: ai_generated, user_uploaded or user_uploaded_and_ai_generated.</param>
        /// <param name="active">Whether the audio track is enabled.</param>
        /// <returns>
        /// 200 OK	The audio track was created.
        /// </returns>
        public virtual Task<RestResult<AudioTrack>> CreateAnAudioTrackForAVideoVersionAsync(int video_id, int version_id,
            string upload_approach,
            long? upload_size = null,
            string upload_link = null,
            string upload_redirect_url = null,
            string language_code = null,
            string type = null,
            string provenance = null,
            bool? active = null) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}/audiotracks")
            .JsonPayload(new VimeoPayload()
                .Set("upload.approach", upload_approach)
                .Set("upload.size", upload_size?.ToString(System.Globalization.CultureInfo.InvariantCulture))
                .Set("upload.link", upload_link)
                .Set("upload.redirect_url", upload_redirect_url)
                .Set("language_code", language_code)
                .Set("type", type)
                .Set("provenance", provenance)
                .Set("active", active))
            .PostAsync<AudioTrack>();

        /// <summary>
        /// This method returns the specified audio track that is associated with a video version.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <param name="audiotrack_id">The ID of the audio track.</param>
        /// <returns>
        /// 200 OK	The audio track was returned.
        /// </returns>
        public virtual Task<RestResult<AudioTrack>> GetAnAudioTrackOfAVideoVersionAsync(int video_id, int version_id, string audiotrack_id) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}/audiotracks/{audiotrack_id}")
            .GetAsync<AudioTrack>();

        /// <summary>
        /// This method edits the metadata for the specified audio track.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <param name="audiotrack_id">The ID of the audio track.</param>
        /// <param name="language_code">The language of the audio track, for example en-US.</param>
        /// <param name="type">The type of audio track: commentary, descriptive or main.</param>
        /// <param name="provenance">The origin of the audio track: ai_generated, user_uploaded or user_uploaded_and_ai_generated.</param>
        /// <param name="active">Whether the audio track is enabled.</param>
        /// <returns>
        /// 200 OK	The audio track was edited.
        /// </returns>
        public virtual Task<RestResult<AudioTrack>> EditAnAudioTrackOfAVideoVersionAsync(int video_id, int version_id, string audiotrack_id,
            string language_code = null,
            string type = null,
            string provenance = null,
            bool? active = null) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}/audiotracks/{audiotrack_id}")
            .JsonPayload(new VimeoPayload()
                .Set("language_code", language_code)
                .Set("type", type)
                .Set("provenance", provenance)
                .Set("active", active))
            .PatchAsync<AudioTrack>();

        /// <summary>
        /// This method deletes an audio track from the specified video version.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <param name="audiotrack_id">The ID of the audio track.</param>
        /// <returns>
        /// 204 No Content	The audio track was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAnAudioTrackFromAVideoVersionAsync(int video_id, int version_id, string audiotrack_id) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}/audiotracks/{audiotrack_id}")
            .DeleteAsync();

        /// <summary>
        /// This method returns a list of downloadable file links for a version of a video that contains an alternate audio track.
        /// The response is not documented by the specification: it is returned as raw JSON.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <returns>
        /// 200 OK	The list of downloadable file links was returned.
        /// </returns>
        public virtual Task<RestResult<JsonElement>> GetTheDownloadLinksOfAVideoVersionAsync(int video_id, int version_id) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}/downloads")
            .GetAsync<JsonElement>();

        /// <summary>
        /// This method returns the thumbnail associated with the specified version of a video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the version.</param>
        /// <returns>
        /// 200 OK	The version thumbnail was returned.
        /// </returns>
        public virtual Task<RestResult<Picture>> GetTheThumbnailOfAVideoVersionAsync(int video_id, int version_id) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}/picture")
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns every text track of the specified video version. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="version_id">The ID of the video version.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The text tracks were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<TextTrack>>> GetAllTheTextTracksOfAVideoVersionAsync(int video_id, int version_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/videos/{video_id}/versions/{version_id}/texttracks")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<TextTrack>(RootAuthorization);

        /// <summary>
        /// This method returns every text track of the specified video in a showcase. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The text tracks were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<TextTrack>>> GetAllTheTextTracksOfAShowcaseVideoAsync(int album_id, int video_id,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/albums/{album_id}/videos/{video_id}/texttracks")
            .ListParameters(null, null, page, per_page)
            .GetPaginationAsync<TextTrack>(RootAuthorization);

        #endregion

        #region [ Transcripts ]

        /// <summary>
        /// This method returns the transcript segments of the specified text track.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="texttrack_id">The ID of the text track.</param>
        /// <returns>
        /// 200 OK	The transcript segments were returned.
        /// </returns>
        public virtual Task<RestResult<VimeoList<TranscriptSegment>>> GetTheTranscriptSegmentsOfATextTrackAsync(int video_id, int texttrack_id) => RootAuthorization()
            .Command($"/videos/{video_id}/transcripts/{texttrack_id}")
            .GetAsync<VimeoList<TranscriptSegment>>();

        /// <summary>
        /// This method returns the transcript metadata of the specified text track.
        /// </summary>
        /// <param name="container_uuid">The UUID of the video container.</param>
        /// <param name="texttrack_id">The ID of the text track.</param>
        /// <returns>
        /// 200 OK	The transcript metadata of the text track was returned.
        /// </returns>
        public virtual Task<RestResult<TranscriptMetadata>> GetTheTranscriptMetadataOfATextTrackAsync(string container_uuid, int texttrack_id) => RootAuthorization()
            .Command($"/videos/{container_uuid}/transcript/{texttrack_id}/metadata")
            .GetAsync<TranscriptMetadata>();

        #endregion

        #region [ Fragments ]

        /// <summary>
        /// This method returns all of the fragments associated with the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The fragments were returned.
        /// </returns>
        public virtual Task<RestResult<VideoFragments>> GetAllTheFragmentsOfAVideoAsync(int video_id) => RootAuthorization()
            .Command($"/videos/{video_id}/fragments")
            .GetAsync<VideoFragments>();

        /// <summary>
        /// This method updates the specified video with new fragments.
        /// The specification does not document the request body: pass the fields in <paramref name="body"/>.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="body">The fragments to set.</param>
        /// <returns>
        /// 204 No Content	The fragments were updated.
        /// </returns>
        public virtual Task<RestResult<string>> UpdateTheFragmentsOfAVideoAsync(int video_id, VimeoPayload body) => RootAuthorization()
            .Command($"/videos/{video_id}/fragments")
            .JsonPayload(body)
            .PutAsync();

        /// <summary>
        /// This method deletes all fragments for the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The fragments were deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteTheFragmentsOfAVideoAsync(int video_id) => RootAuthorization()
            .Command($"/videos/{video_id}/fragments")
            .DeleteAsync();

        #endregion

        #region [ Nondestructive trimming ]

        /// <summary>
        /// This method starts a trim operation for the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="trim_start">The start position in seconds of the trim in the video.</param>
        /// <param name="trim_end">The end position in seconds of the trim in the video.</param>
        /// <returns>
        /// 200 OK	The trim operation was started.
        /// </returns>
        public virtual Task<RestResult<TrimmedVideo>> StartATrimOperationForAVideoAsync(int video_id, double? trim_start = null, double? trim_end = null) => RootAuthorization()
            .Command($"/videos/{video_id}/trim")
            .JsonPayload(new VimeoPayload()
                .Set("trim_start", trim_start?.ToString(System.Globalization.CultureInfo.InvariantCulture))
                .Set("trim_end", trim_end?.ToString(System.Globalization.CultureInfo.InvariantCulture)))
            .PostAsync<TrimmedVideo>();

        #endregion

        #region [ Credits: available users ]

        /// <summary>
        /// This method returns the users who can be credited on the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results: alphabetical or date.</param>
        /// <returns>
        /// 200 OK	The users who can be credited were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<User>>> GetTheUsersWhoCanBeCreditedOnAVideoAsync(int video_id,
            VideoDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            string sort = null) => RootAuthorization()
            .Command($"/videos/{video_id}/credits/available_users")
            .ListParameters(direction, null, page, per_page, query, sort)
            .GetPaginationAsync<User>(RootAuthorization);

        #endregion

        #region [ Moderation ]

        /// <summary>
        /// This method returns the reasons that content of the specified type can be reported for on Vimeo.
        /// </summary>
        /// <param name="content_type">The type of content: comment, file, user, video.</param>
        /// <returns>
        /// 200 OK	The list of reasons was returned.
        /// </returns>
        public virtual Task<RestResult<ReportReasons>> GetTheReasonsThatContentCanBeReportedAsync(ReportContentType content_type) => RootAuthorization()
            .Command($"/report/reasons")
            .OptionalParameter("content_type", content_type)
            .GetAsync<ReportReasons>();

        /// <summary>
        /// This method returns a list of valid reasons for reporting inappropriate videos on Vimeo.
        /// </summary>
        /// <returns>
        /// 200 OK	The list of reasons was returned.
        /// </returns>
        public virtual Task<RestResult<ReportReasons>> GetTheReasonsThatVideosCanBeReportedAsync() => RootAuthorization()
            .Command($"/report/video_report_reasons")
            .GetAsync<ReportReasons>();

        #endregion
    }
}
