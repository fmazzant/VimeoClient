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
    using System.Collections.Generic;
    using Mafesoft.VimeoClient.Body.ShowCase;
    using Mafesoft.VimeoClient.Filter.ShowCase;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoShowCases.
    public partial class VimeoShowCases
    {
        #region [ Essentials ]

        /// <summary>
        /// This method creates a new showcase for the specified user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="parameters">The showcase's body. The name is required.</param>
        /// <returns>
        /// 201 Created	The showcase was created.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't create showcases.
        /// </returns>
        public virtual Task<RestResult<Album>> CreateAShowcaseAsync(int user_id, ShowCaseEditParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/albums")
            .FormUrlEncoded(parameters)
            .PostAsync<Album>();

        /// <summary>
        /// This method creates a new showcase for the authenticated user.
        /// </summary>
        /// <param name="parameters">The showcase's body. The name is required.</param>
        /// <returns>
        /// 201 Created	The showcase was created.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't create showcases.
        /// </returns>
        public virtual Task<RestResult<Album>> CreateAShowcaseAsync(ShowCaseEditParameters parameters) => RootAuthorization()
            .Command($"/me/albums")
            .FormUrlEncoded(parameters)
            .PostAsync<Album>();

        /// <summary>
        /// This method creates a new showcase for the specified user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="name">The name of the showcase.</param>
        /// <param name="brand_color">The hexadecimal code for the color of the player buttons and showcase controls.</param>
        /// <param name="description">The description of the showcase.</param>
        /// <param name="hide_nav">Whether to hide Vimeo navigation when displaying the showcase.</param>
        /// <param name="hide_upcoming">Whether to include the upcoming live event in the showcase.</param>
        /// <param name="layout">The type of layout for presenting the showcase</param>
        /// <param name="password">The showcase's password. This field is required only when privacy is password.</param>
        /// <param name="privacy">The privacy level of the showcase</param>
        /// <param name="review_mode">Whether showcase videos use the review mode URL.</param>
        /// <param name="sort">The default sort order of the videos as they appear in the showcase</param>
        /// <param name="theme">The color theme of the showcase</param>
        /// <returns></returns>
        public virtual Task<RestResult<Album>> CreateAShowcaseAsync(int user_id,
            string name,
            string brand_color = null,
            string description = null,
            bool hide_nav = false,
            bool hide_upcoming = false,
            ShowCasesLayout? layout = null,
            string password = null,
            ShowCasesPrivacy? privacy = null,
            bool review_mode = false,
            ShowCasesSort? sort = null,
            ShowCasesTheme? theme = null) => CreateAShowcaseAsync(user_id,
                ToParameters(name, brand_color, description, hide_nav, hide_upcoming, layout, password, privacy, review_mode, sort, theme));

        /// <summary>
        /// This method creates a new showcase for the authenticated user.
        /// </summary>
        /// <param name="name">The name of the showcase.</param>
        /// <param name="brand_color">The hexadecimal code for the color of the player buttons and showcase controls.</param>
        /// <param name="description">The description of the showcase.</param>
        /// <param name="hide_nav">Whether to hide Vimeo navigation when displaying the showcase.</param>
        /// <param name="hide_upcoming">Whether to include the upcoming live event in the showcase.</param>
        /// <param name="layout">The type of layout for presenting the showcase</param>
        /// <param name="password">The showcase's password. This field is required only when privacy is password.</param>
        /// <param name="privacy">The privacy level of the showcase</param>
        /// <param name="review_mode">Whether showcase videos use the review mode URL.</param>
        /// <param name="sort">The default sort order of the videos as they appear in the showcase</param>
        /// <param name="theme">The color theme of the showcase</param>
        /// <returns></returns>
        public virtual Task<RestResult<Album>> CreateAShowcaseAsync(string name,
           string brand_color = null,
           string description = null,
           bool hide_nav = false,
           bool hide_upcoming = false,
           ShowCasesLayout? layout = null,
           string password = null,
           ShowCasesPrivacy? privacy = null,
           bool review_mode = false,
           ShowCasesSort? sort = null,
           ShowCasesTheme? theme = null) => CreateAShowcaseAsync(
               ToParameters(name, brand_color, description, hide_nav, hide_upcoming, layout, password, privacy, review_mode, sort, theme));

        /// <summary>
        /// This method deletes the specified showcase. The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 204 No Content	The showcase was deleted.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAShowcaseAsync(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}")
            .DeleteAsync();

        /// <summary>
        /// This method deletes the specified showcase. The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 204 No Content	The showcase was deleted.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAShowcaseAsync(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}")
            .DeleteAsync();

        /// <summary>
        /// This method edits the specified showcase. The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="parameters">The values to change. Only the values that are set are sent.</param>
        /// <returns>
        /// 200 OK	The showcase was edited.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Album>> EditAShowcaseAsync(int user_id, int album_id, ShowCaseEditParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}")
            .FormUrlEncoded(parameters)
            .PatchAsync<Album>();

        /// <summary>
        /// This method edits the specified showcase. The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="parameters">The values to change. Only the values that are set are sent.</param>
        /// <returns>
        /// 200 OK	The showcase was edited.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Album>> EditAShowcaseAsync(int album_id, ShowCaseEditParameters parameters) => RootAuthorization()
            .Command($"/me/albums/{album_id}")
            .FormUrlEncoded(parameters)
            .PatchAsync<Album>();

        /// <summary>
        /// This method returns a single showcase belonging to the specified user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The showcase was returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Album>> GetASpecificShowcaseAsync(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}")
            .GetAsync<Album>();

        /// <summary>
        /// This method returns a single showcase belonging to the authenticated user.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The showcase was returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Album>> GetASpecificShowcaseAsync(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}")
            .GetAsync<Album>();

        /// <summary>
        /// This method returns all the showcases belonging to the specified user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>
        /// 200 OK	The showcases were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Album>>> GetAllTheShowcasesThatBelongToTheUserAsync(int user_id,
            ShowCasesDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesGetAllSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPaginationAsync<Album>(RootAuthorization);

        /// <summary>
        /// This method returns all the showcases belonging to the authenticated user.
        /// </summary>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>
        /// 200 OK	The showcases were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Album>>> GetAllTheShowcasesThatBelongToTheUserAsync(ShowCasesDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesGetAllSort? sort = null) => RootAuthorization()
            .Command($"/me/albums")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPaginationAsync<Album>(RootAuthorization);

        /// <summary>
        /// This method adds videos and events to the specified showcases.
        /// The authenticated user must either be the owner of the showcase or have team permissions.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_uris">The URIs of the showcases.</param>
        /// <param name="album_item_uris">The URIs of the videos and events to add.</param>
        /// <returns>
        /// 204 No Content	The videos and events were added to the showcases.
        /// </returns>
        public virtual Task<RestResult<string>> AddVideosAndEventsToShowcasesAsync(int user_id, string[] album_uris, string[] album_item_uris) => RootAuthorization()
            .Command($"/users/{user_id}/albums")
            .OptionalParameter("album_uris", album_uris)
            .OptionalParameter("album_item_uris", album_item_uris)
            .PatchAsync();

        /// <summary>
        /// This method adds all videos and events from a specified folder to showcases.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="folder_id">The ID of the folder.</param>
        /// <param name="album_uris">The URIs of the showcases.</param>
        /// <returns>
        /// 202 Accepted	The folder contents were added to the showcases.
        /// </returns>
        public virtual Task<RestResult<string>> AddFolderContentsToShowcasesAsync(int user_id, int folder_id, string[] album_uris) => RootAuthorization()
            .Command($"/users/{user_id}/albums/from_folder")
            .OptionalParameter("folder_id", folder_id)
            .OptionalParameter("album_uris", album_uris)
            .PatchAsync();

        /// <summary>
        /// This method creates a copy of the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="name">The copied showcase name, up to 255 characters. By default, the source showcase name.</param>
        /// <returns>
        /// 201 Created	The copied showcase was created.
        /// </returns>
        public virtual Task<RestResult<Album>> CopyAShowcaseAsync(int user_id, int album_id, string name = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/copy")
            .JsonPayload(new VimeoPayload().Set("name", name))
            .PostAsync<Album>();

        /// <summary>
        /// This method creates a copy of the specified showcase of the authenticated user.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="name">The copied showcase name, up to 255 characters. By default, the source showcase name.</param>
        /// <returns>
        /// 201 Created	The copied showcase was created.
        /// </returns>
        public virtual Task<RestResult<Album>> MeCopyAShowcaseAsync(int album_id, string name = null) => RootAuthorization()
            .Command($"/me/albums/{album_id}/copy")
            .JsonPayload(new VimeoPayload().Set("name", name))
            .PostAsync<Album>();

        #endregion

        #region [ Custom showcase logos ]

        /// <summary>
        /// This method adds a custom logo to the specified showcase.
        /// The response contains the upload link: upload the image there and then activate it with ReplaceACustomShowcaseLogo.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 201 Created	The custom logo was added.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> AddACustomLogoToAShowcaseAsync(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos")
            .PostAsync<Picture>();

        /// <summary>
        /// This method adds a custom logo to the specified showcase.
        /// The response contains the upload link: upload the image there and then activate it with ReplaceACustomShowcaseLogo.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 201 Created	The custom logo was added.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> AddACustomLogoToAShowcaseAsync(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos")
            .PostAsync<Picture>();

        /// <summary>
        /// This method deletes the specified custom logo from its showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <returns>
        /// 204 No Content	The custom logo was deleted.
        /// 404 Not Found Error code 5000: No such showcase or logo exists.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteACustomShowcaseLogoAsync(int user_id, int album_id, int logo_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos/{logo_id}")
            .DeleteAsync();

        /// <summary>
        /// This method deletes the specified custom logo from its showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <returns>
        /// 204 No Content	The custom logo was deleted.
        /// 404 Not Found Error code 5000: No such showcase or logo exists.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteACustomShowcaseLogoAsync(int album_id, int logo_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos/{logo_id}")
            .DeleteAsync();

        /// <summary>
        /// This method returns a single custom logo belonging to the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <returns>
        /// 200 OK	The custom logo was returned.
        /// 404 Not Found Error code 5000: No such showcase or logo exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> GetASpecificCustomShowcaseLogoAsync(int user_id, int album_id, int logo_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos/{logo_id}")
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns a single custom logo belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <returns>
        /// 200 OK	The custom logo was returned.
        /// 404 Not Found Error code 5000: No such showcase or logo exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> GetASpecificCustomShowcaseLogoAsync(int album_id, int logo_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos/{logo_id}")
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns all the custom logos belonging to the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom logos were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllTheCustomLogosOfAShowcaseAsync(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos")
            .GetPaginationAsync<Picture>(RootAuthorization);

        /// <summary>
        /// This method returns all the custom logos belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom logos were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllTheCustomLogosOfAShowcaseAsync(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos")
            .GetPaginationAsync<Picture>(RootAuthorization);

        /// <summary>
        /// This method replaces the custom logo of the specified showcase, making the specified logo the active one.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <param name="active">Whether the logo is the active one of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom logo was replaced.
        /// 404 Not Found Error code 5000: No such showcase or logo exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> ReplaceACustomShowcaseLogoAsync(int user_id, int album_id, int logo_id, bool active = true) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos/{logo_id}")
            .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
            .PatchAsync<Picture>();

        /// <summary>
        /// This method replaces the custom logo of the specified showcase, making the specified logo the active one.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <param name="active">Whether the logo is the active one of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom logo was replaced.
        /// 404 Not Found Error code 5000: No such showcase or logo exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> ReplaceACustomShowcaseLogoAsync(int album_id, int logo_id, bool active = true) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos/{logo_id}")
            .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
            .PatchAsync<Picture>();

        #endregion

        #region [ Custom showcase thumbnails ]

        /// <summary>
        /// This method adds a custom thumbnail to the specified showcase.
        /// The response contains the upload link: upload the image there and then activate it with ReplaceACustomShowcaseThumbnail.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 201 Created	The custom thumbnail was added.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> AddACustomThumbnailToAShowcaseAsync(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails")
            .PostAsync<Picture>();

        /// <summary>
        /// This method adds a custom thumbnail to the specified showcase.
        /// The response contains the upload link: upload the image there and then activate it with ReplaceACustomShowcaseThumbnail.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 201 Created	The custom thumbnail was added.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> AddACustomThumbnailToAShowcaseAsync(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails")
            .PostAsync<Picture>();

        /// <summary>
        /// This method deletes the specified custom thumbnail from its showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="thumbnail_id">The ID of the custom thumbnail.</param>
        /// <returns>
        /// 204 No Content	The custom thumbnail was deleted.
        /// 404 Not Found Error code 5000: No such showcase or thumbnail exists.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteACustomShowcaseThumbnailAsync(int user_id, int album_id, int thumbnail_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .DeleteAsync();

        /// <summary>
        /// This method deletes the specified custom thumbnail from its showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="thumbnail_id">The ID of the custom thumbnail.</param>
        /// <returns>
        /// 204 No Content	The custom thumbnail was deleted.
        /// 404 Not Found Error code 5000: No such showcase or thumbnail exists.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteACustomShowcaseThumbnailAsync(int album_id, int thumbnail_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .DeleteAsync();

        /// <summary>
        /// This method returns a single custom thumbnail belonging to the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="thumbnail_id">The ID of the custom thumbnail.</param>
        /// <returns>
        /// 200 OK	The custom thumbnail was returned.
        /// 404 Not Found Error code 5000: No such showcase or thumbnail exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> GetASpecificCustomShowcaseThumbnailAsync(int user_id, int album_id, int thumbnail_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns a single custom thumbnail belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="thumbnail_id">The ID of the custom thumbnail.</param>
        /// <returns>
        /// 200 OK	The custom thumbnail was returned.
        /// 404 Not Found Error code 5000: No such showcase or thumbnail exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> GetASpecificCustomShowcaseThumbnailAsync(int album_id, int thumbnail_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns all the custom thumbnails belonging to the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom thumbnails were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllTheCustomThumbnailsOfAShowcaseAsync(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails")
            .GetPaginationAsync<Picture>(RootAuthorization);

        /// <summary>
        /// This method returns all the custom thumbnails belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom thumbnails were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Picture>>> GetAllTheCustomThumbnailsOfAShowcaseAsync(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails")
            .GetPaginationAsync<Picture>(RootAuthorization);

        /// <summary>
        /// This method replaces the custom thumbnail of the specified showcase, making the specified thumbnail the active one.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="thumbnail_id">The ID of the custom thumbnail.</param>
        /// <param name="active">Whether the thumbnail is the active one of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom thumbnail was replaced.
        /// 404 Not Found Error code 5000: No such showcase or thumbnail exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> ReplaceACustomShowcaseThumbnailAsync(int user_id, int album_id, int thumbnail_id, bool active = true) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
            .PatchAsync<Picture>();

        /// <summary>
        /// This method replaces the custom thumbnail of the specified showcase, making the specified thumbnail the active one.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="thumbnail_id">The ID of the custom thumbnail.</param>
        /// <param name="active">Whether the thumbnail is the active one of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom thumbnail was replaced.
        /// 404 Not Found Error code 5000: No such showcase or thumbnail exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> ReplaceACustomShowcaseThumbnailAsync(int album_id, int thumbnail_id, bool active = true) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
            .PatchAsync<Picture>();

        #endregion

        #region [ Showcase videos ]

        /// <summary>
        /// This method adds a single video to the specified showcase. The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> AddASpecificVideoToAShowcaseAsync(int user_id, int album_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}")
            .PutAsync();

        /// <summary>
        /// This method adds a single video to the specified showcase. The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> AddASpecificVideoToAShowcaseAsync(int album_id, int video_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}")
            .PutAsync();

        /// <summary>
        /// This method creates a thumbnail for the specified showcase from a frame of a showcase video.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="time_code">The video frame time in seconds to use as the showcase thumbnail.</param>
        /// <returns>
        /// 200 OK	The thumbnail was created.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> CreateAThumbnailForAShowcaseFromAShowcaseVideoAsync(int user_id, int album_id, int video_id, double? time_code = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}/set_album_thumbnail")
            .FormUrlEncoded(new KeyValuePair<string, object>("time_code", time_code))
            .PostAsync<Picture>();

        /// <summary>
        /// This method creates a thumbnail for the specified showcase from a frame of a showcase video.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="time_code">The video frame time in seconds to use as the showcase thumbnail.</param>
        /// <returns>
        /// 200 OK	The thumbnail was created.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> MeCreateAThumbnailForAShowcaseFromAShowcaseVideoAsync(int album_id, int video_id, double? time_code = null) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}/set_album_thumbnail")
            .FormUrlEncoded(new KeyValuePair<string, object>("time_code", time_code))
            .PostAsync<Picture>();

        /// <summary>
        /// This method returns a single video belonging to the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="password">The password of the showcase.</param>
        /// <returns>
        /// 200 OK	The video was returned.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<Video>> GetASpecificVideoInAShowcaseAsync(int user_id, int album_id, int video_id, string password = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}")
            .OptionalParameter("password", password)
            .GetAsync<Video>();

        /// <summary>
        /// This method returns a single video belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="password">The password of the showcase.</param>
        /// <returns>
        /// 200 OK	The video was returned.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<Video>> GetASpecificVideoInAShowcaseAsync(int album_id, int video_id, string password = null) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}")
            .OptionalParameter("password", password)
            .GetAsync<Video>();

        /// <summary>
        /// This method returns all the showcases to which the authenticated user can add or remove the specified video.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>
        /// 200 OK	The showcases were returned.
        /// 404 Not Found Error code 5000: No such video exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Album>>> GetAllTheShowcasesToWhichTheUserCanAddOrRemoveASpecificVideoAsync(int user_id, int video_id,
            ShowCasesDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesGetAllSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}/available_albums")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPaginationAsync<Album>(RootAuthorization);

        /// <summary>
        /// This method returns all the showcases to which the authenticated user can add or remove the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>
        /// 200 OK	The showcases were returned.
        /// 404 Not Found Error code 5000: No such video exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Album>>> GetAllTheShowcasesToWhichTheUserCanAddOrRemoveASpecificVideoAsync(int video_id,
            ShowCasesDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesGetAllSort? sort = null) => RootAuthorization()
            .Command($"/videos/{video_id}/available_albums")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPaginationAsync<Album>(RootAuthorization);

        /// <summary>
        /// This method returns all the videos of the authenticated user that can be added to or removed from the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheUserVideosThatCanBeAddedToOrRemovedFromAShowcaseAsync(int user_id, int album_id,
            ShowCasesDirection? direction = null,
            ShowCasesVideosFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesVideosSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/available_videos")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .GetPaginationAsync<Video>(RootAuthorization);

        /// <summary>
        /// This method returns all the videos of the authenticated user that can be added to or removed from the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheUserVideosThatCanBeAddedToOrRemovedFromAShowcaseAsync(int album_id,
            ShowCasesDirection? direction = null,
            ShowCasesVideosFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesVideosSort? sort = null) => RootAuthorization()
            .Command($"/albums/{album_id}/available_videos")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .GetPaginationAsync<Video>(RootAuthorization);

        /// <summary>
        /// This method returns all the videos belonging to the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="containing_uri">The page containing the video URI.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false). Required only if filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="password">The password of the showcase.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="weak_search">Whether to include private videos in the search. Please note that a separate search service provides this functionality.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosInAShowcaseAsync(int user_id, int album_id,
            string containing_uri = null,
            ShowCasesDirection? direction = null,
            ShowCasesVideosFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            string password = null,
            int? per_page = null,
            string query = null,
            ShowCasesVideosSort? sort = null,
            bool? weak_search = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("containing_uri", containing_uri)
            .OptionalParameter("filter_embeddable", filter_embeddable)
            .OptionalParameter("password", password)
            .OptionalParameter("weak_search", weak_search)
            .GetPaginationAsync<Video>(RootAuthorization);

        /// <summary>
        /// This method returns all the videos belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="containing_uri">The page containing the video URI.</param>
        /// <param name="direction">The sort direction of the results.</param>
        /// <param name="filter">The attribute by which to filter the results.</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false). Required only if filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="password">The password of the showcase.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results.</param>
        /// <param name="weak_search">Whether to include private videos in the search. Please note that a separate search service provides this functionality.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosInAShowcaseAsync(int album_id,
            string containing_uri = null,
            ShowCasesDirection? direction = null,
            ShowCasesVideosFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            string password = null,
            int? per_page = null,
            string query = null,
            ShowCasesVideosSort? sort = null,
            bool? weak_search = null) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("containing_uri", containing_uri)
            .OptionalParameter("filter_embeddable", filter_embeddable)
            .OptionalParameter("password", password)
            .OptionalParameter("weak_search", weak_search)
            .GetPaginationAsync<Video>(RootAuthorization);

        /// <summary>
        /// This method removes a single video from the specified showcase. The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was removed.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveAVideoFromAShowcaseAsync(int user_id, int album_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}")
            .DeleteAsync();

        /// <summary>
        /// This method removes a single video from the specified showcase. The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was removed.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveAVideoFromAShowcaseAsync(int album_id, int video_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}")
            .DeleteAsync();

        /// <summary>
        /// This method replaces all the videos in the specified showcase with the given ones.
        /// The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="videos">The video URIs to put in the showcase, for instance "/videos/123".</param>
        /// <returns>
        /// 201 Created	The videos were replaced.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<string>> ReplaceAllTheVideosInAShowcaseAsync(int user_id, int album_id, string[] videos) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos")
            .FormUrlEncoded(new KeyValuePair<string, object>("videos", videos))
            .PutAsync();

        /// <summary>
        /// This method replaces all the videos in the specified showcase with the given ones.
        /// The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="videos">The video URIs to put in the showcase, for instance "/videos/123".</param>
        /// <returns>
        /// 201 Created	The videos were replaced.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual Task<RestResult<string>> ReplaceAllTheVideosInAShowcaseAsync(int album_id, string[] videos) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos")
            .FormUrlEncoded(new KeyValuePair<string, object>("videos", videos))
            .PutAsync();

        /// <summary>
        /// This method sets the specified video as the featured video of the showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The featured video was set.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<Video>> SetTheFeaturedVideoOfAShowcaseAsync(int user_id, int album_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}/set_featured_video")
            .PatchAsync<Video>();

        /// <summary>
        /// This method sets the specified video as the featured video of the showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The featured video was set.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase or video exists.
        /// </returns>
        public virtual Task<RestResult<Video>> SetTheFeaturedVideoOfAShowcaseAsync(int album_id, int video_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}/set_featured_video")
            .PatchAsync<Video>();

        #endregion
    }
}
