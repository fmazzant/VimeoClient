﻿/// <summary>
/// 
/// The MIT License (MIT)
/// 
/// Copyright (c) 2020 Federico Mazzanti
/// 
/// Permission is hereby granted, free of charge, to any person
/// obtaining a copy of this software and associated documentation
/// files (the "Software"), to deal in the Software without
/// restriction, including without limitation the rights to use,
/// copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the
/// Software is furnished to do so, subject to the following
/// conditions:
/// 
/// The above copyright notice and this permission notice shall be
/// included in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
/// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
/// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
/// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
/// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
/// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
/// OTHER DEALINGS IN THE SOFTWARE.
/// 
/// </summary>
///

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
    using VimeoClient.Model;

    /// <summary>
    /// Provides a set of methods for connecting to Vimeo REST webapi.
    /// Build something great. Vimeo's API supports flexible, high-quality video integration with your custom apps.
    /// Version Vimeo API: 3.2
    /// </summary>
    public class Vimeo
    {
        /// <summary>
        /// Properites
        /// </summary>
        public VimeoProperties Properties { get; private set; }

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
        protected virtual RestBuilder Root() => Rest
            .Build((p) => p.EndPoint = new Uri(Properties.EndPoint))
            .CertificateValidation((sender, cert, chain, errors) =>
            {
                if (Properties.Debug)
                {
                    return true;
                }

                if (Properties.ValidCertificates == null)
                {
                    return false;
                }

                var certificate = cert.GetCertHashString();
                var noErrors = errors == SslPolicyErrors.None;
                var contains = Properties.ValidCertificates.Contains(certificate);
                return noErrors && contains;
            });

        /// <summary>
        /// Vimeo End Point root with Bearer authentication
        /// </summary>
        /// <returns></returns>
        public virtual RestBuilder RootAuthorization() => Root()
            .EnableGZipCompression() //gzip
            .Authentication(() =>
            {
                if (string.IsNullOrEmpty(Properties.AccessToken))
                {
                    throw new ArgumentNullException("AccessToken is empty or null. Call the client credentials grant or the authorization code grant to get the access token");
                }

                return new AuthenticationHeaderValue("Bearer", Properties.AccessToken);
            });

        /// <summary>
        /// Using the client credentials grant. Access only public information.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public virtual RestResult<AccessTokenResponse> GetAccessToken(string clientId, string clientSecret) => Root()
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
        public virtual RestResult<string> GetAccessToken(string response_type, string client_id, string redirect_uri, string state, string[] scopes) => Root()
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
        public virtual RestResult<AccessTokenResponse> PostAccessToken(string authenticationCode, string requestUri) => Root()
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
        public virtual RestResult<Tutorial> Tutorial() => RootAuthorization()
          .Command("/tutorial")
          .Get<Tutorial>();

        /// <summary>
        /// Me Information
        /// </summary>
        public virtual VimeoMe Me => new VimeoMe(this);

        /// <summary>
        /// Users Information
        /// </summary>
        public virtual VimeoUsers Users => new VimeoUsers(this);

        /// <summary>
        /// API Information
        /// </summary>
        public virtual VimeoAPIInformation APIInformation => new VimeoAPIInformation(this);

        /// <summary>
        /// Authentication Extras
        /// </summary>
        public virtual VimeoAuthenticationExtras AuthenticationExtras => new VimeoAuthenticationExtras(this);

        /// <summary>
        /// Categories on Vimeo are sets of videos for particular genres (like comedy) or other characteristics (like being experimental). 
        /// All the videos in these sets have been hand-chosen by Vimeo staff, but you can bring your videos to our attention 
        /// by recommending them for up to two main categories and one subcategory. 
        /// See our Help Center for more details.
        /// </summary>
        public virtual VimeoCategories Categories => new VimeoCategories(this);

        /// <summary>
        /// Use channels to organize videos by theme or some other grouping. 
        /// You can incorporate your own videos as well as videos from other Vimeo members on any channel that you create. 
        /// Vimeo Basic subscribers get one channel, while paid Vimeo members can have an unlimited number. 
        /// See our Help Center for more details.
        /// </summary>
        public virtual VimeoChannels Channels => new VimeoChannels(this);

        /// <summary>
        /// An embed preset is a reusable collection of settings for customizing the appearance and behavior of the embeddable Vimeo player. 
        /// This feature is available to Vimeo Pro, Business, and Premium members. 
        /// For more information, see our Help Center.
        /// </summary>
        public virtual VimeoEmbedPresets EmbedPresets => new VimeoEmbedPresets(this);

        /// <summary>
        /// Folders
        /// </summary>
        public virtual VimeoFolders Folders => new VimeoFolders(this);

        /// <summary>
        /// A group is a community within Vimeo for collaborating, sharing, and engaging with videos. Groups can be public, where anyone can join, or they can be private, where membership is by invitation only. 
        /// For more information, see our Help Center.
        /// </summary>
        public virtual VimeoGroups Groups => new VimeoGroups(this);

        /// <summary>
        /// A like is a video interaction where a Vimeo member indicates that they liked a video.
        /// </summary>
        public virtual VimeoLikes Likes => new VimeoLikes(this);

        /// <summary>
        /// Please note that Vimeo's live API is available only to Vimeo Enterprise customers. Learn more about Vimeo Enterprise.
        /// </summary>
        public virtual VimeoLive Live => new VimeoLive(this);

        /// <summary>
        /// On Demand
        /// </summary>
        public virtual VimeoOnDemand OnDemand => new VimeoOnDemand(this);

        /// <summary>
        /// Portfolios are customizable websites for showcasing videos. 
        /// Vimeo Pro, Business, and Premium subscribers have access to this feature. For more information, see our Help Center.
        /// </summary>
        public virtual VimeoPortfolios Portfolios => new VimeoPortfolios(this);

        /// <summary>
        /// A showcase (previously album) is a collection of videos for public or private sharing. 
        /// When developing for this feature, keep in mind that our endpoint syntax uses the original album nomenclature, although this is subject to change in the future. 
        /// For more information about showcases, see our Help Center.
        /// </summary>
        public virtual VimeoShowCases ShowCases => new VimeoShowCases(this);

        /// <summary>
        /// Tags are pieces of metadata for categorizing or labeling videos.
        /// </summary>
        public virtual VimeoTags Tags => new VimeoTags(this);

        /// <summary>
        /// Team Members
        /// </summary>
        public virtual VimeoTeamMembers TeamMembers => new VimeoTeamMembers(this);

        /// <summary>
        /// Videos
        /// </summary>
        public virtual VimeoVideos Videos => new VimeoVideos(this);

        /// <summary>
        /// The Watch Later queue contains all the videos that a Vimeo member has flagged to watch later.
        /// </summary>
        public virtual VimeoWatchLaterQueue WatchLaterQueue => new VimeoWatchLaterQueue(this);

        /// <summary>
        /// As you work with the Vimeo API, some common themes begin to emerge, with some common strategies for optimizing your success. 
        /// We've collected these here for your easy reference.
        /// </summary>
        public virtual VimeoCommonFormatsParameters CommonFormatsParameters => new VimeoCommonFormatsParameters(this);

        /// <summary>
        /// Invoke generic Get
        /// </summary>
        /// <typeparam name="T">Response's type</typeparam>
        /// <param name="uri">Uri to call</param>
        /// <returns></returns>
        public virtual RestResult<T> Get<T>(string uri) where T : new()
            => RootAuthorization().Command(uri).Get<T>();
    }
}