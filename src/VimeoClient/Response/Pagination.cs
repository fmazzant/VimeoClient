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

namespace Mafesoft.VimeoClient.Response
{
    using Mafesoft.RestClient;
    using System;
    using System.Collections.Generic;
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
    using System.Runtime.CompilerServices;
#endif
    using System.Text.Json.Serialization;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a pagination list of entities.
    /// Call <see cref="Next"/> and <see cref="Previous"/> (or <see cref="NextAsync"/> and <see cref="PreviousAsync"/>)
    /// to load the other pages, or <see cref="GetAllItems"/> to read the items of this page and of all the next pages.
    /// </summary>
    /// <typeparam name="T">The type of the entities of the list</typeparam>
    public class Pagination<T>
    {
        /// <summary>
        /// total elements
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// current page
        /// </summary>
        [JsonPropertyName("page")]
        public int Page { get; set; }

        /// <summary>
        /// Element per page
        /// </summary>
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        /// <summary>
        /// Paging
        /// </summary>
        [JsonPropertyName("paging")]
        public Paging Paging { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        [JsonPropertyName("data")]
        public List<T> Data { get; set; }

        /// <summary>
        /// Next Action
        /// </summary>
        internal Func<RestResult<Pagination<T>>> NextAction { get; set; } = new Func<RestResult<Pagination<T>>>(() => { return null; });

        /// <summary>
        /// Go to Next page if it is exists
        /// </summary>
        /// <returns>The next page, or null when this is the last page.</returns>
        public RestResult<Pagination<T>> Next() => NextAction();

        /// <summary>
        /// Next Action, asynchronous
        /// </summary>
        internal Func<CancellationToken, Task<RestResult<Pagination<T>>>> NextAsyncAction { get; set; } = (cancellationToken) => Task.FromResult<RestResult<Pagination<T>>>(null);

        /// <summary>
        /// Loads the next page asynchronously, if it exists.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The next page, or null when this is the last page.</returns>
        public Task<RestResult<Pagination<T>>> NextAsync(CancellationToken cancellationToken = default) => NextAsyncAction(cancellationToken);

        /// <summary>
        /// Previous Action
        /// </summary>
        internal Func<RestResult<Pagination<T>>> PreviousAction { get; set; } = new Func<RestResult<Pagination<T>>>(() => { return null; });

        /// <summary>
        /// Go to previuous oage if it is existes
        /// </summary>
        /// <returns>The previous page, or null when this is the first page.</returns>
        public RestResult<Pagination<T>> Previous() => PreviousAction();

        /// <summary>
        /// Previous Action, asynchronous
        /// </summary>
        internal Func<CancellationToken, Task<RestResult<Pagination<T>>>> PreviousAsyncAction { get; set; } = (cancellationToken) => Task.FromResult<RestResult<Pagination<T>>>(null);

        /// <summary>
        /// Loads the previous page asynchronously, if it exists.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The previous page, or null when this is the first page.</returns>
        public Task<RestResult<Pagination<T>>> PreviousAsync(CancellationToken cancellationToken = default) => PreviousAsyncAction(cancellationToken);

        /// <summary>
        /// Returns the items of this page and of all the next pages.
        /// The next pages are loaded one at a time while the items are enumerated.
        /// </summary>
        /// <returns>The items of this page and of the next pages.</returns>
        /// <exception cref="Exception">A next page could not be loaded (see <see cref="RestResult.EnsureSuccessStatusCode"/>).</exception>
        public IEnumerable<T> GetAllItems()
        {
            var page = this;
            while (page != null)
            {
                foreach (var item in page.Data ?? new List<T>())
                {
                    yield return item;
                }

                var next = page.Next();
                page = next?.EnsureSuccessStatusCode().Content;
            }
        }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        /// <summary>
        /// Returns the items of this page and of all the next pages, to read with <c>await foreach</c>.
        /// The next pages are loaded asynchronously one at a time while the items are enumerated.
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the requests of the next pages.</param>
        /// <returns>The items of this page and of the next pages.</returns>
        /// <exception cref="Exception">A next page could not be loaded (see <see cref="RestResult.EnsureSuccessStatusCode"/>).</exception>
        public async IAsyncEnumerable<T> GetAllItemsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var page = this;
            while (page != null)
            {
                foreach (var item in page.Data ?? new List<T>())
                {
                    yield return item;
                }

                cancellationToken.ThrowIfCancellationRequested();
                var next = await page.NextAsync(cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                page = next?.EnsureSuccessStatusCode().Content;
            }
        }
#endif
    }
}
