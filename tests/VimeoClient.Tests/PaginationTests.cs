namespace Mafesoft.VimeoClient.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
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

        [Fact]
        public async Task NextAsync_LoadsTheNextPage_AndPreviousAsync_GoesBack()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);

            var first = await client.Webhooks.GetAllTheWebhooksOfAnAppAsync(1, per_page: 2);

            client.Handler.Respond("/apps/1/webhooks", SecondPage);
            var second = await first.Content.NextAsync();

            Assert.Equal("2", client.Handler.Last.Query["page"]);
            Assert.Equal("/apps/1/webhooks/12", second.Content.Data.Single().Uri);
            Assert.Equal("Bearer test-token", client.Handler.Last.Authorization);

            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            var back = await second.Content.PreviousAsync();

            Assert.Equal("1", client.Handler.Last.Query["page"]);
            Assert.Equal(2, back.Content.Data.Count());
        }

        [Fact]
        public async Task NextAsync_OnTheLastPage_ReturnsNull_AndPreviousAsync_OnTheFirstPage_ReturnsNull()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", SecondPage);
            var last = client.Webhooks.GetAllTheWebhooksOfAnApp(1);

            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            var first = client.Webhooks.GetAllTheWebhooksOfAnApp(1);

            Assert.Null(await last.Content.NextAsync());
            Assert.Null(await first.Content.PreviousAsync());
            Assert.Equal(2, client.Handler.Requests.Count);
        }

        [Fact]
        public async Task NextAsync_WorksOnAPageLoadedSynchronously()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            client.Handler.Respond("/apps/1/webhooks", "page=2", SecondPage);

            var first = client.Webhooks.GetAllTheWebhooksOfAnApp(1, per_page: 2);
            var second = await first.Content.NextAsync();

            Assert.Equal("/apps/1/webhooks/12", second.Content.Data.Single().Uri);
        }

        [Fact]
        public async Task NextAsync_PassesTheCancellationToken()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            var first = client.Webhooks.GetAllTheWebhooksOfAnApp(1, per_page: 2);

            using var source = new CancellationTokenSource();
            source.Cancel();
            var second = await first.Content.NextAsync(source.Token);

            Assert.True(second.IsCancellationRequested);
        }

        [Fact]
        public async Task Navigation_OfTheSectionsThatBuiltItByHand_IsChainedAndAsync()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/groups/9/users", GroupPage(1, next: true));
            client.Handler.Respond("/groups/9/users", "page=2", GroupPage(2, next: true));
            client.Handler.Respond("/groups/9/users", "page=3", GroupPage(3, next: false));

            var first = client.Groups.GetAllTheMembersOfAGroup(9);
            var second = first.Content.Next();
            var third = second.Content.Next();

            Assert.Equal("/users/3", third.Content.Data.Single().Uri);
            Assert.Null(third.Content.Next());
            Assert.Equal("/users/2", (await first.Content.NextAsync()).Content.Data.Single().Uri);
        }

        [Fact]
        public void GetAllItems_ReadsTheItemsOfAllThePages()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            client.Handler.Respond("/apps/1/webhooks", "page=2", SecondPage);

            var first = client.Webhooks.GetAllTheWebhooksOfAnApp(1, per_page: 2);
            var uris = first.Content.GetAllItems().Select(w => w.Uri).ToList();

            Assert.Equal(new[] { "/apps/1/webhooks/10", "/apps/1/webhooks/11", "/apps/1/webhooks/12" }, uris);
            Assert.Equal(2, client.Handler.Requests.Count);
        }

        [Fact]
        public void GetAllItems_LoadsTheNextPagesOnlyWhenNeeded()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            client.Handler.Respond("/apps/1/webhooks", "page=2", SecondPage);

            var first = client.Webhooks.GetAllTheWebhooksOfAnApp(1, per_page: 2);
            var items = first.Content.GetAllItems().Take(2).ToList();

            Assert.Equal(2, items.Count);
            Assert.Single(client.Handler.Requests);
        }

        [Fact]
        public void GetAllItems_WhenANextPageFails_Throws()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            client.Handler.Respond("/apps/1/webhooks", "page=2", @"{ ""error"": ""boom"" }", HttpStatusCode.InternalServerError);

            var first = client.Webhooks.GetAllTheWebhooksOfAnApp(1, per_page: 2);

            Assert.ThrowsAny<Exception>(() => first.Content.GetAllItems().ToList());
        }

#if NET5_0_OR_GREATER
        [Fact]
        public async Task GetAllItemsAsync_ReadsTheItemsOfAllThePages()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            client.Handler.Respond("/apps/1/webhooks", "page=2", SecondPage);

            var first = await client.Webhooks.GetAllTheWebhooksOfAnAppAsync(1, per_page: 2);
            var uris = new List<string>();
            await foreach (var webhook in first.Content.GetAllItemsAsync())
            {
                uris.Add(webhook.Uri);
            }

            Assert.Equal(new[] { "/apps/1/webhooks/10", "/apps/1/webhooks/11", "/apps/1/webhooks/12" }, uris);
            Assert.Equal(2, client.Handler.Requests.Count);
        }

        [Fact]
        public async Task GetAllItemsAsync_StopsWhenCanceled()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/1/webhooks", FirstPage);
            client.Handler.Respond("/apps/1/webhooks", "page=2", SecondPage);

            var first = await client.Webhooks.GetAllTheWebhooksOfAnAppAsync(1, per_page: 2);
            using var source = new CancellationTokenSource();
            var read = 0;

            await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
            {
                await foreach (var webhook in first.Content.GetAllItemsAsync(source.Token))
                {
                    read++;
                    source.Cancel();
                }
            });

            Assert.Equal(2, read);
            Assert.Single(client.Handler.Requests);
        }
#endif

        private static string GroupPage(int page, bool next) => @"{
            ""total"": 3, ""page"": " + page + @", ""per_page"": 1,
            ""paging"": { ""next"": " + (next ? @"""/groups/9/users?page=" + (page + 1) + @"""" : "null") + @", ""previous"": null },
            ""data"": [ { ""uri"": ""/users/" + page + @""" } ]
        }";
    }
}
