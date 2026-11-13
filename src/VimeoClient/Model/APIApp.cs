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

namespace Mafesoft.VimeoClient.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Return an OpenAPI specification.
    /// </summary>
    public class APIApp
    {
        /// <summary>
        /// The version of the OpenAPI specification.
        /// </summary>
        [JsonPropertyName("openapi")]
        public string OpenAPI { get; set; }

        /// <summary>
        /// The information about the API.
        /// </summary>
        [JsonPropertyName("info")]
        public Info Info { get; set; }
    }

    /// <summary>
    /// The information about the API in the OpenAPI specification.
    /// </summary>
    public class Info
    {
        /// <summary>
        /// The title of the API.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The description of the API.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The version of the API.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// The contact information of the API.
        /// </summary>
        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }
    }

    /// <summary>
    /// The contact information of the API in the OpenAPI specification.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// The contact URL.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}