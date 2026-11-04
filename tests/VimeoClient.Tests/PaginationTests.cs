namespace Mafesoft.VimeoClient.Tests
{
    using System.Linq;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class PaginationTests
    {
        private const string FirstPage = @"{
            ""total"": 3, ""page"": 1, ""per_page"": 2,
            ""paging"": { ""next"": ""/apps/1/webhooks?page=2"", ""previous"": null, ""first"": ""/apps/1/webhooks?page=1"", ""last"": ""/apps/1/webhooks?page=2"" },
            ""data"": [ { ""uri"": ""/apps/1/webhooks/10"" }, { ""uri"": ""/apps/1/webhooks/11"" } ]
        }";

        private const string SecondPage = @"{
            ""total"": 3, ""page"": 2, ""per_page"": 2,
            ""paging"": { ""next"": null, ""previous"": ""/apps/1/webhooks?page=1"", ""first"": ""/apps/1/webhooks?page=1"", ""last"": ""/apps/1/webhooks?page=2"" },
            ""data"": [ { ""uri"": ""/apps/1/webhooks/12"" } ]
        }";

        [Fact]
        public void Pagination_IsDeserialized()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);

            var result = client.Webhooks.GetAllTheWebhooksOfAnApp(1, page: 1, per_page: 2);

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(3, result.Content.Total);
            Assert.Equal(2, result.Content.Data.Count());
            Assert.Equal("/apps/1/webhooks/10", result.Content.Data.First().Uri);
            Assert.False(result.Content.Paging.IsSinglePage);
            Assert.Equal("1", client.Handler.Last.Query["page"]);
            Assert.Equal("2", client.Handler.Last.Query["per_page"]);
        }

        [Fact]
        public void Next_LoadsTheNextPage_AndPrevious_GoesBack()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);

            var first = client.Webhooks.GetAllTheWebhooksOfAnApp(1, per_page: 2);

            client.Handler.Respond("/apps/1/webhooks", SecondPage);
            var second = first.Content.Next();

            Assert.Equal("2", client.Handler.Last.Query["page"]);
            Assert.Equal("/apps/1/webhooks/12", second.Content.Data.Single().Uri);
            Assert.Equal("Bearer test-token", client.Handler.Last.Authorization);

            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            var back = second.Content.Previous();

            Assert.Equal("1", client.Handler.Last.Query["page"]);
            Assert.Equal(2, back.Content.Data.Count());
        }

        [Fact]
        public void Next_OnTheLastPage_ReturnsNull()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", SecondPage);

            var last = client.Webhooks.GetAllTheWebhooksOfAnApp(1);

            Assert.Null(last.Content.Next());
            Assert.Single(client.Handler.Requests);
        }
    }
}
