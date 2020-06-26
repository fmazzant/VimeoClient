namespace VimeoClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Net.Security;
    using System.Text;
    using RestClient;
    using RestClient.Generic;
    using VimeoClient.Bodies;
    using VimeoClient.Common;
    using VimeoClient.Responses;

    public static class VimeoScope
    {
        public const string PUBLIC = "public";//* Access public member data.
        public const string PRIVATE = "private";//†	Access private member data.
        public const string PURCHASED = "purchased";//   Access a member's Vimeo On Demand purchase history.
        public const string CREATE = "create";// Create new Vimeo resources like showcases, groups, channels, and portfolios.To create new videos, you need the upload scope.
        public const string EDIT = "edit";// Edit existing Vimeo resources, including videos.
        public const string DELETE = "delete";//  Delete existing Vimeo resources, including videos.
        public const string INTERACT = "interact";// Interact with Vimeo resources, such as liking a video or following a member.
        public const string PUBUPLOAD = "upload";// Upload videos.
        public const string PROMO_CODES = "promo_codes";// Add, remove, and review Vimeo On Demand promotions.
        public const string VIDEO_FILES = "video_files";// Access video files belonging to members with Vimeo Pro membership or higher.
    }

    /// <summary>
    /// 
    /// </summary>
    public class Vimeo
    {
        /// <summary>
        /// 
        /// </summary>
        public VimeoProperties Properties { get; private set; }
            = new VimeoProperties { };

        /// <summary>
        /// 
        /// </summary>
        public Vimeo()
            : this(new VimeoProperties { })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="validCertificates"></param>
        public Vimeo(string clientId, string clientSecret, string accessToken, List<string> validCertificates)
            : this(new VimeoProperties
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                AccessToken = accessToken,
                ValidCertificates = validCertificates
            })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        public Vimeo(VimeoProperties properties)

        {
            Properties = properties;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected RestBuilder Root() => Rest
            .Build((p) => p.EndPoint = new Uri(Properties.EndPoint))
            .CertificateValidation((sender, cert, chain, errors) =>
            {
                if (Properties.ValidCertificates == null) return false;
                var certificate = cert.GetCertHashString();
                var noErrors = errors == SslPolicyErrors.None;
                var contains = Properties.ValidCertificates.Contains(certificate);
                return noErrors && contains;
            });

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected RestBuilder RootAuthorization() => Root()
            .OnStart((e) =>
            {
                Console.WriteLine(e.Url);
            })
            .Authentication(() => new AuthenticationHeaderValue("Bearer", Properties.AccessToken));


        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public RestResult<AccessTokenResponse> GetAccessToken(string clientId, string clientSecret) => Root()
            .Authentication(() =>
            {
                var token = $"{clientId}:{clientSecret}";
                var tokenBytes = Encoding.ASCII.GetBytes(token);
                var encoded = Convert.ToBase64String(tokenBytes);
                return new AuthenticationHeaderValue("Basic", encoded);
            })
            .Command("/oauth/authorize/client")
            .Payload(new AccessTokenPayload { })
            .Post<AccessTokenResponse>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RestResult<Tutorial> Tutorial() => RootAuthorization()
          .Command("/tutorial")
          .Get<Tutorial>();


        /// <summary>
        /// 
        /// </summary>
        public VimeoMe Me => new VimeoMe(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoUsers Users => new VimeoUsers(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoAPIInformation APIInformation => new VimeoAPIInformation(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoAuthenticationExtras AuthenticationExtras => new VimeoAuthenticationExtras(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoCategories Categories => new VimeoCategories(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoEmbedPresets EmbedPresets => new VimeoEmbedPresets(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoFolders Folders => new VimeoFolders(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoGroups Groups => new VimeoGroups(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoLikes Likes => new VimeoLikes(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoLive Live => new VimeoLive(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoOnDemand OnDemand => new VimeoOnDemand(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoPortfolios Portfolios => new VimeoPortfolios(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoShowCases ShowCases => new VimeoShowCases(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoTags Tags => new VimeoTags(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoTeamMembers TeamMembers => new VimeoTeamMembers(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoVideos Videos => new VimeoVideos(Properties);

        /// <summary>
        /// 
        /// </summary>
        public VimeoWatchLaterQueue WatchLaterQueue => new VimeoWatchLaterQueue(Properties);

    }
}