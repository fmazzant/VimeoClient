namespace Mafesoft.VimeoClient.Tests
{
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using Mafesoft.VimeoClient.Body.Video;
    using Mafesoft.VimeoClient.Filter.Video;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class VideosTests
    {
        [Fact]
        public void CreateAnAudioTrack_SendsTheNestedUploadObject()
        {
            var client = new FakeVimeo();

            client.Videos.CreateAnAudioTrackForAVideoVersion(1, 2, upload_approach: "tus", upload_size: 1024,
                language_code: "it-IT", type: "main", provenance: "user_uploaded", active: true);

            var request = client.Handler.Last;
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/videos/1/versions/2/audiotracks", request.Path);
            var upload = request.Json.GetProperty("upload");
            Assert.Equal("tus", upload.GetProperty("approach").GetString());
            Assert.Equal("1024", upload.GetProperty("size").GetString());
            Assert.False(upload.TryGetProperty("link", out _));
            Assert.Equal("it-IT", request.Json.GetProperty("language_code").GetString());
            Assert.Equal("main", request.Json.GetProperty("type").GetString());
            Assert.True(request.Json.GetProperty("active").GetBoolean());
        }

        [Fact]
        public void AudioTrack_IsDeserialized()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/videos/1/versions/2/audiotracks/abc", @"{
                ""uri"": ""/videos/1/versions/2/audiotracks/abc"", ""active"": true, ""type"": ""main"",
                ""language"": { ""code"": ""it"", ""name"": ""Italian"" },
                ""quota"": { ""used"": 1, ""max"": 5, ""has_reached_quota"": false },
                ""download"": [ { ""link"": ""https://example.com/a.mp3"", ""extension"": ""mp3"" } ]
            }");

            var track = client.Videos.GetAnAudioTrackOfAVideoVersion(1, 2, "abc").Content;

            Assert.Equal("Italian", track.Language.Name);
            Assert.Equal(5, track.Quota.Max);
            Assert.Equal("mp3", track.Download.Single().Extension);
        }

        [Fact]
        public void AudioTrack_EditAndDelete()
        {
            var client = new FakeVimeo();

            client.Videos.EditAnAudioTrackOfAVideoVersion(1, 2, "abc", active: false);
            Assert.Equal(new HttpMethod("PATCH"), client.Handler.Last.Method);
            Assert.False(client.Handler.Last.Json.GetProperty("active").GetBoolean());

            client.Videos.DeleteAnAudioTrackFromAVideoVersion(1, 2, "abc");
            Assert.Equal(HttpMethod.Delete, client.Handler.Last.Method);
            Assert.Equal("/videos/1/versions/2/audiotracks/abc", client.Handler.Last.Path);
        }

        [Fact]
        public void Trim_SendsTheTimesAsInvariantStrings()
        {
            var client = new FakeVimeo();

            client.Videos.StartATrimOperationForAVideo(5, trim_start: 1.5, trim_end: 60);

            var request = client.Handler.Last;
            Assert.Equal("/videos/5/trim", request.Path);
            Assert.Equal("1.5", request.Json.GetProperty("trim_start").GetString());
            Assert.Equal("60", request.Json.GetProperty("trim_end").GetString());
        }

        [Fact]
        public void Fragments_GetPutDelete()
        {
            var client = new FakeVimeo();

            client.Videos.GetAllTheFragmentsOfAVideo(5);
            Assert.Equal(HttpMethod.Get, client.Handler.Last.Method);

            client.Videos.UpdateTheFragmentsOfAVideo(5, new VimeoPayload().Set("timecode", 12));
            Assert.Equal(HttpMethod.Put, client.Handler.Last.Method);
            Assert.Equal(12, client.Handler.Last.Json.GetProperty("timecode").GetInt32());

            client.Videos.DeleteTheFragmentsOfAVideo(5);
            Assert.Equal(HttpMethod.Delete, client.Handler.Last.Method);
            Assert.All(client.Handler.Requests, r => Assert.Equal("/videos/5/fragments", r.Path));
        }

        [Fact]
        public void Transcripts_UseTheirPaths()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/videos/5/transcripts/9", @"{ ""total"": 1, ""data"": [ { ""id"": ""s1"", ""cue_start"": 0.5, ""cue_end"": 2, ""speaker"": ""A"" } ] }");

            var segments = client.Videos.GetTheTranscriptSegmentsOfATextTrack(5, 9).Content;
            Assert.Equal("A", segments.Data.Single().Speaker);

            client.Videos.GetTheTranscriptMetadataOfATextTrack("uuid-1", 9);
            Assert.Equal("/videos/uuid-1/transcript/9/metadata", client.Handler.Last.Path);
        }

        [Fact]
        public void VersionDetails_UseTheirPaths()
        {
            var client = new FakeVimeo();

            client.Videos.GetAllTheAudioTracksOfAVideoVersion(1, 2);
            Assert.Equal("/videos/1/versions/2/audiotracks", client.Handler.Last.Path);

            client.Videos.GetTheDownloadLinksOfAVideoVersion(1, 2);
            Assert.Equal("/videos/1/versions/2/downloads", client.Handler.Last.Path);

            client.Videos.GetTheThumbnailOfAVideoVersion(1, 2);
            Assert.Equal("/videos/1/versions/2/picture", client.Handler.Last.Path);

            client.Videos.GetAllTheTextTracksOfAVideoVersion(1, 2, per_page: 10);
            Assert.Equal("/videos/1/versions/2/texttracks", client.Handler.Last.Path);
            Assert.Equal("10", client.Handler.Last.Query["per_page"]);

            client.Videos.GetAllTheTextTracksOfAShowcaseVideo(3, 1);
            Assert.Equal("/albums/3/videos/1/texttracks", client.Handler.Last.Path);

            client.Videos.GetAllTheVersionsOfAChannelVideo("staffpicks", 1);
            Assert.Equal("/channels/staffpicks/videos/1/versions", client.Handler.Last.Path);
        }

        [Fact]
        public void DownloadLinks_AreReturnedAsRawJson()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/videos/1/versions/2/downloads", @"[ { ""link"": ""https://example.com/v.mp4"" } ]");

            var links = client.Videos.GetTheDownloadLinksOfAVideoVersion(1, 2).Content;

            Assert.Equal(JsonValueKind.Array, links.ValueKind);
            Assert.Equal("https://example.com/v.mp4", links[0].GetProperty("link").GetString());
        }

        [Fact]
        public void UsersWhoCanBeCredited_SendsTheListParameters()
        {
            var client = new FakeVimeo();

            client.Videos.GetTheUsersWhoCanBeCreditedOnAVideo(5, direction: VideoDirection.asc, query: "john", sort: "alphabetical", page: 1);

            var request = client.Handler.Last;
            Assert.Equal("/videos/5/credits/available_users", request.Path);
            Assert.Equal("asc", request.Query["direction"]);
            Assert.Equal("john", request.Query["query"]);
            Assert.Equal("alphabetical", request.Query["sort"]);
        }

        [Fact]
        public void Chapters_AndAnimatedThumbnails()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/videos/5/chapters", @"{ ""uri"": ""/videos/5/chapters/1"", ""title"": ""Intro"", ""timecode"": 0 }");

            var chapter = client.Videos.AddAChapterToAVideo(5, new ChapterParameters { Title = "Intro", Timecode = 0 }).Content;
            Assert.Equal(HttpMethod.Post, client.Handler.Last.Method);
            Assert.Equal("Intro", chapter.Title);

            client.Videos.CreateASetOfAnimatedThumbnailsForAVideo(5, duration: 6, start_time: 10);
            Assert.Equal("/videos/5/animated_thumbsets", client.Handler.Last.Path);
            Assert.Equal(6, client.Handler.Last.Json.GetProperty("duration").GetDouble());
            Assert.Equal(10, client.Handler.Last.Json.GetProperty("start_time").GetDouble());
        }

        [Fact]
        public void AI_AskAQuestion()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/videos/5/ai/ask", @"{ ""video_id"": 5, ""status"": ""ready"", ""data"": { ""answer"": ""A demo."" } }");

            var answer = client.Videos.AskAQuestionAboutAVideo(5, "What is it?", language: "en").Content;

            Assert.Equal(HttpMethod.Post, client.Handler.Last.Method);
            Assert.Equal("What is it?", client.Handler.Last.Json.GetProperty("question").GetString());
            Assert.Equal("A demo.", answer.Data.Answer);
            Assert.Equal(5, answer.VideoId);
        }
    }
}
