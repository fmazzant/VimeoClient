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
    /// A showcase (previously album) is a collection of videos for public or private sharing. 
    /// When developing for this feature, keep in mind that our endpoint syntax uses the original album nomenclature, although this is subject to change in the future. 
    /// For more information about showcases, see our Help Center.
    /// https://developer.vimeo.com/api/reference/showcases
    /// </summary>
    public class VimeoShowCases
    {
        /// <summary>
        /// Vimeo Properties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// Vimeo
        /// </summary>
        public Vimeo Vimeo { get; private set; }

        /// <summary>
        /// Root Authorization
        /// </summary>
        public RestBuilder RootAuthorization() => Vimeo.RootAuthorization();

        /// <summary>
        /// Create a new instance of VimeoCategories class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoShowCases(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoShowCases(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]
        //Create a showcase
        //Delete a showcase
        //Edit a showcase
        //Get a specific showcase
        //Get all the showcases that belong to the user
        #endregion

        #region [  Custom showcase logos ]
        //Add a custom logo to a showcase
        //Delete a custom showcase logo
        //Get a specific custom showcase logo
        //Get all the custom logos of a showcase
        //Replace a custom showcase logo
        #endregion

        #region [ Custom showcase thumbnails ]
        //Add a custom thumbnail to a showcase
        //Delete a custom showcase thumbnail
        //Get a specific custom showcase thumbnail
        //Get all the custom thumbnails of a showcase
        //Replace a custom showcase thumbnail
        #endregion

        #region [  Showcase videos ]
        //Add a specific video to a showcase
        //Create a thumbnail for a showcase from a showcase video
        //Get a specific video in a showcase
        //Get all the showcases to which the user can add or remove a specific video
        //Get all the user's videos that can be added to or removed from a showcase
        //Get all the videos in a showcase
        //Remove a video from a showcase
        //Replace all the videos in a showcase
        //Set the featured video of a showcase
        #endregion
    }
}