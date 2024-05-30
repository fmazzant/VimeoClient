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
    using System.Threading.Tasks;
    using VimeoClient.Body.Live;
    using VimeoClient.Filter.Live;
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// Please note that Vimeo's live API is available only to Vimeo Enterprise customers. 
    /// https://developer.vimeo.com/api/reference/live
    /// Learn more about Vimeo Enterprise.
    /// </summary>
    public class VimeoLive
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
        public VimeoLive(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoLive(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]

        /// <summary>
        /// This method creates a new live event for the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> CreateALiveEventAsync(int user_id, LiveParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/live_events")
            .Payload(parameters)
            .PostAsync<LiveEventRecurring>();

        /// <summary>
        /// This method creates a new live event for the authenticated user.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> CreateALiveEventAsync(LiveParameters parameters) => RootAuthorization()
           .Command($"/me/live_events")
           .Payload(parameters)
           .PostAsync<LiveEventRecurring>();

        /// <summary>
        /// This method deletes multiple live events belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteListOfLiveEventsAsync(int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events")
            .DeleteAsync();

        /// <summary>
        /// This method deletes multiple live events belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteListOfLiveEventsAsync() => RootAuthorization()
           .Command($"/live_events")
           .DeleteAsync();

        /// <summary>
        /// This method deletes multiple live events belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteMeListOfLiveEventsAsync() => RootAuthorization()
           .Command($"/me/live_events")
           .DeleteAsync();

        /// <summary>
        /// This method deletes a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteSpecificLiveEventAsync(int user_id, int live_event_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}")
            .DeleteAsync();

        /// <summary>
        /// This method deletes a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteSpecificLiveEventAsync(int live_event_id) => RootAuthorization()
            .Command($"/users/live_events/{live_event_id}")
            .DeleteAsync();

        /// <summary>
        /// This method deletes a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteMeSpecificLiveEvent(int live_event_id) => RootAuthorization()
           .Command($"/me/users/live_events/{live_event_id}")
           .DeleteAsync();

        /// <summary>
        /// This method returns a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> GetSpecificLiveStreamAsync(int user_id, int live_event_id) => RootAuthorization()
            .Command($"/{user_id}/live_events/{live_event_id}")
            .GetAsync<LiveEventRecurring>();

        /// <summary>
        /// This method returns a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> GetSpecificLiveStream(int live_event_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}")
            .GetAsync<LiveEventRecurring>();

        /// <summary>
        /// This method returns a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> GetMeSpecificLiveStreamAsync(int live_event_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}")
            .GetAsync<LiveEventRecurring>();

        /// <summary>
        /// The method returns every live event belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public Task<RestResult<VimeoList<LiveEvent>>> GetAllTheLiveEventsAsync(int user_id,
            LiveDirection? direction = null,
            LiveFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            LiveSort? sort = null,
            LiveType? type = null) => RootAuthorization()
            .Command($"/users/{user_id}/live_events")
            .GetAsync<VimeoList<LiveEvent>>();

        /// <summary>
        /// The method returns every live event belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public Task<RestResult<LiveEvent>> GetAllTheLiveEventsAsync(
            LiveDirection? direction = null,
            LiveFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            LiveSort? sort = null,
            LiveType? type = null) => RootAuthorization()
            .Command($"/live_events")
            .GetAsync<LiveEvent>();

        /// <summary>
        /// The method returns every live event belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public Task<RestResult<LiveEvent>> GetMeAllTheLiveEventsAsync(
            LiveDirection? direction = null,
            LiveFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            LiveSort? sort = null,
            LiveType? type = null) => RootAuthorization()
            .Command($"/me/live_events")
            .GetAsync<LiveEvent>();

        /// <summary>
        /// This method updates a live event belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> PatchSpecificLiveStreamAsync(int user_id, int live_event_id) => RootAuthorization()
           .Command($"/{user_id}/live_events/{live_event_id}")
           .PatchAsync<LiveEventRecurring>();

        /// <summary>
        /// This method updates a live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> PatchSpecificLiveStreamAsync(int live_event_id) => RootAuthorization()
           .Command($"/live_events/{live_event_id}")
           .PatchAsync<LiveEventRecurring>();

        /// <summary>
        /// This method updates a live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> PatchMeSpecificLiveStreamAsync(int live_event_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}")
            .PatchAsync<LiveEventRecurring>();

        #endregion

        #region [ Embed privacy ]

        /// <summary>
        /// Embed a recurring live event on one or more domains
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="domains">An array of the domains on which the embedded live event can appear.</param>
        /// <returns></returns>
        public Task<RestResult<string>> PutEmbedALiveEventOnOneOrMoreDomainsAsync(int user_id, int live_event_id, string[] domains = null) => RootAuthorization()
           .Command($"/{user_id}/live_events/{live_event_id}/privacy/domains")
           .PutAsync();

        /// <summary>
        /// Embed a recurring live event on one or more domains
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="domains">An array of the domains on which the embedded live event can appear.</param>
        /// <returns></returns>
        public Task<RestResult<string>> PutEmbedALiveEventOnOneOrMoreDomainsAsync(int live_event_id, string[] domains = null) => RootAuthorization()
          .Command($"/live_events/{live_event_id}/privacy/domains")
          .PutAsync();

        /// <summary>
        /// Embed a recurring live event on one or more domains
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="domains">An array of the domains on which the embedded live event can appear.</param>
        /// <returns></returns>
        public Task<RestResult<string>> PutMeEmbedALiveEventOnOneOrMoreDomainsAsync(int live_event_id, string[] domains = null) => RootAuthorization()
           .Command($"/me/live_events/{live_event_id}/privacy/domains")
           .PutAsync();

        /// <summary>
        /// Get all the domains on which a recurring live event can be embedded
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<VimeoList<Domain>>> GetAllTheDomainsOnWhichARecurringLiveEventCanBeEmbeddedAsync(int user_id, int live_event_id) => RootAuthorization()
          .Command($"/{user_id}/live_events/{live_event_id}/privacy/domains")
          .GetAsync<VimeoList<Domain>>();

        /// <summary>
        /// Get all the domains on which a recurring live event can be embedded
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<VimeoList<Domain>>> GetAllTheDomainsOnWhichARecurringLiveEventCanBeEmbeddedAsync(int live_event_id) => RootAuthorization()
          .Command($"/live_events/{live_event_id}/privacy/domains")
          .GetAsync<VimeoList<Domain>>();

        /// <summary>
        /// Get all the domains on which a recurring live event can be embedded
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<VimeoList<Domain>>> GetMeAllTheDomainsOnWhichARecurringLiveEventCanBeEmbeddedAsync(int live_event_id) => RootAuthorization()
         .Command($"/me/live_events/{live_event_id}/privacy/domains")
         .GetAsync<VimeoList<Domain>>();

        #endregion

        #region [ Event activation ]
        /// <summary>
        /// Activate a live event
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> ActivateALiveEventAsync(int user_id, int live_event_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/activate")
            .PostAsync();

        /// <summary>
        /// Activate a live event
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> ActivateALiveEventAsync(int live_event_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/activate/live_events/{live_event_id}/activate")
            .PostAsync();

        /// <summary>
        /// Activate a live event
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> MeActivateALiveEventAsync(int live_event_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}/activate")
            .PostAsync();

        #endregion

        #region [ Event M3U8 playback ]

        /// <summary>
        /// This method returns an M3U8 playback URL for the specificed live event stream. You should use this endpoint only in conjunction with our recommended procedure for playing live events via HLS. 
        /// For more information, see our HLS guide.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> GetAnM3U8PlaybackURLForARecurringLiveEventAsync(int user_id, int live_event_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/m3u8_playback")
            .GetAsync();

        /// <summary>
        /// Get an M3U8 playback URL for a recurring live event
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> GetMeAnM3U8PlaybackURLForARecurringLiveEventAsync(int live_event_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}/m3u8_playback")
            .GetAsync();

        #endregion

        #region [ Get the ingest status of a one-time live event ]

        /// <summary>
        /// This method returns the ingest status of the specified one-time live event.
        /// </summary>
        /// <param name="video_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventSessionStatus>> GetTheIngestStatusOfAOneTimeLiveEventAsync(int video_id) => RootAuthorization()
           .Command($"/videos/{video_id}/sessions/status")
           .GetAsync<LiveEventSessionStatus>();

        #endregion


        #region [ Event thumbnails ]

        /// <summary>
        /// This method creates a thumbnail image for the specified live event.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id">The ID of the live even</param>
        /// <returns></returns>
        public Task<RestResult<Picture>> CreateALiveEventThumbnailAsync(int user_id, int live_event_id) => RootAuthorization()
           .Command($"/users/{user_id}/live_events/{live_event_id}/pictures")
           .PostAsync<Picture>();

        /// <summary>
        /// This method creates a thumbnail image for the specified live event.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<Picture>> CreateALiveEventThumbnailAsync(int live_event_id) => RootAuthorization()
           .Command($"/live_events/{live_event_id}/pictures")
           .PostAsync<Picture>();

        /// <summary>
        /// This method creates a thumbnail image for the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live even</param>
        /// <returns></returns>
        public Task<RestResult<Picture>> MeCreateALiveEventThumbnailAsync(int live_event_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}/pictures")
            .PostAsync<Picture>();

        /// <summary>
        /// This method deletes a thumbnail image for the specified live event.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the live even</param>
        /// <param name="thumbnail_id">The ID of the live event.</param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteALiveEventThumbnailAsync(int user_id, int live_event_id, int thumbnail_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/pictures/{thumbnail_id}")
            .DeleteAsync();

        /// <summary>
        /// This method deletes a thumbnail image for the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live even</param>
        /// <param name="thumbnail_id">The ID of the live event.</param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteALiveEventThumbnailAsync(int live_event_id, int thumbnail_id) => RootAuthorization()
           .Command($"/live_events/{live_event_id}/pictures/{thumbnail_id}")
           .DeleteAsync();

        /// <summary>
        /// This method deletes a thumbnail image for the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live even</param>
        /// <param name="thumbnail_id">The ID of the live event.</param>
        /// <returns></returns>
        public Task<RestResult<string>> MeDeleteALiveEventThumbnailAsync(int live_event_id, int thumbnail_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}/pictures/{thumbnail_id}")
            .DeleteAsync();

        /// <summary>
        /// This method edits a thumbnail image for the specified live event.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="thumbnail_id">The ID of the live event.</param>
        /// <param name="active">Whether the thumbnail is the live event's active thumbnail.</param>
        /// <returns></returns>
        public Task<RestResult<Picture>> EditALiveEventThumbnailAsync(int user_id, int live_event_id, int thumbnail_id, bool active) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/pictures/{thumbnail_id}")
            .PatchAsync<Picture>();

        /// <summary>
        /// This method edits a thumbnail image for the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="thumbnail_id">The ID of the live event.</param>
        /// <param name="active">Whether the thumbnail is the live event's active thumbnail.</param>
        /// <returns></returns>
        public Task<RestResult<Picture>> EditALiveEventThumbnailAsync(int live_event_id, int thumbnail_id, bool active) => RootAuthorization()
           .Command($"/live_events/{live_event_id}/pictures/{thumbnail_id}")
           .PatchAsync<Picture>();

        /// <summary>
        /// This method edits a thumbnail image for the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="thumbnail_id">The ID of the live event.</param>
        /// <param name="active">Whether the thumbnail is the live event's active thumbnail.</param>
        /// <returns></returns>
        public Task<RestResult<Picture>> MeEditALiveEventThumbnailAsync(int live_event_id, int thumbnail_id, bool active) => RootAuthorization()
           .Command($"/me/live_events/{live_event_id}/pictures/{thumbnail_id}")
           .PatchAsync<Picture>();

        /// <summary>
        /// This method returns a single thumbnail image of the specified live event.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="thumbnail_id">The ID of the thumbnail.</param>
        /// <returns></returns>
        public Task<RestResult<Picture>> GetASpecificLiveEventThumbnailAsync(int user_id, int live_event_id, int thumbnail_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/pictures/{thumbnail_id}")
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns a single thumbnail image of the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="thumbnail_id">The ID of the thumbnail.</param>
        /// <returns></returns>
        public Task<RestResult<Picture>> GetASpecificLiveEventThumbnailAsync(int live_event_id, int thumbnail_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/pictures/{thumbnail_id}")
            .GetAsync<Picture>();

        /// <summary>
        /// This method returns a single thumbnail image of the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="thumbnail_id">The ID of the thumbnail.</param>
        /// <returns></returns>
        public Task<RestResult<Picture>> MeGetASpecificLiveEventThumbnailAsync(int live_event_id, int thumbnail_id) => RootAuthorization()
          .Command($"/me/live_events/{live_event_id}/pictures/{thumbnail_id}")
          .GetAsync<Picture>();

        /// <summary>
        /// This method returns every thumbnail image of the specified live event.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <returns></returns>
        public Task<RestResult<VimeoList<Picture>>> GetAllTheThumbnailsOfALiveEventAsync(int user_id, int live_event_id) => RootAuthorization()
           .Command($"/users/{user_id}/live_events/{live_event_id}/pictures")
           .GetAsync<VimeoList<Picture>>();

        /// <summary>
        /// This method returns every thumbnail image of the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <returns></returns>
        public Task<RestResult<VimeoList<Picture>>> GetAllTheThumbnailsOfALiveEventAsync(int live_event_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/pictures")
            .GetAsync<VimeoList<Picture>>();

        /// <summary>
        /// This method returns every thumbnail image of the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <returns></returns>
        public Task<RestResult<VimeoList<Picture>>> MeGetAllTheThumbnailsOfALiveEventAsync(int live_event_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}/pictures")
            .GetAsync<VimeoList<Picture>>();

        #endregion

        #region [ Event videos ]

        /// <summary>
        /// This method adds multiple videos to the specified live event.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="videos">An array of video objects.</param>
        /// <returns></returns>
        public Task<RestResult<string>> AddAListOfVideosToALiveEventAsync(int user_id, int live_event_id, Video[] videos) => RootAuthorization()
          .Command($"/users/{user_id}/live_events/{live_event_id}/videos")
          .PostAsync();

        /// <summary>
        /// This method adds multiple videos to the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="videos">An array of video objects.</param>
        /// <returns></returns>
        public Task<RestResult<string>> AddAListOfVideosToALiveEventAsync(int live_event_id, Video[] videos) => RootAuthorization()
          .Command($"/live_events/{live_event_id}/videos")
          .PostAsync();

        /// <summary>
        /// This method adds multiple videos to the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="videos">An array of video objects.</param>
        /// <returns></returns>
        public Task<RestResult<string>> MeAddAListOfVideosToALiveEventAsync(int live_event_id, Video[] videos) => RootAuthorization()
          .Command($"/me/live_events/{live_event_id}/videos")
          .PostAsync();

        /// <summary>
        /// This method returns a single video in the specified live event.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public Task<RestResult<Video>> GetASpecificVideoInALiveEventAsync(int user_id, int live_event_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/videos/{video_id}")
            .GetAsync<Video>();

        /// <summary>
        /// This method returns a single video in the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public Task<RestResult<Video>> GetASpecificVideoInALiveEventAsync(int live_event_id, int video_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/videos/{video_id}")
            .GetAsync<Video>();

        /// <summary>
        /// This method returns a single video in the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public Task<RestResult<Video>> MeGetASpecificVideoInALiveEventAsync(int live_event_id, int video_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}/videos/{video_id}")
            .GetAsync<Video>();

        /// <summary>
        /// This method returns every video in the specified event.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <returns>The video representation consists of the following fields.</returns>
        public Task<RestResult<Video>> GetAllTheVideosInALiveEvent(int user_id, int live_event_id) => RootAuthorization()
           .Command($"/users/{user_id}/live_events/{live_event_id}/videos")
           .GetAsync<Video>();

        /// <summary>
        /// This method returns every video in the specified event.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns>The video representation consists of the following fields.</returns>
        public Task<RestResult<Video>> GetAllTheVideosInALiveEvent(int live_event_id) => RootAuthorization()
             .Command($"/live_events/{live_event_id}/videos")
             .GetAsync<Video>();

        /// <summary>
        /// This method returns every video in the specified event.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns>The video representation consists of the following fields.</returns>
        public Task<RestResult<Video>> MeGetAllTheVideosInALiveEvent(int live_event_id) => RootAuthorization()
           .Command($"/me/live_events/{live_event_id}/videos")
           .GetAsync<Video>();

        /// <summary>
        /// This method removes multiple videos from the specified live event.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="videos">An array of video objects.</param>
        /// <returns></returns>
        public Task<RestResult<string>> RemoveAListOfVideosFromALiveEventAsync(int user_id, int live_event_id, Video[] videos) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/videos")
            .DeleteAsync();

        /// <summary>
        /// This method removes multiple videos from the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="videos">An array of video objects.</param>
        /// <returns></returns>
        public Task<RestResult<string>> RemoveAListOfVideosFromALiveEventAsync(int live_event_id, Video[] videos) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/videos")
            .DeleteAsync();

        /// <summary>
        /// This method removes multiple videos from the specified live event.
        /// </summary>
        /// <param name="live_event_id">The ID of the live event.</param>
        /// <param name="videos">An array of video objects.</param>
        /// <returns></returns>
        public Task<RestResult<string>> MeRemoveAListOfVideosFromALiveEventAsync(int live_event_id, Video[] videos) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}/videos")
            .DeleteAsync();

        #endregion
    }
}