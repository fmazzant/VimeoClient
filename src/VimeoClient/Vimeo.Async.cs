/// <summary>
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

namespace Mafesoft.VimeoClient
{
    using Mafesoft.RestClient;
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Net.Security;
    using System.Text;
    using Mafesoft.VimeoClient.Body;
    using Mafesoft.VimeoClient.Common;
    using Mafesoft.VimeoClient.Model;
    using System.Threading;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of Vimeo.
    public partial class Vimeo
    {
        /// <summary>
        /// Using the client credentials grant. Access only public information.
        /// </summary>
        /// <param name="clientId">The client identifier of the Vimeo API app.</param>
        /// <param name="clientSecret">The client secret of the Vimeo API app.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The access token with the public scope.</returns>
        public virtual Task<RestResult<AccessTokenResponse>> GetAccessTokenAsync(string clientId, string clientSecret, CancellationToken cancellationToken = default) => Root()
            .Authentication(() => new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"))))
            .Command("/oauth/authorize/client")
            .Payload(new AccessTokenPayload
            {
                grant_type = "client_credentials",
                scope = "public"
            })
            .PostAsync<AccessTokenResponse>(cancellationToken);

        /// <summary>
        /// Using the authorization code grant - STEP 1. Access public and private information.
        /// </summary>
        /// <param name="response_type">The response type: code.</param>
        /// <param name="client_id">The client identifier of the Vimeo API app.</param>
        /// <param name="redirect_uri">The redirect URI of the Vimeo API app.</param>
        /// <param name="state">A unique value that the redirect URI receives back, to check the request.</param>
        /// <param name="scopes">The requested scopes (see <see cref="VimeoScope"/>); null requests the public scope.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The response of the authorization page.</returns>
        public virtual Task<RestResult<string>> GetAccessTokenAsync(string response_type, string client_id, string redirect_uri, string state, string[] scopes, CancellationToken cancellationToken = default) => Root()
            .Command("/oauth/authorize")
            .Parameter("response_type", response_type)
            .Parameter("client_id", client_id)
            .Parameter("redirect_uri", redirect_uri)
            .Parameter("state", state)
            .Parameter("scope", scopes == null ? VimeoScope.PUBLIC : string.Join(" ", scopes))
            .OnStart((e) => Console.WriteLine(e.Url))
            .GetAsync(cancellationToken);

        /// <summary>
        /// Using the authorization code grant - STEP 2. Access public and private information.
        /// </summary>
        /// <param name="authenticationCode">The authorization code received on the redirect URI.</param>
        /// <param name="requestUri">The redirect URI used in step 1.</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The access token.</returns>
        public virtual Task<RestResult<AccessTokenResponse>> PostAccessTokenAsync(string authenticationCode, string requestUri, CancellationToken cancellationToken = default) => Root()
            .Authentication(() => new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Properties.ClientId}:{Properties.ClientSecret}"))))
            .Command("/oauth/access_token")
            .Payload(new PostAccessTokenBody
            {
                grant_type = "authorization_code",
                code = authenticationCode,
                redirect_uri = requestUri
            }).PostAsync<AccessTokenResponse>(cancellationToken);

        /// <summary>
        /// Tutotial is Public scope
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The tutorial message: it checks that the access token works.</returns>
        public virtual Task<RestResult<Tutorial>> TutorialAsync(CancellationToken cancellationToken = default) => RootAuthorization()
          .Command("/tutorial")
          .GetAsync<Tutorial>(cancellationToken);

        /// <summary>
        /// Invoke generic Get
        /// </summary>
        /// <typeparam name="T">Response's type</typeparam>
        /// <param name="uri">Uri to call</param>
        /// <param name="cancellationToken">The token to cancel the request.</param>
        /// <returns>The response mapped to <typeparamref name="T"/>.</returns>
        public virtual Task<RestResult<T>> GetAsync<T>(string uri, CancellationToken cancellationToken = default) where T : new()
            => RootAuthorization().Command(uri).GetAsync<T>(cancellationToken);
    }
}
