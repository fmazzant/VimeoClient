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

        internal Func<RestResult<Pagination<T>>> NextAction { get; set; }
        public RestResult<Pagination<T>> Next() => NextAction();

        internal Func<RestResult<Pagination<T>>> PreviousAction { get; set; }
        public RestResult<Pagination<T>> Previous() => PreviousAction();
    }

    public class Paging
    {
        public string next { get; set; }
        public string previous { get; set; }
        public string first { get; set; }
        public string last { get; set; }

        public bool IsSinglePage => first == last;
    }
}
