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
    using VimeoClient.Filter.Portfolio;
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// Portfolios are customizable websites for showcasing videos.
    /// Vimeo Pro, Business, and Premium subscribers have access to this feature.For more information, see our Help Center.
    /// https://developer.vimeo.com/api/reference/portfolios
    /// </summary>
    public class VimeoPortfolios
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
        public VimeoPortfolios(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoPortfolios(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]

        /// <summary>
        /// This method returns a single portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<Portfolio> GetASpecificPortfolio(int portfolio_id, int user_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns a single portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="portfolio_id">The ID of the portfolio.</param>
        /// <returns></returns>
        public RestResult<Portfolio> GetASpecificPortfolio(int portfolio_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">	The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <returns></returns>
        public RestResult<Pagination<Portfolio>> GetAllThePortfoliosThatBelongToTheUser(int user_id,
            PortfolioDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            PortfolioSort? sort = null) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every portfolio belonging to the authenticated user.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">	The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <returns></returns>
        public RestResult<Pagination<Portfolio>> GetAllThePortfoliosThatBelongToTheUser(PortfolioDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            PortfolioSort? sort = null) => throw new NotImplementedException();

        #endregion

        #region [ Videos ]
        //Add a video to a portfolio
        //Get a specific video in a portfolio
        //Get all the videos in a portfolio
        //Remove a video from a portfolio
        #endregion
    }
}