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

namespace VimeoClient.Body
{
    using VimeoClient.Response;

    /// <summary>
    /// Access Token Payload
    /// </summary>
    public class AccessTokenPayload
    {
        /// <summary>
        /// Understanding authentication workflows
        /// 
        /// Client credentials	
        ///     Public data	You don't need access to private data.
        ///     
        /// Authorization code  
        ///     Public data, private data You need long-term access.
        ///     
        /// Implicit    
        ///     Public data, private data You can't properly secure your app's client secret from your end users.
        ///     
        /// Device code 
        ///     Public data, private data Your app runs on a browserless or limited-input device.
        ///  
        /// </summary>
        public string grant_type { get; set; } = "client_credentials";

        /// <summary>
        /// The space-separated list of scopes associated with the access token. 
        /// The default value is public. Any other scopes that you may have specified in Step 1 are ignored.
        /// </summary>
        public string scope { get; set; } = "public";
    }

    /// <summary>
    /// Access Token Response
    /// </summary>
    public class AccessTokenResponse
    {
        /// <summary>
        /// The access token string.
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// The type of the access token, which for the Vimeo API is always bearer.
        /// </summary>
        public string token_type { get; set; }

        /// <summary>
        /// The space-separated list of scopes associated with the access token. 
        /// The default value is public. 
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// The complete representation of the authenticated end user. For more information, see the API Reference.
        /// </summary>
        public User user { get; set; }
    }

    /// <summary>
    /// Access Token Body
    /// </summary>
    public class PostAccessTokenBody
    {
        /// <summary>
        /// Understanding authentication workflows
        /// 
        /// Client credentials	
        ///     Public data	You don't need access to private data.
        ///     
        /// Authorization code  
        ///     Public data, private data You need long-term access.
        ///     
        /// Implicit    
        ///     Public data, private data You can't properly secure your app's client secret from your end users.
        ///     
        /// Device code 
        ///     Public data, private data Your app runs on a browserless or limited-input device.
        ///  
        /// </summary>
        public string grant_type { get; set; }

        /// <summary>
        /// The authorization code to exchange for an access token.
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// A redirect URI associated with your app. To add or review redirect URIs, access your app's information page from My Apps.
        /// </summary>
        public string redirect_uri { get; set; }
    }
}
