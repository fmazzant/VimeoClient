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
    /// Videos
    /// https://developer.vimeo.com/api/reference/videos
    /// </summary>
    public class VimeoVideos
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
        public VimeoVideos(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoVideos(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]
        //Check if the user owns a video

        /// <summary>
        /// This method deletes the specified video. The authenticated user must be the owner of the video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns></returns>
        public virtual RestResult DeleteVideo(int video_id) => RootAuthorization()
           .Command($"/videos/{video_id}")
           .Delete();

        //Edit a video

        /// <summary>
        /// This method returns a single video.
        /// </summary>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>The video was returned.</returns>
        public virtual RestResult<Video> GetSpecificVideo(int video_id) => RootAuthorization()
            .Command($"/videos/{video_id}")
            .Get<Video>();

        //Get all the videos in which the user appears
        //Get all the videos that the user has uploaded
        //Search for videos
        #endregion

        #region [ Content ratings ]
        //Get all content ratings
        //Creative Commons
        //Get all Creative Commons licenses
        #endregion

        #region [ Credits ]
        //Credit a user in a video
        //Delete the credit for a user in a video
        //Edit the credit for a user in a video
        //Get a specific credited user in a video
        //Get all the credited users in a video
        #endregion

        #region [ Embed privacy ]
        //Add a domain to a video's whitelist
        //Get all the domains on a video's whitelist
        //Remove a domain from a video's whitelist
        #endregion

        #region [ Languages ]
        //Get all languages
        //Live M3U8 playback
        //Get an M3U8 playback URL for a one-time live event
        #endregion

        #region [ Private videos ]
        //Get all the users who can view a private video
        //Permit a list of users to access a private video
        //Permit a specific user to access a private video
        //Restrict a user from viewing a private video
        #endregion

        #region [ Recommendations ]
        //Get all the related videos of a video
        //Showcases
        //Add or remove a video from a list of showcases
        //Get all the albums that contain a video
        #endregion

        #region [ Tags ]
        //Add a list of tags to a video
        //Add a specific tag to a video
        //Check if a tag has been added to a video
        //Get all the tags of a video
        //Get all the videos with a specific tag
        //Remove a tag from a video
        #endregion

        #region [ Text tracks ]
        //Add a text track to a video
        //Delete a text track
        //Edit a text track
        //Get a specific text track
        //Get all the text tracks of a video
        #endregion

        #region [ Thumbnails ]
        //Add a video thumbnail
        //Delete a video thumbnail
        //Edit a video thumbnail
        //Get a specific video thumbnail
        //Get all the thumbnails of a video
        #endregion

        #region [ Uploads ]
        //Complete a streaming upload
        //Get an upload attempt
        //Upload a video
        #endregion

        #region [ Versions ]
        //Add a version to a video
        //Delete a video version
        //Edit a video version
        //Get a specific video version
        //Get all the versions of a video
        #endregion

        #region [ Video comments ]
        //Add a reply to a video comment
        //Add a video comment to a video
        //Delete a video comment
        //Edit a video comment
        //Get a specific video comment
        //Get all the replies to a video comment
        //Get all the video comments on a video
        #endregion
    }
}