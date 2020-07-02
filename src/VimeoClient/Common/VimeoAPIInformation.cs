using RestClient;
using RestClient.Generic;
using VimeoClient.Response;

namespace VimeoClient.Common
{
    /// <summary>
    /// Vimeo API Information
    /// </summary>
    public class VimeoAPIInformation
    {
        /// <summary>
        /// Vimeo Properties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// Root Authorization
        /// </summary>
        public RestBuilder RootAuthorization { get; private set; }

        /// <summary>
        /// Create a new instance of VimeoAPIInformation class
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