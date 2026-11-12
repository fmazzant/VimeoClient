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
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;

    /// <summary>
    /// Federated search over the videos and folders of a user or a workspace.
    /// https://developer.vimeo.com/api/reference/search
    /// </summary>
    public class VimeoSearch
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
        /// Create a new instance of VimeoSearch class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoSearch(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoSearch(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Federated ]

        /// <summary>
        /// This method returns the federated search results of the authenticated user's videos and folders according to a search query.
        /// If no query is provided, the method returns items sorted by the most recent user action.
        /// GET https://api.vimeo.com/search/{user_id}/items
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="query_fields">The fields to query over. The default value is title,description,chapters,tags.</param>
        /// <param name="filter">The attribute by which to filter the results: video.</param>
        /// <param name="filter_privacy">The privacy settings to filter the results by, for example unlisted.</param>
        /// <param name="modified_start_date">The inclusive start date of the range.</param>
        /// <param name="modified_end_date">The inclusive end date of the range.</param>
        /// <param name="direction">The sort direction of the results: asc or desc.</param>
        /// <param name="sort">The way to sort the results: alphabetical, date, default, duration, folder_path, last_user_action_event_date.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The federated search results were returned.
        /// </returns>
        public virtual RestResult<Pagination<ProjectItem>> SearchTheItemsOfAUser(string user_id,
            string query = null,
            string[] query_fields = null,
            string filter = null,
            string[] filter_privacy = null,
            string modified_start_date = null,
            string modified_end_date = null,
            string direction = null,
            string sort = null,
            int? page = null,
            int? per_page = null) => SearchParameters(RootAuthorization().Command($"/search/{user_id}/items"),
                query, query_fields, filter, filter_privacy, modified_start_date, modified_end_date, direction, sort, page, per_page)
            .GetPagination<ProjectItem>(RootAuthorization);

        /// <summary>
        /// This method returns the federated search results of the items of the specified workspace according to a search query.
        /// If no query is provided, the method returns items sorted by the most recent user action.
        /// GET https://api.vimeo.com/workspaces/search/{workspace_uuid}/items
        /// </summary>
        /// <param name="workspace_uuid">The UUID of the workspace.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="query_fields">The fields to query over. The default value is title,description,chapters,tags.</param>
        /// <param name="filter">The attribute by which to filter the results: video.</param>
        /// <param name="filter_privacy">The privacy settings to filter the results by, for example unlisted.</param>
        /// <param name="modified_start_date">The inclusive start date of the range.</param>
        /// <param name="modified_end_date">The inclusive end date of the range.</param>
        /// <param name="direction">The sort direction of the results: asc or desc.</param>
        /// <param name="sort">The way to sort the results: alphabetical, date, default, duration, folder_path, last_user_action_event_date.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The federated search results were returned.
        /// </returns>
        public virtual RestResult<Pagination<ProjectItem>> SearchTheItemsOfAWorkspace(string workspace_uuid,
            string query = null,
            string[] query_fields = null,
            string filter = null,
            string[] filter_privacy = null,
            string modified_start_date = null,
            string modified_end_date = null,
            string direction = null,
            string sort = null,
            int? page = null,
            int? per_page = null) => SearchParameters(RootAuthorization().Command($"/workspaces/search/{workspace_uuid}/items"),
                query, query_fields, filter, filter_privacy, modified_start_date, modified_end_date, direction, sort, page, per_page)
            .GetPagination<ProjectItem>(RootAuthorization);

        #endregion

        /// <summary>
        /// Adds the federated search query parameters.
        /// </summary>
        protected virtual RestBuilder SearchParameters(RestBuilder root,
            string query, string[] query_fields, string filter, string[] filter_privacy,
            string modified_start_date, string modified_end_date,
            string direction, string sort, int? page, int? per_page) => root
            .OptionalParameter("query_fields", query_fields)
            .OptionalParameter("filter_privacy", filter_privacy)
            .OptionalParameter("modified_start_date", modified_start_date)
            .OptionalParameter("modified_end_date", modified_end_date)
            .ListParameters(direction, filter, page, per_page, query, sort);
    }
}
