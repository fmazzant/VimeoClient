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
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoSearch.
    public partial class VimeoSearch
    {
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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The federated search results were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<ProjectItem>>> SearchTheItemsOfAUserAsync(string user_id,
            string query = null,
            string[] query_fields = null,
            string filter = null,
            string[] filter_privacy = null,
            string modified_start_date = null,
            string modified_end_date = null,
            string direction = null,
            string sort = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default) => SearchParameters(RootAuthorization().Command($"/search/{user_id}/items"),
                query, query_fields, filter, filter_privacy, modified_start_date, modified_end_date, direction, sort, page, per_page)
            .GetPaginationAsync<ProjectItem>(RootAuthorization, cancellationToken);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The federated search results were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<ProjectItem>>> SearchTheItemsOfAWorkspaceAsync(string workspace_uuid,
            string query = null,
            string[] query_fields = null,
            string filter = null,
            string[] filter_privacy = null,
            string modified_start_date = null,
            string modified_end_date = null,
            string direction = null,
            string sort = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default) => SearchParameters(RootAuthorization().Command($"/workspaces/search/{workspace_uuid}/items"),
                query, query_fields, filter, filter_privacy, modified_start_date, modified_end_date, direction, sort, page, per_page)
            .GetPaginationAsync<ProjectItem>(RootAuthorization, cancellationToken);

        #endregion
    }
}
