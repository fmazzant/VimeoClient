
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
namespace Mafesoft.VimeoClient.Body
{
    /// <summary>
    /// User Edit Parameters
    /// </summary>
    public class UserEditParameters
    {
        /// <summary>Whether the user is available for hire (available_for_hire).</summary>
        public string AvailableForHire { get; set; }
        /// <summary>The user's bio (bio).</summary>
        public string Bio { get; set; }
        /// <summary>The user's content filters (content_filter).</summary>
        public string ContentFilter { get; set; }
        /// <summary>The user's gender (gender).</summary>
        public string Gender { get; set; }
        /// <summary>The user's custom Vimeo URL (link).</summary>
        public string Link { get; set; }
        /// <summary>The user's display name (name).</summary>
        public string Name { get; set; }
        /// <summary>The password for the user's videos (password).</summary>
        public string Password { get; set; }
        /// <summary>The grid layout of the user's profile (grid).</summary>
        public string Grid { get; set; }
        /// <summary>The masonry layout of the user's profile (masonry).</summary>
        public string Masonry { get; set; }
        /// <summary>The preferences of the user's profile (profile_preferences).</summary>
        public string ProfilePreferences { get; set; }
        /// <summary>Whether other users can add the user's videos (videos.privacy.add).</summary>
        public string VideosPrivacyAdd { get; set; }
        /// <summary>Who can comment on the user's videos (videos.privacy.comments).</summary>
        public string VideosPrivacyComments { get; set; }
        /// <summary>The anybody privacy option (anybody).</summary>
        public string Anybody { get; set; }
        /// <summary>The contacts privacy option (contacts).</summary>
        public string Contacts { get; set; }
        /// <summary>The nobody privacy option (nobody).</summary>
        public string Nobody { get; set; }
        /// <summary>Where the user's videos can be embedded (videos.privacy.embed).</summary>
        public string VideosPrivacyEmbed { get; set; }
        /// <summary>The whitelist privacy option (whitelist).</summary>
        public string Whitelist { get; set; }
        /// <summary>Who can view the user's videos (videos.privacy.view).</summary>
        public string VideosPrivacyView { get; set; }
        /// <summary>The disable privacy option (disable).</summary>
        public string Disable { get; set; }
        /// <summary>The unlisted privacy option (unlisted).</summary>
        public string Unlisted { get; set; }
        /// <summary>The users privacy option (users).</summary>
        public string Users { get; set; }
        /// <summary>Whether the user's videos can be downloaded (videos.privacy.download).</summary>
        public string VideosPrivacyDownload { get; internal set; }
    }
}