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
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Team Role (Vimeo schema: team-role).
    /// </summary>
    public class TeamRole
    {
        /// <summary>
        /// The applicable permission policies for the role.
        /// </summary>
        [JsonPropertyName("applicable_permission_policies")]
        public TeamRoleApplicablePermissionPolicies ApplicablePermissionPolicies { get; set; }

        /// <summary>
        /// The total number of team members with this role.
        /// </summary>
        [JsonPropertyName("count")]
        public long? Count { get; set; }

        /// <summary>
        /// The translated display description of the role.
        /// </summary>
        [JsonPropertyName("display_description")]
        public string DisplayDescription { get; set; }

        /// <summary>
        /// The translated display name of the role.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Whether the role is disabled for certain team members.
        /// </summary>
        [JsonPropertyName("is_disabled")]
        public bool? IsDisabled { get; set; }

        /// <summary>
        /// The untranslated role of the user who made the request.
        /// </summary>
        [JsonPropertyName("permission_level")]
        public string PermissionLevel { get; set; }

        /// <summary>
        /// The untranslated role of the user who made the request.
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// The URI of the team role.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// The applicable permission policies for the role.
    /// </summary>
    public class TeamRoleApplicablePermissionPolicies
    {
        /// <summary>
        /// The applicable AI-related permission policies for the role.
        /// </summary>
        [JsonPropertyName("ai")]
        public TeamRoleApplicablePermissionPoliciesAiItem[] Ai { get; set; }

        /// <summary>
        /// The applicable folder-related permission policies for the role.
        /// </summary>
        [JsonPropertyName("folder")]
        public string[] Folder { get; set; }

        /// <summary>
        /// The applicable permission policies related to regional delivery for the role.
        /// </summary>
        [JsonPropertyName("regional_delivery")]
        public TeamRoleApplicablePermissionPoliciesRegionalDeliveryItem[] RegionalDelivery { get; set; }

        /// <summary>
        /// The applicable video-related permission policies for the role.
        /// </summary>
        [JsonPropertyName("video")]
        public string[] Video { get; set; }
    }

    /// <summary>
    /// TeamRoleApplicablePermissionPoliciesRegionalDeliveryItem
    /// </summary>
    public class TeamRoleApplicablePermissionPoliciesRegionalDeliveryItem
    {
        /// <summary>
        /// The translated display description of the regional delivery permission policy.
        /// </summary>
        [JsonPropertyName("display_description")]
        public string DisplayDescription { get; set; }

        /// <summary>
        /// The translated display name of the regional delivery permission policy.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The name of the regional delivery permission policy.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// TeamRoleApplicablePermissionPoliciesAiItem
    /// </summary>
    public class TeamRoleApplicablePermissionPoliciesAiItem
    {
        /// <summary>
        /// The translated display description of the AI permission policy.
        /// </summary>
        [JsonPropertyName("display_description")]
        public string DisplayDescription { get; set; }

        /// <summary>
        /// The translated display name of the AI permission policy.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The name of the AI permission policy.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
