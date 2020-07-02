namespace VimeoClient
{
    using RestClient;
    using RestClient.Generic;
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Net.Security;
    using System.Text;
    using VimeoClient.Body;
    using VimeoClient.Common;
    using VimeoClient.Responses;

    /// <summary>
    /// Provides a set of methods for connecting to Vimeo REST webapi
    /// </summary>
    public class Vimeo
    {
        /// <summary>
        /// Properites
        /// </summary>
        public VimeoProperties Properties { get; private set; }
            = new VimeoProperties { };

        /// <summary>
        /// Creates an instance
        /// </summary>
        public Vimeo()
            : this(new VimeoProperties { })
        {

        }

        /// <summary>
        /// Creates an instance with auth information to access private or public information
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
        /// Creates an instance with Vimeo Properties
        /// </summary>
        /// <param name="properties"></param>
        public Vimeo(VimeoProperties properties)

        {
            Properties = properties;
        }

        /// <summary>
        /// Vimeo End Point root
        /// </summary>
        /// <returns></returns>
        protected RestBuilder Root() => Rest
            .Build((p) => p.EndPoint = new Uri(Properties.EndPoint))
            .CertificateValidation((sender, cert, chain, errors) =>
            {
                if (Properties.Debug) return true;
                if (Properties.ValidCertificates == null) return false;
                var certificate = cert.GetCertHashString();
                var noErrors = errors == SslPolicyErrors.None;
                var contains = Properties.ValidCertificates.Contains(certificate);
                return noErrors && contains;
            });

        /// <summary>
        /// Vimeo End Point root with Bearer authentication
        /// </summary>
        /// <returns></returns>
        protected RestBuilder RootAuthorization() => Root()
            .Authentication(() =>
            {
                if (string.IsNullOrEmpty(Properties.AccessToken))
                    throw new ArgumentNullException("AccessToken is empty or null. Call the client credentials grant or the authorization code grant to get the access token");
                return new AuthenticationHeaderValue("Bearer", Properties.AccessToken);
            });

        /// <summary>
        /// Using the client credentials grant. Access only public information.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public RestResult<AccessTokenResponse> GetAccessToken(string clientId, string clientSecret) => Root()
            .Authentication(() => new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"))))
            .Command("/oauth/authorize/client")
            .Payload(new AccessTokenPayload
            {
                grant_type = "client_credentials",
                scope = "public"
            })
            .Post<AccessTokenResponse>();

        /// <summary>
        /// Using the authorization code grant - STEP 1. Access public and private information.
        /// </summary>
        /// <param name="response_type"></param>
        /// <param name="client_id"></param>
        /// <param name="redirect_uri"></param>
        /// <param name="state"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public RestResult<string> GetAccessToken(string response_type, string client_id, string redirect_uri, string state, string[] scopes) => Root()
            .Command("/oauth/authorize")
            .Parameter("response_type", response_type)
            .Parameter("client_id", client_id)
            .Parameter("redirect_uri", redirect_uri)
            .Parameter("state", state)
            .Parameter("scope", scopes == null ? VimeoScope.PUBLIC : string.Join(" ", scopes))
            .OnStart((e) => Console.WriteLine(e.Url))
            .Get();

        /// <summary>
        /// Using the authorization code grant - STEP 2. Access public and private information.
        /// </summary>
        /// <param name="authenticationCode"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public RestResult<AccessTokenResponse> PostAccessToken(string authenticationCode, string requestUri) => Root()
            .Authentication(() => new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Properties.ClientId}:{Properties.ClientSecret}"))))
            .Command("/oauth/access_token")
            .Payload(new PostAccessTokenBody
            {
                grant_type = "authorization_code",
                code = authenticationCode,
                redirect_uri = requestUri
            }).Post<AccessTokenResponse>();

        /// <summary>
        /// Tutotial is Public scope
        /// </summary>
        /// <returns></returns>
        public RestResult<Tutorial> Tutorial() => RootAuthorization()
          .Command("/tutorial")
          .Get<Tutorial>();

        /// <summary>
        /// Me Information
        /// </summary>
        public VimeoMe Me => new VimeoMe(Properties, RootAuthorization());

        /// <summary>
        /// Users Information
        /// </summary>
        public VimeoUsers Users => new VimeoUsers(Properties, RootAuthorization());

        /// <summary>
        /// API Information
        /// </summary>
        public VimeoAPIInformation APIInformation => new VimeoAPIInformation(Properties, RootAuthorization());

        /// <summary>
        /// Authentication Extras
        /// </summary>
        public VimeoAuthenticationExtras AuthenticationExtras => new VimeoAuthenticationExtras(Properties, RootAuthorization());

        /// <summary>
        /// Categories on Vimeo are sets of videos for particular genres (like comedy) or other characteristics (like being experimental). 
        /// All the videos in these sets have been hand-chosen by Vimeo staff, but you can bring your videos to our attention 
        /// by recommending them for up to two main categories and one subcategory. 
        /// See our Help Center for more details.
        /// </summary>
        public VimeoCategories Categories => new VimeoCategories(Properties, RootAuthorization());

        /// <summary>
        /// Use channels to organize videos by theme or some other grouping. 
        /// You can incorporate your own videos as well as videos from other Vimeo members on any channel that you create. 
        /// Vimeo Basic subscribers get one channel, while paid Vimeo members can have an unlimited number. 
        /// See our Help Center for more details.
        /// </summary>
        public VimeoChannels Channels => new VimeoChannels(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoEmbedPresets EmbedPresets => new VimeoEmbedPresets(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoFolders Folders => new VimeoFolders(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoGroups Groups => new VimeoGroups(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoLikes Likes => new VimeoLikes(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoLive Live => new VimeoLive(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoOnDemand OnDemand => new VimeoOnDemand(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoPortfolios Portfolios => new VimeoPortfolios(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoShowCases ShowCases => new VimeoShowCases(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoTags Tags => new VimeoTags(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoTeamMembers TeamMembers => new VimeoTeamMembers(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoVideos Videos => new VimeoVideos(Properties, RootAuthorization());

        /// <summary>
        /// 
        /// </summary>
        public VimeoWatchLaterQueue WatchLaterQueue => new VimeoWatchLaterQueue(Properties, RootAuthorization());

    }
}