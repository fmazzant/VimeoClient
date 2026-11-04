namespace Mafesoft.VimeoClient.Tests
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using Mafesoft.VimeoClient.Filter.Analytics;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class AnalyticsTests
    {
        [Fact]
        public void AuthenticatedUser_SendsTheRequiredParameters()
        {
            var client = new FakeVimeo();

            client.Analytics.GetAnalyticsForTheAuthenticatedUser(AnalyticsDimension.country,
                new DateTime(2026, 1, 1), new DateTime(2026, 1, 31, 23, 59, 59));

            var request = client.Handler.Last;
            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal("/me/analytics", request.Path);
            Assert.Equal("country", request.Query["dimension"]);
            Assert.Equal("2026-01-01T00:00:00", request.Query["from"]);
            Assert.Equal("2026-01-31T23:59:59", request.Query["to"]);
            Assert.False(request.Query.ContainsKey("time_interval"));
            Assert.False(request.Query.ContainsKey("sort"));
        }

        [Fact]
        public void Dates_KeepTheUtcDesignator()
        {
            var client = new FakeVimeo();

            client.Analytics.GetAnalyticsForTheAuthenticatedUser(AnalyticsDimension.total,
                new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 2, 1, 0, 0, 0, DateTimeKind.Utc));

            Assert.Equal("2026-01-01T00:00:00Z", client.Handler.Last.Query["from"]);
        }

        [Fact]
        public void User_SendsFiltersSortAndPaging()
        {
            var client = new FakeVimeo();

            client.Analytics.GetAnalyticsForAUser("152184", AnalyticsDimension.video,
                new DateTime(2026, 1, 1), new DateTime(2026, 1, 31),
                time_interval: AnalyticsTimeInterval.week,
                filter_content: new[] { "/videos/1", "/videos/2" },
                filter_countries: new[] { "IT", "US" },
                filter_device_types: new[] { "desktop" },
                filter_embed_domains: new[] { "example.com" },
                filter_streaming_types: new[] { "live" },
                direction: AnalyticsDirection.desc,
                sort: AnalyticsSort.@default,
                page: 2,
                per_page: 1000);

            var query = client.Handler.Last.Query;
            Assert.Equal("/users/152184/analytics", client.Handler.Last.Path);
            Assert.Equal("video", query["dimension"]);
            Assert.Equal("week", query["time_interval"]);
            Assert.Equal("/videos/1,/videos/2", query["filter_content"]);
            Assert.Equal("IT,US", query["filter_countries"]);
            Assert.Equal("desktop", query["filter_device_types"]);
            Assert.Equal("example.com", query["filter_embed_domains"]);
            Assert.Equal("live", query["filter_streaming_types"]);
            Assert.Equal("desc", query["direction"]);
            Assert.Equal("default", query["sort"]);
            Assert.Equal("2", query["page"]);
            Assert.Equal("1000", query["per_page"]);
        }

        [Fact]
        public void Response_IsDeserialized()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/me/analytics", @"{
                ""total"": 1, ""page"": 1, ""per_page"": 50, ""paging"": { ""next"": null, ""previous"": null },
                ""data"": [ {
                    ""views"": 120, ""unique_viewers"": 80, ""impressions"": 300, ""finishes"": 40,
                    ""total_time_watched"": 3600.5, ""average_percent_watched"": 47.2,
                    ""country"": { ""code"": ""IT"", ""name"": ""Italy"" },
                    ""start_date"": ""2026-01-01T00:00:00+00:00"", ""end_date"": ""2026-01-31T00:00:00+00:00"",
                    ""metadata"": { ""connections"": { ""video"": { ""uri"": ""/videos/1"", ""title"": ""Demo"", ""duration"": 60 } } }
                } ]
            }");

            var row = client.Analytics.GetAnalyticsForTheAuthenticatedUser(AnalyticsDimension.country,
                new DateTime(2026, 1, 1), new DateTime(2026, 1, 31)).Content.Data.Single();

            Assert.Equal(120, row.Views);
            Assert.Equal(80, row.UniqueViewers);
            Assert.Equal(3600.5, row.TotalTimeWatched);
            Assert.Equal("Italy", row.Country.Name);
            Assert.Equal("IT", row.Country.Code);
            Assert.Equal("Demo", row.Metadata.Connections.Video.Title);
            Assert.Null(row.DeviceType);
        }
    }
}
