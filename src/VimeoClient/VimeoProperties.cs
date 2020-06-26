namespace VimeoClient
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class VimeoProperties
    {
        /// <summary>
        /// 
        /// </summary>
        public string ClientId { get; set; }
         = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ClientSecret { get; set; }
         = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string AccessToken { get; set; }
            = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public List<string> ValidCertificates { get; set; }
            = new List<string>();

        /// <summary>
        /// https://api.vimeo.com
        /// </summary>
        public string EndPoint { get; set; }
         = "https://api.vimeo.com";
    }
}
