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
    using System.Collections.Generic;

    /// <summary>
    /// The credentials and the settings of a <see cref="Vimeo"/> client: the access token, the credentials of the
    /// Vimeo API app, the end point, the Vimeo API version and the certificate validation.
    /// </summary>
    public class VimeoProperties
    {
        /// <summary>
        /// The client identifier of the Vimeo API app (https://developer.vimeo.com/apps).
        /// Used by the authentication methods (client credentials and authorization code grants).
        /// </summary>
        public string ClientId { get; set; }
            = string.Empty;

        /// <summary>
        /// The client secret of the Vimeo API app (https://developer.vimeo.com/apps).
        /// Used by the authentication methods (client credentials and authorization code grants).
        /// </summary>
        public string ClientSecret { get; set; }
         = string.Empty;

        /// <summary>
        /// The access token sent as Bearer token on each request.
        /// When it is empty the authenticated requests are not sent and their result has an <see cref="System.ArgumentNullException"/>.
        /// </summary>
        public string AccessToken { get; set; }
            = string.Empty;

        /// <summary>
        /// The hashes of the trusted certificates (certificate pinning).
        /// Empty: the standard TLS validation is used.
        /// Set: the certificate must be valid and its hash must be in the list.
        /// </summary>
        public List<string> ValidCertificates { get; set; }
            = new List<string>();

        /// <summary>
        /// The Vimeo API end point, https://api.vimeo.com by default.
        /// </summary>
        public string EndPoint { get; set; }
            = "https://api.vimeo.com";

        /// <summary>
        /// The default Vimeo API version supported by this library
        /// </summary>
        public const string DefaultApiVersion = "3.4";

        /// <summary>
        /// The Vimeo API version requested by the Accept header.
        /// https://developer.vimeo.com/api/guides/start#versioning
        /// </summary>
        public string ApiVersion { get; set; }
            = DefaultApiVersion;

        /// <summary>
        /// The Accept header sent on each request: application/vnd.vimeo.*+json;version={ApiVersion}
        /// </summary>
        public string AcceptHeader => $"application/vnd.vimeo.*+json;version={ApiVersion}";

        /// <summary>
        /// If debug is true the certificate validation is skipped. Use it only in development.
        /// </summary>
        public bool Debug { get; set; }
            = false;

        /// <summary>
        /// How many times a request is sent again after a transient error: 429 Too Many Requests, 408, 500, 502, 503,
        /// 504, a network error or a timeout. 0 (the default) turns the retry off.
        /// The delay doubles at every attempt, starting from <see cref="RetryDelay"/> (with jitter); the Retry-After header
        /// of the response is honored (up to 30 seconds). See <see cref="VimeoRateLimit"/> for the rate limit headers.
        /// </summary>
        public int MaxRetries { get; set; }
            = 0;

        /// <summary>
        /// The delay before the first retry; it doubles at every retry. 1 second by default.
        /// </summary>
        public System.TimeSpan RetryDelay { get; set; }
            = System.TimeSpan.FromSeconds(1);

        /// <summary>
        /// Whether POST and PATCH requests are retried too. False by default: a POST or a PATCH that reached Vimeo before
        /// the error (for example creating a video) would be executed twice. GET, HEAD, PUT and DELETE are always retried.
        /// </summary>
        public bool RetryNonIdempotentMethods { get; set; }
            = false;
    }
}
