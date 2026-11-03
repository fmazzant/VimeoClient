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

namespace VimeoClient.Body.Video
{
    using System.Collections.Generic;

    /// <summary>
    /// Who can view the video.
    /// </summary>
    public enum VideoPrivacyView
    {
        /// <summary>
        /// Anyone can view the video.
        /// </summary>
        anybody,

        /// <summary>
        /// Only contacts can view the video (deprecated).
        /// </summary>
        contacts,

        /// <summary>
        /// The video is hidden from Vimeo and can be embedded only.
        /// </summary>
        disable,

        /// <summary>
        /// Only the owner can view the video.
        /// </summary>
        nobody,

        /// <summary>
        /// Only people with the password can view the video.
        /// </summary>
        password,

        /// <summary>
        /// Only people with the private link can view the video.
        /// </summary>
        unlisted,

        /// <summary>
        /// Only Vimeo members can view the video (deprecated).
        /// </summary>
        users,
    }

    /// <summary>
    /// The video's embed permission setting.
    /// </summary>
    public enum VideoPrivacyEmbed
    {
        /// <summary>
        /// The video can't be embedded.
        /// </summary>
        @private,

        /// <summary>
        /// The video can be embedded anywhere.
        /// </summary>
        @public,

        /// <summary>
        /// The video can be embedded only on the domains of the whitelist.
        /// </summary>
        whitelist,
    }

    /// <summary>
    /// Who can comment on the video.
    /// </summary>
    public enum VideoPrivacyComments
    {
        /// <summary>
        /// Anyone can comment on the video.
        /// </summary>
        anybody,

        /// <summary>
        /// Only contacts can comment on the video.
        /// </summary>
        contacts,

        /// <summary>
        /// No one can comment on the video.
        /// </summary>
        nobody,
    }

    /// <summary>
    /// The upload approach.
    /// </summary>
    public enum VideoUploadApproach
    {
        /// <summary>
        /// The post approach (HTML form).
        /// </summary>
        post,

        /// <summary>
        /// The pull approach (Vimeo downloads the file from a link).
        /// </summary>
        pull,

        /// <summary>
        /// The streaming approach (deprecated).
        /// </summary>
        streaming,

        /// <summary>
        /// The resumable tus approach.
        /// </summary>
        tus,
    }

    /// <summary>
    /// The type of the text track.
    /// </summary>
    public enum TextTrackType
    {
        /// <summary>
        /// The text track is captions.
        /// </summary>
        captions,

        /// <summary>
        /// The text track is chapters.
        /// </summary>
        chapters,

        /// <summary>
        /// The text track is descriptions.
        /// </summary>
        descriptions,

        /// <summary>
        /// The text track is metadata.
        /// </summary>
        metadata,

        /// <summary>
        /// The text track is subtitles.
        /// </summary>
        subtitles,
    }

    /// <summary>
    /// Helpers used by the video's bodies
    /// </summary>
    internal static class VideoParametersHelper
    {
        /// <summary>
        /// Adds the value to the dictionary only when it is set.
        /// </summary>
        public static void AddIfSet(this Dictionary<string, string> dict, string key, object value)
        {
            var vimeoValue = VimeoRestBuilderExtensions.ToVimeoValue(value);
            if (vimeoValue != null)
            {
                dict.Add(key, vimeoValue);
            }
        }

        /// <summary>
        /// Adds the value to the JSON payload only when it is set.
        /// A dotted key (privacy.view) becomes a nested object.
        /// </summary>
        public static void AddIfSet(this Dictionary<string, object> payload, string key, object value)
        {
            if (value == null)
            {
                return;
            }

            if (value is System.Enum)
            {
                value = VimeoRestBuilderExtensions.ToVimeoValue(value);
            }

            var keys = key.Split('.');
            var current = payload;
            for (int i = 0; i < keys.Length - 1; i++)
            {
                if (!current.TryGetValue(keys[i], out var child) || !(child is Dictionary<string, object>))
                {
                    child = new Dictionary<string, object>();
                    current[keys[i]] = child;
                }
                current = (Dictionary<string, object>)child;
            }
            current[keys[keys.Length - 1]] = value;
        }
    }

    /// <summary>
    /// The video edit object.
    /// </summary>
    public class VideoEditParameters : IEditParameters
    {
        /// <summary>
        /// The title of the video.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the video.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Creative Commons license: by, by-nc, by-nc-nd, by-nc-sa, by-nd, by-sa, cc0.
        /// </summary>
        public string License { get; set; }

        /// <summary>
        /// The video's default language.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// The password. Required only when PrivacyView is password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// A list of values describing the content in this video.
        /// </summary>
        public string[] ContentRating { get; set; }

        /// <summary>
        /// Who can view the video.
        /// </summary>
        public VideoPrivacyView? PrivacyView { get; set; }

        /// <summary>
        /// The video's embed permission setting.
        /// </summary>
        public VideoPrivacyEmbed? PrivacyEmbed { get; set; }

        /// <summary>
        /// Who can comment on the video.
        /// </summary>
        public VideoPrivacyComments? PrivacyComments { get; set; }

        /// <summary>
        /// Whether a user can add the video to a showcase, channel, or group.
        /// </summary>
        public bool? PrivacyAdd { get; set; }

        /// <summary>
        /// Whether a user can download the video.
        /// </summary>
        public bool? PrivacyDownload { get; set; }

