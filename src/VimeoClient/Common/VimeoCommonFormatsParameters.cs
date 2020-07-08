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

namespace VimeoClient
{
    using RestClient;
    using RestClient.Generic;

    /// <summary>
    /// Field filtering is a technique where you request only specific fields of a JSON representation instead of the entire representation. 
    /// We like field filtering so much that we double the normal rate-limiting quota on any API request that uses it.
    /// https://developer.vimeo.com/guidelines/rate-limiting
    /// https://developer.vimeo.com/api/common-formats#json-filter
    /// </summary>
    public class VimeoCommonFormatsParameters
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
        public VimeoCommonFormatsParameters(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoCommonFormatsParameters(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Use field filtering ]
        /// <summary>
        /// The fields parameter enables you to specify exactly which fields of a representation to return. 
        /// If the field doesn't appear among your choices, the API doesn't return it, which can speed up response time dramatically.
        /// -> GET https://api.vimeo.com/me?fields=uri,name,metadata.connections.albums
        /// this.FieldFiltering("/me", new string[]{ "uri", "name", "metadata", "connections", "albums"});
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public RestResult<string> FieldFiltering(string command, string[] fields) => RootAuthorization()
             .Command(command)
             .Parameter("fields", string.Join(",", fields))
             .Get();

        /// <summary>
        /// The fields parameter enables you to specify exactly which fields of a representation to return. 
        /// If the field doesn't appear among your choices, the API doesn't return it, which can speed up response time dramatically.
        /// -> GET https://api.vimeo.com/me?fields=uri,name,metadata.connections.albums
        /// this.FieldFiltering("/me", new string[]{ "uri", "name", "metadata", "connections", "albums"});
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public RestResult<T> FieldFiltering<T>(string command, string[] fields) where T : new() => RootAuthorization()
             .Command(command)
             .Parameter("fields", string.Join(",", fields))
             .Get<T>();
        #endregion

        #region [ Using the sort and direction parameters ]
        //GET https://api.vimeo.com/me/videos?sort=date&direction=asc
        #endregion

        #region [ Using the filter parameter ]
        //GET https://api.vimeo.com/channels?filter=featured
        #endregion

        #region [ Using the page and per_page parameters ]
        //GET https://api.vimeo.com/videos/174560759/pictures?page=3
        #endregion

        #region [ Using the sizes parameter ]
        //GET https://api.vimeo.com/videos/174560759?sizes=640x480,100x100
        #endregion

        #region [ Working with batch requests ]
        //PUT https://api.vimeo.com/videos/174560759/categories
        //[
        //  { "category": "animation" },
        //  { "category": "talks" }
        //]
        #endregion
    }
}