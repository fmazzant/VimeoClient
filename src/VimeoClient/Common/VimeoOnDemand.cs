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
    using Mafesoft.VimeoClient.Body.OnDemand;
    using Mafesoft.VimeoClient.Filter.OnDemand;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;

    /// <summary>
    /// Vimeo On Demand is a marketplace for films, series, and other member-produced videos.
    /// For more information, see our Help Center FAQs for On Demand purchases or On Demand sales.
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
        /// Create a new instance of VimeoOnDemand class
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
        /// <param name="body">The page to create. Type, Name, Description and ContentRating are required.</param>
        /// <returns>
        /// 201 Created	The On Demand page was created.
        /// 400 Bad Request A parameter is invalid.
        /// 403 Forbidden The authenticated user can't create On Demand pages.
        /// </returns>
        public virtual RestResult<OnDemandPage> CreateAnOnDemandPage(int user_id, CreateAnOnDemandPageBody body) => RootAuthorization()
            .Command($"/users/{user_id}/ondemand/pages")
            .JsonPayload(body)
            .Post<OnDemandPage>();

        /// <summary>
        /// This method creates a new On Demand page for the authenticated user. To publish the page, use the edit method.
        /// </summary>
        /// <param name="body">The page to create. Type, Name, Description and ContentRating are required.</param>
        /// <returns>
        /// 201 Created	The On Demand page was created.
        /// 400 Bad Request A parameter is invalid.
        /// 403 Forbidden The authenticated user can't create On Demand pages.
        /// </returns>
        public virtual RestResult<OnDemandPage> MeCreateAnOnDemandPage(CreateAnOnDemandPageBody body) => RootAuthorization()
            .Command($"/me/ondemand/pages")
            .JsonPayload(body)
            .Post<OnDemandPage>();

        /// <summary>
        /// This method deletes the specified On Demand page. Only draft pages can be deleted.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>
        /// 204 No Content	The On Demand page was deleted.
        /// 403 Forbidden The page isn't a draft or the authenticated user isn't the owner.
        /// </returns>
        public virtual RestResult DeleteAnOnDemandPage(int ondemand_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified On Demand page. Use this method to enable preorders on the page or to publish the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="body">The fields to edit.</param>
        /// <returns>
        /// 200 OK	The On Demand page was edited.
        /// 400 Bad Request A parameter is invalid.
        /// 403 Forbidden The authenticated user isn't the owner of the page.
        /// </returns>
        public virtual RestResult<OnDemandPage> EditAnOnDemandPage(int ondemand_id, EditAnOnDemandPageBody body) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}")
            .JsonPayload(body)
            .Patch<OnDemandPage>();

        /// <summary>
        /// This method returns the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>
        /// 200 OK	The On Demand page was returned.
        /// 404 Not Found No such On Demand page exists.
        /// </returns>
        public virtual RestResult<OnDemandPage> GetASpecificOnDemandPage(int ondemand_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}")
            .Get<OnDemandPage>();

        /// <summary>
        /// This method returns every On Demand page belonging to the specified user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The type of the page to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>200 OK	The On Demand pages were returned.</returns>
        public virtual RestResult<Pagination<OnDemandPage>> GetAllTheOnDemandPagesOfTheUser(int user_id,
            OnDemandDirection? direction = null,
            OnDemandFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandPagesSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/ondemand/pages")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPagination<OnDemandPage>(RootAuthorization);

        /// <summary>
        /// This method returns every On Demand page belonging to the authenticated user.
        /// </summary>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The type of the page to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>200 OK	The On Demand pages were returned.</returns>
        public virtual RestResult<Pagination<OnDemandPage>> MeGetAllTheOnDemandPagesOfTheUser(OnDemandDirection? direction = null,
            OnDemandFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandPagesSort? sort = null) => RootAuthorization()
            .Command($"/me/ondemand/pages")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPagination<OnDemandPage>(RootAuthorization);

        #endregion

        #region [ Backgrounds ]

        /// <summary>
        /// This method adds a background image to the specified On Demand page. The authenticated user must be the owner of the page.
        /// The returned picture contains the link to upload the image.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>201 Created	The background was added.</returns>
        public virtual RestResult<Picture> AddABackgroundToAnOnDemandPage(int ondemand_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds")
            .Post<Picture>();

        /// <summary>
        /// This method deletes the specified background image on an On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="background_id">The ID of the background image.</param>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>204 No Content	The background was deleted.</returns>
        public virtual RestResult DeleteABackgroundOnAnOnDemandPage(int background_id, int ondemand_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds/{background_id}")
            .Delete();

        /// <summary>
        /// This method edits the specified background image on an On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="background_id">The ID of the background image.</param>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="body">The fields to edit.</param>
        /// <returns>200 OK	The background was edited.</returns>
        public virtual RestResult<Picture> EditABackgroundToAnOnDemandPage(int background_id, int ondemand_id, EditABackgroundToAnOnDemandPageBody body) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds/{background_id}")
            .JsonPayload(body)
            .Patch<Picture>();

        /// <summary>
        /// This method returns the specified background image on an On Demand page.
        /// </summary>
        /// <param name="background_id">The ID of the background image.</param>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>200 OK	The background was returned.</returns>
        public virtual RestResult<Picture> GetASpecificBackgroundOnAnOnDemandPage(int background_id, int ondemand_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds/{background_id}")
            .Get<Picture>();

        /// <summary>
        /// This method returns every background image on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>200 OK	The backgrounds were returned.</returns>
        public virtual RestResult<Pagination<Picture>> GetAllTheBackgroundsOnAnOnDemandPage(int ondemand_id, int? page = null, int? per_page = null) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds")
            .ListParameters(page: page, per_page: per_page)
            .GetPagination<Picture>(RootAuthorization);

        #endregion

        #region [ Genres ]

        /// <summary>
        /// This method adds a genre to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <returns>
        /// 201 Created	The genre was added.
        /// 400 Bad Request The page already has the maximum number of genres.
        /// </returns>
        public virtual RestResult<OnDemandGenre> AddAGenreToAnOnDemandPage(int ondemand_id, string genre_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/genres/{genre_id}")
            .Put<OnDemandGenre>();

        /// <summary>
        /// This method checks whether the specified On Demand page belongs to a genre.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <returns>
        /// 200 OK	The page belongs to the genre.
        /// 404 Not Found The page doesn't belong to the genre.
        /// </returns>
        public virtual RestResult<OnDemandGenre> CheckWhetherAnOnDemandPageBelongsToASpecificGenre(int ondemand_id, string genre_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/genres/{genre_id}")
            .Get<OnDemandGenre>();

        /// <summary>
        /// This method returns the specified On Demand genre.
        /// </summary>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <returns>200 OK	The genre was returned.</returns>
        public virtual RestResult<OnDemandGenre> GetASpecificOnDemandGenre(string genre_id) => RootAuthorization()
            .Command($"/ondemand/genres/{genre_id}")
            .Get<OnDemandGenre>();

        /// <summary>
        /// This method checks whether the specified On Demand page belongs to a genre and returns the page.
        /// </summary>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>200 OK	The page was returned.</returns>
        public virtual RestResult<OnDemandPage> GetASpecificOnDemandPageInAGenre(string genre_id, int ondemand_id) => RootAuthorization()
            .Command($"/ondemand/genres/{genre_id}/pages/{ondemand_id}")
            .Get<OnDemandPage>();

        /// <summary>
        /// This method returns every available On Demand genre.
        /// </summary>
        /// <returns>200 OK	The genres were returned.</returns>
        public virtual RestResult<VimeoList<OnDemandGenre>> GetAllOnDemandGenres() => RootAuthorization()
            .Command($"/ondemand/genres")
            .Get<VimeoList<OnDemandGenre>>();

        /// <summary>
        /// This method returns every On Demand page that belongs to the specified genre.
        /// </summary>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>200 OK	The pages were returned.</returns>
        public virtual RestResult<Pagination<OnDemandPage>> GetAllTheOnDemandPagesInAGenre(string genre_id,
            OnDemandDirection? direction = null,
            OnDemandGenrePagesFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            OnDemandGenrePagesSort? sort = null) => RootAuthorization()
            .Command($"/ondemand/genres/{genre_id}/pages")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .GetPagination<OnDemandPage>(RootAuthorization);

        /// <summary>
        /// This method returns every genre of the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>200 OK	The genres were returned.</returns>
        public virtual RestResult<VimeoList<OnDemandGenre>> GetAllTheGenresOfAnOnDemandPage(int ondemand_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/genres")
            .Get<VimeoList<OnDemandGenre>>();

        /// <summary>
        /// This method removes a genre from the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <returns>
        /// 204 No Content	The genre was removed.
        /// 400 Bad Request The page must have at least one genre.
        /// </returns>
        public virtual RestResult RemoveAGenreFromAnOnDemandPage(int ondemand_id, string genre_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/genres/{genre_id}")
            .Delete();

        #endregion

        #region [ Posters ]

        /// <summary>
        /// This method adds a poster image to the specified On Demand page. The authenticated user must be the owner of the page.
        /// The returned picture contains the link to upload the image.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>201 Created	The poster was added.</returns>
        public virtual RestResult<Picture> AddAPosterToAnOnDemandPage(int ondemand_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/pictures")
            .Post<Picture>();

        /// <summary>
        /// This method edits the specified poster on an On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="poster_id">The ID of the poster.</param>
        /// <param name="body">The fields to edit.</param>
        /// <returns>200 OK	The poster was edited.</returns>
        public virtual RestResult<Picture> EditAPosterOnAnOnDemandPage(int ondemand_id, int poster_id, EditAPosterOnAnOnDemandPageBody body) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/pictures/{poster_id}")
            .JsonPayload(body)
            .Patch<Picture>();

        /// <summary>
        /// This method returns the specified poster on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="poster_id">The ID of the poster.</param>
        /// <returns>200 OK	The poster was returned.</returns>
        public virtual RestResult<Picture> GetASpecificPosterOnAnOnDemandPage(int ondemand_id, int poster_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/pictures/{poster_id}")
            .Get<Picture>();

        /// <summary>
        /// This method returns every poster on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>200 OK	The posters were returned.</returns>
        public virtual RestResult<Pagination<Picture>> GetAllThePostersOnAnOnDemandPage(int ondemand_id, int? page = null, int? per_page = null) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/pictures")
            .ListParameters(page: page, per_page: per_page)
            .GetPagination<Picture>(RootAuthorization);

        #endregion

        #region [ Promotions ]

        /// <summary>
        /// This method adds a promotion to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="body">The promotion. Download, StreamPeriod, Total and Type are required.</param>
        /// <returns>
        /// 201 Created	The promotion was added.
        /// 400 Bad Request A parameter is invalid.
        /// </returns>
        public virtual RestResult<OnDemandPromotion> AddAPromotionToAnOnDemandPage(int ondemand_id, AddAPromotionToAnOnDemandPageBody body) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions")
            .JsonPayload(body)
            .Post<OnDemandPromotion>();

        /// <summary>
        /// This method deletes the specified promotion on an On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="promotion_id">The ID of the promotion.</param>
        /// <returns>204 No Content	The promotion was deleted.</returns>
        public virtual RestResult DeleteAPromotionOnAnOnDemandPage(int ondemand_id, int promotion_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions/{promotion_id}")
            .Delete();

        /// <summary>
        /// This method returns the specified promotion on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="promotion_id">The ID of the promotion.</param>
        /// <returns>200 OK	The promotion was returned.</returns>
        public virtual RestResult<OnDemandPromotion> GetASpecificPromotionOnAnOnDemandPage(int ondemand_id, int promotion_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions/{promotion_id}")
            .Get<OnDemandPromotion>();

        /// <summary>
        /// This method returns every code of the specified promotion on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="promotion_id">The ID of the promotion.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>200 OK	The promotion codes were returned.</returns>
        public virtual RestResult<Pagination<OnDemandPromotionCode>> GetAllTheCodesOfAPromotionOnAnOnDemandPage(int ondemand_id, int promotion_id, int? page = null, int? per_page = null) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions/{promotion_id}/codes")
            .ListParameters(page: page, per_page: per_page)
            .GetPagination<OnDemandPromotionCode>(RootAuthorization);

        /// <summary>
        /// This method returns every promotion on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="filter">The type of promotion to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>200 OK	The promotions were returned.</returns>
        public virtual RestResult<Pagination<OnDemandPromotion>> GetAllThePromotionsOnAnOnDemandPage(int ondemand_id,
            OnDemandPromotionFilter? filter = null,
            int? page = null,
            int? per_page = null) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions")
            .ListParameters(filter: filter, page: page, per_page: per_page)
            .GetPagination<OnDemandPromotion>(RootAuthorization);

        #endregion

        #region [ Purchases and rentals ]

        /// <summary>
        /// This method returns every On Demand page that the specified user has purchased or rented.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>200 OK	The purchases and rentals were returned.</returns>
        public virtual RestResult<Pagination<OnDemandPage>> GetAllTheOnDemandPurchasesAndRentalsThatTheUserHasMade(int user_id,
            OnDemandDirection? direction = null,
            OnDemandPurchasesFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandPurchasesSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/ondemand/purchases")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPagination<OnDemandPage>(RootAuthorization);

        /// <summary>
        /// This method returns every On Demand page that the authenticated user has purchased or rented.
        /// </summary>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>200 OK	The purchases and rentals were returned.</returns>
        public virtual RestResult<Pagination<OnDemandPage>> MeGetAllTheOnDemandPurchasesAndRentalsThatTheUserHasMade(OnDemandDirection? direction = null,
            OnDemandPurchasesFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandPurchasesSort? sort = null) => RootAuthorization()
            .Command($"/me/ondemand/purchases")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPagination<OnDemandPage>(RootAuthorization);

        /// <summary>
        /// This method checks whether the authenticated user has purchased or rented the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>
        /// 200 OK	The user has purchased or rented the page.
        /// 404 Not Found The user hasn't purchased or rented the page.
        /// </returns>
        public virtual RestResult<OnDemandPage> MeCheckIfTheUserHasPurchasedAnOnDemandPage(int ondemand_id) => RootAuthorization()
            .Command($"/me/ondemand/purchases/{ondemand_id}")
            .Get<OnDemandPage>();

        #endregion

        #region [ Regions ]

        /// <summary>
        /// This method adds a list of regions to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="countries">The ISO 3166-1 alpha-2 codes of the countries to add (for example US, IT).</param>
        /// <returns>200 OK	The regions were added.</returns>
        public virtual RestResult<VimeoList<OnDemandRegion>> AddAListOfRegionsToAnOnDemandPage(int ondemand_id, string[] countries) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions")
            .JsonPayload(new VimeoPayload().Set("countries", countries))
            .Put<VimeoList<OnDemandRegion>>();

        /// <summary>
        /// This method adds a specific region to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="country">The ISO 3166-1 alpha-2 code of the country.</param>
        /// <returns>201 Created	The region was added.</returns>
        public virtual RestResult<OnDemandRegion> AddASpecificRegionToAnOnDemandPage(int ondemand_id, string country) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions/{country}")
            .Put<OnDemandRegion>();

        /// <summary>
        /// This method returns the specified On Demand region.
        /// </summary>
        /// <param name="country">The ISO 3166-1 alpha-2 code of the country.</param>
        /// <returns>200 OK	The region was returned.</returns>
        public virtual RestResult<OnDemandRegion> GetASpecificOnDemandRegion(string country) => RootAuthorization()
            .Command($"/ondemand/regions/{country}")
            .Get<OnDemandRegion>();

        /// <summary>
        /// This method checks whether the specified On Demand page is available in a region.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="country">The ISO 3166-1 alpha-2 code of the country.</param>
        /// <returns>
        /// 200 OK	The page is available in the region.
        /// 404 Not Found The page isn't available in the region.
        /// </returns>
        public virtual RestResult<OnDemandRegion> GetASpecificRegionOnAnOnDemandPage(int ondemand_id, string country) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions/{country}")
            .Get<OnDemandRegion>();

        /// <summary>
        /// This method returns every available On Demand region.
        /// </summary>
        /// <returns>200 OK	The regions were returned.</returns>
        public virtual RestResult<VimeoList<OnDemandRegion>> GetAllTheOnDemandRegions() => RootAuthorization()
            .Command($"/ondemand/regions")
            .Get<VimeoList<OnDemandRegion>>();

        /// <summary>
        /// This method returns every region in which the specified On Demand page is available.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <returns>200 OK	The regions were returned.</returns>
        public virtual RestResult<VimeoList<OnDemandRegion>> GetAllTheRegionsOnAnOnDemandPage(int ondemand_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions")
            .Get<VimeoList<OnDemandRegion>>();

        /// <summary>
        /// This method removes a list of regions from the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="countries">The ISO 3166-1 alpha-2 codes of the countries to remove.</param>
        /// <returns>204 No Content	The regions were removed.</returns>
        public virtual RestResult RemoveAListOfRegionsFromAnOnDemandPage(int ondemand_id, string[] countries) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions")
            .JsonPayload(new VimeoPayload().Set("countries", countries))
            .Delete();

        /// <summary>
        /// This method removes a specific region from the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="country">The ISO 3166-1 alpha-2 code of the country.</param>
        /// <returns>204 No Content	The region was removed.</returns>
        public virtual RestResult RemoveASpecificRegionFromAnOnDemandPage(int ondemand_id, string country) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions/{country}")
            .Delete();

        #endregion

        #region [ Seasons ]

        /// <summary>
        /// This method returns the specified season on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="season_id">The ID of the season.</param>
        /// <returns>200 OK	The season was returned.</returns>
        public virtual RestResult<OnDemandSeason> GetASpecificSeasonOnAnOnDemandPage(int ondemand_id, int season_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/seasons/{season_id}")
            .Get<OnDemandSeason>();

        /// <summary>
        /// This method returns every season on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>200 OK	The seasons were returned.</returns>
        public virtual RestResult<Pagination<OnDemandSeason>> GetAllTheSeasonsOnAnOnDemandPage(int ondemand_id,
            OnDemandDirection? direction = null,
            OnDemandSeasonFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandSeasonSort? sort = null) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/seasons")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPagination<OnDemandSeason>(RootAuthorization);

        /// <summary>
        /// This method returns every video in the specified season on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="season_id">The ID of the season.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>200 OK	The videos were returned.</returns>
        public virtual RestResult<Pagination<OnDemandVideo>> GetAllTheVideosInASeasonOnAnOnDemandPage(int ondemand_id, int season_id,
            OnDemandSeasonFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandVideoSort? sort = null) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/seasons/{season_id}/videos")
            .ListParameters(filter: filter, page: page, per_page: per_page, sort: sort)
            .GetPagination<OnDemandVideo>(RootAuthorization);

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method adds a video to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="body">The video settings. Type is required.</param>
        /// <returns>
        /// 200 OK	The video was already on the page and has been updated.
        /// 201 Created	The video was added.
        /// </returns>
        public virtual RestResult<OnDemandVideo> AddAVideoToAnOnDemandPage(int ondemand_id, int video_id, AddAVideoToAnOnDemandPageBody body) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/videos/{video_id}")
            .JsonPayload(body)
            .Put<OnDemandVideo>();

        /// <summary>
        /// This method returns the specified video on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>200 OK	The video was returned.</returns>
        public virtual RestResult<OnDemandVideo> GetASpecificVideoOnAnOnDemandPage(int ondemand_id, int video_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/videos/{video_id}")
            .Get<OnDemandVideo>();

        /// <summary>
        /// This method returns every video on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>200 OK	The videos were returned.</returns>
        public virtual RestResult<Pagination<OnDemandVideo>> GetAllTheVideosOnAnOnDemandPage(int ondemand_id,
            OnDemandDirection? direction = null,
            OnDemandVideoFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandVideoSort? sort = null) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/videos")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPagination<OnDemandVideo>(RootAuthorization);

        /// <summary>
        /// This method removes a video from the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>204 No Content	The video was removed.</returns>
        public virtual RestResult RemoveAVideoFromAnOnDemandPage(int ondemand_id, int video_id) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/videos/{video_id}")
            .Delete();

        #endregion
    }
}
