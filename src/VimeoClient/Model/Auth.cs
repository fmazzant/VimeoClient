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
///

namespace VimeoClient.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The auth representation consists of the following fields.
    /// </summary>
    public class Auth
    {
        /// <summary>
        /// The access token string.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The API application associated with the token.
        /// </summary>
        [JsonPropertyName("app")]
        public APIApp App { get; set; }

        /// <summary>
        /// The token's expiration date.
        /// </summary>
        [JsonPropertyName("expires_on")]
        public string ExpiresOn { get; set; }

        /// <summary>
        /// The refresh token string.
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// The scope or scopes that the token supports.
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// The token type.
        /// bearer - The token is of the bearer type.
        /// </summary>
        [JsonPropertyName("token_type")]
        public string token_type { get; set; }

        /// <summary>
        /// The user associated with the token.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}