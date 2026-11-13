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

namespace Mafesoft.VimeoClient.Body.Folder
{
    using System.Collections.Generic;

    /// <summary>
    /// The user preferences of the Slack channel
    /// </summary>
    public enum FolderUserPreference
    {
        /// <summary>User preferences for collection change notifications.</summary>
        COLLECTION_CHANGE,
        /// <summary>User preferences for privacy change notifications.</summary>
        PRIVACY_CHANGE,
        /// <summary>User preferences for review page notifications.</summary>
        REVIEW_PAGE,
        /// <summary>User preferences for video detail notifications.</summary>
        VIDEO_DETAIL,
    }

    /// <summary>
    /// The language preference of the Slack channel
    /// </summary>
    public enum FolderLanguagePreference
    {
        /// <summary>The language preference is German.</summary>
        de_DE,
        /// <summary>The language preference is English.</summary>
        en,
        /// <summary>The language preference is Spanish.</summary>
        es,
        /// <summary>The language preference is French.</summary>
        fr_FR,
        /// <summary>The language preference is Japanese.</summary>
        ja_JP,
        /// <summary>The language preference is Korean.</summary>
        ko_KR,
        /// <summary>The language preference is Brazilian Portuguese.</summary>
        pt_BR,
    }

    /// <summary>
    /// Body Folder Edit Parameters
    /// </summary>
    public class FolderEditParameters : IEditParameters
    {
        /// <summary>
        /// The name of the folder.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URI of the parent folder (only on create). Use it to create a subfolder.
        /// </summary>
        public string ParentFolderUri { get; set; }

        /// <summary>
        /// The ID of the Slack incoming webhook.
        /// </summary>
        public int? IncomingWebhooksId { get; set; }

        /// <summary>
        /// The language preference of the Slack channel.
        /// </summary>
        public FolderLanguagePreference? LanguagePreferences { get; set; }

        /// <summary>
        /// The user preferences of the Slack channel.
        /// </summary>
        public List<FolderUserPreference> UserPreferences { get; set; }
            = new List<FolderUserPreference>();

        /// <summary>
        /// Convert object to key value pair enumerable.
        /// Only the values that are set are sent to Vimeo.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(Name))
            {
                dict.Add("name", Name);
            }
            if (!string.IsNullOrEmpty(ParentFolderUri))
            {
                dict.Add("parent_folder_uri", ParentFolderUri);
            }
            if (IncomingWebhooksId.HasValue)
            {
                dict.Add("slack_incoming_webhooks_id", IncomingWebhooksId.Value.ToString());
            }
            if (LanguagePreferences.HasValue)
            {
                dict.Add("slack_language_preference", LanguagePreferences.Value.ToString().Replace("_", "-"));
            }
            if (UserPreferences != null && UserPreferences.Count > 0)
            {
                dict.Add("slack_user_preferences", string.Join(",", UserPreferences));
            }

            return dict;
        }
    }
}
