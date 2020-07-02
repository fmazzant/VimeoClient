namespace VimeoClient.Common
{
    using RestClient;
    using RestClient.Generic;
    using System;
    using VimeoClient.Filter.Channel;
    using VimeoClient.Parameter.Channel;

    /// <summary>
    /// 
    /// </summary>
    public class VimeoChannels
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
        public VimeoChannels(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essential ]

        /// <summary>
        /// This method creates a new channel.
        /// </summary>
        /// <param name="name">The name of the channel.</param>
        /// <param name="privacy">
        /// The privacy level of the channel.
        /// Option descriptions:
        ///     anybody - Anyone can access the channel.
        ///     moderators - Only moderators can access the channel.
        ///     user - Only moderators and designated users can access the channel.
        /// </param>
        /// <param name="description"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public RestResult<string> CreateAChannel(ChannelEditParameters obj)
            => RootAuthorization
            .Command($"/channels")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                foreach (var item in obj.ToEnumerable())
                    pars.Add(item.Key, item.Value);
            })
            .Post();

        public RestResult<string> DeleteAChannel(int channel_id) => throw new NotImplementedException();

        public RestResult<string> EditAChannel(int channel_id, ChannelEditParameters pars) => throw new NotImplementedException();

        public RestResult<string> GetASpecificChannel(int channel_id) => throw new NotImplementedException();

        public RestResult<string> GetAllChannels(ChannelDirection direction,
            ChannelFilter filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSort? sort = null) => throw new NotImplementedException();

        public RestResult<string> GetAllTheChannelsToWhichAUserSubscribes(int user_id,
            ChannelDirection direction,
            ChannelFilter filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSort? sort = null) => throw new NotImplementedException();

        public RestResult<string> GetAllTheChannelsToWhichAUserSubscribes(ChannelDirection direction,
            ChannelFilter filter,
            int? page = null,
            int? per_page = null,
            string query = null,
            ChannelSort? sort = null) => throw new NotImplementedException();

        #endregion

        #region [Categories]

        #endregion

        #region [ Moderators]

        #endregion

        #region [ Private channel members]

        #endregion

        #region [ Subscriptions and subscribers]

        #endregion

        #region [ Tags]

        #endregion

        #region [ Videos]

        #endregion

    }
}