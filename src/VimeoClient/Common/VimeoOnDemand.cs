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
    /// On Demand
    /// </summary>
    public class VimeoOnDemand
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
        /// Vimeo On Demand
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="rootAuthorization"></param>
        public VimeoOnDemand(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essentials ]
        //Create an On Demand page
        //Delete an On Demand page
        //Edit an On Demand page
        //Get a specific On Demand page
        //Get all the On Demand pages of the user
        #endregion

        #region [ Backgrounds ]
        //Add a background to an On Demand page
        //Delete a background on an On Demand page
        //Edit a background on an On Demand page
        //Get a specific background on an On Demand page
        //Get all the backgrounds on an On Demand page
        #endregion

        #region [ Genres ]
        //Add a genre to an On Demand page
        //Check whether an On Demand page belongs to a specific genre
        //Get a specific On Demand genre
        //Get a specific On Demand page in a genre
        //Get all On Demand genres
        //Get all the On Demand pages in a genre
        //Get all the genres of an On Demand page
        //Remove a genre from an On Demand page
        #endregion

        #region [ Posters ]
        //Add a poster to an On Demand page
        //Edit a poster on an On Demand page
        //Get a specific poster on an On Demand page
        //Get all the posters on an On Demand page
        #endregion

        #region [ Promotions ]
        //Add a promotion to an On Demand page
        //Delete a promotion on an On Demand page
        //Get a specific promotion on an On Demand page
        //Get all the codes of a promotion on an On Demand page
        //Get all the promotions on an On Demand page
        #endregion

        #region [ Purchases and rentals ]
        //Get all the On Demand purchases and rentals that the user has made
        #endregion

        #region [ Regions ]
        //Add a list of regions to an On Demand page
        //Add a specific region to an On Demand page
        //Get a specific On Demand region
        //Get a specific region on an On Demand page
        //Get all the On Demand regions
        //Get all the regions on an On Demand page
        //Remove a list of regions from an On Demand page
        //Remove a specific region from an On Demand page
        #endregion

        #region [ Seasons ]
        //Get a specific season on an On Demand page
        //Get all the seasons on an On Demand page
        //Get all the videos in a season on an On Demand page
        #endregion

        #region [ Videos ]
        //Add a video to an On Demand page
        //Get a specific video on an On Demand page
        //Get all the videos on an On Demand page
        //Remove a video from an On Demand page
        #endregion
    }
}