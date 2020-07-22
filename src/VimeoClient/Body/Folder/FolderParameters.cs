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

namespace VimeoClient.Body.Folder
{
    using System.Collections.Generic;

    /// <summary>
    /// The user preferences of the Slack channel
    /// </summary>
    public enum FolderUserPreference
    {
        COLLECTION_CHANGE,// - User preferences for collection change notifications.
        PRIVACY_CHANGE,// - User preferences for privacy change notifications.
        REVIEW_PAGE,// - User preferences for review page notifications.
        VIDEO_DETAIL,// - User preferences for video detail notifications.
    }

    /// <summary>
    /// The language preference of the Slack channel
    /// </summary>
    public enum FolderLanguagePreference
    {
        de_DE,// - The language preference is German.
        en,// - The language preference is English.
        es,// - The language preference is Spanish.
        fr_FR,// - The language preference is French.
        ja_JP,// - The language preference is Japanese.
        ko_KR,// - The language preference is Korean.
        pt_BR,// - The language preference is Brazilian Portuguese.
    }

    /// <summary>
    /// Body Folder Edit Parameters
    /// </summary>
    public class FolderEditParameters : IEditParameters
    {
        public string Name { get; set; }
        public int IncomingWebhooksId { get; set; }
        public FolderLanguagePreference LanguagePreferences { get; set; } = FolderLanguagePreference.en;

        public List<FolderUserPreference> UserPreferences { get; set; }
            = new List<FolderUserPreference>();

        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("name", this.Name);
            dict.Add("slack_incoming_webhooks_id", IncomingWebhooksId.ToString());
            dict.Add("slack_language_preference", LanguagePreferences.ToString().Replace("_", "-"));
            dict.Add("slack_user_preferences", string.Join(",", UserPreferences));

            return dict;
        }
    }
}
