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

namespace Mafesoft.VimeoClient.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The folder (project) representation consists of the following fields.
    /// https://developer.vimeo.com/api/reference/folders
    /// </summary>
    public class Project : VimeoIdentity
    {
        /// <summary>
        /// The time in ISO 8601 format when the folder was created.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the user last performed an action on the folder.
        /// </summary>
        [JsonPropertyName("last_user_action_event_date")]
        public string LastUserActionEventDate { get; set; }

        /// <summary>
        /// The URL to access the folder in a browser.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Metadata about the folder.
        /// </summary>
        [JsonPropertyName("metadata")]
        public ProjectMetadata Metadata { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the folder was last modified.
        /// </summary>
        [JsonPropertyName("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// The name of the folder.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The privacy settings of the folder.
        /// </summary>
        [JsonPropertyName("privacy")]
        public ProjectPrivacy Privacy { get; set; }

        /// <summary>
        /// The owner of the folder.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    /// <summary>
    /// The privacy settings of the folder.
    /// </summary>
    public class ProjectPrivacy
    {
        /// <summary>
        /// Who can view the folder (for instance: anybody, nobody, team).
        /// </summary>
        [JsonPropertyName("view")]
        public string View { get; set; }
    }

    /// <summary>
    /// Metadata about the folder.
    /// </summary>
    public class ProjectMetadata
    {
        /// <summary>
        /// A collection of information that is connected to this resource.
        /// </summary>
        [JsonPropertyName("connections")]
        public ProjectConnection Connections { get; set; }
    }

    /// <summary>
    /// A collection of information that is connected to this resource.
    /// </summary>
    public class ProjectConnection
    {
        /// <summary>
        /// Information about the subfolders of the folder.
        /// </summary>
        [JsonPropertyName("folders")]
        public GenericRelatedEntity Folders { get; set; }

        /// <summary>
        /// Information about the items (videos and subfolders) of the folder.
        /// </summary>
        [JsonPropertyName("items")]
        public GenericRelatedEntity Items { get; set; }

        /// <summary>
        /// Information about the parent folder.
        /// </summary>
        [JsonPropertyName("parent_folder")]
        public GenericRelatedEntity ParentFolder { get; set; }

        /// <summary>
        /// Information about the users of the folder.
        /// </summary>
        [JsonPropertyName("users")]
        public GenericRelatedEntity Users { get; set; }

        /// <summary>
        /// Information about the videos of the folder.
        /// </summary>
        [JsonPropertyName("videos")]
        public GenericRelatedEntity Videos { get; set; }
    }
}
