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
    /// An embed preset is a reusable collection of settings for customizing the appearance and behavior of the embeddable Vimeo player. 
    /// This feature is available to Vimeo Pro, Business, and Premium members. 
    /// For more information, see our Help Center.
    /// https://developer.vimeo.com/api/reference/embed-presets
    /// </summary>
    public class VimeoEmbedPresets
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
        /// Create an instance of VimeoEmbedPresets
        /// </summary>
        /// <param name="properties">VimeoProperties</param>
        /// <param name="rootAuthorization">RestBuilder</param>
        public VimeoEmbedPresets(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ Essentials ]
        //Edit an embed preset
        //Get a specific embed preset
        //Get all the embed presets that a user has created
        #endregion

        #region [ Custom logos ]
        //Add a custom logo for the user
        //Get a specific custom logo for the user
        //Get all the custom logos that belong to the user
        #endregion

        #region [ Timeline events ]
        //Add a timeline event thumbnail to a video
        //Get a timeline event thumbnail
        #endregion

        #region [ Videos ]
        //Add an embed preset to a video
        //Check if an embed preset has been added to a video
        //Get all the videos that have a specific embed preset
        //Remove an embed preset from a video
        #endregion
    }
}