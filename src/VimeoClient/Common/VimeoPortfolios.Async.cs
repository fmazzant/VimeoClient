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
    using System;
    using Mafesoft.VimeoClient.Filter.Portfolio;
    using Mafesoft.VimeoClient.Filter.Video;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoPortfolios.
    public partial class VimeoPortfolios
    {
        #region [ Essentials ]

        /// <summary>
        /// This method returns a single portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The portfolio was returned.
        /// 404 Not Found   No such portfolio exists.
        /// </returns>
        public virtual Task<RestResult<Portfolio>> GetASpecificPortfolioAsync(int portfolio_id, int user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/portfolios/{portfolio_id}")
            .GetAsync<Portfolio>(cancellationToken);

        /// <summary>
        /// This method returns a single portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The portfolio was returned.
        /// 404 Not Found   No such portfolio exists.
        /// </returns>
        public virtual Task<RestResult<Portfolio>> GetASpecificPortfolioAsync(int portfolio_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/portfolios/{portfolio_id}")
            .GetAsync<Portfolio>(cancellationToken);

        /// <summary>
        /// This method returns every portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">	The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The portfolios were returned.</returns>
        public virtual Task<RestResult<Pagination<Portfolio>>> GetAllThePortfoliosThatBelongToTheUserAsync(int user_id,
            PortfolioDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            PortfolioSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/portfolios")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPaginationAsync<Portfolio>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">	The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The portfolios were returned.</returns>
        public virtual Task<RestResult<Pagination<Portfolio>>> GetAllThePortfoliosThatBelongToTheUserAsync(PortfolioDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            PortfolioSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/portfolios")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPaginationAsync<Portfolio>(RootAuthorization, cancellationToken);

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method adds a video to the specified portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">Number  The ID of the user</param>
        /// <param name="portfolio_id">Number  The ID of the portfolio</param>
        /// <param name="video_id">Number  The ID of the video</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// 404 Not Found   No such portfolio or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> AddAVideoToAPortfolioAsync(int user_id, int portfolio_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/portfolios/{portfolio_id}/videos/{video_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method adds a video to the specified portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="portfolio_id">Number  The ID of the portfolio</param>
        /// <param name="video_id">Number  The ID of the video</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// 404 Not Found   No such portfolio or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> AddAVideoToAPortfolioAsync(int portfolio_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/portfolios/{portfolio_id}/videos/{video_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method returns a single video from the specified portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// The video was returned.
        /// </returns>
        public virtual Task<RestResult<Video>> GetASpecificVideoInAPortfolioAsync(int user_id, int portfolio_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/portfolios/{portfolio_id}/videos/{video_id}")
            .GetAsync<Video>(cancellationToken);

        /// <summary>
        /// This method returns a single video from the specified portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// The video was returned.
        /// </returns>
        public virtual Task<RestResult<Video>> GetASpecificVideoInAPortfolioAsync(int portfolio_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/portfolios/{portfolio_id}/videos/{video_id}")
            .GetAsync<Video>(cancellationToken);

        /// <summary>
        /// This method returns every video from the specified portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="containing_uri">The page that contains the video URI.</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false).
        /// This parameter is required only when filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The videos were returned.</returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosInAPortfolioAsync(int user_id, int portfolio_id,
            string containing_uri,
            VideoFilter? filter = null,
            bool filter_embeddable = false,
            int? page = null,
            int? per_page = null,
            VideoSort? sort = null
            , CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/portfolios/{portfolio_id}/videos")
            .OptionalParameter("containing_uri", containing_uri)
            .OptionalParameter("filter_embeddable", filter == VideoFilter.embeddable ? (bool?)filter_embeddable : null)
            .ListParameters(filter: filter, page: page, per_page: per_page, sort: sort)
            .GetPaginationAsync<Video>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every video from the specified portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="containing_uri">The page that contains the video URI.</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false).
        /// This parameter is required only when filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The videos were returned.</returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosInAPortfolioAsync(int portfolio_id,
           string containing_uri,
           VideoFilter? filter = null,
           bool filter_embeddable = false,
           int? page = null,
           int? per_page = null,
           VideoSort? sort = null
           , CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/portfolios/{portfolio_id}/videos")
            .OptionalParameter("containing_uri", containing_uri)
            .OptionalParameter("filter_embeddable", filter == VideoFilter.embeddable ? (bool?)filter_embeddable : null)
            .ListParameters(filter: filter, page: page, per_page: per_page, sort: sort)
            .GetPaginationAsync<Video>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every video from the specified portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The videos were returned.</returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosInAPortfolioAsync(int portfolio_id, CancellationToken cancellationToken = default)
            => GetAllTheVideosInAPortfolioAsync(portfolio_id, null, cancellationToken: cancellationToken);

        /// <summary>
        /// This method removes a video from the specified portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was removed.
        /// 404 Not Found   No such portfolio or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveAVideoFromAPortfolioAsync(int user_id, int portfolio_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/portfolios/{portfolio_id}/videos/{video_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method removes a video from the specified portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The video was removed.
        /// 404 Not Found   No such portfolio or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveAVideoFromAPortfolioAsync(int portfolio_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/portfolios/{portfolio_id}/videos/{video_id}")
            .DeleteAsync(cancellationToken);

        #endregion
    }
}
