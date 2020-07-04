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

namespace VimeoClient.Common
{
    using RestClient;
    using RestClient.Generic;

    /// <summary>
    /// Vimeo Authentication Extras
    /// https://developer.vimeo.com/api/reference/authentication-extras
    /// </summary>
    public class VimeoAuthenticationExtras
    {
        /// <summary>
        /// Vimeo properties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// Root Authorization
        /// </summary>
        public RestBuilder RootAuthorization { get; private set; }

        /// <summary>
        /// Create a new instance of VimeoAuthenticationExtras class
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="rootAuthorization"></param>
        public VimeoAuthenticationExtras(VimeoProperties properties, RestBuilder rootAuthorization)
        {
            this.Properties = properties;
            this.RootAuthorization = rootAuthorization;
        }

        #region [ ESSENTIALS ]

        /// <summary>
        /// This method revokes the access token that the requesting app is currently using. The token must be of the OAuth 2 type.
        /// </summary>
        /// <returns></returns>
        public RestResult<string> RevokeTheCurrentAccessToken() => RootAuthorization
            .Command("/tokens")
            .Delete();

        /// <summary>
        /// This method verifies that an OAuth 2 access token exists.
        /// </summary>
        /// <returns></returns>
        public RestResult<string> VerifyAnOAuth2AccessToken() => RootAuthorization
            .Command("/oauth/verify")
            .Get();

        #endregion

        #region [ AUTHENTICATE ]

        /// <summary>
        /// This method uses the OAuth protocol to authorize a client. 
        /// For details on OAuth client authorization, see our Working with Authentication guide or the OAuth spec.
        /// </summary>
        /// <param name="scope">The grant type. The value of this field must be client_credentials.</param>
        /// <param name="grant_type">A space-separated list of the authentication scopes to access. The default is public.</param>
        /// <returns></returns>
        public RestResult<string> AuthorizeClientWithOAuth(string scope, string grant_type = "client_credentials") => RootAuthorization
            .Command("/oauth/authorize/client")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                pars.Add("scope", scope);
                pars.Add("grant_type", grant_type);
            })
            .Post();

        #endregion

        #region [ CONVERT ]

        /// <summary>
        /// This method exchanges a legacy Advanced API OAuth 1 token for an API v3 OAuth 2 token.
        /// </summary>
        /// <param name="token">The OAuth 1 token.</param>
        /// <param name="token_secret">The OAuth 1 token secret.</param>
        /// <param name="grant_type">The grant type. The value of this field must be vimeo_oauth1.</param>
        /// <returns></returns>
        public RestResult<string> ConvertOAuth1AccessTokenToAnOAuth2AccessToken(string token, string token_secret, string grant_type = "vimeo_oauth1") => RootAuthorization
            .Command("/oauth/authorize/vimeo_oauth1")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                pars.Add("token", token);
                pars.Add("token_secret", token_secret);
                pars.Add("grant_type", grant_type);
            })
            .Post();

        #endregion

        #region [ EXCHANGE ]

        /// <summary>
        /// This method exchanges an OAuth authorization code for an OAuth access token.
        /// </summary>
        /// <param name="code">The authorization code received from the authorization server.</param>
        /// <param name="redirect_uri">The redirect URI. The value of this field must match the URI from /oauth/authorize.</param>
        /// <param name="grant_type">The grant type.The value of this field must be authorization_code.</param>
        /// <returns></returns>
        public RestResult<string> ExchangeAnAuthorizationCodeForAnAccessToken(string code, string redirect_uri, string grant_type = "authorization_code") => RootAuthorization
            .Command("/oauth/access_token")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                pars.Add("code", code);
                pars.Add("grant_type", grant_type);
                pars.Add("redirect_uri", redirect_uri);
            })
            .Post();

        #endregion
    }
}