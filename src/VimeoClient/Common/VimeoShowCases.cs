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
    using System.Collections.Generic;
    using VimeoClient.Body.ShowCase;
    using VimeoClient.Filter.ShowCase;
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// A showcase (previously album) is a collection of videos for public or private sharing.
    /// When developing for this feature, keep in mind that our endpoint syntax uses the original album nomenclature, although this is subject to change in the future.
    /// For more information about showcases, see our Help Center.
    /// https://developer.vimeo.com/api/reference/showcases
    /// </summary>
    public class VimeoShowCases
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
        /// Create a new instance of VimeoShowCases class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoShowCases(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoShowCases(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

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
        public virtual RestResult<Album> CreateAShowcase(int user_id, ShowCaseEditParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/albums")
            .FormUrlEncoded(parameters)
            .Post<Album>();

        /// <summary>
        /// This method creates a new showcase for the authenticated user.
        /// </summary>
        /// <param name="parameters">The showcase's body. The name is required.</param>
        /// <returns>
        /// 201 Created	The showcase was created.
        /// 400 Bad Request Error code 2204: The input is invalid.
        /// 403 Forbidden Error code 3200: The authenticated user can't create showcases.
        /// </returns>
        public virtual RestResult<Album> CreateAShowcase(ShowCaseEditParameters parameters) => RootAuthorization()
            .Command($"/me/albums")
            .FormUrlEncoded(parameters)
            .Post<Album>();

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
        public virtual RestResult<Album> CreateAShowcase(int user_id,
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
            ShowCasesTheme? theme = null) => CreateAShowcase(user_id,
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
        public virtual RestResult<Album> CreateAShowcase(string name,
           string brand_color = null,
           string description = null,
           bool hide_nav = false,
           bool hide_upcoming = false,
           ShowCasesLayout? layout = null,
           string password = null,
           ShowCasesPrivacy? privacy = null,
           bool review_mode = false,
           ShowCasesSort? sort = null,
           ShowCasesTheme? theme = null) => CreateAShowcase(
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
        public virtual RestResult DeleteAShowcase(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}")
            .Delete();

        /// <summary>
        /// This method deletes the specified showcase. The authenticated user must be the owner of the showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 204 No Content	The showcase was deleted.
        /// 403 Forbidden Error code 3200: The authenticated user doesn't own the showcase.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual RestResult DeleteAShowcase(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}")
            .Delete();

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
        public virtual RestResult<Album> EditAShowcase(int user_id, int album_id, ShowCaseEditParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}")
            .FormUrlEncoded(parameters)
            .Patch<Album>();

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
        public virtual RestResult<Album> EditAShowcase(int album_id, ShowCaseEditParameters parameters) => RootAuthorization()
            .Command($"/me/albums/{album_id}")
            .FormUrlEncoded(parameters)
            .Patch<Album>();

        /// <summary>
        /// This method returns a single showcase belonging to the specified user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The showcase was returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual RestResult<Album> GetASpecificShowcase(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}")
            .Get<Album>();

        /// <summary>
        /// This method returns a single showcase belonging to the authenticated user.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The showcase was returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual RestResult<Album> GetASpecificShowcase(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}")
            .Get<Album>();

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
        public virtual RestResult<Pagination<Album>> GetAllTheShowcasesThatBelongToTheUser(int user_id,
            ShowCasesDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesGetAllSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPagination<Album>(RootAuthorization);

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
        public virtual RestResult<Pagination<Album>> GetAllTheShowcasesThatBelongToTheUser(ShowCasesDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesGetAllSort? sort = null) => RootAuthorization()
            .Command($"/me/albums")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPagination<Album>(RootAuthorization);

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
        public virtual RestResult<Picture> AddACustomLogoToAShowcase(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos")
            .Post<Picture>();

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
        public virtual RestResult<Picture> AddACustomLogoToAShowcase(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos")
            .Post<Picture>();

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
        public virtual RestResult DeleteACustomShowcaseLogo(int user_id, int album_id, int logo_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos/{logo_id}")
            .Delete();

        /// <summary>
        /// This method deletes the specified custom logo from its showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <returns>
        /// 204 No Content	The custom logo was deleted.
        /// 404 Not Found Error code 5000: No such showcase or logo exists.
        /// </returns>
        public virtual RestResult DeleteACustomShowcaseLogo(int album_id, int logo_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos/{logo_id}")
            .Delete();

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
        public virtual RestResult<Picture> GetASpecificCustomShowcaseLogo(int user_id, int album_id, int logo_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos/{logo_id}")
            .Get<Picture>();

        /// <summary>
        /// This method returns a single custom logo belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <returns>
        /// 200 OK	The custom logo was returned.
        /// 404 Not Found Error code 5000: No such showcase or logo exists.
        /// </returns>
        public virtual RestResult<Picture> GetASpecificCustomShowcaseLogo(int album_id, int logo_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos/{logo_id}")
            .Get<Picture>();

        /// <summary>
        /// This method returns all the custom logos belonging to the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom logos were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual RestResult<Pagination<Picture>> GetAllTheCustomLogosOfAShowcase(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos")
            .GetPagination<Picture>(RootAuthorization);

        /// <summary>
        /// This method returns all the custom logos belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom logos were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual RestResult<Pagination<Picture>> GetAllTheCustomLogosOfAShowcase(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos")
            .GetPagination<Picture>(RootAuthorization);

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
        public virtual RestResult<Picture> ReplaceACustomShowcaseLogo(int user_id, int album_id, int logo_id, bool active = true) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/logos/{logo_id}")
            .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
            .Patch<Picture>();

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
        public virtual RestResult<Picture> ReplaceACustomShowcaseLogo(int album_id, int logo_id, bool active = true) => RootAuthorization()
            .Command($"/me/albums/{album_id}/logos/{logo_id}")
            .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
            .Patch<Picture>();

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
        public virtual RestResult<Picture> AddACustomThumbnailToAShowcase(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails")
            .Post<Picture>();

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
        public virtual RestResult<Picture> AddACustomThumbnailToAShowcase(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails")
            .Post<Picture>();

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
        public virtual RestResult DeleteACustomShowcaseThumbnail(int user_id, int album_id, int thumbnail_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .Delete();

        /// <summary>
        /// This method deletes the specified custom thumbnail from its showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="thumbnail_id">The ID of the custom thumbnail.</param>
        /// <returns>
        /// 204 No Content	The custom thumbnail was deleted.
        /// 404 Not Found Error code 5000: No such showcase or thumbnail exists.
        /// </returns>
        public virtual RestResult DeleteACustomShowcaseThumbnail(int album_id, int thumbnail_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .Delete();

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
        public virtual RestResult<Picture> GetASpecificCustomShowcaseThumbnail(int user_id, int album_id, int thumbnail_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .Get<Picture>();

        /// <summary>
        /// This method returns a single custom thumbnail belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <param name="thumbnail_id">The ID of the custom thumbnail.</param>
        /// <returns>
        /// 200 OK	The custom thumbnail was returned.
        /// 404 Not Found Error code 5000: No such showcase or thumbnail exists.
        /// </returns>
        public virtual RestResult<Picture> GetASpecificCustomShowcaseThumbnail(int album_id, int thumbnail_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .Get<Picture>();

        /// <summary>
        /// This method returns all the custom thumbnails belonging to the specified showcase.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom thumbnails were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual RestResult<Pagination<Picture>> GetAllTheCustomThumbnailsOfAShowcase(int user_id, int album_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails")
            .GetPagination<Picture>(RootAuthorization);

        /// <summary>
        /// This method returns all the custom thumbnails belonging to the specified showcase.
        /// </summary>
        /// <param name="album_id">The ID of the showcase.</param>
        /// <returns>
        /// 200 OK	The custom thumbnails were returned.
        /// 404 Not Found Error code 5000: No such showcase exists.
        /// </returns>
        public virtual RestResult<Pagination<Picture>> GetAllTheCustomThumbnailsOfAShowcase(int album_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails")
            .GetPagination<Picture>(RootAuthorization);

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
        public virtual RestResult<Picture> ReplaceACustomShowcaseThumbnail(int user_id, int album_id, int thumbnail_id, bool active = true) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
            .Patch<Picture>();

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
        public virtual RestResult<Picture> ReplaceACustomShowcaseThumbnail(int album_id, int thumbnail_id, bool active = true) => RootAuthorization()
            .Command($"/me/albums/{album_id}/custom_thumbnails/{thumbnail_id}")
            .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
            .Patch<Picture>();

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
        public virtual RestResult AddASpecificVideoToAShowcase(int user_id, int album_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}")
            .Put();

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
        public virtual RestResult AddASpecificVideoToAShowcase(int album_id, int video_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}")
            .Put();

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
        public virtual RestResult<Picture> CreateAThumbnailForAShowcaseFromAShowcaseVideo(int user_id, int album_id, int video_id, double? time_code = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}/set_album_thumbnail")
            .FormUrlEncoded(new KeyValuePair<string, object>("time_code", time_code))
            .Post<Picture>();

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
        public virtual RestResult<Picture> MeCreateAThumbnailForAShowcaseFromAShowcaseVideo(int album_id, int video_id, double? time_code = null) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}/set_album_thumbnail")
            .FormUrlEncoded(new KeyValuePair<string, object>("time_code", time_code))
            .Post<Picture>();

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
        public virtual RestResult<Video> GetASpecificVideoInAShowcase(int user_id, int album_id, int video_id, string password = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}")
            .OptionalParameter("password", password)
            .Get<Video>();

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
        public virtual RestResult<Video> GetASpecificVideoInAShowcase(int album_id, int video_id, string password = null) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}")
            .OptionalParameter("password", password)
            .Get<Video>();

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
        public virtual RestResult<Pagination<Album>> GetAllTheShowcasesToWhichTheUserCanAddOrRemoveASpecificVideo(int user_id, int video_id,
            ShowCasesDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesGetAllSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/videos/{video_id}/available_albums")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPagination<Album>(RootAuthorization);

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
        public virtual RestResult<Pagination<Album>> GetAllTheShowcasesToWhichTheUserCanAddOrRemoveASpecificVideo(int video_id,
            ShowCasesDirection? direction = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesGetAllSort? sort = null) => RootAuthorization()
            .Command($"/videos/{video_id}/available_albums")
            .ListParameters(direction: direction, page: page, per_page: per_page, query: query, sort: sort)
            .GetPagination<Album>(RootAuthorization);

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
        public virtual RestResult<Pagination<Video>> GetAllTheUserVideosThatCanBeAddedToOrRemovedFromAShowcase(int user_id, int album_id,
            ShowCasesDirection? direction = null,
            ShowCasesVideosFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesVideosSort? sort = null) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/available_videos")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .GetPagination<Video>(RootAuthorization);

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
        public virtual RestResult<Pagination<Video>> GetAllTheUserVideosThatCanBeAddedToOrRemovedFromAShowcase(int album_id,
            ShowCasesDirection? direction = null,
            ShowCasesVideosFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            ShowCasesVideosSort? sort = null) => RootAuthorization()
            .Command($"/me/albums/{album_id}/available_videos")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .GetPagination<Video>(RootAuthorization);

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
        public virtual RestResult<Pagination<Video>> GetAllTheVideosInAShowcase(int user_id, int album_id,
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
            .GetPagination<Video>(RootAuthorization);

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
        public virtual RestResult<Pagination<Video>> GetAllTheVideosInAShowcase(int album_id,
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
            .GetPagination<Video>(RootAuthorization);

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
        public virtual RestResult RemoveAVideoFromAShowcase(int user_id, int album_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}")
            .Delete();

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
        public virtual RestResult RemoveAVideoFromAShowcase(int album_id, int video_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}")
            .Delete();

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
        public virtual RestResult ReplaceAllTheVideosInAShowcase(int user_id, int album_id, string[] videos) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos")
            .FormUrlEncoded(new KeyValuePair<string, object>("videos", videos))
            .Put();

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
        public virtual RestResult ReplaceAllTheVideosInAShowcase(int album_id, string[] videos) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos")
            .FormUrlEncoded(new KeyValuePair<string, object>("videos", videos))
            .Put();

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
        public virtual RestResult<Video> SetTheFeaturedVideoOfAShowcase(int user_id, int album_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/albums/{album_id}/videos/{video_id}/set_featured_video")
            .Post<Video>();

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
        public virtual RestResult<Video> SetTheFeaturedVideoOfAShowcase(int album_id, int video_id) => RootAuthorization()
            .Command($"/me/albums/{album_id}/videos/{video_id}/set_featured_video")
            .Post<Video>();

        #endregion

        /// <summary>
        /// Builds the showcase body from the legacy CreateAShowcase arguments
        /// </summary>
        private static ShowCaseEditParameters ToParameters(string name,
            string brand_color,
            string description,
            bool hide_nav,
            bool hide_upcoming,
            ShowCasesLayout? layout,
            string password,
            ShowCasesPrivacy? privacy,
            bool review_mode,
            ShowCasesSort? sort,
            ShowCasesTheme? theme) => new ShowCaseEditParameters
            {
                Name = name,
                BrandColor = brand_color,
                Description = description,
                HideNav = hide_nav,
                HideUpcoming = hide_upcoming,
                Layout = layout,
                Password = password,
                Privacy = privacy,
                ReviewMode = review_mode,
                Sort = sort,
                Theme = theme,
            };
    }
}
