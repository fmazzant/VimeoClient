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
    /// Team Membership (Vimeo schema: team-membership).
    /// </summary>
    public class TeamMembership
    {
        /// <summary>
        /// Information about an access grant that applies to the team member on the folder. _This field is deprecated because grants are no longer exposed via API responses._
        /// </summary>
        [JsonPropertyName("access_grant")]
        public JsonElement? AccessGrant { get; set; }

        /// <summary>
        /// AI permission policy names that are switched off at the account level, so they cannot be granted to the member until re-enabled in the account's Vimeo AI settings.
        /// </summary>
        [JsonPropertyName("account_disabled_ai_features")]
        public string[] AccountDisabledAiFeatures { get; set; }

        /// <summary>
        /// Whether the team membership is currently active.
        /// </summary>
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// The member's per-member AI credit limit for the current quota period, or null when uncapped.
        /// </summary>
        [JsonPropertyName("ai_credit_limit")]
        public double? AiCreditLimit { get; set; }

        /// <summary>
        /// Information about permission policies that can apply to the team member.
        /// </summary>
        [JsonPropertyName("applicable_permission_policies")]
        public TeamMembershipApplicablePermissionPolicies ApplicablePermissionPolicies { get; set; }

        /// <summary>
        /// An array of the team roles this team member can have.
        /// </summary>
        [JsonPropertyName("applicable_roles")]
        public TeamRole[] ApplicableRoles { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the invite was sent.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// The team member's email.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Whether the team member should be excluded from single sign-on.
        /// </summary>
        [JsonPropertyName("exclude_sso")]
        public bool? ExcludeSso { get; set; }

        /// <summary>
        /// Whether the team member has folder access.
        /// </summary>
        [JsonPropertyName("has_folder_access")]
        public bool? HasFolderAccess { get; set; }

        /// <summary>
        /// Whether the team member has an LMS user.
        /// </summary>
        [JsonPropertyName("has_lms_user")]
        public bool? HasLmsUser { get; set; }

        /// <summary>
        /// The URL for the invited user to join the team. The value of this field is null if the invited user has already joined.
        /// </summary>
        [JsonPropertyName("invite_url")]
        public string InviteUrl { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the invite was accepted.
        /// </summary>
        [JsonPropertyName("joined_time")]
        public string JoinedTime { get; set; }

        /// <summary>
        /// The metadata of the team membership.
        /// </summary>
        [JsonPropertyName("metadata")]
        public TeamMembershipMetadata Metadata { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the team membership was last modified.
        /// </summary>
        [JsonPropertyName("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// The allowable permission actions of the team user.
        /// </summary>
        [JsonPropertyName("permission_actions")]
        public string[] PermissionActions { get; set; }

        /// <summary>
        /// The team member's permission level.
        /// </summary>
        [JsonPropertyName("permission_level")]
        public string PermissionLevel { get; set; }

        /// <summary>
        /// Whether the team member has been reminded about the invite.
        /// </summary>
        [JsonPropertyName("recently_reminded")]
        public bool? RecentlyReminded { get; set; }

        /// <summary>
        /// The resource key of the team membership.
        /// </summary>
        [JsonPropertyName("resource_key")]
        public string ResourceKey { get; set; }

        /// <summary>
        /// The team member's role, translated.
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// The status of the team membership invite.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The URI of the team membership resource.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The team member. The value of this field is null if the user hasn't joined the team yet.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// The metadata of the team membership.
    /// </summary>
    public class TeamMembershipMetadata
    {
        /// <summary>
        /// A list of resource URIs related to the user.
        /// </summary>
        [JsonPropertyName("connections")]
        public TeamMembershipMetadataConnections Connections { get; set; }
    }

    /// <summary>
    /// A list of resource URIs related to the user.
    /// </summary>
    public class TeamMembershipMetadataConnections
    {
        /// <summary>
        /// A standard connection object indicating how to return groups that this team user is a part of.
        /// </summary>
        [JsonPropertyName("groups")]
        public TeamMembershipMetadataConnectionsGroups Groups { get; set; }

        /// <summary>
        /// Information about the team owner.
        /// </summary>
        [JsonPropertyName("owner")]
        public TeamMembershipMetadataConnectionsOwner Owner { get; set; }

        /// <summary>
        /// A standard connection object indicating how to return personal team folders.
        /// </summary>
        [JsonPropertyName("personal_team_folder")]
        public TeamMembershipMetadataConnectionsPersonalTeamFolder PersonalTeamFolder { get; set; }
    }

    /// <summary>
    /// A standard connection object indicating how to return personal team folders.
    /// </summary>
    public class TeamMembershipMetadataConnectionsPersonalTeamFolder
    {
        /// <summary>
        /// An array of HTTP methods permitted on this URI.
        /// </summary>
        [JsonPropertyName("options")]
        public string[] Options { get; set; }

        /// <summary>
        /// The total number of personal team folders on this connection.
        /// </summary>
        [JsonPropertyName("total")]
        public long? Total { get; set; }

        /// <summary>
        /// The API URI that resolves to the connection data.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// Information about the team owner.
    /// </summary>
    public class TeamMembershipMetadataConnectionsOwner
    {
        /// <summary>
        /// The display name of the team owner.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The team owner's email address.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// The total number of remaining team member invites.
        /// </summary>
        [JsonPropertyName("invites_remaining")]
        public double? InvitesRemaining { get; set; }

        /// <summary>
        /// An array of HTTP methods permitted on this URI.
        /// </summary>
        [JsonPropertyName("options")]
        public string[] Options { get; set; }

        /// <summary>
        /// The total number of owners on this connection.
        /// </summary>
        [JsonPropertyName("total")]
        public long? Total { get; set; }

        /// <summary>
        /// The total number of team members for the specified team owner.
        /// </summary>
        [JsonPropertyName("total_members")]
        public long? TotalMembers { get; set; }

        /// <summary>
        /// The API URI that resolves to the connection data.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// A standard connection object indicating how to return groups that this team user is a part of.
    /// </summary>
    public class TeamMembershipMetadataConnectionsGroups
    {
        /// <summary>
        /// An array of HTTP methods permitted on this URI.
        /// </summary>
        [JsonPropertyName("options")]
        public string[] Options { get; set; }

        /// <summary>
        /// The API URI that resolves to the connection data.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// Information about permission policies that can apply to the team member.
    /// </summary>
    public class TeamMembershipApplicablePermissionPolicies
    {
        /// <summary>
        /// An array of AI permission policies that can apply to the team member.
        /// </summary>
        [JsonPropertyName("ai")]
        public TeamMembershipApplicablePermissionPoliciesAiItem[] Ai { get; set; }

        /// <summary>
        /// An array of folder permission policies that can apply to the team member.
        /// </summary>
        [JsonPropertyName("folder")]
        public TeamMembershipApplicablePermissionPoliciesFolderItem[] Folder { get; set; }

        /// <summary>
        /// An array of regional delivery permission policies that can apply to the team member.
        /// </summary>
        [JsonPropertyName("regional_delivery")]
        public TeamMembershipApplicablePermissionPoliciesRegionalDeliveryItem[] RegionalDelivery { get; set; }

        /// <summary>
        /// An array of video permission policies that can apply to the team member.
        /// </summary>
        [JsonPropertyName("video")]
        public TeamMembershipApplicablePermissionPoliciesVideoItem[] Video { get; set; }
    }

    /// <summary>
    /// Permission Policy
    /// </summary>
    public class TeamMembershipApplicablePermissionPoliciesVideoItem
    {
        /// <summary>
        /// The time at which the permission policy was created.
        /// </summary>
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// The display description of the permission policy, translated where applicable.
        /// </summary>
        [JsonPropertyName("display_description")]
        public string DisplayDescription { get; set; }

        /// <summary>
        /// The display name of the permission policy, translated where applicable.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The time at which the permission policy was last modified.
        /// </summary>
        [JsonPropertyName("modified_on")]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// The name of the permission policy.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The permission actions associated with the policy.
        /// </summary>
        [JsonPropertyName("permission_actions")]
        public JsonElement? PermissionActions { get; set; }

        /// <summary>
        /// The URI of the permission policy.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// Permission Policy
    /// </summary>
    public class TeamMembershipApplicablePermissionPoliciesRegionalDeliveryItem
    {
        /// <summary>
        /// The time at which the permission policy was created.
        /// </summary>
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// The display description of the permission policy, translated where applicable.
        /// </summary>
        [JsonPropertyName("display_description")]
        public string DisplayDescription { get; set; }

        /// <summary>
        /// The display name of the permission policy, translated where applicable.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The time at which the permission policy was last modified.
        /// </summary>
        [JsonPropertyName("modified_on")]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// The name of the permission policy.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The permission actions associated with the policy.
        /// </summary>
        [JsonPropertyName("permission_actions")]
        public JsonElement? PermissionActions { get; set; }

        /// <summary>
        /// The URI of the permission policy.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// Permission Policy
    /// </summary>
    public class TeamMembershipApplicablePermissionPoliciesFolderItem
    {
        /// <summary>
        /// The time at which the permission policy was created.
        /// </summary>
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// The display description of the permission policy, translated where applicable.
        /// </summary>
        [JsonPropertyName("display_description")]
        public string DisplayDescription { get; set; }

        /// <summary>
        /// The display name of the permission policy, translated where applicable.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The time at which the permission policy was last modified.
        /// </summary>
        [JsonPropertyName("modified_on")]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// The name of the permission policy.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The permission actions associated with the policy.
        /// </summary>
        [JsonPropertyName("permission_actions")]
        public JsonElement? PermissionActions { get; set; }

        /// <summary>
        /// The URI of the permission policy.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    /// <summary>
    /// Permission Policy
    /// </summary>
    public class TeamMembershipApplicablePermissionPoliciesAiItem
    {
        /// <summary>
        /// The time at which the permission policy was created.
        /// </summary>
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// The display description of the permission policy, translated where applicable.
        /// </summary>
        [JsonPropertyName("display_description")]
        public string DisplayDescription { get; set; }

        /// <summary>
        /// The display name of the permission policy, translated where applicable.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The time at which the permission policy was last modified.
        /// </summary>
        [JsonPropertyName("modified_on")]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// The name of the permission policy.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The permission actions associated with the policy.
        /// </summary>
        [JsonPropertyName("permission_actions")]
        public JsonElement? PermissionActions { get; set; }

        /// <summary>
        /// The URI of the permission policy.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}
