namespace Mafesoft.VimeoClient.Tests
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    /// <summary>
    /// Rate limits and retry (issue #15): the X-RateLimit-* headers and the retry of the transient errors.
    /// </summary>
    public class RateLimitAndRetryTests
    {
        private const string VideoPath = "/videos/1";
        private const string CopyPath = "/me/videos/1/copy";

        private static FakeVimeo Client(int maxRetries, bool nonIdempotent = false)
        {
            var client = new FakeVimeo();
            client.Properties.MaxRetries = maxRetries;
            client.Properties.RetryDelay = TimeSpan.FromMilliseconds(1);
            client.Properties.RetryNonIdempotentMethods = nonIdempotent;
            return client;
        }

        private static Func<HttpResponseMessage> Status(HttpStatusCode status) => () => FakeHttpHandler.Response(status);

        [Fact]
        public void ByDefault_TransientErrorsAreNotRetried()
        {
            var client = new FakeVimeo();
            client.Handler.RespondInOrder(VideoPath, Status((HttpStatusCode)429), Status(HttpStatusCode.OK));

            var result = client.Videos.GetSpecificVideo(1);

            Assert.Equal((HttpStatusCode)429, result.StatusCode);
            Assert.Equal(0, result.RetryCount);
            Assert.Single(client.Handler.Requests);
        }

        [Fact]
        public void MaxRetries_RetriesTooManyRequestsAndServerErrors()
        {
            var client = Client(maxRetries: 3);
            client.Handler.RespondInOrder(VideoPath,
                Status((HttpStatusCode)429), Status(HttpStatusCode.ServiceUnavailable), () => FakeHttpHandler.Response(HttpStatusCode.OK, "{\"name\":\"ok\"}"));

            var result = client.Videos.GetSpecificVideo(1);

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal("ok", result.Content.Name);
            Assert.Equal(2, result.RetryCount);
            Assert.Equal(3, client.Handler.Requests.Count);
        }

        [Fact]
        public async Task MaxRetries_AppliesToTheAsyncMethods()
        {
            var client = Client(maxRetries: 1);
            client.Handler.RespondInOrder(VideoPath, Status(HttpStatusCode.BadGateway), Status(HttpStatusCode.OK));

            var result = await client.Videos.GetSpecificVideoAsync(1);

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(1, result.RetryCount);
        }

        [Fact]
        public void MaxRetries_StopsAfterTheLastRetry()
        {
            var client = Client(maxRetries: 2);
            client.Handler.RespondInOrder(VideoPath, Status((HttpStatusCode)429));

            var result = client.Videos.GetSpecificVideo(1);

            Assert.Equal((HttpStatusCode)429, result.StatusCode);
            Assert.Equal(3, client.Handler.Requests.Count);
        }

        [Fact]
        public void ClientErrors_AreNotRetried()
        {
            var client = Client(maxRetries: 3);
            client.Handler.RespondInOrder(VideoPath, Status(HttpStatusCode.NotFound), Status(HttpStatusCode.OK));

            var result = client.Videos.GetSpecificVideo(1);

            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
            Assert.Single(client.Handler.Requests);
        }

        [Fact]
        public void Post_IsRetriedOnlyWhenNonIdempotentMethodsAreAllowed()
        {
            var safe = Client(maxRetries: 2);
            safe.Handler.RespondInOrder(CopyPath, Status((HttpStatusCode)429), Status(HttpStatusCode.Created));
            Assert.Equal((HttpStatusCode)429, safe.Videos.MeCopyAVideo(1).StatusCode);
            Assert.Single(safe.Handler.Requests);

            var allowed = Client(maxRetries: 2, nonIdempotent: true);
            allowed.Handler.RespondInOrder(CopyPath, Status((HttpStatusCode)429), Status(HttpStatusCode.Created));
            Assert.Equal(HttpStatusCode.Created, allowed.Videos.MeCopyAVideo(1).StatusCode);
            Assert.Equal(2, allowed.Handler.Requests.Count);
        }

        [Fact]
        public void GetRateLimit_ReadsTheHeaders()
        {
            var client = new FakeVimeo();
            client.Handler.RespondInOrder(VideoPath, () => FakeHttpHandler.Response(HttpStatusCode.OK, "{}",
                ("X-RateLimit-Limit", "1000"), ("X-RateLimit-Remaining", "998"), ("X-RateLimit-Reset", "2026-11-17T22:00:00+00:00")));

            var limit = client.Videos.GetSpecificVideo(1).GetRateLimit();

            Assert.NotNull(limit);
            Assert.Equal(1000, limit.Limit);
            Assert.Equal(998, limit.Remaining);
            Assert.Equal(new DateTimeOffset(2026, 11, 17, 22, 0, 0, TimeSpan.Zero), limit.Reset);
        }

        [Fact]
        public void GetRateLimit_AcceptsUnixSecondsAndPartialHeaders()
        {
            var client = new FakeVimeo();
            client.Handler.RespondInOrder(VideoPath, () => FakeHttpHandler.Response((HttpStatusCode)429, "{}",
                ("X-RateLimit-Remaining", "0"), ("X-RateLimit-Reset", "1795000000")));

            var limit = client.Videos.GetSpecificVideo(1).GetRateLimit();

            Assert.Null(limit.Limit);
            Assert.Equal(0, limit.Remaining);
            Assert.Equal(DateTimeOffset.FromUnixTimeSeconds(1795000000), limit.Reset);
        }

        [Fact]
        public void GetRateLimit_IsNullWithoutHeadersOrResponse()
        {
            var client = new FakeVimeo();
            client.Handler.Respond(VideoPath, "{}");

            Assert.Null(client.Videos.GetSpecificVideo(1).GetRateLimit());
            Assert.Null(VimeoRateLimitExtensions.GetRateLimit(null));
            Assert.Null(VimeoRateLimit.FromHeaders(null));
        }

        [Fact]
        public void Defaults_RetryIsOff()
        {
            var properties = new VimeoProperties();

            Assert.Equal(0, properties.MaxRetries);
            Assert.Equal(TimeSpan.FromSeconds(1), properties.RetryDelay);
            Assert.False(properties.RetryNonIdempotentMethods);
        }
    }
}
