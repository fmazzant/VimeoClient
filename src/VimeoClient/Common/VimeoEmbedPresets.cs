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
    using System.Runtime.CompilerServices;
    using System.Threading;
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// An embed preset is a reusable collection of settings for customizing the appearance and behavior of the embeddable Vimeo player. 
    /// This feature is available to Vimeo Pro, Business, and Premium members. 
    /// For more information, see our Help Center.
    /// https://developer.vimeo.com/api/reference/embed-presets
    /// </summary>
    public class VimeoEmbedPresets
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
        public VimeoEmbedPresets(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoEmbedPresets(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]

        /// <summary>
        /// This method edits the specified embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="disable">What to do with the outro: true disable outro</param>
        /// <returns></returns>
        public RestResult<Presets> EditAnEmbedPreset(int preset_id, int user_id, bool disable = false) => RootAuthorization()
            .Command($"/users/{user_id}/presets/{preset_id}")
            .FormUrlEncoded(true, (p) =>
            {
                if (!disable)
                {
                    p.Add("outro", "nothing");
                }
            })
            .Patch<Presets>();

        /// <summary>
        /// This method edits the specified embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <param name="disable">What to do with the outro: true disable outro</param>
        /// <returns></returns>
        public RestResult<Presets> EditAnEmbedPreset(int preset_id, bool disable = false) => RootAuthorization()
            .Command($"/me/presets/{preset_id}")
            .FormUrlEncoded(true, (p) =>
            {
                if (!disable)
                {
                    p.Add("outro", "nothing");
                }
            })
            .Patch<Presets>();

        /// <summary>
        /// This method returns a single embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<Presets> GetASpecificEmbedPreset(int preset_id, int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/presets/{preset_id}")
            .Get<Presets>();

        /// <summary>
        /// This method returns a single embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <returns></returns>
        public RestResult<Presets> GetASpecificEmbedPreset(int preset_id) => RootAuthorization()
            .Command($"/me/presets/{preset_id}")
            .Get<Presets>();

        /// <summary>
        /// This method returns every embed preset that belongs to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<Pagination<Presets>> GetAllTheEmbedPresetsThatAUserHasCreadted(int user_id, int? page = null, int? per_page = null)
        {
            var root = RootAuthorization()
                .Command($"/users/{user_id}/presets")
                .Parameter((p) =>
                {
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                });

            var result = root.Get<Pagination<Presets>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Presets>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Presets>>();
            }

            return result;
        }

        /// <summary>
        /// This method returns every embed preset that belongs to the authenticated user.
        /// </summary>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public RestResult<Pagination<Presets>> GetAllTheEmbedPresetsThatAUserHasCreadted(int? page = null, int? per_page = null)
        {
            var root = RootAuthorization()
                .Command($"/me/presets")
                .Parameter((p) =>
                {
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                });

            var result = root.Get<Pagination<Presets>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Presets>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Presets>>();
            }

            return result;
        }

        #endregion

        #region [ Custom logos ]

        //Add a custom logo for the user
        /// <summary>
        /// This method adds a custom logo representing the authenticated user for display in the embedded player.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns>
        /// 201 Created	The custom logo was added.
        /// 403 Forbidden The authenticated user can't add the custom logo.
        /// </returns>
        public RestResult<Picture> AddACustomLogoForTheUser(int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/customlogos")
            .Post<Picture>();

        //Add a custom logo for the user
        /// <summary>
        /// This method adds a custom logo representing the authenticated user for display in the embedded player.
        /// </summary>
        /// <returns>
        /// 201 Created	The custom logo was added.
        /// 403 Forbidden The authenticated user can't add the custom logo.
        /// </returns>
        public RestResult<Picture> AddACustomLogoForTheUser() => RootAuthorization()
            .Command($"/me/customlogos")
            .Post<Picture>();

        /// <summary>
        /// This method returns a single custom logo belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <returns></returns>
        public RestResult<Picture> GetASpecificCustomLogoForThwUser(int user_id, int logo_id) => RootAuthorization()
            .Command($"/users/{user_id}/customlogos/{logo_id}")
            .Get<Picture>();

        /// <summary>
        /// This method returns a single custom logo belonging to the authenticated user.
        /// </summary>
        /// <param name="logo_id">The ID of the custom logo.</param>
        /// <returns></returns>
        public RestResult<Picture> GetASpecificCustomLogoForThwUser(int logo_id) => RootAuthorization()
           .Command($"/me/customlogos/{logo_id}")
           .Get<Picture>();

        /// <summary>
        /// This method returns every custom logo that belongs to the authenticated user or team owner.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <returns></returns>
        public RestResult<VimeoList<Picture>> GetAllTheCustomLogosThatBelongToTheUser(int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/customlogos")
            .Get<VimeoList<Picture>>();

        /// <summary>
        /// This method returns every custom logo that belongs to the authenticated user or team owner.
        /// </summary>
        /// <returns></returns>
        public RestResult<VimeoList<Picture>> GetAllTheCustomLogosThatBelongToTheUser() => RootAuthorization()
            .Command($"/me/customlogos")
            .Get<VimeoList<Picture>>();

        #endregion

        #region [ Timeline events ]

        /// <summary>
        /// This method adds a timeline event thumbnail to the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 201 Created	The timeline event thumbnail was added.
        /// 403 Forbidden The authenticated user can't add a timeline event thumbnail to the video.
        /// 404 Not Found   No such video exists.
        /// </returns>
        public RestResult<Picture> AddTimelineEventThumbnailToAVideo(int video_id) => RootAuthorization()
            .Command($"/videos/{video_id}/timelinethumbnails")
            .Post<Picture>();

        /// <summary>
        /// This method returns a single timeline event thumbnail that belongs to the specified video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="thumbnail_id">The ID of the timeline event thumbnail.</param>
        /// <returns>
        /// 200 OK	The timeline event thumbnail was returned.
        /// 403 Forbidden The authenticated user can't access the timeline event thumbnail.
        /// </returns>
        public RestResult<Picture> GetTimelineEventThumnail(int video_id, int thumbnail_id) => RootAuthorization()
            .Command($"/videos/{video_id}/timelinethumbnails/{thumbnail_id}")
            .Get<Picture>();

        #endregion

        #region [ Videos ]

        /// <summary>
        /// This method adds an embed preset to the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <returns>
        /// 204 No Content	The embed preset was added to the video.
        /// </returns>
        public RestResult AddEmbedPresetToAVideo(int video_id, int preset_id) => RootAuthorization()
            .Command($"/videos/{video_id}/presets/{preset_id}")
            .Put();

        /// <summary>
        /// This method determines whether a video has the specified embed preset.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <returns>
        /// 204 No Content	The embed preset has been added to the video.
        /// 404 Not Found   No such video or embed preset exists.
        /// </returns>
        public RestResult CheckIfAnEmbedPresetHasBeenAddedToAVideo(int video_id, int preset_id) => RootAuthorization()
            .Command($"/videos/{video_id}/presets/{preset_id}")
            .Get();

        /// <summary>
        /// This method returns every video to which the specified embed preset has been added. The authenticated user must be the owner of videos.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// </returns>
        public RestResult<Pagination<Video>> GetAllTheVideosThatHaveASpecificEmbedPreset(int user_id, int preset_id, int? page = null, int? per_page = null)
        {
            var root = RootAuthorization()
                .Command($"/users/{user_id}/presets/{preset_id}/videos")
                .Parameter((p) =>
                {
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                });

            var result = root.Get<Pagination<Video>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Video>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Video>>();
            }

            return result;
        }

        /// <summary>
        /// This method returns every video to which the specified embed preset has been added. The authenticated user must be the owner of videos.
        /// </summary>
        /// <param name="preset_id">The ID of the embed preset.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// </returns>
        public RestResult<Pagination<Video>> GetAllTheVideosThatHaveASpecificEmbedPreset(int preset_id, int? page = null, int? per_page = null)
        {
            var root = RootAuthorization()
                .Command($"/me/presets/{preset_id}/videos")
                .Parameter((p) =>
                {
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                });

            var result = root.Get<Pagination<Video>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Video>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Video>>();
            }

            return result;
        }

        /// <summary>
        /// This method removes the specified embed preset from a video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <param name="preset_id">The ID of the embed preset</param>
        /// <returns></returns>
        public RestResult RemoveAnEmbedPresetFromVideo(int video_id, int preset_id) => RootAuthorization()
            .Command($"/videos/{video_id}/presets/{preset_id}")
            .Delete();

        #endregion
    }
}