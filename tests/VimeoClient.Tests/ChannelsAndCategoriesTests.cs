namespace Mafesoft.VimeoClient.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Mafesoft.VimeoClient.Body.Video;
    using Mafesoft.VimeoClient.Common;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class ChannelsAndCategoriesTests
    {
        public static IEnumerable<object[]> ChannelVideoCalls()
        {
            yield return Call("/channels/c/videos/7", HttpMethod.Put, c => c.AddASpecificVideoToAChannel("c", 7), c => c.AddASpecificVideoToAChannel("c", "7"));
            yield return Call("/channels/c/videos/7", HttpMethod.Get, c => c.GetASpecificVideoInAChannel("c", 7), c => c.GetASpecificVideoInAChannel("c", "7"));
            yield return Call("/channels/c/videos/7", HttpMethod.Delete, c => c.RemoveASpecificVideoFromAChannel("c", 7), c => c.RemoveASpecificVideoFromAChannel("c", "7"));
            yield return Call("/channels/c/videos/7/comments", HttpMethod.Get, c => c.GetAllTheCommentsOnAChannelVideo("c", 7), c => c.GetAllTheCommentsOnAChannelVideo("c", "7"));
            yield return Call("/channels/c/videos/7/comments", HttpMethod.Post, c => c.AddACommentToAChannelVideo("c", 7, "hi"), c => c.AddACommentToAChannelVideo("c", "7", "hi"));
            yield return Call("/channels/c/videos/7/credits", HttpMethod.Get, c => c.GetAllTheCreditedUsersInAChannelVideo("c", 7), c => c.GetAllTheCreditedUsersInAChannelVideo("c", "7"));
            yield return Call("/channels/c/videos/7/credits", HttpMethod.Post, c => c.CreditAUserInAChannelVideo("c", 7, new CreditParameters()), c => c.CreditAUserInAChannelVideo("c", "7", new CreditParameters()));
            yield return Call("/channels/c/videos/7/pictures", HttpMethod.Get, c => c.GetAllTheThumbnailsOfAChannelVideo("c", 7), c => c.GetAllTheThumbnailsOfAChannelVideo("c", "7"));
            yield return Call("/channels/c/videos/7/pictures", HttpMethod.Post, c => c.AddAThumbnailToAChannelVideo("c", 7, new ThumbnailParameters()), c => c.AddAThumbnailToAChannelVideo("c", "7", new ThumbnailParameters()));
            yield return Call("/channels/c/videos/7/privacy/users", HttpMethod.Get, c => c.GetAllTheUsersWhoCanViewAPrivateChannelVideo("c", 7), c => c.GetAllTheUsersWhoCanViewAPrivateChannelVideo("c", "7"));
            yield return Call("/channels/c/videos/7/privacy/users", HttpMethod.Put, c => c.PermitAListOfUsersToViewAPrivateChannelVideo("c", 7, new[] { "/users/1" }), c => c.PermitAListOfUsersToViewAPrivateChannelVideo("c", "7", new[] { "/users/1" }));
            yield return Call("/channels/c/videos/7/texttracks", HttpMethod.Get, c => c.GetAllTheTextTracksOfAChannelVideo("c", 7), c => c.GetAllTheTextTracksOfAChannelVideo("c", "7"));
            yield return Call("/channels/c/videos/7/texttracks", HttpMethod.Post, c => c.AddATextTrackToAChannelVideo("c", 7, new TextTrackParameters()), c => c.AddATextTrackToAChannelVideo("c", "7", new TextTrackParameters()));
            yield return Call("/videos/7/available_channels", HttpMethod.Get, c => c.GetAllTheChannelsToWhichTheUserCanAddOrRemoveASpecificVideo(7), c => c.GetAllTheChannelsToWhichTheUserCanAddOrRemoveASpecificVideo("7"));
        }

        private static object[] Call(string path, HttpMethod method, Action<VimeoChannels> withInt, Action<VimeoChannels> withString)
            => new object[] { path, method, withInt, withString };

        [Theory]
        [MemberData(nameof(ChannelVideoCalls))]
        public void Channels_IntOverload_SendsTheSameRequestAsTheStringOne(string path, HttpMethod method, Action<VimeoChannels> withInt, Action<VimeoChannels> withString)
        {
            var client = new FakeVimeo();

            withInt(client.Channels);
            withString(client.Channels);

            Assert.Equal(2, client.Handler.Requests.Count);
            Assert.All(client.Handler.Requests, r =>
            {
                Assert.Equal(path, r.Path);
                Assert.Equal(method, r.Method);
            });
            Assert.Equal(client.Handler.Requests[0].Body, client.Handler.Requests[1].Body);
        }

        [Fact]
        public void Channels_AddAComment_IsFormUrlEncoded()
        {
            var client = new FakeVimeo();

            client.Channels.AddACommentToAChannelVideo("staffpicks", 7, "Great video!");

            Assert.Equal("application/x-www-form-urlencoded", client.Handler.Last.ContentType);
            Assert.Contains("text=Great", client.Handler.Last.Body);
        }

        [Fact]
        public void Channels_PermitUsers_SendsTheUserUris()
        {
            var client = new FakeVimeo();

            client.Channels.PermitAListOfUsersToViewAPrivateChannelVideo("c", 7, new[] { "/users/1", "/users/2" });

            var uris = client.Handler.Last.Json.EnumerateArray().Select(e => e.GetProperty("uri").GetString());
            Assert.Equal(new[] { "/users/1", "/users/2" }, uris);
        }

        [Fact]
        public void Categories_IntOverloads_SendTheSameRequests()
        {
            var client = new FakeVimeo();

            client.Categories.GetASpecificVideoInACategory("music", 7);
            client.Categories.GetASpecificVideoInACategory("music", "7");
            client.Categories.GetAllTheCategoriesToWhichAVideoBelongs(7);
            client.Categories.GetAllTheCategoriesToWhichAVideoBelongs("7");
            client.Categories.SuggestCategoriesForAVideo(7, new[] { "music" });
            client.Categories.SuggestCategoriesForAVideo("7", new[] { "music" });

            var r = client.Handler.Requests;
            Assert.Equal("/categories/music/videos/7", r[0].Path);
            Assert.Equal(r[0].Path, r[1].Path);
            Assert.Equal("/videos/7/categories", r[2].Path);
            Assert.Equal(r[2].Path, r[3].Path);
            Assert.Equal("/videos/7/categories", r[4].Path);
            Assert.Equal(r[4].Method, r[5].Method);
            Assert.Equal(r[4].Body, r[5].Body);
        }
    }
}
