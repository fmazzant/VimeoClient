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
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// File (Vimeo schema: file).
    /// </summary>
    public class HostedFile
    {
        /// <summary>
        /// Whether viewers are allowed to download the file.
        /// </summary>
        [JsonPropertyName("allow_downloads")]
        public bool? AllowDownloads { get; set; }

        /// <summary>
        /// Whether the current user can delete the file.
        /// </summary>
        [JsonPropertyName("can_user_delete")]
        public bool? CanUserDelete { get; set; }

        /// <summary>
        /// Whether the current user can edit the file.
        /// </summary>
        [JsonPropertyName("can_user_edit")]
        public bool? CanUserEdit { get; set; }

        /// <summary>
        /// Whether the current user can view the file.
        /// </summary>
        [JsonPropertyName("can_user_view")]
        public bool? CanUserView { get; set; }

        /// <summary>
        /// The IANA media type of the file.
        /// </summary>
        [JsonPropertyName("content_type")]
        public string ContentType { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the file was uploaded.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// The user who deleted this file. Null when the file was deleted by its owner, isn't in Recently Deleted, or was moved to permanent deletion.
        /// </summary>
        [JsonPropertyName("deleted_by")]
        public HostedFileDeletedBy DeletedBy { get; set; }

        /// <summary>
        /// The description of the file. A Quill Delta JSON string when rich text is enabled.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// A signed URL to download the original file, when the current user is allowed to download it.
        /// </summary>
        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        [JsonPropertyName("file_size")]
        public long? FileSize { get; set; }

        /// <summary>
        /// The pixel height of the file, for visual items (images) where it is known.
        /// </summary>
        [JsonPropertyName("height")]
        public double? Height { get; set; }

        /// <summary>
        /// Whether the file has been frozen in cold storage.
        /// </summary>
        [JsonPropertyName("is_cold_storage")]
        public bool? IsColdStorage { get; set; }

        /// <summary>
        /// Whether the file is in the owner's Recently Deleted bin.
        /// </summary>
        [JsonPropertyName("is_recently_deleted")]
        public bool? IsRecentlyDeleted { get; set; }

        /// <summary>
        /// -
        /// </summary>
        [JsonPropertyName("metadata")]
        public HostedFileMetadata Metadata { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the file was last modified.
        /// </summary>
        [JsonPropertyName("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// The display name of the file.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The folder that contains the file, when the file lives inside a folder.
        /// </summary>
        [JsonPropertyName("parent_folder")]
        public HostedFileParentFolder ParentFolder { get; set; }

        /// <summary>
        /// The password required to view the file. Only returned to the owner or a user with edit access, and only when **privacy** is `password`.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// The privacy of the file.
        /// </summary>
        [JsonPropertyName("privacy")]
        public string Privacy { get; set; }

        /// <summary>
        /// The public identifier of the file.
        /// </summary>
        [JsonPropertyName("public_id")]
        public string PublicId { get; set; }

        /// <summary>
        /// The image that represents the file in a library, when one has been generated.
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public HostedFileThumbnail Thumbnail { get; set; }

        /// <summary>
        /// The file's upload information.
        /// </summary>
        [JsonPropertyName("upload")]
        public HostedFileUpload Upload { get; set; }

        /// <summary>
        /// The upload state of the file.
        /// </summary>
        [JsonPropertyName("upload_state")]
        public string UploadState { get; set; }

        /// <summary>
        /// The file's uploader.
        /// </summary>
        [JsonPropertyName("uploader")]
        public HostedFileUploader Uploader { get; set; }

        /// <summary>
        /// The URI of the file.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The pixel width of the file, for visual items (images) where it is known.
        /// </summary>
        [JsonPropertyName("width")]
        public double? Width { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// The file's uploader.
    /// </summary>
    public class HostedFileUploader
    {
        /// <summary>
        /// The profile link of the user who uploaded the file.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The display name of the user who uploaded the file.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The active portrait of the user who uploaded the file.
        /// </summary>
        [JsonPropertyName("pictures")]
        public Picture Pictures { get; set; }
    }

    /// <summary>
    /// The file's upload information.
    /// </summary>
    public class HostedFileUpload
    {
        /// <summary>
        /// The approach for uploading the file.
        /// </summary>
        [JsonPropertyName("approach")]
        public string Approach { get; set; }

        /// <summary>
        /// The error that caused the upload to fail.
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; }

        /// <summary>
        /// The HTML form for uploading a file through the POST approach.
        /// </summary>
        [JsonPropertyName("form")]
        public string Form { get; set; }

        /// <summary>
        /// The file size in bytes.
        /// </summary>
        [JsonPropertyName("size")]
        public long? Size { get; set; }

        /// <summary>
        /// The status of the file upload.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The link for sending file data.
        /// </summary>
        [JsonPropertyName("upload_link")]
        public string UploadLink { get; set; }
    }

    /// <summary>
    /// The image that represents the file in a library, when one has been generated.
    /// </summary>
    public class HostedFileThumbnail
    {
        /// <summary>
        /// The URL of the thumbnail image on the Vimeo CDN.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// The folder that contains the file, when the file lives inside a folder.
    /// </summary>
    public class HostedFileParentFolder
    {
        /// <summary>
        /// Whether the parent folder is a private-to-me folder for the current user.
        /// </summary>
        [JsonPropertyName("is_private_to_user")]
        public bool? IsPrivateToUser { get; set; }

        /// <summary>
        /// The display name of the parent folder.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The API URI of the parent folder.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// HostedFileMetadata
    /// </summary>
    public class HostedFileMetadata
    {
        /// <summary>
        /// -
        /// </summary>
        [JsonPropertyName("connections")]
        public HostedFileMetadataConnections Connections { get; set; }
    }

    /// <summary>
    /// HostedFileMetadataConnections
    /// </summary>
    public class HostedFileMetadataConnections
    {
        /// <summary>
        /// Information about the file's ancestry, ordered from the direct parent folder to higher-level ancestors.
        /// </summary>
        [JsonPropertyName("ancestor_path")]
        public HostedFileMetadataConnectionsAncestorPathItem[] AncestorPath { get; set; }
    }

    /// <summary>
    /// Ancestor Path
    /// </summary>
    public class HostedFileMetadataConnectionsAncestorPathItem
    {
        /// <summary>
        /// The link to the folder.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The name of the folder.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// The user who deleted this file. Null when the file was deleted by its owner, isn't in Recently Deleted, or was moved to permanent deletion.
    /// </summary>
    public class HostedFileDeletedBy
    {
        /// <summary>
        /// The display name of the user who deleted the file.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The portrait of the user who deleted the file.
        /// </summary>
        [JsonPropertyName("pictures")]
        public Picture Pictures { get; set; }

        /// <summary>
        /// The URI of the user who deleted the file.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}
