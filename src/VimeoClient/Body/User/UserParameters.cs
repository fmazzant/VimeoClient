
using System.Collections.Generic;
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
namespace VimeoClient.Body
{
    /// <summary>
    /// User Edit Parameters
    /// </summary>
    public class UserEditParameters : IEditParameters
    {
        public string AvailableForHire { get; set; }
        public string Bio { get; set; }
        public string ContentFilter { get; set; }
        public string Gender { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Grid { get; set; }
        public string Masonry { get; set; }
        public string ProfilePreferences { get; set; }
        public string VideosPrivacyAdd { get; set; }
        public string VideosPrivacyComments { get; set; }
        public string Anybody { get; set; }
        public string Contacts { get; set; }
        public string Nobody { get; set; }
        public string VideosPrivacyEmbed { get; set; }
        public string Whitelist { get; set; }
        public string VideosPrivacyView { get; set; }
        public string Disable { get; set; }
        public string Unlisted { get; set; }
        public string Users { get; set; }
        public string VideosPrivacyDownload { get; internal set; }

        /// <summary>
        /// Convert object to key value pair enumerable 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("available_for_hire", this.AvailableForHire);
            dict.Add("bio", this.Bio);
            dict.Add("content_filter", this.ContentFilter);
            dict.Add("gender", this.Gender);
            dict.Add("link", this.Link);
            dict.Add("name", this.Name);
            dict.Add("password", this.Password);
            dict.Add("grid", this.Grid);
            dict.Add("masonry", this.Masonry);
            dict.Add("profile_preferences", this.ProfilePreferences);
            dict.Add("videos_privacy_add", this.VideosPrivacyAdd);
            dict.Add("videos_privacy_comments", this.VideosPrivacyComments);
            dict.Add("anybody", this.Anybody);
            dict.Add("contacts", this.Contacts);
            dict.Add("nobody", this.Nobody);
            dict.Add("videos_privacy_embed", this.VideosPrivacyEmbed);
            dict.Add("whitelist", this.Whitelist);
            dict.Add("videos_privacy_view", this.VideosPrivacyView);
            dict.Add("disable", this.Disable);
            dict.Add("unlisted", this.Unlisted);
            dict.Add("users", this.Users);
            dict.Add("videos_privacy_download", this.VideosPrivacyDownload);

            return dict;
        }
    }
}