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
    using System.Text.Json;
    using System.Threading.Tasks;
    using Mafesoft.VimeoClient.Body.Live;
    using Mafesoft.VimeoClient.Filter.Live;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;

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
            .JsonPayload(parameters)
            .PostAsync<LiveEventRecurring>();

        /// <summary>
        /// This method creates a new live event for the authenticated user.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> CreateALiveEventAsync(LiveParameters parameters) => RootAuthorization()
           .Command($"/me/live_events")
           .JsonPayload(parameters)
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
            .Command($"/live_events/{live_event_id}")
            .DeleteAsync();

        /// <summary>
        /// This method deletes a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteMeSpecificLiveEvent(int live_event_id) => RootAuthorization()
           .Command($"/me/live_events/{live_event_id}")
           .DeleteAsync();

        /// <summary>
        /// This method returns a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> GetSpecificLiveStreamAsync(int user_id, int live_event_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}")
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
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("type", type)
            .GetAsync<VimeoList<LiveEvent>>();

        /// <summary>
        /// The method returns every live event belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public Task<RestResult<VimeoList<LiveEvent>>> GetAllTheLiveEventsAsync(
            LiveDirection? direction = null,
            LiveFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            LiveSort? sort = null,
            LiveType? type = null) => RootAuthorization()
            .Command($"/live_events")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("type", type)
            .GetAsync<VimeoList<LiveEvent>>();

        /// <summary>
        /// The method returns every live event belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public Task<RestResult<VimeoList<LiveEvent>>> GetMeAllTheLiveEventsAsync(
            LiveDirection? direction = null,
            LiveFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            LiveSort? sort = null,
            LiveType? type = null) => RootAuthorization()
            .Command($"/me/live_events")
            .ListParameters(direction, filter, page, per_page, query, sort)
            .OptionalParameter("type", type)
            .GetAsync<VimeoList<LiveEvent>>();

        /// <summary>
        /// This method updates a live event belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <param name="parameters">The fields to update</param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> PatchSpecificLiveStreamAsync(int user_id, int live_event_id, LiveParameters parameters = null) => RootAuthorization()
           .Command($"/users/{user_id}/live_events/{live_event_id}")
           .JsonPayload(parameters)
           .PatchAsync<LiveEventRecurring>();

        /// <summary>
        /// This method updates a live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <param name="parameters">The fields to update</param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> PatchSpecificLiveStreamAsync(int live_event_id, LiveParameters parameters = null) => RootAuthorization()
           .Command($"/live_events/{live_event_id}")
           .JsonPayload(parameters)
           .PatchAsync<LiveEventRecurring>();

        /// <summary>
        /// This method updates a live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <param name="parameters">The fields to update</param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> PatchMeSpecificLiveStreamAsync(int live_event_id, LiveParameters parameters = null) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}")
            .JsonPayload(parameters)
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
           .Command($"/users/{user_id}/live_events/{live_event_id}/privacy/domains")
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
          .Command($"/users/{user_id}/live_events/{live_event_id}/privacy/domains")
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
            .Command($"/live_events/{live_event_id}/activate")
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
            .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
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
           .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
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
           .FormUrlEncoded(new KeyValuePair<string, object>("active", active))
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
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <returns>The video representation consists of the following fields.</returns>
        public Task<RestResult<VimeoList<Video>>> GetAllTheVideosInALiveEvent(int user_id, int live_event_id) => RootAuthorization()
           .Command($"/users/{user_id}/live_events/{live_event_id}/videos")
           .GetAsync<VimeoList<Video>>();

        /// <summary>
        /// This method returns every video in the specified event.
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <returns>The video representation consists of the following fields.</returns>
        public Task<RestResult<VimeoList<Video>>> GetAllTheVideosInALiveEvent(int live_event_id) => RootAuthorization()
             .Command($"/live_events/{live_event_id}/videos")
             .GetAsync<VimeoList<Video>>();

        /// <summary>
        /// This method returns every video in the specified event.
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <returns>The video representation consists of the following fields.</returns>
        public Task<RestResult<VimeoList<Video>>> MeGetAllTheVideosInALiveEvent(int live_event_id) => RootAuthorization()
           .Command($"/me/live_events/{live_event_id}/videos")
           .GetAsync<VimeoList<Video>>();

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

        #region [ Event sessions ]

        /// <summary>
        /// This method returns the ingest status of the specified event and associated video.
        /// GET https://api.vimeo.com/live_events/{live_event_id}/session_status
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <param name="clip_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The ingest status was returned.
        /// </returns>
        public virtual Task<RestResult<LiveEventSessionStatus>> GetTheIngestStatusOfAnEventAsync(int live_event_id, int? clip_id = null) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/session_status")
            .OptionalParameter("clip_id", clip_id)
            .GetAsync<LiveEventSessionStatus>();

        #endregion

        #region [ Event destinations ]

        /// <summary>
        /// This method returns every available event destination for the authenticated user to stream to.
        /// The response is not documented by the specification: it is returned as raw JSON.
        /// GET https://api.vimeo.com/me/destinations
        /// </summary>
        /// <returns>
        /// 200 OK	The event destinations were returned.
        /// </returns>
        public virtual Task<RestResult<JsonElement>> GetAllTheAvailableEventDestinationsAsync() => RootAuthorization()
            .Command($"/me/destinations")
            .GetAsync<JsonElement>();

        /// <summary>
        /// This method returns every available event destination for the specified team owner to stream to.
        /// The response is not documented by the specification: it is returned as raw JSON.
        /// GET https://api.vimeo.com/users/{user_id}/destinations
        /// </summary>
        /// <param name="user_id">The user ID of the team owner.</param>
        /// <returns>
        /// 200 OK	The event destinations were returned.
        /// </returns>
        public virtual Task<RestResult<JsonElement>> GetAllTheAvailableEventDestinationsAsync(int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/destinations")
            .GetAsync<JsonElement>();

        /// <summary>
        /// This method returns the specified event destination belonging to the authenticated user.
        /// GET https://api.vimeo.com/destination/{destination_id}
        /// </summary>
        /// <param name="destination_id">The ID of the event destination.</param>
        /// <returns>
        /// 200 OK	The event destination was returned.
        /// </returns>
        public virtual Task<RestResult<LiveEventDestination>> GetAnEventDestinationAsync(long destination_id) => RootAuthorization()
            .Command($"/destination/{destination_id}")
            .GetAsync<LiveEventDestination>();

        /// <summary>
        /// This method updates the specified event destination belonging to the authenticated user.
        /// PATCH https://api.vimeo.com/destination/{destination_id}
        /// </summary>
        /// <param name="destination_id">The ID of the event destination.</param>
        /// <param name="display_name">The title to display for the simulcast.</param>
        /// <param name="is_enabled">Whether the destination is enabled for simulcasting.</param>
        /// <param name="privacy">The privacy setting of the destination: CONNECTIONS, PUBLIC, all_friends, everyone, private, public, self, unlisted.</param>
        /// <param name="provider_destination_id">The ID of the destination on the service, such as the YouTube channel ID or the Facebook page ID.</param>
        /// <param name="service_name">The service to simulcast to: custom_rtmp, facebook, linkedin, youtube.</param>
        /// <param name="stream_key">The RTMP stream key.</param>
        /// <param name="stream_url">The RTMP URL for receiving the video stream.</param>
        /// <param name="type">The type of the destination: channel, custom, organization, page, profile.</param>
        /// <returns>
        /// 200 OK	The event destination was updated.
        /// </returns>
        public virtual Task<RestResult<LiveEventDestination>> UpdateAnEventDestinationAsync(long destination_id,
            string display_name = null,
            bool? is_enabled = null,
            string privacy = null,
            string provider_destination_id = null,
            string service_name = null,
            string stream_key = null,
            string stream_url = null,
            string type = null) => RootAuthorization()
            .Command($"/destination/{destination_id}")
            .JsonPayload(new VimeoPayload()
                .Set("display_name", display_name)
                .Set("is_enabled", is_enabled)
                .Set("privacy", privacy)
                .Set("provider_destination_id", provider_destination_id)
                .Set("service_name", service_name)
                .Set("stream_key", stream_key)
                .Set("stream_url", stream_url)
                .Set("type", type))
            .PatchAsync<LiveEventDestination>();

        /// <summary>
        /// This method deletes the specified event destination belonging to the authenticated user.
        /// DELETE https://api.vimeo.com/destination/{destination_id}
        /// </summary>
        /// <param name="destination_id">The ID of the event destination.</param>
        /// <returns>
        /// 204 No Content	The event destination was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAnEventDestinationAsync(long destination_id) => RootAuthorization()
            .Command($"/destination/{destination_id}")
            .DeleteAsync();

        /// <summary>
        /// This method returns every OTT destination of the specified event. The authenticated user must be the owner of the event.
        /// GET https://api.vimeo.com/users/{user_id}/live_events/{live_event_id}/ott_destinations
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <returns>
        /// 200 OK	The OTT destinations were returned.
        /// </returns>
        public virtual Task<RestResult<VimeoList<OttDestination>>> GetAllTheOttDestinationsOfAnEventAsync(int user_id, int live_event_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/ott_destinations")
            .GetAsync<VimeoList<OttDestination>>();

        /// <summary>
        /// This method creates an OTT channel as the destination of the specified event. The authenticated user must be the owner of the event.
        /// The specification does not document the request body: pass the fields in <paramref name="body"/>.
        /// POST https://api.vimeo.com/users/{user_id}/live_events/{live_event_id}/ott_destinations
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <param name="body">The fields of the OTT destination, for example ott_channel_id.</param>
        /// <returns>
        /// 200 OK	The new OTT destination was created.
        /// </returns>
        public virtual Task<RestResult<OttDestination>> CreateAnOttDestinationForAnEventAsync(int user_id, int live_event_id, VimeoPayload body = null) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/ott_destinations")
            .JsonPayload(body)
            .PostAsync<OttDestination>();

        /// <summary>
        /// This method deletes an OTT channel as the destination of the specified event. The authenticated user must be the owner of the event.
        /// DELETE https://api.vimeo.com/users/{user_id}/live_events/{live_event_id}/ott_destination/{destination_id}
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <param name="destination_id">The ID of the OTT destination.</param>
        /// <returns>
        /// 204 No Content	The OTT destination was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAnOttDestinationOfAnEventAsync(int user_id, int live_event_id, string destination_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}/ott_destination/{destination_id}")
            .DeleteAsync();

        #endregion

        #region [ Graphics ]

        /// <summary>
        /// This method returns every video graphics item belonging to the specified event.
        /// GET https://api.vimeo.com/live_events/{live_event_id}/composer/graphics/videos
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <returns>
        /// 200 OK	The video graphic items were returned.
        /// </returns>
        public virtual Task<RestResult<VimeoList<ComposerGraphic>>> GetAllTheVideoGraphicsItemsOfAnEventAsync(int live_event_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/composer/graphics/videos")
            .GetAsync<VimeoList<ComposerGraphic>>();

        /// <summary>
        /// This method adds a new video graphics item to the specified event.
        /// POST https://api.vimeo.com/live_events/{live_event_id}/composer/graphics/videos
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <param name="video_id">The ID of the associated video.</param>
        /// <returns>
        /// 200 OK	The video graphic item was added.
        /// </returns>
        public virtual Task<RestResult<ComposerGraphic>> AddAVideoGraphicsItemToAnEventAsync(int live_event_id, long video_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/composer/graphics/videos")
            .JsonPayload(new VimeoPayload().Set("video_id", video_id))
            .PostAsync<ComposerGraphic>();

        /// <summary>
        /// This method deletes a video graphics item belonging to the specified event.
        /// DELETE https://api.vimeo.com/live_events/{live_event_id}/composer/graphics/videos/{video_id}
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <param name="video_id">The ID of the associated video.</param>
        /// <returns>
        /// 204 No Content	The video graphic item was deleted.
        /// </returns>
        public virtual Task<RestResult<string>> DeleteAVideoGraphicsItemFromAnEventAsync(int live_event_id, long video_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/composer/graphics/videos/{video_id}")
            .DeleteAsync();

        #endregion

        #region [ Scenes ]

        /// <summary>
        /// This method returns every scene belonging to the specified event.
        /// GET https://api.vimeo.com/live_events/{live_event_id}/composer/scenes
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <returns>
        /// 200 OK	The scenes were returned.
        /// </returns>
        public virtual Task<RestResult<VimeoList<ComposerScene>>> GetAllTheScenesOfAnEventAsync(int live_event_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/composer/scenes")
            .GetAsync<VimeoList<ComposerScene>>();

        /// <summary>
        /// This method creates a new scene for the specified event.
        /// POST https://api.vimeo.com/live_events/{live_event_id}/composer/scenes
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <param name="scene_type">The type of scene to create. Defaults to live.</param>
        /// <returns>
        /// 200 OK	The scene was created.
        /// </returns>
        public virtual Task<RestResult<ComposerScene>> CreateASceneForAnEventAsync(int live_event_id, string scene_type = null) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/composer/scenes")
            .JsonPayload(new VimeoPayload().Set("scene_type", scene_type))
            .PostAsync<ComposerScene>();

        /// <summary>
        /// This method updates a scene belonging to the specified event.
        /// The specification does not document the request body: pass the fields in <paramref name="body"/>.
        /// PATCH https://api.vimeo.com/live_events/{live_event_id}/composer/scenes/{scene_id}
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <param name="scene_id">The ID of the scene.</param>
        /// <param name="body">The fields of the scene to update.</param>
        /// <returns>
        /// 200 OK	The scene was returned.
        /// </returns>
        public virtual Task<RestResult<ComposerScene>> UpdateASceneOfAnEventAsync(int live_event_id, string scene_id, VimeoPayload body = null) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/composer/scenes/{scene_id}")
            .JsonPayload(body)
            .PatchAsync<ComposerScene>();

        /// <summary>
        /// This method attaches a graphic item to the specified scene.
        /// POST https://api.vimeo.com/live_events/{live_event_id}/composer/scenes/{scene_id}/graphics
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <param name="scene_id">The ID of the scene.</param>
        /// <param name="item">The content of the graphic item.</param>
        /// <returns>
        /// 200 OK	The scene was returned.
        /// </returns>
        public virtual Task<RestResult<ComposerScene>> AttachAGraphicItemToASceneAsync(int live_event_id, string scene_id, VimeoPayload item) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/composer/scenes/{scene_id}/graphics")
            .JsonPayload(new VimeoPayload().Set("item", item))
            .PostAsync<ComposerScene>();

        /// <summary>
        /// This method resets the scenes of the specified event by deleting every existing scene and then recreating the default scene.
        /// DELETE https://api.vimeo.com/live_events/{live_event_id}/composer/scenes
        /// </summary>
        /// <param name="live_event_id">The ID of the event.</param>
        /// <returns>
        /// 200 OK	The scenes were reset.
        /// </returns>
        public virtual Task<RestResult<VimeoList<ComposerScene>>> ResetTheScenesOfAnEventAsync(int live_event_id) => RootAuthorization()
            .Command($"/live_events/{live_event_id}/composer/scenes")
            .DeleteAsync<VimeoList<ComposerScene>>();

        #endregion
    }
}