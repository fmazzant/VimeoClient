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
        //Add a specific video to a folder
        //Get all the videos in a folder
        //Remove a list of videos from a folder
        //Remove a specific video from a folder
        #endregion

    }
}