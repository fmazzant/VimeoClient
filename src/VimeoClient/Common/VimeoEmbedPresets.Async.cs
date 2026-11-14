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
    using Mafesoft.VimeoClient.Body.EmbedPreset;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoEmbedPresets.
    public partial class VimeoEmbedPresets
    {
        #region [ Essentials ]

        /// <summary>
        /// This method creates an embed preset.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="parameters">The embed preset.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The embed preset was created.
        /// </returns>
        public virtual Task<RestResult<Presets>> CreateAnEmbedPresetAsync(int user_id, EmbedPresetParameters parameters, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/presets")
            .JsonPayload(parameters)
            .PostAsync<Presets>(cancellationToken);

        /// <summary>
        /// This method creates an embed preset for the authenticated user.
        /// </summary>
        /// <param name="parameters">The embed preset.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The embed preset was created.
        /// </returns>
        public virtual Task<RestResult<Presets>> MeCreateAnEmbedPresetAsync(EmbedPresetParameters parameters, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/presets")
            .JsonPayload(parameters)
            .PostAsync<Presets>(cancellationToken);

        /// <summary>
        /// This method deletes the specified embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The embed preset was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAnEmbedPresetAsync(int user_id, int preset_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/presets/{preset_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method deletes the specified embed preset of the authenticated user.
        /// </summary>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The embed preset was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> MeDeleteAnEmbedPresetAsync(int preset_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/presets/{preset_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method edits the specified embed preset (name and embed settings). The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="parameters">The fields to edit: only the values that are set are sent.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The embed preset was edited.
        /// </returns>
        public virtual Task<RestResult<Presets>> EditAnEmbedPresetAsync(int preset_id, int user_id, EmbedPresetParameters parameters, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/presets/{preset_id}")
            .JsonPayload(parameters)
            .PatchAsync<Presets>(cancellationToken);

        /// <summary>
        /// This method edits the specified embed preset (name and embed settings) of the authenticated user.
        /// </summary>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="parameters">The fields to edit: only the values that are set are sent.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The embed preset was edited.
        /// </returns>
        public virtual Task<RestResult<Presets>> MeEditAnEmbedPresetAsync(int preset_id, EmbedPresetParameters parameters, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/presets/{preset_id}")
            .JsonPayload(parameters)
            .PatchAsync<Presets>(cancellationToken);

        /// <summary>
        /// This method edits the specified embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="disable">What to do with the outro: true disable outro</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Presets>> EditAnEmbedPresetAsync(int preset_id, int user_id, bool disable = false, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/presets/{preset_id}")
            .FormUrlEncoded(true, (p) =>
            {
                if (!disable)
                {
                    p.Add("outro", "nothing");
                }
            })
            .PatchAsync<Presets>(cancellationToken);

        /// <summary>
        /// This method edits the specified embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <param name="disable">What to do with the outro: true disable outro</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Presets>> EditAnEmbedPresetAsync(int preset_id, bool disable = false, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/presets/{preset_id}")
            .FormUrlEncoded(true, (p) =>
            {
                if (!disable)
                {
                    p.Add("outro", "nothing");
                }
            })
            .PatchAsync<Presets>(cancellationToken);

        /// <summary>
        /// This method returns a single embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Presets>> GetASpecificEmbedPresetAsync(int preset_id, int user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/presets/{preset_id}")
            .GetAsync<Presets>(cancellationToken);

        /// <summary>
        /// This method returns a single embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Presets>> GetASpecificEmbedPresetAsync(int preset_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/presets/{preset_id}")
            .GetAsync<Presets>(cancellationToken);

        /// <summary>
        /// This method returns every embed preset that belongs to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Presets>>> GetAllTheEmbedPresetsThatAUserHasCreatedAsync(int user_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/presets")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<Presets>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every embed preset that belongs to the authenticated user.
        /// </summary>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<Presets>>> MeGetAllTheEmbedPresetsThatAUserHasCreatedAsync(int? page = null, int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/presets")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<Presets>(RootAuthorization, cancellationToken);

        #endregion

        #region [ Custom logos ]

        /// <summary>
        /// This method adds a custom logo representing the authenticated user for display in the embedded player.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The custom logo was added.
        /// 403 Forbidden The authenticated user can't add the custom logo.
        /// </returns>
        public virtual Task<RestResult<Picture>> AddACustomLogoForTheUserAsync(int user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/customlogos")
            .PostAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method adds a custom logo representing the authenticated user for display in the embedded player.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The custom logo was added.
        /// 403 Forbidden The authenticated user can't add the custom logo.
        /// </returns>
        public virtual Task<RestResult<Picture>> AddACustomLogoForTheUserAsync(CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/customlogos")
            .PostAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns a single custom logo belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> GetASpecificCustomLogoForTheUserAsync(int user_id, int logo_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/customlogos/{logo_id}")
            .GetAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns a single custom logo belonging to the authenticated user.
        /// </summary>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Picture>> MeGetASpecificCustomLogoForTheUserAsync(int logo_id, CancellationToken cancellationToken = default) => RootAuthorization()
           .Command($"/me/customlogos/{logo_id}")
           .GetAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns every custom logo that belongs to the authenticated user or team owner.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Picture>>> GetAllTheCustomLogosThatBelongToTheUserAsync(int user_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/customlogos")
            .GetAsync<VimeoList<Picture>>(cancellationToken);

        /// <summary>
        /// This method returns every custom logo that belongs to the authenticated user or team owner.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<VimeoList<Picture>>> GetAllTheCustomLogosThatBelongToTheUserAsync(CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/customlogos")
            .GetAsync<VimeoList<Picture>>(cancellationToken);

        /// <summary>
        /// This method deletes the specified custom logo belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The custom logo was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteACustomUserLogoAsync(int user_id, int logo_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/customlogos/{logo_id}")
            .DeleteAsync(cancellationToken);

        /// <summary>
        /// This method deletes the specified custom logo belonging to the authenticated user.
        /// </summary>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The custom logo was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> MeDeleteACustomUserLogoAsync(int logo_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/customlogos/{logo_id}")
            .DeleteAsync(cancellationToken);

        #endregion

        #region [ Folders ]

        /// <summary>
        /// This method removes the specified embed preset from a folder.
        /// The authenticated user must be either the owner of the folder or a team user with the contributor role or higher.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="project_id">The ID of the folder.</param>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The embed preset was removed.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveAnEmbedPresetFromAFolderAsync(int user_id, int project_id, int preset_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/projects/{project_id}/presets/{preset_id}")
            .DeleteAsync(cancellationToken);

        #endregion

        #region [ Timeline events ]

        /// <summary>
        /// This method adds a timeline event thumbnail to the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 201 Created	The timeline event thumbnail was added.
        /// 403 Forbidden The authenticated user can't add a timeline event thumbnail to the video.
        /// 404 Not Found   No such video exists.
        /// </returns>
        public virtual Task<RestResult<Picture>> AddTimelineEventThumbnailToAVideoAsync(int video_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/videos/{video_id}/timelinethumbnails")
            .PostAsync<Picture>(cancellationToken);

        /// <summary>
        /// This method returns a single timeline event thumbnail that belongs to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="thumbnail_id">The ID of the timeline event thumbnail.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The timeline event thumbnail was returned.
        /// 403 Forbidden The authenticated user can't access the timeline event thumbnail.
        /// </returns>
        public virtual Task<RestResult<Picture>> GetTimelineEventThumbnailAsync(int video_id, int thumbnail_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/videos/{video_id}/timelinethumbnails/{thumbnail_id}")
            .GetAsync<Picture>(cancellationToken);

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method adds an embed preset to the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The embed preset was added to the video.
        /// </returns>
        public virtual Task<RestResult<string>> AddEmbedPresetToAVideoAsync(int video_id, int preset_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/videos/{video_id}/presets/{preset_id}")
            .PutAsync(cancellationToken);

        /// <summary>
        /// This method determines whether a video has the specified embed preset.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The embed preset has been added to the video.
        /// 404 Not Found   No such video or embed preset exists.
        /// </returns>
        public virtual Task<RestResult<string>> CheckIfAnEmbedPresetHasBeenAddedToAVideoAsync(int video_id, int preset_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/videos/{video_id}/presets/{preset_id}")
            .GetAsync(cancellationToken);

        /// <summary>
        /// This method returns every video to which the specified embed preset has been added. The authenticated user must be the owner of videos.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Video>>> GetAllTheVideosThatHaveASpecificEmbedPresetAsync(int user_id, int preset_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/users/{user_id}/presets/{preset_id}/videos")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<Video>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method returns every video to which the specified embed preset has been added. The authenticated user must be the owner of videos.
        /// </summary>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// </returns>
        public virtual Task<RestResult<Pagination<Video>>> MeGetAllTheVideosThatHaveASpecificEmbedPresetAsync(int preset_id, int? page = null, int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/me/presets/{preset_id}/videos")
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<Video>(RootAuthorization, cancellationToken);

        /// <summary>
        /// This method removes the specified embed preset from a video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="preset_id">The ID of the embed preset</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>
        /// 204 No Content	The embed preset was removed.
        /// 404 Not Found   No such video or embed preset exists.
        /// </returns>
        public virtual Task<RestResult<string>> RemoveAnEmbedPresetFromVideoAsync(int video_id, int preset_id, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command($"/videos/{video_id}/presets/{preset_id}")
            .DeleteAsync(cancellationToken);

        #endregion
    }
}
