
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
    public class UserEditParameters
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
    }
}