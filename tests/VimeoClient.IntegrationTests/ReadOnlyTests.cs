namespace Mafesoft.VimeoClient.IntegrationTests
{
    using Mafesoft.VimeoClient.IntegrationTests.Infrastructure;

    /// <summary>
    /// Read-only calls against the real Vimeo API: they don't change the account.
    /// </summary>
    public class ReadOnlyTests
    {
        private readonly Vimeo client = VimeoIntegration.IsConfigured ? VimeoIntegration.CreateClient() : null;

        [VimeoFact]
        public void Tutorial_ReturnsTheMessage()
        {
            var result = client.Tutorial();

            VimeoIntegration.AssertSuccess(result);
            Assert.False(string.IsNullOrEmpty(result.Content.message));
        }

        [VimeoFact]
        public void Me_ReturnsTheAuthenticatedUser()
        {
            var result = client.Me.GetTheUser();

            VimeoIntegration.AssertSuccess(result);
            Assert.StartsWith("/users/", result.Content.Uri);
        }

        [VimeoFact]
        public void Videos_ReturnsTheUploadedVideos_WithPagination()
        {
            var result = client.Videos.GetAllTheVideosThatTheUserHasUploaded(per_page: 2);

            VimeoIntegration.AssertSuccess(result);
            Assert.NotNull(result.Content.Data);
            Assert.True(result.Content.Data.Count <= 2);
            Assert.Equal(2, result.Content.PerPage);

            if (result.Content.Paging?.Next != null)
            {
                var next = result.Content.Next();

                VimeoIntegration.AssertSuccess(next);
                Assert.Equal(result.Content.Page + 1, next.Content.Page);
            }
        }

        [VimeoFact]
        public void Folders_ReturnsTheFoldersOfTheUser()
        {
            var result = client.Folders.GetAllTheFoldersThatBelongToTheUser(per_page: 2);

            VimeoIntegration.AssertSuccess(result);
            Assert.NotNull(result.Content.Data);
            Assert.True(result.Content.Data.Count <= 2);
        }
    }
}
