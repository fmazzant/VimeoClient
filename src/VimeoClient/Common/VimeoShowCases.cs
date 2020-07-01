﻿using RestClient;

namespace VimeoClient.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class VimeoShowCases
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
        public VimeoShowCases(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }
    }
}