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

    public class Category
    {
        /// <summary>
        /// The active icon for the category.
        /// </summary>
        [JsonPropertyName("icon")]
        public Picture Icon { get; set; }

        /// <summary>
        /// The most recent time in ISO 8601 format when the video was featured.
        /// </summary>
        [JsonPropertyName("last_video_featured_time")]
        public string LastVideoFeaturedTime { get; set; }

        /// <summary>
        /// The URL to access the category in a browser.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Metadata about the category.
        /// </summary>
        [JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        /// <summary>
        /// The display name that identifies the category.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The container of the category's parent category, if the current category is a subcategory.
        /// </summary>
        [JsonPropertyName("parent")]
        public Subcategory Parent { get; set; }

        /// <summary>
        /// The active picture for this category.The default shows vertical color bars.
        /// </summary>
        [JsonPropertyName("pictures")]
        public Picture Pictures { get; set; }

        /// <summary>
        /// The resource key of the category.
        /// </summary>
        [JsonPropertyName("resource_key")]
        public string ResourceKey { get; set; }

        /// <summary>
        /// All the subcategories that belong to the category, if the current category is a top-level parent.
        /// </summary>
        [JsonPropertyName("top_level")]
        public Subcategory[] subcategories { get; set; }

        /// <summary>
        /// Whether the category isn't a subcategory of another category.
        /// </summary>
        [JsonPropertyName("top_level")]
        public bool TopLevel { get; set; }

        /// <summary>
        /// The unique identifier to access the category resource.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}