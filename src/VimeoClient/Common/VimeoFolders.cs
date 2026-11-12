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
    using Mafesoft.VimeoClient.Body.Folder;
    using Mafesoft.VimeoClient.Filter.Folder;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;

    /// <summary>
    /// VimeoFolders
    /// https://developer.vimeo.com/api/reference/folders
    /// </summary>
    public class VimeoFolders
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
        /// Create a new instance of VimeoFolders class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoFolders(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoFolders(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essential ]

        /// <summary>
        /// This method creates a new folder for the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="parameters">Body: name (required) and parent_folder_uri</param>
        /// <returns>
        /// 201 Created	The folder was created.
        /// 400 Bad Request
        /// Error code 2205: The input is empty.
        /// Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't create folders.
        /// </returns>
        public virtual RestResult<Project> CreateAFolder(int user_id, FolderEditParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/projects")
            .FormUrlEncoded(parameters)
            .Post<Project>();

        /// <summary>
        /// This method creates a new folder for the authenticated user.
        /// </summary>
        /// <param name="parameters">Body: name (required) and parent_folder_uri</param>
        /// <returns>
        /// 201 Created	The folder was created.
        /// 400 Bad Request
        /// Error code 2205: The input is empty.
        /// Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't create folders.
        /// </returns>
        public virtual RestResult<Project> CreateAFolder(FolderEditParameters parameters) => RootAuthorization()
            .Command($"/me/projects")
            .FormUrlEncoded(parameters)
            .Post<Project>();

        /// <summary>
        /// This method deletes the specified folder and optionally also the videos that it contains. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="should_delete_clips">Whether to delete all the videos in the folder along with the folder itself.</param>
        /// <returns>
        /// 204 No Content	The folder was deleted.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't delete the folder.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult DeleteAFolder(int project_id, int user_id, bool should_delete_clips) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}")
            .OptionalParameter("should_delete_clips", should_delete_clips)
            .Delete();

        /// <summary>
        /// This method deletes the specified folder and optionally also the videos that it contains. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="should_delete_clips">Whether to delete all the videos in the folder along with the folder itself.</param>
        /// <returns>
        /// 204 No Content	The folder was deleted.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't delete the folder.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult DeleteAFolder(int project_id, bool should_delete_clips) => RootAuthorization()
            .Command($"/me/projects/{project_id}")
            .OptionalParameter("should_delete_clips", should_delete_clips)
            .Delete();

        /// <summary>
        /// This method edits the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="parameters">Body</param>
        /// <returns>
        /// 200 OK	The folder was edited.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult<Project> EditAFolder(int project_id, int user_id, FolderEditParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}")
            .FormUrlEncoded(parameters)
            .Patch<Project>();

        /// <summary>
        /// This method edits the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="parameters">Body</param>
        /// <returns>
        /// 200 OK	The folder was edited.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult<Project> EditAFolder(int project_id, FolderEditParameters parameters) => RootAuthorization()
            .Command($"/me/projects/{project_id}")
            .FormUrlEncoded(parameters)
            .Patch<Project>();

        /// <summary>
        /// This method returns a single folder belonging to the authenticated user.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 200 OK	The folder was returned.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult<Project> GetASpecificFolder(int project_id, int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}")
            .Get<Project>();

        /// <summary>
        /// This method returns a single folder belonging to the authenticated user.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <returns>
        /// 200 OK	The folder was returned.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult<Project> GetASpecificFolder(int project_id) => RootAuthorization()
            .Command($"/me/projects/{project_id}")
            .Get<Project>();

        /// <summary>
        /// This method returns all the folders belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <returns>
        /// 200 OK	The folders were returned.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// </returns>
        public virtual RestResult<Pagination<Project>> GetAllTheFoldersThatBelongToTheUser(int user_id,
            FolderDirection? direction = null,
            FolderSort? sort = null,
            int? page = null,
            int? per_page = null,
            string query = null) => RootAuthorization()
            .Command($"/users/{user_id}/projects")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPagination<Project>(RootAuthorization);

        /// <summary>
        /// This method returns all the folders belonging to the authenticated user.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <returns>
        /// 200 OK	The folders were returned.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// </returns>
        public virtual RestResult<Pagination<Project>> GetAllTheFoldersThatBelongToTheUser(FolderDirection? direction = null,
            FolderSort? sort = null,
            int? page = null,
            int? per_page = null,
            string query = null) => RootAuthorization()
            .Command($"/me/projects")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPagination<Project>(RootAuthorization);

        /// <summary>
        /// This method returns the private-to-me folder of the specified user.
        /// </summary>
        /// <param name="owner_id">The ID of the owner of the folder.</param>
        /// <returns>
        /// 200 OK	The folder was returned.
        /// </returns>
        public virtual RestResult<Project> GetAUserPrivateToMeFolder(int owner_id) => RootAuthorization()
            .Command($"/users/{owner_id}/folders/private_to_me")
            .Get<Project>();

        #endregion

        #region [ Items ]

        /// <summary>
        /// This method returns every item (videos, folders, live events, files) that belongs to the specified folder.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The type of item to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="clip_privacy_filters">The privacy filters of the videos to return.</param>
        /// <returns>
        /// 200 OK	The items were returned.
        /// </returns>
        public virtual RestResult<Pagination<ProjectItem>> GetAllTheItemsInAFolder(int user_id, int project_id,
            FolderDirection? direction = null,
            FolderItemFilter? filter = null,
            int? page = null,
            int? per_page = null,
            FolderItemSort? sort = null,
            string clip_privacy_filters = null) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}/items")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .OptionalParameter("clip_privacy_filters", clip_privacy_filters)
            .GetPagination<ProjectItem>(RootAuthorization);

        /// <summary>
        /// This method returns every item (videos, folders, live events, files) that belongs to the specified folder of the authenticated user.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The type of item to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="clip_privacy_filters">The privacy filters of the videos to return.</param>
        /// <returns>
        /// 200 OK	The items were returned.
        /// </returns>
        public virtual RestResult<Pagination<ProjectItem>> MeGetAllTheItemsInAFolder(int project_id,
            FolderDirection? direction = null,
            FolderItemFilter? filter = null,
            int? page = null,
            int? per_page = null,
            FolderItemSort? sort = null,
            string clip_privacy_filters = null) => RootAuthorization()
            .Command($"/me/projects/{project_id}/items")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .OptionalParameter("clip_privacy_filters", clip_privacy_filters)
            .GetPagination<ProjectItem>(RootAuthorization);

        /// <summary>
        /// This method removes the specified items from a folder of the authenticated user.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="uris">The URIs of the items to remove.</param>
        /// <param name="should_delete_items">Whether to delete the items when removing them from the folder.</param>
        /// <param name="send_to_recently_deleted">Whether the deleted items go to the Recently Deleted bin.</param>
        /// <returns>
        /// 204 No Content	The items were removed.
        /// </returns>
        public virtual RestResult MeRemoveItemsFromAFolder(int project_id, string[] uris, bool? should_delete_items = null, bool? send_to_recently_deleted = null) => RootAuthorization()
            .Command($"/me/projects/{project_id}/items")
            .OptionalParameter("uris", uris)
            .OptionalParameter("should_delete_items", should_delete_items)
            .OptionalParameter("send_to_recently_deleted", send_to_recently_deleted)
            .Delete();

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method adds multiple videos to the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="uris">A list of video URIs to add (sent comma-separated).</param>
        /// <returns>
        /// 204 No Content	The videos were added.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder or video exists.
        /// </returns>
        public virtual RestResult AddAListOfVideosToAFolder(int project_id, int user_id, string[] uris) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}/videos")
            .OptionalParameter("uris", uris)
            .Put();

        /// <summary>
        /// This method adds multiple videos to the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="uris">A list of video URIs to add (sent comma-separated).</param>
        /// <returns>
        /// 204 No Content	The videos were added.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder or video exists.
        /// </returns>
        public virtual RestResult AddAListOfVideosToAFolder(int project_id, string[] uris) => RootAuthorization()
            .Command($"/me/projects/{project_id}/videos")
            .OptionalParameter("uris", uris)
            .Put();

        /// <summary>
        /// This method adds a single video to the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// 404 Not Found   Error code 5000: No such user, folder, or video exists.
        /// </returns>
        public virtual RestResult AddASpecificVideoToAFolder(int project_id, int user_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}/videos/{video_id}")
            .Put();

        /// <summary>
        /// This method adds a single video to the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// 404 Not Found   Error code 5000: No such user, folder, or video exists.
        /// </returns>
        public virtual RestResult AddASpecificVideoToAFolder(int project_id, int video_id) => RootAuthorization()
            .Command($"/me/projects/{project_id}/videos/{video_id}")
            .Put();

        /// <summary>
        /// This method returns all the videos that belong to the specified folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">	The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult<Pagination<Video>> GetAllTheVideoInAFolder(int project_id, int user_id, FolderDirection? direction = null, int? page = null, int? per_page = null, string query = null, FilderAllVideoSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}/videos")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPagination<Video>(RootAuthorization);

        /// <summary>
        /// This method returns all the videos that belong to the specified folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">	The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult<Pagination<Video>> GetAllTheVideoInAFolder(int project_id, FolderDirection? direction = null, int? page = null, int? per_page = null, string query = null, FilderAllVideoSort? sort = null) => RootAuthorization()
            .Command($"/me/projects/{project_id}/videos")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPagination<Video>(RootAuthorization);

        /// <summary>
        /// This method removes multiple videos from the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="uris">A comma-separated list of the video URIs to remove.</param>
        /// <param name="should_delete_clips">Whether to delete the videos when removing them from the folder.</param>
        /// <returns>
        /// 204 No Content	The videos were removed.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult RemoveAListOfVideosFromAFolder(int user_id, int project_id, string uris, bool should_delete_clips) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}/videos")
            .OptionalParameter("uris", uris)
            .OptionalParameter("should_delete_clips", should_delete_clips)
            .Delete();

        /// <summary>
        /// This method removes multiple videos from the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="uris">A comma-separated list of the video URIs to remove.</param>
        /// <param name="should_delete_clips">Whether to delete the videos when removing them from the folder.</param>
        /// <returns>
        /// 204 No Content	The videos were removed.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public virtual RestResult RemoveAListOfVideosFromAFolder(int project_id, string uris, bool should_delete_clips) => RootAuthorization()
            .Command($"/me/projects/{project_id}/videos")
            .OptionalParameter("uris", uris)
            .OptionalParameter("should_delete_clips", should_delete_clips)
            .Delete();

        /// <summary>
        /// This method removes a single video from the specified folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was removed.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such video exists in the folder.
        /// </returns>
        public virtual RestResult RemoveASpecificVideoFromAFolder(int project_id, int user_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}/videos/{video_id}")
            .Delete();

        /// <summary>
        /// This method removes a single video from the specified folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was removed.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such video exists in the folder.
        /// </returns>
        public virtual RestResult RemoveASpecificVideoFromAFolder(int project_id, int video_id) => RootAuthorization()
            .Command($"/me/projects/{project_id}/videos/{video_id}")
            .Delete();

        #endregion
    }
}
