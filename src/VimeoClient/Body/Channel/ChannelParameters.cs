namespace VimeoClient.Body.Channel
{
    using System.Collections.Generic;

    /// <summary>
    /// The privacy level of the channel.Option descriptions:
    ///     anybody - Anyone can access the channel.
    ///     moderators - Only moderators can access the channel.
    ///     user - Only moderators and designated users can access the channel.
    /// </summary>
    public enum ChannelVimeoPrivacy
    {
        /// <summary>
        /// Anyone can access the channel
        /// </summary>
        anybody,

        /// <summary>
        /// Only moderators can access the channel
        /// </summary>
        moderators,

        /// <summary>
        /// Only moderators and designated users can access the channel
        /// </summary>
        user
    }

    /// <summary>
    /// 
    /// </summary>
    public class ChannelEditParameters
    {
        public string name { get; set; }
        public ChannelVimeoPrivacy privacy { get; set; }
        public string description { get; set; }
        public string link { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("name", this.name);
            dict.Add("privacy", this.privacy.ToString());

            if (string.IsNullOrEmpty(this.description))
                dict.Add("description", this.description);

            if (string.IsNullOrEmpty(this.link))
                dict.Add("link", this.link);

            return dict;
        }
    }
}