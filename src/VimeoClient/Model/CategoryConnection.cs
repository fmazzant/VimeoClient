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
    public class CategoryConnection
    {
        /// <summary>
        /// Information about the channels related to this category.
        /// </summary>
        [JsonPropertyName("channels")]
        public CategoryConnectionEntityChannel Channel { get; set; }

        /// <summary>
        /// Information about the groups related to this category.
        /// </summary>
        [JsonPropertyName("groups")]
        public CategoryConnectionEntityGroup Group { get; set; }

        /// <summary>
        /// Information about the users related to this category.
        /// </summary>
        [JsonPropertyName("users")]
        public CategoryConnectionEntityUser User { get; set; }

        /// <summary>
        /// Information about the videos related to this category.
        /// </summary>
        [JsonPropertyName("videos")]
        public CategoryConnectionEntityVideo Video { get; set; }
    }

    /// <summary>
    /// Information about the channels related to this category.
    /// </summary>
    public class CategoryConnectionEntityChannel : GenericRelatedEntity { }

    /// <summary>
    /// Information about the groups related to this category.
    /// </summary>
    public class CategoryConnectionEntityGroup : GenericRelatedEntity { }

    /// <summary>
    /// Information about the users related to this category.
    /// </summary>
    public class CategoryConnectionEntityUser : GenericRelatedEntity { }

    /// <summary>
    /// Information about the videos related to this category.
    /// </summary>
    public class CategoryConnectionEntityVideo : GenericRelatedEntity { }
}