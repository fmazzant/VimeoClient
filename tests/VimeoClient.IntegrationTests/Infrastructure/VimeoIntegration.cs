namespace Mafesoft.VimeoClient.IntegrationTests.Infrastructure
{
    using System;
    using Mafesoft.RestClient;

    /// <summary>
    /// The configuration of the integration tests, read from environment variables:
    /// - VIMEO_ACCESS_TOKEN: the access token of a Vimeo test account. Without it every integration test is skipped.
    /// - VIMEO_INTEGRATION_WRITE: "true" also runs the tests that create and delete resources on the account.
    /// Never commit an access token: set it in the environment (locally) or as a GitHub secret (CI).
    /// </summary>
    public static class VimeoIntegration
    {
        public const string AccessTokenVariable = "VIMEO_ACCESS_TOKEN";

        public const string WriteVariable = "VIMEO_INTEGRATION_WRITE";

        public static string AccessToken => Environment.GetEnvironmentVariable(AccessTokenVariable);

        public static bool IsConfigured => !string.IsNullOrWhiteSpace(AccessToken);

        public static bool IsWriteEnabled => IsConfigured
            && string.Equals(Environment.GetEnvironmentVariable(WriteVariable)?.Trim(), "true", StringComparison.OrdinalIgnoreCase);

        /// <summary>A client for the real Vimeo API, with the standard TLS validation.</summary>
        public static Vimeo CreateClient() => new Vimeo(new VimeoProperties
        {
            AccessToken = AccessToken.Trim()
        });

        /// <summary>Asserts that the request succeeded, showing the status code and the error when it did not.</summary>
        public static void AssertSuccess(RestResult result)
        {
            Assert.NotNull(result);
            Assert.True(result.IsSuccessStatusCode,
                $"Vimeo returned {(int)result.StatusCode} {result.ReasonPhrase}: {result.Exception?.Message}");
        }
    }

    /// <summary>
    /// A test against the real Vimeo API, read-only: skipped when VIMEO_ACCESS_TOKEN is not set.
    /// </summary>
    public sealed class VimeoFactAttribute : FactAttribute
    {
        public VimeoFactAttribute()
        {
            if (!VimeoIntegration.IsConfigured)
            {
                Skip = $"{VimeoIntegration.AccessTokenVariable} is not set: integration test skipped.";
            }
        }
    }

    /// <summary>
    /// A test against the real Vimeo API that creates and deletes resources: skipped unless VIMEO_ACCESS_TOKEN
    /// is set and VIMEO_INTEGRATION_WRITE is "true". Use a test account.
    /// </summary>
    public sealed class VimeoWriteFactAttribute : FactAttribute
    {
        public VimeoWriteFactAttribute()
        {
            if (!VimeoIntegration.IsConfigured)
            {
                Skip = $"{VimeoIntegration.AccessTokenVariable} is not set: integration test skipped.";
            }
            else if (!VimeoIntegration.IsWriteEnabled)
            {
                Skip = $"{VimeoIntegration.WriteVariable} is not \"true\": write integration test skipped.";
            }
        }
    }
}
