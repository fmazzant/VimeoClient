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
    /// The file representation (a generic file stored in a folder) consists of the following fields.
    /// The fields not mapped by the library are available in <see cref="AdditionalData"/>.
    /// </summary>
    public class VimeoFile
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
        /// The description of the file.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// A signed URL to download the original file, when the current user is allowed to.
        /// </summary>
        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        [JsonPropertyName("file_size")]
        public long? FileSize { get; set; }

        /// <summary>
        /// The pixel height of the file, for images.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

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
        /// The folder that contains the file.
        /// </summary>
        [JsonPropertyName("parent_folder")]
        public Project ParentFolder { get; set; }

        /// <summary>
        /// The privacy of the file: nobody, password, team, unlisted.
        /// </summary>
        [JsonPropertyName("privacy")]
        public string Privacy { get; set; }

        /// <summary>
        /// The public identifier of the file.
        /// </summary>
        [JsonPropertyName("public_id")]
        public string PublicId { get; set; }

        /// <summary>
        /// The image that represents the file.
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public Picture Thumbnail { get; set; }

        /// <summary>
        /// The upload state of the file: complete, failed, uploading.
        /// </summary>
        [JsonPropertyName("upload_state")]
        public string UploadState { get; set; }

        /// <summary>
        /// The file's uploader.
        /// </summary>
        [JsonPropertyName("uploader")]
        public User Uploader { get; set; }

        /// <summary>
        /// The URI of the file.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The pixel width of the file, for images.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library (metadata, upload, deleted_by...).
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }
}
