using RestClient;
using RestClient.Generic;
using VimeoClient.Response;

namespace VimeoClient.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class VimeoAPIInformation
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
        public VimeoAPIInformation(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            Properties = properties;
            RootAuthorization = rootAuthorization;
        }

        /// <summary>
        /// This method returns the full OpenAPI specification for the Vimeo API.
        /// </summary>
        /// <returns></returns>
        public RestResult<APIApp> GetTheAPISpecification() => RootAuthorization
            .Get<APIApp>();
    }
}