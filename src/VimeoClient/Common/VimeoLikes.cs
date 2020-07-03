namespace VimeoClient.Common
{
    using RestClient;

    /// <summary>
    /// VimeoLikes
    /// </summary>
    public class VimeoLikes
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
        /// VimeoLikes
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="rootAuthorization"></param>
        public VimeoLikes(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essential ]
        //Cause a user to unlike a video
        //Cause the user to like a video
        //Check if the user has liked a video
        //Get all the users who have liked a video
        //Get all the users who have liked a video on an On Demand page
        //Get all the videos that a user has liked
        #endregion
    }
}