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

namespace VimeoClient.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The report-reason taxonomy, flattened to a parent-referenced node list
    /// (report-reason-discovery and video-report-reason).
    /// </summary>
    public class ReportReasons
    {
        /// <summary>
        /// The reasons: categories, submittable reasons and external hand-offs.
        /// </summary>
        [JsonPropertyName("reasons")]
        public ReportReasonNode[] Reasons { get; set; }
    }

    /// <summary>
    /// A node of the report-reason taxonomy.
    /// </summary>
    public class ReportReasonNode
    {
        /// <summary>
        /// A human-readable description of the category or leaf, in the requesting user's locale.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// For external-handoff leaves, the dedicated form to use instead of the API.
        /// </summary>
        [JsonPropertyName("external_url")]
        public string ExternalUrl { get; set; }

        /// <summary>
        /// For reason leaves with a gender fork, the distinct variant to submit when the target is a woman or girl.
        /// </summary>
        [JsonPropertyName("gendered")]
        public ReportReasonGenderedVariant Gendered { get; set; }

        /// <summary>
        /// Stable identifier for this node: the opaque reason UUID for a submittable leaf.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The node kind: category, external, reason.
        /// </summary>
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        /// <summary>
        /// The display name for the category or leaf, in the requesting user's locale.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The id of the node this is nested under, or null at the top level.
        /// </summary>
        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }
    }

    /// <summary>
    /// The gendered variant of a report reason.
    /// </summary>
    public class ReportReasonGenderedVariant
    {
        /// <summary>
        /// A human-readable description of the gendered variant.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The display name of the gendered variant.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The opaque reason UUID to submit when the target is a woman or girl.
        /// </summary>
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }
    }

    /// <summary>
    /// The type of content to report.
    /// </summary>
    public enum ReportContentType
    {
        /// <summary>
        /// A comment.
        /// </summary>
        comment,

        /// <summary>
        /// A file.
        /// </summary>
        file,

        /// <summary>
        /// A user.
        /// </summary>
        user,

        /// <summary>
        /// A video.
        /// </summary>
        video
    }
}
