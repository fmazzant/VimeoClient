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

namespace Mafesoft.VimeoClient.Tests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class RatingsTests
    {
        [Fact]
        public void GetTheRatingsOfAVideo_ReturnsTheSummary()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/videos/5/ratings", @"{
                ""type"": ""stars"", ""total"": 12, ""average"": 4.25, ""thumbs_up"": null, ""thumbs_down"": null,
                ""distribution"": { ""1"": 0, ""2"": 1, ""3"": 1, ""4"": 4, ""5"": 6 }
            }");

            var ratings = client.Videos.GetTheRatingsOfAVideo(5).Content;

            Assert.Equal(HttpMethod.Get, client.Handler.Last.Method);
            Assert.Equal("stars", ratings.Type);
            Assert.Equal(12, ratings.Total);
            Assert.Equal(4.25, ratings.Average);
            Assert.Null(ratings.ThumbsUp);
            Assert.Equal(6, ratings.AdditionalData["distribution"].GetProperty("5").GetInt32());
        }

        [Fact]
        public async Task GetTheRatingsOfAVideoAsync_ReturnsTheThumbs()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/videos/5/ratings", @"{ ""type"": ""thumbs"", ""total"": 10, ""thumbs_up"": 8, ""thumbs_down"": 2 }");

            var ratings = (await client.Videos.GetTheRatingsOfAVideoAsync(5)).Content;

            Assert.Equal("thumbs", ratings.Type);
            Assert.Equal(8, ratings.ThumbsUp);
            Assert.Equal(2, ratings.ThumbsDown);
        }

        [Fact]
        public void GetTheRatingSettingsOfAVideo_ReturnsTheSettings()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/videos/5/ratings/settings", @"{ ""enabled"": true, ""type"": ""thumbs"" }");

            var settings = client.Videos.GetTheRatingSettingsOfAVideo(5).Content;

            Assert.Equal("/videos/5/ratings/settings", client.Handler.Last.Path);
            Assert.True(settings.Enabled);
            Assert.Equal("thumbs", settings.Type);
        }

        [Fact]
        public void EditTheRatingSettingsOfAVideo_SendsTheSettings()
        {
            var client = new FakeVimeo();

            client.Videos.EditTheRatingSettingsOfAVideo(5, enabled: true, type: VideoRatingType.stars);

            var request = client.Handler.Last;
            Assert.Equal(new HttpMethod("PATCH"), request.Method);
            Assert.Equal("/videos/5/ratings/settings", request.Path);
            Assert.True(request.Json.GetProperty("enabled").GetBoolean());
            Assert.Equal("stars", request.Json.GetProperty("type").GetString());
        }

        [Fact]
        public void EditTheRatingSettingsOfAVideo_SkipsTheNullValues()
        {
            var client = new FakeVimeo();

            client.Videos.EditTheRatingSettingsOfAVideo(5, enabled: false);

            var request = client.Handler.Last;
            Assert.False(request.Json.GetProperty("enabled").GetBoolean());
            Assert.False(request.Json.TryGetProperty("type", out _));
        }
    }
}
