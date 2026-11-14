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
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoOnDemand.
    public partial class VimeoOnDemand
    {
        #region [ Essentials ]

        /// <summary>
        /// This method creates a new On Demand page for the specified user. To publish the page, use the edit method.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="body">The page to create. Type, Name, Description and ContentRating are required.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The On Demand page was created.
        /// 400 Bad Request A parameter is invalid.
        /// 403 Forbidden The authenticated user can't create On Demand pages.
        /// </returns>
        public virtual Task<RestResult<OnDemandPage>> CreateAnOnDemandPageAsync(int user_id, CreateAnOnDemandPageBody body, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/ondemand/pages")
            .JsonPayload(body)
            .PostAsync<OnDemandPage>(cancellationToken);

        /// <summary>
        /// This method creates a new On Demand page for the authenticated user. To publish the page, use the edit method.
        /// </summary>
        /// <param name="body">The page to create. Type, Name, Description and ContentRating are required.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The On Demand page was created.
        /// 400 Bad Request A parameter is invalid.
        /// 403 Forbidden The authenticated user can't create On Demand pages.
        /// </returns>
        public virtual Task<RestResult<OnDemandPage>> MeCreateAnOnDemandPageAsync(CreateAnOnDemandPageBody body, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/ondemand/pages")
            .JsonPayload(body)
            .PostAsync<OnDemandPage>(cancellationToken);

        /// <summary>
        /// This method deletes the specified On Demand page. Only draft pages can be deleted.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The On Demand page was deleted.
        /// 403 Forbidden The page isn't a draft or the authenticated user isn't the owner.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAnOnDemandPageAsync(int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method edits the specified On Demand page. Use this method to enable preorders on the page or to publish the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="body">The fields to edit.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The On Demand page was edited.
        /// 400 Bad Request A parameter is invalid.
        /// 403 Forbidden The authenticated user isn't the owner of the page.
        /// </returns>
        public virtual Task<RestResult<OnDemandPage>> EditAnOnDemandPageAsync(int ondemand_id, EditAnOnDemandPageBody body, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}")
            .JsonPayload(body)
            .PatchAsync<OnDemandPage>(cancellationToken);

        /// <summary>
        /// This method returns the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The On Demand page was returned.
        /// 404 Not Found No such On Demand page exists.
        /// </returns>
        public virtual Task<RestResult<OnDemandPage>> GetASpecificOnDemandPageAsync(int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}")
            .GetAsync<OnDemandPage>(cancellationToken);

        /// <summary>
        /// This method returns every On Demand page belonging to the specified user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The type of the page to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The On Demand pages were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandPage>>> GetAllTheOnDemandPagesOfTheUserAsync(int user_id,
            OnDemandDirection? direction = null,
            OnDemandFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandPagesSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/ondemand/pages")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPaginationAsync<OnDemandPage>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every On Demand page belonging to the authenticated user.
        /// </summary>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The type of the page to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The On Demand pages were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandPage>>> MeGetAllTheOnDemandPagesOfTheUserAsync(OnDemandDirection? direction = null,
            OnDemandFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandPagesSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/ondemand/pages")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPaginationAsync<OnDemandPage>(RootAuthorization, cancellationToken);

        #endregion

        #region [ Backgrounds ]

        /// <summary>
        /// This method adds a background image to the specified On Demand page. The authenticated user must be the owner of the page.
        /// The returned picture contains the link to upload the image.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>201 Created	The background was added.</returns>
        public virtual Task<RestResult<Picture>> AddABackgroundToAnOnDemandPageAsync(int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds")
            .PostAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method deletes the specified background image on an On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="background_id">The ID of the background image.</param>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>204 No Content	The background was deleted.</returns>
        public virtual Task<RestResult<string>> DeleteABackgroundOnAnOnDemandPageAsync(int background_id, int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds/{background_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method edits the specified background image on an On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="background_id">The ID of the background image.</param>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="body">The fields to edit.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The background was edited.</returns>
        public virtual Task<RestResult<Picture>> EditABackgroundToAnOnDemandPageAsync(int background_id, int ondemand_id, EditABackgroundToAnOnDemandPageBody body, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds/{background_id}")
            .JsonPayload(body)
            .PatchAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns the specified background image on an On Demand page.
        /// </summary>
        /// <param name="background_id">The ID of the background image.</param>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The background was returned.</returns>
        public virtual Task<RestResult<Picture>> GetASpecificBackgroundOnAnOnDemandPageAsync(int background_id, int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds/{background_id}")
            .GetAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns every background image on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The backgrounds were returned.</returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllTheBackgroundsOnAnOnDemandPageAsync(int ondemand_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/backgrounds")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<Picture>(RootAuthorization, cancellationToken);

        #endregion

        #region [ Genres ]

        /// <summary>
        /// This method adds a genre to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The genre was added.
        /// 400 Bad Request The page already has the maximum number of genres.
        /// </returns>
        public virtual Task<RestResult<OnDemandGenre>> AddAGenreToAnOnDemandPageAsync(int ondemand_id, string genre_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/genres/{genre_id}")
            .PutAsync<OnDemandGenre>(cancellationToken);

        /// <summary>
        /// This method checks whether the specified On Demand page belongs to a genre.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The page belongs to the genre.
        /// 404 Not Found The page doesn't belong to the genre.
        /// </returns>
        public virtual Task<RestResult<OnDemandGenre>> CheckWhetherAnOnDemandPageBelongsToASpecificGenreAsync(int ondemand_id, string genre_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/genres/{genre_id}")
            .GetAsync<OnDemandGenre>(cancellationToken);

        /// <summary>
        /// This method returns the specified On Demand genre.
        /// </summary>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The genre was returned.</returns>
        public virtual Task<RestResult<OnDemandGenre>> GetASpecificOnDemandGenreAsync(string genre_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/genres/{genre_id}")
            .GetAsync<OnDemandGenre>(cancellationToken);

        /// <summary>
        /// This method checks whether the specified On Demand page belongs to a genre and returns the page.
        /// </summary>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The page was returned.</returns>
        public virtual Task<RestResult<OnDemandPage>> GetASpecificOnDemandPageInAGenreAsync(string genre_id, int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/genres/{genre_id}/pages/{ondemand_id}")
            .GetAsync<OnDemandPage>(cancellationToken);

        /// <summary>
        /// This method returns every available On Demand genre.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The genres were returned.</returns>
        public virtual Task<RestResult<VimeoList<OnDemandGenre>>> GetAllOnDemandGenresAsync(CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/genres")
            .GetAsync<VimeoList<OnDemandGenre>>(cancellationToken);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The pages were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandPage>>> GetAllTheOnDemandPagesInAGenreAsync(string genre_id,
            OnDemandDirection? direction = null,
            OnDemandGenrePagesFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            OnDemandGenrePagesSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/genres/{genre_id}/pages")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .GetPaginationAsync<OnDemandPage>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every genre of the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The genres were returned.</returns>
        public virtual Task<RestResult<VimeoList<OnDemandGenre>>> GetAllTheGenresOfAnOnDemandPageAsync(int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/genres")
            .GetAsync<VimeoList<OnDemandGenre>>(cancellationToken);

        /// <summary>
        /// This method removes a genre from the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="genre_id">The ID of the genre.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The genre was removed.
        /// 400 Bad Request The page must have at least one genre.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveAGenreFromAnOnDemandPageAsync(int ondemand_id, string genre_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/genres/{genre_id}")
            .DeleteAsync(cancellationToken);

        #endregion

        #region [ Posters ]

        /// <summary>
        /// This method adds a poster image to the specified On Demand page. The authenticated user must be the owner of the page.
        /// The returned picture contains the link to upload the image.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>201 Created	The poster was added.</returns>
        public virtual Task<RestResult<Picture>> AddAPosterToAnOnDemandPageAsync(int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/pictures")
            .PostAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method edits the specified poster on an On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="poster_id">The ID of the poster.</param>
        /// <param name="body">The fields to edit.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The poster was edited.</returns>
        public virtual Task<RestResult<Picture>> EditAPosterOnAnOnDemandPageAsync(int ondemand_id, int poster_id, EditAPosterOnAnOnDemandPageBody body, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/pictures/{poster_id}")
            .JsonPayload(body)
            .PatchAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns the specified poster on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="poster_id">The ID of the poster.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The poster was returned.</returns>
        public virtual Task<RestResult<Picture>> GetASpecificPosterOnAnOnDemandPageAsync(int ondemand_id, int poster_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/pictures/{poster_id}")
            .GetAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns every poster on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The posters were returned.</returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllThePostersOnAnOnDemandPageAsync(int ondemand_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/pictures")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<Picture>(RootAuthorization, cancellationToken);

        #endregion

        #region [ Promotions ]

        /// <summary>
        /// This method adds a promotion to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="body">The promotion. Download, StreamPeriod, Total and Type are required.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The promotion was added.
        /// 400 Bad Request A parameter is invalid.
        /// </returns>
        public virtual Task<RestResult<OnDemandPromotion>> AddAPromotionToAnOnDemandPageAsync(int ondemand_id, AddAPromotionToAnOnDemandPageBody body, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions")
            .JsonPayload(body)
            .PostAsync<OnDemandPromotion>(cancellationToken);

        /// <summary>
        /// This method deletes the specified promotion on an On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="promotion_id">The ID of the promotion.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>204 No Content	The promotion was deleted.</returns>
        public virtual Task<RestResult<string>> DeleteAPromotionOnAnOnDemandPageAsync(int ondemand_id, int promotion_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions/{promotion_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method returns the specified promotion on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="promotion_id">The ID of the promotion.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The promotion was returned.</returns>
        public virtual Task<RestResult<OnDemandPromotion>> GetASpecificPromotionOnAnOnDemandPageAsync(int ondemand_id, int promotion_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions/{promotion_id}")
            .GetAsync<OnDemandPromotion>(cancellationToken);

        /// <summary>
        /// This method returns every code of the specified promotion on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="promotion_id">The ID of the promotion.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The promotion codes were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandPromotionCode>>> GetAllTheCodesOfAPromotionOnAnOnDemandPageAsync(int ondemand_id, int promotion_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions/{promotion_id}/codes")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<OnDemandPromotionCode>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every promotion on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="filter">The type of promotion to return.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The promotions were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandPromotion>>> GetAllThePromotionsOnAnOnDemandPageAsync(int ondemand_id,
            OnDemandPromotionFilter? filter = null,
            int? page = null,
            int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/promotions")
            .ListParameters(filter: filter, page: page, per_page: per_page)
            .GetPaginationAsync<OnDemandPromotion>(RootAuthorization, cancellationToken);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The purchases and rentals were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandPage>>> GetAllTheOnDemandPurchasesAndRentalsThatTheUserHasMadeAsync(int user_id,
            OnDemandDirection? direction = null,
            OnDemandPurchasesFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandPurchasesSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/ondemand/purchases")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPaginationAsync<OnDemandPage>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every On Demand page that the authenticated user has purchased or rented.
        /// </summary>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The purchases and rentals were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandPage>>> MeGetAllTheOnDemandPurchasesAndRentalsThatTheUserHasMadeAsync(OnDemandDirection? direction = null,
            OnDemandPurchasesFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandPurchasesSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/ondemand/purchases")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPaginationAsync<OnDemandPage>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method checks whether the authenticated user has purchased or rented the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The user has purchased or rented the page.
        /// 404 Not Found The user hasn't purchased or rented the page.
        /// </returns>
        public virtual Task<RestResult<OnDemandPage>> MeCheckIfTheUserHasPurchasedAnOnDemandPageAsync(int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/ondemand/purchases/{ondemand_id}")
            .GetAsync<OnDemandPage>(cancellationToken);

        #endregion

        #region [ Regions ]

        /// <summary>
        /// This method adds a list of regions to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="countries">The ISO 3166-1 alpha-2 codes of the countries to add (for example US, IT).</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The regions were added.</returns>
        public virtual Task<RestResult<VimeoList<OnDemandRegion>>> AddAListOfRegionsToAnOnDemandPageAsync(int ondemand_id, string[] countries, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions")
            .JsonPayload(new VimeoPayload().Set("countries", countries))
            .PutAsync<VimeoList<OnDemandRegion>>(cancellationToken);

        /// <summary>
        /// This method adds a specific region to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="country">The ISO 3166-1 alpha-2 code of the country.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>201 Created	The region was added.</returns>
        public virtual Task<RestResult<OnDemandRegion>> AddASpecificRegionToAnOnDemandPageAsync(int ondemand_id, string country, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions/{country}")
            .PutAsync<OnDemandRegion>(cancellationToken);

        /// <summary>
        /// This method returns the specified On Demand region.
        /// </summary>
        /// <param name="country">The ISO 3166-1 alpha-2 code of the country.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The region was returned.</returns>
        public virtual Task<RestResult<OnDemandRegion>> GetASpecificOnDemandRegionAsync(string country, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/regions/{country}")
            .GetAsync<OnDemandRegion>(cancellationToken);

        /// <summary>
        /// This method checks whether the specified On Demand page is available in a region.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="country">The ISO 3166-1 alpha-2 code of the country.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The page is available in the region.
        /// 404 Not Found The page isn't available in the region.
        /// </returns>
        public virtual Task<RestResult<OnDemandRegion>> GetASpecificRegionOnAnOnDemandPageAsync(int ondemand_id, string country, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions/{country}")
            .GetAsync<OnDemandRegion>(cancellationToken);

        /// <summary>
        /// This method returns every available On Demand region.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The regions were returned.</returns>
        public virtual Task<RestResult<VimeoList<OnDemandRegion>>> GetAllTheOnDemandRegionsAsync(CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/regions")
            .GetAsync<VimeoList<OnDemandRegion>>(cancellationToken);

        /// <summary>
        /// This method returns every region in which the specified On Demand page is available.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The regions were returned.</returns>
        public virtual Task<RestResult<VimeoList<OnDemandRegion>>> GetAllTheRegionsOnAnOnDemandPageAsync(int ondemand_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions")
            .GetAsync<VimeoList<OnDemandRegion>>(cancellationToken);

        /// <summary>
        /// This method removes a list of regions from the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="countries">The ISO 3166-1 alpha-2 codes of the countries to remove.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>204 No Content	The regions were removed.</returns>
        public virtual Task<RestResult<string>> RemoveAListOfRegionsFromAnOnDemandPageAsync(int ondemand_id, string[] countries, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions")
            .JsonPayload(new VimeoPayload().Set("countries", countries))
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method removes a specific region from the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="country">The ISO 3166-1 alpha-2 code of the country.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>204 No Content	The region was removed.</returns>
        public virtual Task<RestResult<string>> RemoveASpecificRegionFromAnOnDemandPageAsync(int ondemand_id, string country, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/regions/{country}")
            .DeleteAsync(cancellationToken);

        #endregion

        #region [ Seasons ]

        /// <summary>
        /// This method returns the specified season on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="season_id">The ID of the season.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The season was returned.</returns>
        public virtual Task<RestResult<OnDemandSeason>> GetASpecificSeasonOnAnOnDemandPageAsync(int ondemand_id, int season_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/seasons/{season_id}")
            .GetAsync<OnDemandSeason>(cancellationToken);

        /// <summary>
        /// This method returns every season on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The seasons were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandSeason>>> GetAllTheSeasonsOnAnOnDemandPageAsync(int ondemand_id,
            OnDemandDirection? direction = null,
            OnDemandSeasonFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandSeasonSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/seasons")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPaginationAsync<OnDemandSeason>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every video in the specified season on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="season_id">The ID of the season.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The videos were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandVideo>>> GetAllTheVideosInASeasonOnAnOnDemandPageAsync(int ondemand_id, int season_id,
            OnDemandSeasonFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandVideoSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/seasons/{season_id}/videos")
            .ListParameters(filter: filter, page: page, per_page: per_page, sort: sort)
            .GetPaginationAsync<OnDemandVideo>(RootAuthorization, cancellationToken);

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method adds a video to the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="body">The video settings. Type is required.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The video was already on the page and has been updated.
        /// 201 Created	The video was added.
        /// </returns>
        public virtual Task<RestResult<OnDemandVideo>> AddAVideoToAnOnDemandPageAsync(int ondemand_id, int video_id, AddAVideoToAnOnDemandPageBody body, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/videos/{video_id}")
            .JsonPayload(body)
            .PutAsync<OnDemandVideo>(cancellationToken);

        /// <summary>
        /// This method returns the specified video on an On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The video was returned.</returns>
        public virtual Task<RestResult<OnDemandVideo>> GetASpecificVideoOnAnOnDemandPageAsync(int ondemand_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/videos/{video_id}")
            .GetAsync<OnDemandVideo>(cancellationToken);

        /// <summary>
        /// This method returns every video on the specified On Demand page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>200 OK	The videos were returned.</returns>
        public virtual Task<RestResult<Pagination<OnDemandVideo>>> GetAllTheVideosOnAnOnDemandPageAsync(int ondemand_id,
            OnDemandDirection? direction = null,
            OnDemandVideoFilter? filter = null,
            int? page = null,
            int? per_page = null,
            OnDemandVideoSort? sort = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/videos")
            .ListParameters(direction, filter, page, per_page, null, sort)
            .GetPaginationAsync<OnDemandVideo>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method removes a video from the specified On Demand page. The authenticated user must be the owner of the page.
        /// </summary>
        /// <param name="ondemand_id">The ID of the On Demand page.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>204 No Content	The video was removed.</returns>
        public virtual Task<RestResult<string>> RemoveAVideoFromAnOnDemandPageAsync(int ondemand_id, int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/ondemand/pages/{ondemand_id}/videos/{video_id}")
            .DeleteAsync(cancellationToken);

        #endregion
    }
}
