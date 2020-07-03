namespace VimeoClient.Common
{
    using RestClient;

    /// <summary>
    /// VimeoLive
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