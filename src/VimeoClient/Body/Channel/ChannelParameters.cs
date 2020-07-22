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
    public class ChannelEditParameters : IEditParameters
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
            dict.Add("description", this.description);
            dict.Add("link", this.link);

            return dict;
        }
    }
}