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

namespace VimeoClient.Common
{
    using RestClient;
    using RestClient.Generic;
    using VimeoClient.Filter.Group;
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// A group is a community within Vimeo for collaborating, sharing, and engaging with videos. 
    /// Groups can be public, where anyone can join, or they can be private, where membership is by invitation only. 
    /// For more information, see our Help Center.
    /// https://developer.vimeo.com/api/reference/groups
    /// </summary>
    public class VimeoGroups
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
        /// Create a new instance of VimeoCategories class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoGroups(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoGroups(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]
        /// <summary>
        /// This method creates a new group
        /// </summary>
        /// <param name="name">The name of the group.</param>
        /// <param name="description">The description of the group.</param>
        /// <returns>
        /// 200 OK	The group was created.
        /// 400 Bad Request A parameter is invalid.
        /// 403 Forbidden The authenticated user can't create groups.
        /// </returns>
        public RestResult<Group> CreateAGroup(string name, string description) => RootAuthorization()
            .Command("/groups")
            .FormUrlEncoded(true, (p) =>
            {
                p.Add("name", name);
                p.Add("description", description);
            })
            .Post<Group>();

        /// <summary>
        /// This method deletes the specified group. The authenticated user must be the owner of the group.
        /// </summary>
        /// <param name="group_id">group_id</param>
        /// <returns>
        /// 204 No Content	The group was deleted.
        /// 403 Forbidden The authenticated user can't delete the group.
        /// </returns>
        public RestResult DeleteAGroup(int group_id) => RootAuthorization()
            .Command($"/groups/{group_id}")
            .Delete();

        /// <summary>
        /// This method returns the specified group
        /// </summary>
        /// <param name="group_id">group_id</param>
        /// <returns>
        /// 200 OK	The group was returned.
        /// </returns>
        public RestResult<Group> GetASpecificGroup(int group_id) => RootAuthorization()
            .Command($"/groups/{group_id}")
            .Get<Group>();

        /// <summary>
        /// This method returns every available group.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filer">The attribute by which to filter the results</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <returns>
        /// 200 OK	The groups were returned.
        /// </returns>
        public RestResult<Pagination<Group>> GetAllTheVideosThatHaveASpecificEmbedPreset(GroupDirection? direction = null,
            string filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            GroupSort? sort = null)
        {
            var root = RootAuthorization()
                .Command($"/groups")
                .Parameter((p) =>
                {
                    if (direction.HasValue)
                    {
                        p.Add(new RestParameter { Key = "direction", Value = direction });
                    }
                    if (filter != null)
                    {
                        p.Add(new RestParameter { Key = "filter", Value = filter });
                    }
                    if (page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "page", Value = page });
                    }
                    if (per_page.HasValue)
                    {
                        p.Add(new RestParameter { Key = "per_page", Value = per_page });
                    }
                    if (query != null)
                    {
                        p.Add(new RestParameter { Key = "query", Value = query });
                    }
                    if (sort.HasValue)
                    {
                        p.Add(new RestParameter { Key = "sort", Value = sort });
                    }
                });

            var result = root.Get<Pagination<Group>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Group>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Group>>();
            }

            return result;
        }

        #endregion

        #region [ Subscriptions ]
        //Add the user to a group
        //Remove the user from a group
        #endregion

        #region [ Users ]
        //Check if a user has joined a group
        //Get all the groups that the user has joined
        //Get all the members of a group
        #endregion

        #region [ Videos ]
        //Add a video to a group
        //Get a specific video in a group
        //Get all the videos in a group
        //Remove a video from a group
        #endregion
    }
}