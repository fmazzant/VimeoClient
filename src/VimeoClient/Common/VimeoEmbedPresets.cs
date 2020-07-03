namespace VimeoClient.Common
{
    using RestClient;

    /// <summary>
    /// Vimeo Embed Presets
    /// </summary>
    public class VimeoEmbedPresets
    {
        /// <summary>
        /// Properties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// Root Authorization
        /// </summary>
        public RestBuilder RootAuthorization { get; private set; }

        /// <summary>
        /// Create an instance of VimeoEmbedPresets
        /// </summary>
        /// <param name="properties">VimeoProperties</param>
        /// <param name="rootAuthorization">RestBuilder</param>
        public VimeoEmbedPresets(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essentials ]
        //Edit an embed preset
        //Get a specific embed preset
        //Get all the embed presets that a user has created
        #endregion

        #region [ Custom logos ]
        //Add a custom logo for the user
        //Get a specific custom logo for the user
        //Get all the custom logos that belong to the user
        #endregion

        #region [ Timeline events ]
        //Add a timeline event thumbnail to a video
        //Get a timeline event thumbnail
        #endregion

        #region [ Videos ]
        //Add an embed preset to a video
        //Check if an embed preset has been added to a video
        //Get all the videos that have a specific embed preset
        //Remove an embed preset from a video
        #endregion
    }
}