using RestClient;

namespace VimeoClient.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class VimeoGroups
    {
        /// <summary>
        /// 
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public RestBuilder RootAuthorization { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="rootAuthorization"></param>
        public VimeoGroups(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essentials ]
        //Create a group
        //Delete a group
        //Get a specific group
        //Get all groups
        #endregion

        #region [ Subscriptions ]
        //Add the user to a group
        //Remove the user from a group
        #endregion

        #region [ Users ]
        //Check if a user has joined a group
        //Get all the groups that the user has joined
        //Get all the members of a group
        #endregion

        #region [ Videos ]
        //Add a video to a group
        //Get a specific video in a group
        //Get all the videos in a group
        //Remove a video from a group
        #endregion
    }
}