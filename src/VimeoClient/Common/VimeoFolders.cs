namespace VimeoClient.Common
{
    using RestClient;

    /// <summary>
    /// VimeoFolders
    /// </summary>
    public class VimeoFolders
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
        /// VimeoFolders
        /// </summary>
        /// <param name="properties">VimeoProperties</param>
        /// <param name="rootAuthorization">RestBuilder</param>
        public VimeoFolders(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essential ]
        //Create a folder
        //Delete a folder
        //Edit a folder
        //Get a specific folder
        //Get all the folders that belong to the user
        #endregion

        #region [ Videos ]
        //Add a list of videos to a folder
        //Add a specific video to a folder
        //Get all the videos in a folder
        //Remove a list of videos from a folder
        //Remove a specific video from a folder
        #endregion

    }
}