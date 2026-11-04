namespace VimeoClient.Tests
{
    using System;
    using System.Net.Http;
    using VimeoClient.Tests.Infrastructure;

    public class ClientTests
    {
        [Fact]
        public void Properties_HaveTheVimeoDefaults()
        {
            var properties = new VimeoProperties();

            Assert.Equal("https://api.vimeo.com", properties.EndPoint);
            Assert.Equal("3.4", properties.ApiVersion);
            Assert.Equal("application/vnd.vimeo.*+json;version=3.4", properties.AcceptHeader);
            Assert.False(properties.Debug);
            Assert.Empty(properties.ValidCertificates);
        }

        [Fact]
        public void AcceptHeader_FollowsTheApiVersion()
        {
            var properties = new VimeoProperties { ApiVersion = "3.5" };

            Assert.Equal("application/vnd.vimeo.*+json;version=3.5", properties.AcceptHeader);
        }

        [Fact]
        public void Request_SendsTheBearerTokenAndTheAcceptHeader()
        {
            var client = new FakeVimeo(accessToken: "my-token");

            client.Me.GetTheUser();

            var request = client.Handler.Last;
            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal("https://api.vimeo.com/me", request.Uri.GetLeftPart(UriPartial.Path));
            Assert.Equal("Bearer my-token", request.Authorization);
            Assert.Contains("application/vnd.vimeo.*+json;version=3.4", request.Accept.Replace(" ", string.Empty));
        }

        [Fact]
        public void Request_UsesTheConfiguredApiVersion()
        {
            var client = new FakeVimeo(apiVersion: "3.5");

            client.Me.GetTheUser();

            Assert.Contains("version=3.5", client.Handler.Last.Accept);
        }

        [Fact]
        public void Request_WithoutAccessToken_IsNotSent()
        {
            var client = new FakeVimeo(accessToken: string.Empty);

            var result = client.Me.GetTheUser();

            Assert.Empty(client.Handler.Requests);
            Assert.False(result.IsSuccessStatusCode);
            Assert.IsType<ArgumentNullException>(result.Exception);
        }

        [Fact]
        public void Sections_AreAvailableFromTheClient()
        {
            var client = new FakeVimeo();

            Assert.NotNull(client.Me);
            Assert.NotNull(client.Users);
            Assert.NotNull(client.Videos);
            Assert.NotNull(client.Channels);
            Assert.NotNull(client.Categories);
            Assert.NotNull(client.Live);
            Assert.NotNull(client.Analytics);
            Assert.NotNull(client.Webhooks);
            Assert.NotNull(client.Teams);
            Assert.NotNull(client.Payments);
            Assert.NotNull(client.Search);
            Assert.NotNull(client.Files);
            Assert.Same(client, client.Webhooks.Vimeo);
            Assert.Same(client.Properties, client.Teams.Properties);
        }

        [Fact]
        public void Get_CallsTheGivenUri()
        {
            var client = new FakeVimeo();

            client.Get<VimeoClient.Model.User>("/users/123");

            Assert.Equal("/users/123", client.Handler.Last.Path);
        }
    }
}
