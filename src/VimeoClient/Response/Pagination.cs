namespace VimeoClient.Response
{
    using RestClient.Generic;
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class VimeoList<T>
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("data")]
        public T[] Data { get; set; }
    }

    public class Pagination<T>
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("paging")]
        public Paging Paging { get; set; }

        [JsonPropertyName("data")]
        public List<T> Data { get; set; }

        internal Func<RestResult<Pagination<T>>> NextAction { get; set; } = new Func<RestResult<Pagination<T>>>(() => { return null; });
        public RestResult<Pagination<T>> Next() => NextAction();

        internal Func<RestResult<Pagination<T>>> PreviousAction { get; set; } = new Func<RestResult<Pagination<T>>>(() => { return null; });
        public RestResult<Pagination<T>> Previous() => PreviousAction();
    }

    public class Paging
    {
        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }

        public bool IsSinglePage => First == Last;
    }
}
