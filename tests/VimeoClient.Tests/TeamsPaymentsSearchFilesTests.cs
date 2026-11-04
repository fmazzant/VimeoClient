namespace Mafesoft.VimeoClient.Tests
{
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using Mafesoft.VimeoClient.Body.Team;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class TeamsTests
    {
        [Fact]
        public void RoleAndMembership_UseTheirPaths()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/users/1/team/role", @"{ ""uri"": ""/users/1/team/role"", ""role"": ""Admin"", ""display_name"": ""Admin"" }");

            var role = client.Teams.GetTheRoleOfTheUserOnATeam("1").Content;
            Assert.Equal("Admin", role.Role);

            client.Teams.GetTheMembershipOfATeamUser("1", 55);
            Assert.Equal("/users/1/team_users/55", client.Handler.Last.Path);
        }

        [Fact]
        public void CustomMetadataFields_AreSentAsAnArrayOfObjects()
        {
            var client = new FakeVimeo();

            client.Teams.CreateUpdateOrDeleteTheCustomMetadataFieldsOfATeam("1", new[]
            {
                new CustomMetadataFieldChange { Name = "Department", Type = "select", Mandatory = true, Values = new[] { "Sales", "R&D" } },
                new CustomMetadataFieldChange { Id = 42, Delete = true },
            });

            var request = client.Handler.Last;
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/teams/1/custom_metadata", request.Path);
            var fields = request.Json.GetProperty("fields").EnumerateArray().ToArray();
            Assert.Equal(2, fields.Length);
            Assert.Equal("Department", fields[0].GetProperty("name").GetString());
            Assert.True(fields[0].GetProperty("mandatory").GetBoolean());
            Assert.Equal(new[] { "Sales", "R&D" }, fields[0].GetProperty("values").EnumerateArray().Select(v => v.GetString()));
            Assert.False(fields[0].TryGetProperty("id", out _));
            Assert.Equal(42, fields[1].GetProperty("id").GetInt64());
            Assert.True(fields[1].GetProperty("delete").GetBoolean());
            Assert.False(fields[1].TryGetProperty("name", out _));
        }

        [Fact]
        public void CustomMetadataOptions_AreSent()
        {
            var client = new FakeVimeo();

            client.Teams.UpdateTheOptionsOfACustomMetadataField("1", 42, new[]
            {
                new CustomMetadataOptionChange { OldValue = "Engineering", NewValue = "R&D" },
                new CustomMetadataOptionChange { NewValue = "Marketing" },
            });

            var request = client.Handler.Last;
            Assert.Equal(new HttpMethod("PATCH"), request.Method);
            Assert.Equal(42, request.Json.GetProperty("field_id").GetInt64());
            var options = request.Json.GetProperty("options").EnumerateArray().ToArray();
            Assert.Equal("Engineering", options[0].GetProperty("old_value").GetString());
            Assert.Equal("R&D", options[0].GetProperty("new_value").GetString());
            Assert.False(options[1].TryGetProperty("old_value", out _));
        }

        [Fact]
        public void Backfill_AndIncompleteVideos()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/teams/1/custom_metadata/backfill", @"{ ""field_id"": 42, ""total_videos"": 120 }");

            var backfill = client.Teams.BackfillACustomMetadataValueAcrossTheVideosOfATeam("1", 42, "Sales", override_existing: true).Content;
            Assert.Equal(120, backfill.GetProperty("total_videos").GetInt32());
            Assert.Equal("Sales", client.Handler.Last.Json.GetProperty("field_value").GetString());
            Assert.True(client.Handler.Last.Json.GetProperty("override_existing").GetBoolean());

            client.Teams.GetTheVideosMissingMandatoryCustomMetadata("1", sort: "title_desc", per_page: 25);
            Assert.Equal("/teams/1/custom_metadata/incomplete_videos", client.Handler.Last.Path);
            Assert.Equal("title_desc", client.Handler.Last.Query["sort"]);
            Assert.Equal("25", client.Handler.Last.Query["per_page"]);
        }
    }

    public class PaymentsSearchFilesTests
    {
        [Fact]
        public void PaymentMethods()
        {
            var client = new FakeVimeo();

            client.Payments.GetAllThePaymentMethods(show_disabled: true, per_page: 5);
            Assert.Equal("/me/payment_methods", client.Handler.Last.Path);
            Assert.Equal("true", client.Handler.Last.Query["show_disabled"]);
            Assert.False(client.Handler.Last.Query.ContainsKey("cardmember_name"));

            client.Payments.GetAPaymentMethod("pm_1");
            Assert.Equal("/me/payment_methods/pm_1", client.Handler.Last.Path);

            client.Payments.DeleteAPaymentMethod("pm_1");
            Assert.Equal(HttpMethod.Delete, client.Handler.Last.Method);
        }

        [Fact]
        public void SubscriptionAndPlan()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/subscription_plans/pro", @"{ ""uri"": ""/subscription_plans/pro"", ""name"": ""Pro"", ""tier"": ""pro"" }");

            var plan = client.Payments.GetASubscriptionPlan("pro").Content;
            Assert.Equal("Pro", plan.Name);
            Assert.Equal("pro", plan.Tier);

            client.Payments.GetASubscription("1", "sub_1");
            Assert.Equal("/users/1/subscriptions/sub_1", client.Handler.Last.Path);
        }

        [Fact]
        public void Search_SendsAllTheParameters()
        {
            var client = new FakeVimeo();

            client.Search.SearchTheItemsOfAUser("1", query: "demo", query_fields: new[] { "title", "tags" }, filter: "video",
                filter_privacy: new[] { "unlisted", "anybody" }, modified_start_date: "2026-01-01", modified_end_date: "2026-02-01",
                direction: "desc", sort: "date", page: 2, per_page: 10);

            var query = client.Handler.Last.Query;
            Assert.Equal("/search/1/items", client.Handler.Last.Path);
            Assert.Equal("demo", query["query"]);
            Assert.Equal("title,tags", query["query_fields"]);
            Assert.Equal("video", query["filter"]);
            Assert.Equal("unlisted,anybody", query["filter_privacy"]);
            Assert.Equal("2026-01-01", query["modified_start_date"]);
            Assert.Equal("2026-02-01", query["modified_end_date"]);
            Assert.Equal("desc", query["direction"]);
            Assert.Equal("date", query["sort"]);
            Assert.Equal("2", query["page"]);

            client.Search.SearchTheItemsOfAWorkspace("ws-uuid");
            Assert.Equal("/workspaces/search/ws-uuid/items", client.Handler.Last.Path);
            Assert.Empty(client.Handler.Last.Query);
        }

        [Fact]
        public void Files_SendsThePasswordOnlyWhenGiven()
        {
            var client = new FakeVimeo();

            client.Files.GetAFile("abc");
            Assert.Equal("/files/abc", client.Handler.Last.Path);
            Assert.Empty(client.Handler.Last.Query);

            client.Files.GetAFile("abc", password: "p@ss");
            Assert.Equal("p@ss", client.Handler.Last.Query["password"]);
        }

        [Fact]
        public void LmsPackage_ReturnsTheBytes()
        {
            var client = new FakeVimeo();
            var zip = new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x01 };
            client.Handler.RespondBytes("/users/1/lms/download/7", zip, "application/zip");

            var package = client.Users.DownloadAnLmsPackageForAVideo(1, 7, standard: "scorm12", passing_score: 80.5);

            Assert.Equal(zip, package.Content);
            Assert.Equal("scorm12", client.Handler.Last.Query["standard"]);
            Assert.Equal("80.5", client.Handler.Last.Query["passing_score"]);
        }
    }
}
