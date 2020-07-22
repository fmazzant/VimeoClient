﻿/// <summary>
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
        public string available_for_hire { get; set; }
        public string bio { get; set; }
        public string content_filter { get; set; }
        public string gender { get; set; }
        public string link { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string grid { get; set; }
        public string masonry { get; set; }
        public string profile_preferences { get; set; }
        public string videos_privacy_add { get; set; }
        public string videos_privacy_comments { get; set; }
        public string anybody { get; set; }
        public string contacts { get; set; }
        public string nobody { get; set; }
        public string videos_privacy_embed { get; set; }
        public string whitelist { get; set; }
        public string videos_privacy_view { get; set; }
        public string disable { get; set; }
        public string unlisted { get; set; }
        public string users { get; set; }
        public string videos_privacy_download { get; internal set; }
    }
}