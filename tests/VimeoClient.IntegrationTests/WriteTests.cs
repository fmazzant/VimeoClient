namespace Mafesoft.VimeoClient.IntegrationTests
{
    using System;
    using Mafesoft.VimeoClient.Body.Folder;
    using Mafesoft.VimeoClient.IntegrationTests.Infrastructure;

    /// <summary>
    /// Calls against the real Vimeo API that create and delete resources:
    /// they run only with VIMEO_INTEGRATION_WRITE=true, on a test account.
    /// Every resource created by a test is deleted by the same test.
    /// </summary>
    public class WriteTests
    {
        private readonly Vimeo client = VimeoIntegration.IsConfigured ? VimeoIntegration.CreateClient() : null;

        [VimeoWriteFact]
        public void Folder_IsCreatedReadAndDeleted()
        {
            var name = $"VimeoClient integration test {DateTime.UtcNow:yyyyMMddHHmmss}";

            var created = client.Folders.CreateAFolder(new FolderEditParameters { Name = name });
            VimeoIntegration.AssertSuccess(created);

            var folderId = int.Parse(created.Content.Identity);
            try
            {
                Assert.Equal(name, created.Content.Name);

                var folder = client.Folders.GetASpecificFolder(folderId);

                VimeoIntegration.AssertSuccess(folder);
                Assert.Equal(name, folder.Content.Name);
            }
            finally
            {
                var deleted = client.Folders.DeleteAFolder(folderId, should_delete_clips: false);
                VimeoIntegration.AssertSuccess(deleted);
            }
        }
    }
}
