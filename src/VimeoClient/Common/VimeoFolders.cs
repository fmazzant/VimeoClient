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
    using VimeoClient.Body.Folder;
    using VimeoClient.Filter.Folder;
    using VimeoClient.Model;
    using VimeoClient.Response;

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
        /// Create a new instance of VimeoCategories class
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
        /// <returns>
        /// 201 Created	The folder was created.
        /// 400 Bad Request
        /// Error code 2205: The input is empty.
        /// Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't create folders.
        /// </returns>
        public RestResult<Project> CreateAFolder(int user_id, FolderEditParameters parameters) => throw new NotImplementedException();

        /// <summary>
        /// This method creates a new folder for the authenticated user.
        /// </summary>
        /// <returns>
        /// 201 Created	The folder was created.
        /// 400 Bad Request
        /// Error code 2205: The input is empty.
        /// Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't create folders. 
        /// </returns>
        public RestResult<Project> CreateAFolder(FolderEditParameters parameters) => throw new NotImplementedException();

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
        public RestResult DeleteAFolder(int project_id, int user_id, bool should_delete_clips) => throw new NotImplementedException();

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
        public RestResult DeleteAFolder(int project_id, bool should_delete_clips) => throw new NotImplementedException();

        /// <summary>
        /// This method edits the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="parameters">Body</param>
        /// <returns></returns>
        public RestResult<Project> EditAFolder(int project_id, int user_id, FolderEditParameters parameters) => throw new NotImplementedException();

        /// <summary>
        /// This method edits the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="parameters">Body</param>
        /// <returns></returns>
        public RestResult<Project> EditAFolder(int project_id, FolderEditParameters parameters) => throw new NotImplementedException();

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
        public RestResult<Project> GetASpecificFolder(int project_id, int user_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns a single folder belonging to the authenticated user.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <returns>
        /// 200 OK	The folder was returned.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public RestResult<Project> GetASpecificFolder(int project_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns all the folders belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<Pagination<Project>> GetAllTheFoldersThatBelongToTheUser(int user_id, FolderDirection direction, FolderSort sort, int? page = null, int? per_page = null) => throw new NotImplementedException();
        #endregion

        #region [ Videos ]
        //Add a list of videos to a folder
        /// <summary>
        /// This method adds multiple videos to the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="uris">A comma-separated list of video URIs to add.</param>
        /// <returns></returns>
        public RestResult AddAListOfVideosToAFolder(int project_id, int user_id, string[] uris) => throw new NotImplementedException();

        /// <summary>
        /// This method adds multiple videos to the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="uris">A comma-separated list of video URIs to add.</param>
        /// <returns>
        /// 204 No Content	The videos were added.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder or video exists.
        /// </returns>
        public RestResult AddAListOfVideosToAFolder(int project_id, string[] uris) => throw new NotImplementedException();

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
        public RestResult AddASpecificVideoToAFolder(int project_id, int user_id, int video_id) => throw new NotImplementedException();

        /// <summary>
        /// This method adds a single video to the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// 404 Not Found   Error code 5000: No such user, folder, or video exists.
        /// </returns>
        public RestResult AddASpecificVideoToAFolder(int project_id, int video_id) => throw new NotImplementedException();

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
        /// <returns></returns>
        public RestResult<Pagination<Video>> GetAllTheVideoInAFolder(int project_id, int user_id, FolderDirection direction, int? page = null, int? per_page, string query = null, FilderAllVideoSort sort) => throw new NotImplementedException();

        /// <summary>
        /// This method returns all the videos that belong to the specified folder.
        /// </summary>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">	The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns></returns>
        public RestResult<Pagination<Video>> GetAllTheVideoInAFolder(int project_id, FolderDirection direction, int? page = null, int? per_page, string query = null, FilderAllVideoSort sort) => throw new NotImplementedException();

        /// <summary>
        /// This method removes multiple videos from the specified folder. The authenticated user must be the owner of the folder.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="project_id">The ID of the folder.</param>
        /// <returns>
        /// 204 No Content	The videos were removed.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 401 Unauthorized Error code 8000: The user credentials are invalid.
        /// 404 Not Found   Error code 5000: No such folder exists.
        /// </returns>
        public RestResult RemoveAListOfVideosFromAFolder(int user_id, int project_id, string uris, bool should_delete_clips) => throw new NullReferenceException();

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
        public RestResult RemoveAListOfVideosFromAFolder(int project_id, string uris, bool should_delete_clips) => throw new NullReferenceException();

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
        public RestResult RemoveASpecificVideoFromAFolder(int project_id, int user_id, int video_id) => throw new NullReferenceException();

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
        public RestResult RemoveASpecificVideoFromAFolder(int project_id, int video_id) => throw new NullReferenceException();

        #endregion

    }
}