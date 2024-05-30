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
    using VimeoClient.Model;
    using VimeoClient.Body.OnDemand;
    using VimeoClient.Filter.OnDemand;
    using VimeoClient.Response;

    /// <summary>
    /// Vimeo On Demand is a marketplace for films, series, and other member-produced videos. For more information, see our Help Center FAQs for On Demand purchases or On Demand sales.
    /// https://developer.vimeo.com/api/reference/on-demand
    /// </summary>
    public class VimeoOnDemand
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
        public VimeoOnDemand(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoOnDemand(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]

        /// <summary>
        /// This method creates a new On Demand page for the specified user. To publish the page, use the edit method.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="body"></param>
        /// <returns>The on demand page representation consists of the following fields.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual RestResult<OnDemandPage> CreateAnOnDemandPage(int user_id, CreateAnOnDemandPageBody body) => throw new NotImplementedException();

        /// <summary>
        /// This method creates a new On Demand page for the specified user. To publish the page, use the edit method.
        /// </summary>
        /// <param name="body"></param>
        /// <returns>The on demand page representation consists of the following fields.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual RestResult<OnDemandPage> MeCreateAnOnDemandPage(CreateAnOnDemandPageBody body) => throw new NotImplementedException();

        /// <summary>
        /// This method deletes the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual RestResult DeleteAnOnDemandPage(int ondemand_id) => throw new NotImplementedException();

        /// <summary>
        /// This method edits the specified On Demand page. Use this method to enable preorders on the page or to publish the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="body"></param>
        /// <returns>The on demand page representation consists of the following fields.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual RestResult<OnDemandPage> EditAnOnDemandPage(int ondemand_id, EditAnOnDemandPageBody body) => throw new NotImplementedException();

        /// <summary>
        /// This method returns the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>The on demand page representation consists of the following fields.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual RestResult<OnDemandPage> GetASpecificOnDemandPage(int ondemand_id) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every On Demand page belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The type of the page to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>The on demand page representation consists of the following fields.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual RestResult<Pagination<OnDemandPage>> GetAllTheOnDemandPagesOfTheUser(int user_id, OnDemandDirection? direction,
            OnDemandFilter? filter,
            int? page = null,
            int? per_page = null,
           OnDemandSortGetAllChannel? sort = null) => throw new NotImplementedException();

        /// <summary>
        /// This method returns every On Demand page belonging to the authenticated user.
        /// </summary>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The type of the page to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>The on demand page representation consists of the following fields.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual RestResult<Pagination<OnDemandPage>> MeGetAllTheOnDemandPagesOfTheUser(OnDemandDirection? direction,
            OnDemandFilter? filter,
            int? page = null,
            int? per_page = null,
            OnDemandSortGetAllChannel? sort = null) => throw new NotImplementedException();
        #endregion

        #region [ Backgrounds ]
        //Add a background to an On Demand page
        //Delete a background on an On Demand page
        //Edit a background on an On Demand page
        //Get a specific background on an On Demand page
        //Get all the backgrounds on an On Demand page
        #endregion

        #region [ Genres ]
        //Add a genre to an On Demand page
        //Check whether an On Demand page belongs to a specific genre
        //Get a specific On Demand genre
        //Get a specific On Demand page in a genre
        //Get all On Demand genres
        //Get all the On Demand pages in a genre
        //Get all the genres of an On Demand page
        //Remove a genre from an On Demand page
        #endregion

        #region [ Posters ]
        //Add a poster to an On Demand page
        //Edit a poster on an On Demand page
        //Get a specific poster on an On Demand page
        //Get all the posters on an On Demand page
        #endregion

        #region [ Promotions ]
        //Add a promotion to an On Demand page
        //Delete a promotion on an On Demand page
        //Get a specific promotion on an On Demand page
        //Get all the codes of a promotion on an On Demand page
        //Get all the promotions on an On Demand page
        #endregion

        #region [ Purchases and rentals ]
        //Get all the On Demand purchases and rentals that the user has made
        #endregion

        #region [ Regions ]
        //Add a list of regions to an On Demand page
        //Add a specific region to an On Demand page
        //Get a specific On Demand region
        //Get a specific region on an On Demand page
        //Get all the On Demand regions
        //Get all the regions on an On Demand page
        //Remove a list of regions from an On Demand page
        //Remove a specific region from an On Demand page
        #endregion

        #region [ Seasons ]
        //Get a specific season on an On Demand page
        //Get all the seasons on an On Demand page
        //Get all the videos in a season on an On Demand page
        #endregion

        #region [ Videos ]
        //Add a video to an On Demand page
        //Get a specific video on an On Demand page
        //Get all the videos on an On Demand page
        //Remove a video from an On Demand page
        #endregion
    }
}