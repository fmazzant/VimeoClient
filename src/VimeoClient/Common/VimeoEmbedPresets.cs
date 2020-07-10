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
    using VimeoClient.Model;

    /// <summary>
    /// An embed preset is a reusable collection of settings for customizing the appearance and behavior of the embeddable Vimeo player. 
    /// This feature is available to Vimeo Pro, Business, and Premium members. 
    /// For more information, see our Help Center.
    /// https://developer.vimeo.com/api/reference/embed-presets
    /// </summary>
    public class VimeoEmbedPresets
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
        public VimeoEmbedPresets(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoEmbedPresets(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]

        /// <summary>
        /// This method edits the specified embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="disable">What to do with the outro: true disable outro</param>
        /// <returns></returns>
        public RestResult<Presets> EditAnEmbedPreset(int preset_id, int user_id, bool disable = false) => RootAuthorization()
            .Command($"/users/{user_id}/presets/{preset_id}")
            .FormUrlEncoded(true, (p) =>
            {
                if (!disable)
                {
                    p.Add("outro", "nothing");
                }
            })
            .Patch<Presets>();

        /// <summary>
        /// This method edits the specified embed preset. The authenticated user must be the owner of the preset.
        /// </summary>
        /// <param name="preset_id">The ID of the preset.</param>
        /// <param name="disable">What to do with the outro: true disable outro</param>
        /// <returns></returns>
        public RestResult<Presets> EditAnEmbedPreset(int preset_id, bool disable = false) => RootAuthorization()
            .Command($"/me/presets/{preset_id}")
            .FormUrlEncoded(true, (p) =>
            {
                if (!disable)
                {
                    p.Add("outro", "nothing");
                }
            })
            .Patch<Presets>();


        //Get a specific embed preset
        //Get all the embed presets that a user has created
        #endregion

        #region [ Custom logos ]
        //Add a custom logo for the user
        //Get a specific custom logo for the user
        //Get all the custom logos that belong to the user
        #endregion

        #region [ Timeline events ]
        //Add a timeline event thumbnail to a video
        //Get a timeline event thumbnail
        #endregion

        #region [ Videos ]
        //Add an embed preset to a video
        //Check if an embed preset has been added to a video
        //Get all the videos that have a specific embed preset
        //Remove an embed preset from a video
        #endregion
    }
}