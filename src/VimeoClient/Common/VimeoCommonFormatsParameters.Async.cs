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
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoCommonFormatsParameters.
    public partial class VimeoCommonFormatsParameters
    {
        #region [ Use field filtering ]

        /// <summary>
        /// The fields parameter enables you to specify exactly which fields of a representation to return. 
        /// If the field doesn't appear among your choices, the API doesn't return it, which can speed up response time dramatically.
        /// -> GET https://api.vimeo.com/me?fields=uri,name,metadata.connections.albums
        /// this.FieldFiltering("/me", new string[]{ "uri", "name", "metadata", "connections", "albums"});
        /// </summary>
        /// <param name="command">The path of the request, for instance /me</param>
        /// <param name="fields">The fields to return</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The response as a raw JSON string</returns>
        public virtual Task<RestResult<string>> FieldFilteringAsync(string command, string[] fields, CancellationToken cancellationToken = default) => RootAuthorization()
             .Command(command)
             .Parameter("fields", string.Join(",", fields))
             .GetAsync(cancellationToken);

        /// <summary>
        /// The fields parameter enables you to specify exactly which fields of a representation to return. 
        /// If the field doesn't appear among your choices, the API doesn't return it, which can speed up response time dramatically.
        /// -> GET https://api.vimeo.com/me?fields=uri,name,metadata.connections.albums
        /// this.FieldFiltering("/me", new string[]{ "uri", "name", "metadata", "connections", "albums"});
        /// </summary>
        /// <typeparam name="T">The type of the response</typeparam>
        /// <param name="command">The path of the request, for instance /me</param>
        /// <param name="fields">The fields to return</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The response mapped to <typeparamref name="T"/></returns>
        public virtual Task<RestResult<T>> FieldFilteringAsync<T>(string command, string[] fields, CancellationToken cancellationToken = default) where T : new() => RootAuthorization()
             .Command(command)
             .Parameter("fields", string.Join(",", fields))
             .GetAsync<T>(cancellationToken);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<T>> SortAndDirectionAsync<T>(string command, object sort, object direction = null, CancellationToken cancellationToken = default) where T : new() => RootAuthorization()
            .Command(command)
            .OptionalParameter("sort", sort)
            .OptionalParameter("direction", direction)
            .GetAsync<T>(cancellationToken);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<T>> FilterAsync<T>(string command, object filter, CancellationToken cancellationToken = default) where T : new() => RootAuthorization()
            .Command(command)
            .OptionalParameter("filter", filter)
            .GetAsync<T>(cancellationToken);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<Pagination<T>>> PageAsync<T>(string command, int? page = null, int? per_page = null, CancellationToken cancellationToken = default) => RootAuthorization()
            .Command(command)
            .ListParameters(page: page, per_page: per_page)
            .GetPaginationAsync<T>(RootAuthorization, cancellationToken);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<T>> SizesAsync<T>(string command, string[] sizes, CancellationToken cancellationToken) where T : new() => RootAuthorization()
            .Command(command)
            .OptionalParameter("sizes", sizes)
            .GetAsync<T>(cancellationToken);

        /// <summary>
        /// Requests only specific picture sizes.
        /// -> GET https://api.vimeo.com/videos/174560759?sizes=640x480,100x100
        /// this.Sizes&lt;Video&gt;("/videos/174560759", "640x480", "100x100");
        /// </summary>
        /// <typeparam name="T">The response's type</typeparam>
        /// <param name="command">The endpoint, for instance /videos/174560759</param>
        /// <param name="sizes">The sizes in the format WIDTHxHEIGHT</param>
        /// <returns></returns>
        public virtual Task<RestResult<T>> SizesAsync<T>(string command, params string[] sizes) where T : new() => SizesAsync<T>(command, sizes, CancellationToken.None);

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
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> BatchAsync(string command, VimeoPayload[] items, CancellationToken cancellationToken) => RootAuthorization()
            .Command(command)
            .Payload<Dictionary<string, object>[]>(items)
            .PutAsync(cancellationToken);

        /// <summary>
        /// Sends a batch request: a JSON array of objects in a single PUT.
        /// -> PUT https://api.vimeo.com/videos/174560759/categories
        /// [ { "category": "animation" }, { "category": "talks" } ]
        /// this.Batch("/videos/174560759/categories", new VimeoPayload().Set("category", "animation"), new VimeoPayload().Set("category", "talks"));
        /// </summary>
        /// <param name="command">The endpoint, for instance /videos/174560759/categories</param>
        /// <param name="items">The objects of the batch</param>
        /// <returns></returns>
        public virtual Task<RestResult<string>> BatchAsync(string command, params VimeoPayload[] items) => BatchAsync(command, items, CancellationToken.None);

        #endregion
    }
}
