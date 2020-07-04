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

    /// <summary>
    /// Portfolios are customizable websites for showcasing videos.
    /// Vimeo Pro, Business, and Premium subscribers have access to this feature.For more information, see our Help Center.
    /// https://developer.vimeo.com/api/reference/portfolios
    /// </summary>
    public class VimeoPortfolios
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
        /// Portfolios are customizable websites for showcasing videos. 
        /// Vimeo Pro, Business, and Premium subscribers have access to this feature.For more information, see our Help Center.
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="rootAuthorization"></param>
        public VimeoPortfolios(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essentials ]
        //Get a specific portfolio
        //Get all the portfolios that belong to the user
        #endregion

        #region [ Videos ]
        //Add a video to a portfolio
        //Get a specific video in a portfolio
        //Get all the videos in a portfolio
        //Remove a video from a portfolio
        #endregion
    }
}