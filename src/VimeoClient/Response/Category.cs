namespace VimeoClient.Response
{
    using System;

    public class Category
    {
        public Icon icon { get; set; }
        public DateTime last_video_featured_time { get; set; }
        public string link { get; set; }
        public string name { get; set; }
        public Picture pictures { get; set; }
        public string resource_key { get; set; }
        public bool top_level { get; set; }
        public string uri { get; set; }
    }

    public class Icon
    {
        public bool active { get; set; }
        public string link { get; set; }
        public string resource_key { get; set; }
        public Size[] sizes { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Size
    {
        public int height { get; set; }
        public string link { get; set; }
        public string link_with_play_button { get; set; }
        public int width { get; set; }
    }

}