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

namespace VimeoClient.Body.ShowCase
{
    using System.Collections.Generic;
    using VimeoClient.Filter.ShowCase;

    /// <summary>
    /// The showcase edit object. Used to create or edit a showcase.
    /// Only the values that are set are sent to Vimeo.
    /// </summary>
    public class ShowCaseEditParameters : IEditParameters
    {
        /// <summary>
        /// The name of the showcase. Required when creating a showcase.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The hexadecimal code for the color of the player buttons and showcase controls.
        /// </summary>
        public string BrandColor { get; set; }

        /// <summary>
        /// The description of the showcase.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The custom domain of the showcase.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Whether to hide Vimeo navigation when displaying the showcase.
        /// </summary>
        public bool? HideNav { get; set; }

        /// <summary>
        /// Whether to include the upcoming live event in the showcase.
        /// </summary>
        public bool? HideUpcoming { get; set; }

        /// <summary>
        /// Whether to hide the Vimeo logo in the showcase.
        /// </summary>
        public bool? HideVimeoLogo { get; set; }

        /// <summary>
        /// The type of layout for presenting the showcase.
        /// </summary>
        public ShowCasesLayout? Layout { get; set; }

        /// <summary>
        /// The showcase's password. This field is required only when privacy is password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The privacy level of the showcase.
        /// </summary>
        public ShowCasesPrivacy? Privacy { get; set; }

        /// <summary>
        /// Whether showcase videos use the review mode URL.
        /// </summary>
        public bool? ReviewMode { get; set; }

        /// <summary>
        /// The default sort order of the videos as they appear in the showcase.
        /// </summary>
        public ShowCasesSort? Sort { get; set; }

        /// <summary>
        /// The color theme of the showcase.
        /// </summary>
        public ShowCasesTheme? Theme { get; set; }

        /// <summary>
        /// The custom Vimeo URL of the showcase.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Whether the user has opted in to use a custom domain for the showcase.
        /// </summary>
        public bool? UseCustomDomain { get; set; }

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            Add(dict, "name", Name);
            Add(dict, "brand_color", BrandColor);
            Add(dict, "description", Description);
            Add(dict, "domain", Domain);
            Add(dict, "hide_nav", HideNav);
            Add(dict, "hide_upcoming", HideUpcoming);
            Add(dict, "hide_vimeo_logo", HideVimeoLogo);
            Add(dict, "layout", Layout);
            Add(dict, "password", Password);
            Add(dict, "privacy", Privacy);
            Add(dict, "review_mode", ReviewMode);
            Add(dict, "sort", Sort);
            Add(dict, "theme", Theme);
            Add(dict, "url", Url);
            Add(dict, "use_custom_domain", UseCustomDomain);

            return dict;
        }

        /// <summary>
        /// Adds the value only when it is set
        /// </summary>
        private static void Add(Dictionary<string, string> dict, string key, object value)
        {
            var vimeoValue = VimeoRestBuilderExtensions.ToVimeoValue(value);
            if (!string.IsNullOrEmpty(vimeoValue))
            {
                dict.Add(key, vimeoValue);
            }
        }
    }
}
