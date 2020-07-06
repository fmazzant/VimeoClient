/// <summary>
/// 
/// The MIT License (MIT)
/// 
/// Copyright (c) 2020 Federico Mazzanti
/// 
/// Permission is hereby granted, free of charge, to any person
/// obtaining a copy of this software and associated documentation
/// files (the "Software"), to deal in the Software without
/// restriction, including without limitation the rights to use,
/// copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the
/// Software is furnished to do so, subject to the following
/// conditions:
/// 
/// The above copyright notice and this permission notice shall be
/// included in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
/// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
/// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
/// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
/// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
/// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
/// OTHER DEALINGS IN THE SOFTWARE.
/// 
/// </summary>

namespace VimeoClient.Common
{
    using RestClient;
    using RestClient.Generic;
    using System.Threading.Tasks;
    using VimeoClient.Model;

    /// <summary>
    /// Vimeo API Information
    /// https://developer.vimeo.com/api/reference/api-information
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
        public Task<RestResult<APIApp>> GetTheAPISpecificationAsync() => RootAuthorization
            .GetAsync<APIApp>();

        /// <summary>
        /// This method returns the full OpenAPI specification for the Vimeo API.
        /// </summary>
        /// <returns></returns>
        public RestResult<APIApp> GetTheAPISpecification() => GetTheAPISpecificationAsync().Result;
    }
}