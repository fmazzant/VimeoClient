namespace VimeoClient.Model
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Category
    {
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("parent")]
        public string Parent { get; set; }

        [JsonPropertyName("top_level")]
        public bool TopLevel { get; set; }

        [JsonPropertyName("pictures")]
        public Pictures Pictures { get; set; }

        [JsonPropertyName("last_video_featured_time")]
        public string LastVideoFeaturedTime { get; set; }

        [JsonPropertyName("metadata")]
        public AlbumMetadata Metadata { get; set; }

        [JsonPropertyName("options")]
        public List<string> Options { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("subcategories")]
        public List<Subcategory> SubCategories { get; set; }

        [JsonPropertyName("icon")]
        public Pictures Icon { get; set; }
    }
}