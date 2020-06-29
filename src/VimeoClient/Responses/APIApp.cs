namespace VimeoClient.Response
{
    public class APIApp
    {
        public string openapi { get; set; }
        public Info info { get; set; }
    }

    public class Info
    {
        public string title { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public Contact contact { get; set; }
    }

    public class Contact
    {
        public string url { get; set; }
    }
}