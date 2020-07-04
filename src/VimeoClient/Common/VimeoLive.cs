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

    /// <summary>
    /// Please note that Vimeo's live API is available only to Vimeo Enterprise customers. 
    /// https://developer.vimeo.com/api/reference/live
    /// Learn more about Vimeo Enterprise.
    /// </summary>
    public class VimeoLive
    {
        /// <summary>
        /// VimeoProperties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// RestBuilder
        /// </summary>
        public RestBuilder RootAuthorization { get; private set; }

        /// <summary>
        /// VimeoLive
        /// </summary>
        /// <param name="properties">VimeoProperties</param>
        /// <param name="rootAuthorization">RestBuilder</param>
        public VimeoLive(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essentials ]
        //Create a live event
        //Delete a list of live events
        //Delete a specific live event
        //Get a specific live event
        //Get all the live events that belong to the user
        //Update a live event
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