        /// <summary>
        /// Whether to enable video review.
        /// </summary>
        public bool? ReviewPageActive { get; set; }

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.AddIfSet("name", Name);
            dict.AddIfSet("description", Description);
            dict.AddIfSet("license", License);
            dict.AddIfSet("locale", Locale);
            dict.AddIfSet("password", Password);
            dict.AddIfSet("content_rating", ContentRating);
            dict.AddIfSet("privacy.view", PrivacyView);
            dict.AddIfSet("privacy.embed", PrivacyEmbed);
            dict.AddIfSet("privacy.comments", PrivacyComments);
            dict.AddIfSet("privacy.add", PrivacyAdd);
            dict.AddIfSet("privacy.download", PrivacyDownload);
            dict.AddIfSet("review_page.active", ReviewPageActive);

            return dict;
        }

        /// <summary>
        /// Convert object to the JSON payload expected by Vimeo
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToPayload()
        {
            Dictionary<string, object> payload = new Dictionary<string, object>();

            payload.AddIfSet("name", Name);
            payload.AddIfSet("description", Description);
            payload.AddIfSet("license", License);
            payload.AddIfSet("locale", Locale);
            payload.AddIfSet("password", Password);
            payload.AddIfSet("content_rating", ContentRating);
            payload.AddIfSet("privacy.view", PrivacyView);
            payload.AddIfSet("privacy.embed", PrivacyEmbed);
            payload.AddIfSet("privacy.comments", PrivacyComments);
            payload.AddIfSet("privacy.add", PrivacyAdd);
            payload.AddIfSet("privacy.download", PrivacyDownload);
            payload.AddIfSet("review_page.active", ReviewPageActive);

            return payload;
        }
    }

    /// <summary>
    /// The video upload object.
    /// </summary>
    public class VideoUploadParameters : IEditParameters
    {
        /// <summary>
        /// The upload approach.
        /// </summary>
        public VideoUploadApproach Approach { get; set; } = VideoUploadApproach.tus;

        /// <summary>
        /// The size in bytes of the video file. Required for the tus and post approaches.
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// The public URL of the video file. Required for the pull approach.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// The app's redirect URL. Required for the post approach.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The title of the video.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the video.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Who can view the video.
        /// </summary>
        public VideoPrivacyView? PrivacyView { get; set; }

        /// <summary>
        /// The URI of the folder to which the video is uploaded.
        /// </summary>
        public string FolderUri { get; set; }

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.AddIfSet("upload.approach", Approach);
            dict.AddIfSet("upload.size", Size);
            dict.AddIfSet("upload.link", Link);
            dict.AddIfSet("upload.redirect_url", RedirectUrl);
            dict.AddIfSet("name", Name);
            dict.AddIfSet("description", Description);
            dict.AddIfSet("privacy.view", PrivacyView);
            dict.AddIfSet("folder_uri", FolderUri);

            return dict;
        }

        /// <summary>
        /// Convert object to the JSON payload expected by Vimeo
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToPayload()
        {
            Dictionary<string, object> payload = new Dictionary<string, object>();

            payload.AddIfSet("upload.approach", Approach);
            payload.AddIfSet("upload.size", Size);
            payload.AddIfSet("upload.link", Link);
            payload.AddIfSet("upload.redirect_url", RedirectUrl);
            payload.AddIfSet("name", Name);
            payload.AddIfSet("description", Description);
            payload.AddIfSet("privacy.view", PrivacyView);
            payload.AddIfSet("folder_uri", FolderUri);

            return payload;
        }
    }

    /// <summary>
    /// The video version object.
    /// </summary>
    public class VideoVersionParameters : IEditParameters
    {
        /// <summary>
        /// The name of the file to upload.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The upload approach.
        /// </summary>
        public VideoUploadApproach? Approach { get; set; }

        /// <summary>
        /// The size in bytes of the video file.
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// The public URL of the video file (pull approach).
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Whether this version is the active one (edit only).
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.AddIfSet("file_name", FileName);
            dict.AddIfSet("upload.approach", Approach);
            dict.AddIfSet("upload.size", Size);
            dict.AddIfSet("upload.link", Link);
            dict.AddIfSet("active", Active);

            return dict;
        }

        /// <summary>
        /// Convert object to the JSON payload expected by Vimeo
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToPayload()
        {
            Dictionary<string, object> payload = new Dictionary<string, object>();

            payload.AddIfSet("file_name", FileName);
            payload.AddIfSet("upload.approach", Approach);
            payload.AddIfSet("upload.size", Size);
            payload.AddIfSet("upload.link", Link);
            payload.AddIfSet("active", Active);

            return payload;
        }
    }

    /// <summary>
    /// The text track edit object.
    /// </summary>
    public class TextTrackParameters : IEditParameters
    {
        /// <summary>
        /// Whether the text track is active.
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// The language code of the text track.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The name of the text track.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the text track.
        /// </summary>
        public TextTrackType? Type { get; set; }

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.AddIfSet("active", Active);
            dict.AddIfSet("language", Language);
            dict.AddIfSet("name", Name);
            dict.AddIfSet("type", Type);

            return dict;
        }
    }

    /// <summary>
    /// The credit edit object.
    /// </summary>
    public class CreditParameters : IEditParameters
    {
        /// <summary>
        /// The email address of the credited person.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The name of the credited person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The role of the credited person.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The Vimeo URI of the credited person.
        /// </summary>
        public string UserUri { get; set; }

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.AddIfSet("email", Email);
            dict.AddIfSet("name", Name);
            dict.AddIfSet("role", Role);
            dict.AddIfSet("user_uri", UserUri);

            return dict;
        }
    }

    /// <summary>
    /// The thumbnail edit object.
    /// </summary>
    public class ThumbnailParameters : IEditParameters
    {
        /// <summary>
        /// Whether the image is the video's active thumbnail.
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// The time offset in seconds from which to create the thumbnail (create only).
        /// </summary>
        public double? Time { get; set; }

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.AddIfSet("active", Active);
            dict.AddIfSet("time", Time);

            return dict;
        }
    }
}
