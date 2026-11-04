namespace VimeoClient.Tests.Infrastructure
{
    using RestClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A request captured by <see cref="FakeHttpHandler"/>.
    /// </summary>
    public sealed class CapturedRequest
    {
        public HttpMethod Method { get; init; }
        public Uri Uri { get; init; }
        public string Body { get; init; }
        public string ContentType { get; init; }
        public string Authorization { get; init; }
        public string Accept { get; init; }

        /// <summary>The path of the request, without the query string.</summary>
        public string Path => Uri.AbsolutePath;

        /// <summary>The query string parameters, decoded.</summary>
        public Dictionary<string, string> Query => Uri.Query.TrimStart('?')
            .Split('&', StringSplitOptions.RemoveEmptyEntries)
            .Select(p => p.Split('=', 2))
            .ToDictionary(
                p => Uri.UnescapeDataString(p[0]),
                p => p.Length > 1 ? Uri.UnescapeDataString(p[1].Replace('+', ' ')) : string.Empty);

        /// <summary>The JSON body, parsed.</summary>
        public JsonElement Json => JsonDocument.Parse(Body).RootElement;
    }

    /// <summary>
    /// An HTTP handler that records the requests and returns canned responses: no network is used.
    /// </summary>
    public sealed class FakeHttpHandler : HttpMessageHandler
    {
        private readonly List<(Func<HttpRequestMessage, bool> Match, Func<HttpResponseMessage> Response)> responses = new();

        public List<CapturedRequest> Requests { get; } = new();

        public CapturedRequest Last => Requests.Last();

        /// <summary>Returns <paramref name="json"/> for the requests whose path is <paramref name="path"/>.</summary>
        public FakeHttpHandler Respond(string path, string json, HttpStatusCode status = HttpStatusCode.OK)
        {
            responses.Add((r => r.RequestUri.AbsolutePath == path, () => Json(json, status)));
            return this;
        }

        /// <summary>Returns <paramref name="bytes"/> for the requests whose path is <paramref name="path"/>.</summary>
        public FakeHttpHandler RespondBytes(string path, byte[] bytes, string contentType)
        {
            responses.Add((r => r.RequestUri.AbsolutePath == path, () =>
            {
                var content = new ByteArrayContent(bytes);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
            }));
            return this;
        }

        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            => Handle(request);

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(Handle(request));

        private HttpResponseMessage Handle(HttpRequestMessage request)
        {
            Requests.Add(new CapturedRequest
            {
                Method = request.Method,
                Uri = request.RequestUri,
                Body = request.Content?.ReadAsStringAsync().GetAwaiter().GetResult(),
                ContentType = request.Content?.Headers.ContentType?.MediaType,
                Authorization = request.Headers.Authorization?.ToString(),
                Accept = request.Headers.TryGetValues("Accept", out var accept) ? string.Join(",", accept) : null,
            });

            var match = responses.LastOrDefault(r => r.Match(request));
            return match.Response != null ? match.Response() : Json("{}", HttpStatusCode.OK);
        }

        private static HttpResponseMessage Json(string json, HttpStatusCode status) => new(status)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
    }

    /// <summary>
    /// A Vimeo client that sends every request to a <see cref="FakeHttpHandler"/>.
    /// </summary>
    public sealed class FakeVimeo : Vimeo
    {
        private readonly HttpClient httpClient;

        public FakeHttpHandler Handler { get; }

        public FakeVimeo(string accessToken = "test-token", string apiVersion = VimeoProperties.DefaultApiVersion)
            : base(new VimeoProperties { AccessToken = accessToken, ApiVersion = apiVersion })
        {
            Handler = new FakeHttpHandler();
            httpClient = new HttpClient(Handler);
        }

        protected override RestBuilder Root() => base.Root().UseHttpClient(httpClient);
    }
}
