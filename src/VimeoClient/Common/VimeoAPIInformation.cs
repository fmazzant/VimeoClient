using RestClient.Generic;
using VimeoClient.Response;

namespace VimeoClient.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class VimeoAPIInformation : Vimeo
    {
        public VimeoAPIInformation(VimeoProperties properties)
               : base(properties) { }


        /// <summary>
        /// This method returns the full OpenAPI specification for the Vimeo API.
        /// </summary>
        /// <returns></returns>
        public RestResult<APIApp> GetTheAPISpecification() => RootAuthorization()
            .Get<APIApp>();
    }
}