namespace Mafesoft.VimeoClient.Tests
{
    using System.Net.Http;
    using System.Text.Json;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class WebhooksTests
    {
        [Fact]
        public void Add_PostsTheWebhookAsJson()
        {
            var client = new FakeVimeo();

            client.Webhooks.AddAWebhookForAnApp(42, "video-transcode-complete", "https://example.com/hook", is_enabled: true, secret: "s3cr3t");

            var request = client.Handler.Last;
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/apps/42/webhooks", request.Path);
            Assert.Equal("application/json", request.ContentType);
            Assert.Equal("video-transcode-complete", request.Json.GetProperty("webhook_type").GetString());
            Assert.Equal("https://example.com/hook", request.Json.GetProperty("webhook_url").GetString());
            Assert.True(request.Json.GetProperty("is_enabled").GetBoolean());
            Assert.Equal("s3cr3t", request.Json.GetProperty("secret").GetString());
        }

        [Fact]
        public void Update_SendsOnlyTheGivenFields()
        {
            var client = new FakeVimeo();

            client.Webhooks.UpdateAWebhook(42, 7, is_enabled: false);

            var request = client.Handler.Last;
            Assert.Equal(new HttpMethod("PATCH"), request.Method);
            Assert.Equal("/apps/42/webhooks/7", request.Path);
            Assert.False(request.Json.GetProperty("is_enabled").GetBoolean());
            Assert.False(request.Json.TryGetProperty("webhook_url", out _));
            Assert.False(request.Json.TryGetProperty("secret", out _));
        }

        [Fact]
        public void Get_AndDelete_UseTheWebhookPath()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/apps/42/webhooks/7", @"{
                ""uri"": ""/apps/42/webhooks/7"", ""webhook_type"": ""video-created"", ""webhook_url"": ""https://example.com/hook"",
                ""is_enabled"": true, ""failure_rate_before_disabling"": 0.25, ""created_on"": ""2026-01-01T00:00:00+00:00"",
                ""not_mapped_field"": ""kept""
            }");

            var webhook = client.Webhooks.GetAWebhook(42, 7).Content;
            Assert.Equal(HttpMethod.Get, client.Handler.Last.Method);
            Assert.Equal("video-created", webhook.WebhookType);
            Assert.True(webhook.IsEnabled);
            Assert.Equal(0.25, webhook.FailureRateBeforeDisabling);
            Assert.Equal("kept", webhook.AdditionalData["not_mapped_field"].GetString());

            client.Webhooks.DeleteAWebhook(42, 7);
            Assert.Equal(HttpMethod.Delete, client.Handler.Last.Method);
            Assert.Equal("/apps/42/webhooks/7", client.Handler.Last.Path);
        }
    }
}
