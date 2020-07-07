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
    /// The group's privacy settings.
    /// </summary>
    public class GroupPrivacy
    {
        /// <summary>
        /// Who can comment on the group.
        /// Option descriptions:
        /// all         - Anyone can comment on the group.
        /// members     - Only group members can comment on the group.
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Who can invite new members to the group.
        /// Option descriptions:
        ///  all         - Anyone can invite new members.
        ///  members     - Only group members can invite new members.
        /// </summary>
        [JsonPropertyName("invite")]
        public string Invite { get; set; }

        /// <summary>
        /// Who can join the group.
        /// Option descriptions:
        /// anybody     - Anyone can join the group.
        /// members     - Only people with a Vimeo account can join the group.
        /// </summary>
        [JsonPropertyName("join")]
        public string Join { get; set; }

        /// <summary>
        /// Who can add videos to the group.
        /// Option descriptions:
        /// all     - Anyone can add videos to the group.
        /// members - Only group members can add videos to the group.
        /// </summary>
        [JsonPropertyName("videos")]
        public string Videos { get; set; }

        /// <summary>
        /// Who can access the group.
        /// Option descriptions:
        /// anybody - Anyone can access the group.
        /// members - Only group members can access the group.
        /// </summary>
        [JsonPropertyName("view")]
        public string View { get; set; }
    }
}