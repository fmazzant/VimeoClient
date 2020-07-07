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
    using VimeoClient.Model;

    /// <summary>
    /// Vimeo Authentication Extras
    /// https://developer.vimeo.com/api/reference/authentication-extras
    /// </summary>
    public class VimeoAuthenticationExtras
    {
        /// <summary>
        /// Vimeo
        /// </summary>
        public Vimeo Vimeo { get; private set; }

        /// <summary>
        /// Vimeo properties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// Root Authorization
        /// </summary>
        public RestBuilder RootAuthorization() => Vimeo.RootAuthorization();

        /// <summary>
        /// Create a new instance of VimeoAuthenticationExtras class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoAuthenticationExtras(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance of VimeoAuthenticationExtras class
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoAuthenticationExtras(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ ESSENTIALS ]

        /// <summary>
        /// This method revokes the access token that the requesting app is currently using. The token must be of the OAuth 2 type.
        /// </summary>
        /// <returns>
        /// 204 No Content	    The token was revoked.
        /// 400 Bad Request     Access can't be revoked for an OAuth 1 token.
        /// </returns>
        public RestResult RevokeTheCurrentAccessToken() => RootAuthorization()
            .Command("/tokens")
            .Delete();

        /// <summary>
        /// This method verifies that an OAuth 2 access token exists.
        /// </summary>
        /// <returns>
        /// 200 OK	            The token was verified.
        /// 401 Unauthorized    The token isn't a valid OAuth 2 token.
        /// </returns>
        public RestResult<Auth> VerifyAnOAuth2AccessToken() => RootAuthorization()
            .Command("/oauth/verify")
            .Get<Auth>();

        #endregion

        #region [ AUTHENTICATE ]

        /// <summary>
        /// This method uses the OAuth protocol to authorize a client. 
        /// For details on OAuth client authorization, see our Working with Authentication guide or the OAuth spec.
        /// </summary>
        /// <param name="scope">The grant type. The value of this field must be client_credentials.</param>
        /// <param name="grant_type">A space-separated list of the authentication scopes to access. The default is public.</param>
        /// <returns>
        /// 200 OK	The authorization was successful.
        /// 401 Unauthorized Error code 8001: No such client secret exists.
        /// </returns>
        public RestResult<Auth> AuthorizeClientWithOAuth(string scope, string grant_type = "client_credentials") => RootAuthorization()
            .Command("/oauth/authorize/client")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                pars.Add("scope", scope);
                pars.Add("grant_type", grant_type);
            })
            .Post<Auth>();

        #endregion

        #region [ CONVERT ]

        /// <summary>
        /// This method exchanges a legacy Advanced API OAuth 1 token for an API v3 OAuth 2 token.
        /// </summary>
        /// <param name="token">The OAuth 1 token.</param>
        /// <param name="token_secret">The OAuth 1 token secret.</param>
        /// <param name="grant_type">The grant type. The value of this field must be vimeo_oauth1.</param>
        /// <returns>
        /// 200 OK	The token was converted.
        /// 400 Bad Request
        ///     The token is invalid.
        ///     The token has unauthorized scopes.
        /// </returns>
        public RestResult<Auth> ConvertOAuth1AccessTokenToAnOAuth2AccessToken(string token, string token_secret, string grant_type = "vimeo_oauth1") => RootAuthorization()
            .Command("/oauth/authorize/vimeo_oauth1")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                pars.Add("token", token);
                pars.Add("token_secret", token_secret);
                pars.Add("grant_type", grant_type);
            })
            .Post<Auth>();

        #endregion

        #region [ EXCHANGE ]

        /// <summary>
        /// This method exchanges an OAuth authorization code for an OAuth access token.
        /// </summary>
        /// <param name="code">The authorization code received from the authorization server.</param>
        /// <param name="redirect_uri">The redirect URI. The value of this field must match the URI from /oauth/authorize.</param>
        /// <param name="grant_type">The grant type.The value of this field must be authorization_code.</param>
        /// <returns>
        /// 200 OK	The authorization code was exchanged.
        /// 400 Bad Request
        ///     The grant type is invalid.
        ///     The authorization code is invalid.
        ///     The redirect URI doesn't match the URI to create the authorization code.
        /// </returns>
        public RestResult<Auth> ExchangeAnAuthorizationCodeForAnAccessToken(string code, string redirect_uri, string grant_type = "authorization_code") => RootAuthorization()
            .Command("/oauth/access_token")
            .EnableFormUrlEncoded(true)
            .FormUrlEncoded((pars) =>
            {
                pars.Add("code", code);
                pars.Add("grant_type", grant_type);
                pars.Add("redirect_uri", redirect_uri);
            })
            .Post<Auth>();

        #endregion
    }
}