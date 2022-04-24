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

namespace VimeoClient
{
    /// <summary>
    /// Scope
    /// </summary>
    public static class VimeoScope
    {
        /// <summary>
        /// Access public member data.
        /// </summary>
        public const string PUBLIC = "public";

        /// <summary>
        /// Access private member data.
        /// </summary>
        public const string PRIVATE = "private";

        /// <summary>
        /// Access a member's Vimeo On Demand purchase history.
        /// </summary>
        public const string PURCHASED = "purchased";

        /// <summary>
        /// Create new Vimeo resources like showcases, groups, channels, and portfolios.To create new videos, you need the upload scope.
        /// </summary>
        public const string CREATE = "create";

        /// <summary>
        /// Edit existing Vimeo resources, including videos.
        /// </summary>
        public const string EDIT = "edit";

        /// <summary>
        /// Delete existing Vimeo resources, including videos.
        /// </summary>
        public const string DELETE = "delete";

        /// <summary>
        /// Interact with Vimeo resources, such as liking a video or following a member.
        /// </summary>
        public const string INTERACT = "interact";

        /// <summary>
        /// Upload videos.
        /// </summary>
        public const string PUBUPLOAD = "upload";

        /// <summary>
        /// Add, remove, and review Vimeo On Demand promotions.
        /// </summary>
        public const string PROMO_CODES = "promo_codes";

        /// <summary>
        /// Access video files belonging to members with Vimeo Pro membership or higher.
        /// </summary>
        public const string VIDEO_FILES = "video_files";// 
    }
}