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
        public Task<RestResult<LiveEventRecurring>> CreateALiveEvent(int user_id, LiveParameters parameters) => RootAuthorization()
            .Command($"/users/{user_id}/live_events")
            .Payload(parameters)
            .PostAsync<LiveEventRecurring>();

        /// <summary>
        /// This method creates a new live event for the authenticated user.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> CreateALiveEvent(LiveParameters parameters) => RootAuthorization()
           .Command($"/me/live_events")
           .Payload(parameters)
           .PostAsync<LiveEventRecurring>();

        /// <summary>
        /// This method deletes multiple live events belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteListOfLiveEvents(int user_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events")
            .DeleteAsync();

        /// <summary>
        /// This method deletes multiple live events belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteListOfLiveEvents() => RootAuthorization()
           .Command($"/live_events")
           .DeleteAsync();

        /// <summary>
        /// This method deletes multiple live events belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteMeListOfLiveEvents() => RootAuthorization()
           .Command($"/me/live_events")
           .DeleteAsync();

        /// <summary>
        /// This method deletes a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteSpecificLiveEvent(int user_id, int live_event_id) => RootAuthorization()
            .Command($"/users/{user_id}/live_events/{live_event_id}")
            .DeleteAsync();

        /// <summary>
        /// This method deletes a single live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<string>> DeleteSpecificLiveEvent(int live_event_id) => RootAuthorization()
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
        public Task<RestResult<LiveEventRecurring>> GetSpecificLiveStream(int user_id, int live_event_id) => RootAuthorization()
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
        public Task<RestResult<LiveEventRecurring>> GetMeSpecificLiveStream(int live_event_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}")
            .GetAsync<LiveEventRecurring>();


        /// <summary>
        /// The method returns every live event belonging to the authenticated user.
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEvent>> GetAllTheLiveEvents(int user_id,
            LiveDirection? direction = null,
            LiveFilter? filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            LiveSort? sort = null,
            LiveType? type = null) => RootAuthorization()
            .Command($"/users/{user_id}/live_events")
            .GetAsync<LiveEvent>();

        /// <summary>
        /// The method returns every live event belonging to the authenticated user.
        /// </summary>
        /// <returns></returns>
        public Task<RestResult<LiveEvent>> GetAllTheLiveEvents(
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
        public Task<RestResult<LiveEvent>> GetMeAllTheLiveEvents(
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
        public Task<RestResult<LiveEventRecurring>> PatchSpecificLiveStream(int user_id, int live_event_id) => RootAuthorization()
           .Command($"/{user_id}/live_events/{live_event_id}")
           .PatchAsync<LiveEventRecurring>();

        /// <summary>
        /// This method updates a live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> PatchSpecificLiveStream(int live_event_id) => RootAuthorization()
           .Command($"/live_events/{live_event_id}")
           .PatchAsync<LiveEventRecurring>();

        /// <summary>
        /// This method updates a live event belonging to the authenticated user.
        /// </summary>
        /// <param name="live_event_id"></param>
        /// <returns></returns>
        public Task<RestResult<LiveEventRecurring>> PatchMeSpecificLiveStream(int live_event_id) => RootAuthorization()
            .Command($"/me/live_events/{live_event_id}")
            .PatchAsync<LiveEventRecurring>();

        #endregion

        #region [ Embed privacy ]
        //Embed a recurring live event on one or more domains
        //Get all the domains on which a recurring live event can be embedded
        #endregion

        #region [ Event activation ]
        //Activate a live event
        #endregion

        #region [ Event M3U8 playback ]
        //Get an M3U8 playback URL for a recurring live event
        #endregion

        #region [ Event thumbnails ]
        //Create a live event thumbnail
        //Delete a live event thumbnail
        //Edit a live event thumbnail
        //Get a specific live event thumbnail
        //Get all the thumbnails of a live event
        #endregion

        #region [ Event videos ]
        //Add a list of videos to a live event
        //Get a specific video in a live event
        //Get all the videos in a live event
        //Remove a list of videos from a live event
        #endregion
    }
}