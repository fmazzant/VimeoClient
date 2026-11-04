namespace Mafesoft.VimeoClient.Tests
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class LiveTests
    {
        [Fact]
        public async Task SessionStatus_SendsTheClipId()
        {
            var client = new FakeVimeo();

            await client.Live.GetTheIngestStatusOfAnEventAsync(10, clip_id: 99);

            Assert.Equal("/live_events/10/session_status", client.Handler.Last.Path);
            Assert.Equal("99", client.Handler.Last.Query["clip_id"]);
        }

        [Fact]
        public async Task Destinations_ListGetUpdateDelete()
        {
            var client = new FakeVimeo();

            await client.Live.GetAllTheAvailableEventDestinationsAsync();
            Assert.Equal("/me/destinations", client.Handler.Last.Path);

            await client.Live.GetAllTheAvailableEventDestinationsAsync(152184);
            Assert.Equal("/users/152184/destinations", client.Handler.Last.Path);

            client.Handler.Respond("/destination/7", @"{ ""id"": 7, ""service_name"": ""youtube"", ""is_enabled"": true, ""display_name"": ""My channel"" }");
            var destination = (await client.Live.GetAnEventDestinationAsync(7)).Content;
            Assert.Equal("youtube", destination.ServiceName);
            Assert.Equal(7, destination.Id);

            await client.Live.UpdateAnEventDestinationAsync(7, is_enabled: false, service_name: "custom_rtmp", stream_url: "rtmp://example.com/live");
            var update = client.Handler.Last;
            Assert.Equal(new HttpMethod("PATCH"), update.Method);
            Assert.False(update.Json.GetProperty("is_enabled").GetBoolean());
            Assert.Equal("custom_rtmp", update.Json.GetProperty("service_name").GetString());
            Assert.Equal("rtmp://example.com/live", update.Json.GetProperty("stream_url").GetString());
            Assert.False(update.Json.TryGetProperty("stream_key", out _));

            await client.Live.DeleteAnEventDestinationAsync(7);
            Assert.Equal(HttpMethod.Delete, client.Handler.Last.Method);
            Assert.Equal("/destination/7", client.Handler.Last.Path);
        }

        [Fact]
        public async Task OttDestinations()
        {
            var client = new FakeVimeo();

            await client.Live.GetAllTheOttDestinationsOfAnEventAsync(1, 10);
            Assert.Equal("/users/1/live_events/10/ott_destinations", client.Handler.Last.Path);

            await client.Live.CreateAnOttDestinationForAnEventAsync(1, 10, new VimeoPayload().Set("ott_channel_id", 5));
            Assert.Equal(HttpMethod.Post, client.Handler.Last.Method);
            Assert.Equal(5, client.Handler.Last.Json.GetProperty("ott_channel_id").GetInt32());

            await client.Live.DeleteAnOttDestinationOfAnEventAsync(1, 10, "d1");
            Assert.Equal("/users/1/live_events/10/ott_destination/d1", client.Handler.Last.Path);
        }

        [Fact]
        public async Task Graphics()
        {
            var client = new FakeVimeo();

            await client.Live.AddAVideoGraphicsItemToAnEventAsync(10, 123);
            Assert.Equal("/live_events/10/composer/graphics/videos", client.Handler.Last.Path);
            Assert.Equal(123, client.Handler.Last.Json.GetProperty("video_id").GetInt64());

            client.Handler.Respond("/live_events/10/composer/graphics/videos", @"{ ""total"": 1, ""data"": [ { ""id"": ""g1"", ""videoId"": 123, ""type"": ""video"" } ] }");
            var graphics = (await client.Live.GetAllTheVideoGraphicsItemsOfAnEventAsync(10)).Content;
            Assert.Equal(123, graphics.Data.Single().VideoId);

            await client.Live.DeleteAVideoGraphicsItemFromAnEventAsync(10, 123);
            Assert.Equal(HttpMethod.Delete, client.Handler.Last.Method);
            Assert.Equal("/live_events/10/composer/graphics/videos/123", client.Handler.Last.Path);
        }

        [Fact]
        public async Task Scenes()
        {
            var client = new FakeVimeo();

            await client.Live.CreateASceneForAnEventAsync(10, scene_type: "live");
            Assert.Equal(HttpMethod.Post, client.Handler.Last.Method);
            Assert.Equal("live", client.Handler.Last.Json.GetProperty("scene_type").GetString());

            await client.Live.UpdateASceneOfAnEventAsync(10, "s1", new VimeoPayload().Set("name", "Main"));
            Assert.Equal(new HttpMethod("PATCH"), client.Handler.Last.Method);
            Assert.Equal("/live_events/10/composer/scenes/s1", client.Handler.Last.Path);

            await client.Live.AttachAGraphicItemToASceneAsync(10, "s1", new VimeoPayload().Set("type", "video").Set("id", "g1"));
            Assert.Equal("/live_events/10/composer/scenes/s1/graphics", client.Handler.Last.Path);
            Assert.Equal("g1", client.Handler.Last.Json.GetProperty("item").GetProperty("id").GetString());

            await client.Live.GetAllTheScenesOfAnEventAsync(10);
            Assert.Equal(HttpMethod.Get, client.Handler.Last.Method);

            await client.Live.ResetTheScenesOfAnEventAsync(10);
            Assert.Equal(HttpMethod.Delete, client.Handler.Last.Method);
            Assert.Equal("/live_events/10/composer/scenes", client.Handler.Last.Path);
        }
    }
}
