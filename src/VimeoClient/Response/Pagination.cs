namespace VimeoClient.Response
{
    using RestClient.Generic;
    using System;
    using System.Collections.Generic;

    public class Pagination<T>
    {
        public int total { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public Paging paging { get; set; }
        public List<T> data { get; set; }

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
