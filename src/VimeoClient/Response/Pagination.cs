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

namespace VimeoClient.Response
{
    using RestClient.Generic;
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a vimeo list of entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VimeoList<T>
    {
        /// <summary>
        /// total of entities
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// data
        /// </summary>
        [JsonPropertyName("data")]
        public T[] Data { get; set; }
    }

    /// <summary>
    /// Represents a pagination list of entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
        /// <returns></returns>
        public RestResult<Pagination<T>> Next() => NextAction();

        /// <summary>
        /// Previous Action
        /// </summary>
        internal Func<RestResult<Pagination<T>>> PreviousAction { get; set; } = new Func<RestResult<Pagination<T>>>(() => { return null; });

        /// <summary>
        /// Go to previuous oage if it is existes
        /// </summary>
        /// <returns></returns>
        public RestResult<Pagination<T>> Previous() => PreviousAction();
    }

    /// <summary>
    /// Paging relationship
    /// </summary>
    public class Paging
    {
        /// <summary>
        /// uri next page
        /// </summary>
        [JsonPropertyName("next")]
        public string Next { get; set; }

        /// <summary>
        /// uri previous page
        /// </summary>
        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        /// <summary>
        /// uri first page
        /// </summary>
        [JsonPropertyName("first")]
        public string First { get; set; }

        /// <summary>
        /// uri last page
        /// </summary>
        [JsonPropertyName("last")]
        public string Last { get; set; }

        /// <summary>
        /// true if exists a single page, false otherwise
        /// </summary>
        public bool IsSinglePage => First == Last;
    }
}
