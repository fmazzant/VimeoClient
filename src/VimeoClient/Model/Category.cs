namespace VimeoClient.Model
{
    using System.Collections.Generic;

    public class Category
    {
        public string uri { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string parent { get; set; }
        public bool top_level { get; set; }
        public Pictures pictures { get; set; }
        public string last_video_featured_time { get; set; }
        public AlbumMetadata metadata { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
        public List<Subcategory> subcategories { get; set; }
        public Pictures icon { get; set; }
    }
}