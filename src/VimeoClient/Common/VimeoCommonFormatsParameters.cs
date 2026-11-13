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

namespace Mafesoft.VimeoClient
{
    using Mafesoft.RestClient;
    using System.Collections.Generic;
    using Mafesoft.VimeoClient.Response;

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
        /// <param name="command">The path of the request, for instance /me</param>
        /// <param name="fields">The fields to return</param>
        /// <returns>The response as a raw JSON string</returns>
        public virtual RestResult<string> FieldFiltering(string command, string[] fields) => RootAuthorization()
             .Command(command)
             .Parameter("fields", string.Join(",", fields))
             .Get();

        /// <summary>
        /// The fields parameter enables you to specify exactly which fields of a representation to return. 
        /// If the field doesn't appear among your choices, the API doesn't return it, which can speed up response time dramatically.
        /// -> GET https://api.vimeo.com/me?fields=uri,name,metadata.connections.albums
        /// this.FieldFiltering("/me", new string[]{ "uri", "name", "metadata", "connections", "albums"});
        /// </summary>
        /// <typeparam name="T">The type of the response</typeparam>
        /// <param name="command">The path of the request, for instance /me</param>
        /// <param name="fields">The fields to return</param>
        /// <returns>The response mapped to <typeparamref name="T"/></returns>
        public virtual RestResult<T> FieldFiltering<T>(string command, string[] fields) where T : new() => RootAuthorization()
             .Command(command)
             .Parameter("fields", string.Join(",", fields))
             .Get<T>();
        #endregion

        #region [ Using the sort and direction parameters ]

        /// <summary>
        /// Sorts the results of a list endpoint.
        /// -> GET https://api.vimeo.com/me/videos?sort=date&amp;direction=asc
        /// this.SortAndDirection&lt;Pagination&lt;Video&gt;&gt;("/me/videos", "date", "asc");
        /// </summary>
        /// <typeparam name="T">The response's type</typeparam>
        /// <param name="command">The endpoint, for instance /me/videos</param>
        /// <param name="sort">The way to sort the results (an enum value or a string)</param>
        /// <param name="direction">The sort direction of the results: asc or desc</param>
        /// <returns></returns>
        public virtual RestResult<T> SortAndDirection<T>(string command, object sort, object direction = null) where T : new() => RootAuthorization()
            .Command(command)
            .OptionalParameter("sort", sort)
            .OptionalParameter("direction", direction)
            .Get<T>();

        #endregion

        #region [ Using the filter parameter ]

        /// <summary>
        /// Filters the results of a list endpoint.
        /// -> GET https://api.vimeo.com/channels?filter=featured
        /// this.Filter&lt;Pagination&lt;Channel&gt;&gt;("/channels", "featured");
        /// </summary>
        /// <typeparam name="T">The response's type</typeparam>
        /// <param name="command">The endpoint, for instance /channels</param>
        /// <param name="filter">The attribute by which to filter the results (an enum value or a string)</param>
        /// <returns></returns>
        public virtual RestResult<T> Filter<T>(string command, object filter) where T : new() => RootAuthorization()
            .Command(command)
            .OptionalParameter("filter", filter)
            .Get<T>();

        #endregion

        #region [ Using the page and per_page parameters ]

        /// <summary>
        /// Returns a page of a list endpoint with Next() and Previous() navigation.
        /// -> GET https://api.vimeo.com/videos/174560759/pictures?page=3
        /// this.Page&lt;Picture&gt;("/videos/174560759/pictures", 3);
        /// </summary>
        /// <typeparam name="T">The item's type</typeparam>
        /// <param name="command">The endpoint, for instance /videos/174560759/pictures</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns></returns>
        public virtual RestResult<Pagination<T>> Page<T>(string command, int? page = null, int? per_page = null) => RootAuthorization()
            .Command(command)
            .ListParameters(page: page, per_page: per_page)
            .GetPagination<T>(RootAuthorization);

        #endregion

        #region [ Using the sizes parameter ]

        /// <summary>
        /// Requests only specific picture sizes.
        /// -> GET https://api.vimeo.com/videos/174560759?sizes=640x480,100x100
        /// this.Sizes&lt;Video&gt;("/videos/174560759", "640x480", "100x100");
        /// </summary>
        /// <typeparam name="T">The response's type</typeparam>
        /// <param name="command">The endpoint, for instance /videos/174560759</param>
        /// <param name="sizes">The sizes in the format WIDTHxHEIGHT</param>
        /// <returns></returns>
        public virtual RestResult<T> Sizes<T>(string command, params string[] sizes) where T : new() => RootAuthorization()
            .Command(command)
            .OptionalParameter("sizes", sizes)
            .Get<T>();

        #endregion

        #region [ Working with batch requests ]

        /// <summary>
        /// Sends a batch request: a JSON array of objects in a single PUT.
        /// -> PUT https://api.vimeo.com/videos/174560759/categories
        /// [ { "category": "animation" }, { "category": "talks" } ]
        /// this.Batch("/videos/174560759/categories", new VimeoPayload().Set("category", "animation"), new VimeoPayload().Set("category", "talks"));
        /// </summary>
        /// <param name="command">The endpoint, for instance /videos/174560759/categories</param>
        /// <param name="items">The objects of the batch</param>
        /// <returns></returns>
        public virtual RestResult<string> Batch(string command, params VimeoPayload[] items) => RootAuthorization()
            .Command(command)
            .Payload<Dictionary<string, object>[]>(items)
            .Put();

        #endregion
    }
}