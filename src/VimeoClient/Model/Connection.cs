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

namespace VimeoClient.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A collection of information that is connected to this resource.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Information about the channels related to this category.
        /// </summary>
        [JsonPropertyName("channels")]
        public ConnectionEntityChannel Channel { get; set; }

        /// <summary>
        /// Information about the groups related to this category.
        /// </summary>
        [JsonPropertyName("groups")]
        public ConnectionEntityGroup Group { get; set; }

        /// <summary>
        /// Information about the users related to this category.
        /// </summary>
        [JsonPropertyName("users")]
        public ConnectionEntityUser User { get; set; }

        /// <summary>
        /// Information about the videos related to this category.
        /// </summary>
        [JsonPropertyName("videos")]
        public ConnectionEntityVideo Video { get; set; }
    }

    /// <summary>
    /// A collection of information
    /// </summary>
    public class ConnectionEntity
    {
        /// <summary>
        /// An array of HTTP methods permitted on this URI.
        /// </summary>
        [JsonPropertyName("options")]
        public string[] Options { get; set; }

        /// <summary>
        /// The total number of entities on this connection.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// The API URI that resolves to the connection data.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// Information about the channels related to this category.
    /// </summary>
    public class ConnectionEntityChannel : ConnectionEntity { }

    /// <summary>
    /// Information about the groups related to this category.
    /// </summary>
    public class ConnectionEntityGroup : ConnectionEntity { }

    /// <summary>
    /// Information about the users related to this category.
    /// </summary>
    public class ConnectionEntityUser : ConnectionEntity { }

    /// <summary>
    /// Information about the videos related to this category.
    /// </summary>
    public class ConnectionEntityVideo : ConnectionEntity { }
}