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

namespace Mafesoft.VimeoClient.Common
{
    using Mafesoft.RestClient;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using Mafesoft.VimeoClient.Body.Team;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;

    /// <summary>
    /// Teams: team roles, team memberships and the custom metadata fields of a team.
    /// https://developer.vimeo.com/api/reference/teams
    /// </summary>
    public class VimeoTeams
    {
        /// <summary>
        /// Vimeo Properties
        /// </summary>
        public VimeoProperties Properties { get; private set; }

        /// <summary>
        /// Vimeo
        /// </summary>
        public Vimeo Vimeo { get; private set; }

        /// <summary>
        /// Root Authorization
        /// </summary>
        public RestBuilder RootAuthorization() => Vimeo.RootAuthorization();

        /// <summary>
        /// Create a new instance of VimeoTeams class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoTeams(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoTeams(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Members ]

        /// <summary>
        /// This method returns information about the authenticated user's role on the specified team owner's team.
        /// GET https://api.vimeo.com/users/{user_id}/team/role
        /// </summary>
        /// <param name="user_id">The ID of the team owner.</param>
        /// <returns>
        /// 200 OK	The role information was returned.
        /// </returns>
        public virtual RestResult<TeamRole> GetTheRoleOfTheUserOnATeam(string user_id) => RootAuthorization()
            .Command($"/users/{user_id}/team/role")
            .Get<TeamRole>();

        /// <summary>
        /// This method returns information about the membership of the specified team user.
        /// GET https://api.vimeo.com/users/{user_id}/team_users/{team_user_id}
        /// </summary>
        /// <param name="user_id">The ID of the team owner.</param>
        /// <param name="team_user_id">The ID of the team user.</param>
        /// <returns>
        /// 200 OK	The membership information was returned.
        /// </returns>
        public virtual RestResult<TeamMembership> GetTheMembershipOfATeamUser(string user_id, long team_user_id) => RootAuthorization()
            .Command($"/users/{user_id}/team_users/{team_user_id}")
            .Get<TeamMembership>();

        #endregion

        #region [ Custom metadata ]

        /// <summary>
        /// This method returns every custom metadata field defined for the specified team.
        /// GET https://api.vimeo.com/teams/{user_id}/custom_metadata
        /// </summary>
        /// <param name="user_id">The ID of the team owner.</param>
        /// <returns>
        /// 200 OK	The custom metadata fields were returned.
        /// </returns>
        public virtual RestResult<VimeoList<CustomMetadataSetting>> GetTheCustomMetadataFieldsOfATeam(string user_id) => RootAuthorization()
            .Command($"/teams/{user_id}/custom_metadata")
            .Get<VimeoList<CustomMetadataSetting>>();

        /// <summary>
        /// This method creates, updates, or deletes custom metadata fields for a team in a single request.
        /// Each field is treated independently: omit the id to create a field (name, type and mandatory are required),
        /// set the id to update it, set the id and delete = true to delete it.
        /// POST https://api.vimeo.com/teams/{user_id}/custom_metadata
        /// </summary>
        /// <param name="user_id">The ID of the team owner.</param>
        /// <param name="fields">The custom metadata fields to create, update, or delete.</param>
        /// <returns>
        /// 200 OK	The updated set of custom metadata fields was returned.
        /// </returns>
        public virtual RestResult<VimeoList<CustomMetadataSetting>> CreateUpdateOrDeleteTheCustomMetadataFieldsOfATeam(string user_id, IEnumerable<CustomMetadataFieldChange> fields) => RootAuthorization()
            .Command($"/teams/{user_id}/custom_metadata")
            .JsonPayload(new VimeoPayload().Set("fields", fields?.Select(VimeoPayload.FromObject).ToArray()))
            .Post<VimeoList<CustomMetadataSetting>>();

        /// <summary>
        /// This method applies a custom metadata value across every existing video owned by the team.
        /// The backfill runs asynchronously: the response is returned as soon as the job is accepted.
        /// The response is not documented by the specification: it is returned as raw JSON (field_id and total_videos).
        /// POST https://api.vimeo.com/teams/{user_id}/custom_metadata/backfill
        /// </summary>
        /// <param name="user_id">The ID of the team owner.</param>
        /// <param name="field_id">The ID of the custom metadata field to populate.</param>
        /// <param name="field_value">The value to assign to the field. Must match the field's data type.</param>
        /// <param name="override_existing">Whether to overwrite values that are already set. The default value is false.</param>
        /// <returns>
        /// 200 OK	The backfill request was accepted.
        /// </returns>
        public virtual RestResult<JsonElement> BackfillACustomMetadataValueAcrossTheVideosOfATeam(string user_id, long field_id, string field_value, bool? override_existing = null) => RootAuthorization()
            .Command($"/teams/{user_id}/custom_metadata/backfill")
            .JsonPayload(new VimeoPayload()
                .Set("field_id", field_id)
                .Set("field_value", field_value)
                .Set("override_existing", override_existing))
            .Post<JsonElement>();

        /// <summary>
        /// This method returns the team's videos that are missing one or more values for mandatory custom metadata fields.
        /// The response is not documented by the specification: it is returned as raw JSON.
        /// GET https://api.vimeo.com/teams/{user_id}/custom_metadata/incomplete_videos
        /// </summary>
        /// <param name="user_id">The ID of the team owner.</param>
        /// <param name="sort">The order of the results: modified_asc, modified_desc, title_asc (default), title_desc.</param>
        /// <param name="page">The page number of the results to show. Defaults to 1.</param>
        /// <param name="per_page">The number of items to show on each page, up to a maximum of 100. Defaults to 25.</param>
        /// <returns>
        /// 200 OK	The list of incomplete videos was returned.
        /// </returns>
        public virtual RestResult<JsonElement> GetTheVideosMissingMandatoryCustomMetadata(string user_id, string sort = null, int? page = null, int? per_page = null) => RootAuthorization()
            .Command($"/teams/{user_id}/custom_metadata/incomplete_videos")
            .ListParameters(page: page, per_page: per_page, sort: sort)
            .Get<JsonElement>();

        /// <summary>
        /// This method modifies the allowed values of a select or multi-select custom metadata field:
        /// rename (old_value and new_value), remove (old_value only) or add (new_value only) an option.
        /// PATCH https://api.vimeo.com/teams/{user_id}/custom_metadata/options
        /// </summary>
        /// <param name="user_id">The ID of the team owner.</param>
        /// <param name="field_id">The ID of the select or multi-select custom metadata field to modify.</param>
        /// <param name="options">The list of changes to apply to the field's allowed values.</param>
        /// <returns>
        /// 200 OK	The updated field definition was returned.
        /// </returns>
        public virtual RestResult<CustomMetadataSetting> UpdateTheOptionsOfACustomMetadataField(string user_id, long field_id, IEnumerable<CustomMetadataOptionChange> options) => RootAuthorization()
            .Command($"/teams/{user_id}/custom_metadata/options")
            .JsonPayload(new VimeoPayload()
                .Set("field_id", field_id)
                .Set("options", options?.Select(VimeoPayload.FromObject).ToArray()))
            .Patch<CustomMetadataSetting>();

        #endregion
    }
}
