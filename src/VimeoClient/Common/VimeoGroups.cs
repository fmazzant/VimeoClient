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
    /// A group is a community within Vimeo for collaborating, sharing, and engaging with videos. 
    /// Groups can be public, where anyone can join, or they can be private, where membership is by invitation only. 
    /// For more information, see our Help Center.
    /// https://developer.vimeo.com/api/reference/groups
    /// </summary>
    public class VimeoGroups
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
        public VimeoGroups(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoGroups(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]
        //Create a group
        //Delete a group
        //Get a specific group
        //Get all groups
        #endregion

        #region [ Subscriptions ]
        //Add the user to a group
        //Remove the user from a group
        #endregion

        #region [ Users ]
        //Check if a user has joined a group
        //Get all the groups that the user has joined
        //Get all the members of a group
        #endregion

        #region [ Videos ]
        //Add a video to a group
        //Get a specific video in a group
        //Get all the videos in a group
        //Remove a video from a group
        #endregion
    }
}