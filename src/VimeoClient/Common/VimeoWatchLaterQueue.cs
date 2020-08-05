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

namespace VimeoClient
{
    using RestClient;
    using RestClient.Generic;
    using VimeoClient.Filter.Video;
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// The Watch Later queue contains all the videos that a Vimeo member has flagged to watch later.
    /// https://developer.vimeo.com/api/reference/watch-later-queue
    /// </summary>
    public class VimeoWatchLaterQueue
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
        public VimeoWatchLaterQueue(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoWatchLaterQueue(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Essentials ]
        /// <summary>
        /// This method adds the specified video to the authenticated user's Watch Later queue.
        /// </summary>
        /// <param name="user_id">Number  The ID of the user.</param>
        /// <param name="video_id">Number  The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// </returns>
        public virtual RestResult AddAVideoToUserWathLaterQueue(int user_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/watchlater/{video_id}")
            .Put();

        /// <summary>
        /// This method adds the specified video to the authenticated user's Watch Later queue.
        /// </summary>
        /// <param name="video_id">Number  The ID of the video.</param>
        /// <returns>
        /// 204 No Content	The video was added.
        /// </returns>
        public virtual RestResult AddAVideoToUserWathLaterQueue(int video_id) => RootAuthorization()
            .Command($"/me/watchlater/{video_id}")
            .Put();

        /// <summary>
        /// This method checks the authenticated user's Watch Later queue for the specified video.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The video is in the user's Watch Later queue.
        /// 404 Not Found   The video isn't in the user's Watch Later queue.
        /// </returns>
        public virtual RestResult<Video> CheckIfTheUserHasAddedAVideoToTheirWatchLaterQueue(int user_id, int video_id) => RootAuthorization()
            .Command($"/users/{user_id}/watchlater/{video_id}")
            .Get<Video>();

        /// <summary>
        /// This method checks the authenticated user's Watch Later queue for the specified video.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="video_id">The ID of the video.</param>
        /// <returns>
        /// 200 OK	The video is in the user's Watch Later queue.
        /// 404 Not Found   The video isn't in the user's Watch Later queue.
        /// </returns>
        public virtual RestResult<Video> CheckIfTheUserHasAddedAVideoToTheirWatchLaterQueue(int video_id) => RootAuthorization()
           .Command($"/me/watchlater/{video_id}")
           .Get<Video>();

        /// <summary>
        /// The Watch Later queue contains all the videos that a Vimeo member has flagged to watch later.
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false). 
        /// This parameter is required only when filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// 304 Not Modified
        ///     The user hasn't added any videos to their Watch Later queue since the given If-Modified-Since header.
        /// </returns>
        public virtual RestResult<Pagination<Video>> GetAllTheVideosInTheUserWatchLaterQueue(string user_id,
            VideoDirection? direction = null,
            VideoFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoSort? sort = null)
        {
            var root = RootAuthorization()
                .Command($"/users/{user_id}/watchlater")
                .Parameter((p) =>
                {
                    if (direction.HasValue)
                    {
                        p.Add(new RestParameter { Key = "direction", Value = direction });
                    }
                    if (filter.HasValue)
                    {
                        p.Add(new RestParameter { Key = "filter", Value = filter });
                    }
                    if (filter_embeddable == true)
                    {
                        p.Add(new RestParameter { Key = "filter_embeddable", Value = filter_embeddable });
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

            var result = root.Get<Pagination<Video>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Video>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Video>>();
            }

            return result;
        }

        /// <summary>
        /// The Watch Later queue contains all the videos that a Vimeo member has flagged to watch later.
        /// </summary>
        /// <param name="direction">The sort direction of the results</param>
        /// <param name="filter">The attribute by which to filter the results</param>
        /// <param name="filter_embeddable">Whether to filter the results by embeddable videos (true) or non-embeddable videos (false). 
        /// This parameter is required only when filter is embeddable.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <param name="query">The search query to use to filter the results.</param>
        /// <param name="sort">The way to sort the results</param>
        /// <returns>
        /// 200 OK	The videos were returned.
        /// 304 Not Modified
        ///     The user hasn't added any videos to their Watch Later queue since the given If-Modified-Since header.
        /// </returns>
        public virtual RestResult<Pagination<Video>> GetAllTheVideosInTheUserWatchLaterQueue(VideoDirection? direction = null,
            VideoFilter? filter = null,
            bool? filter_embeddable = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            VideoSort? sort = null)
        {
            var root = RootAuthorization()
                .Command($"/me/watchlater")
                .Parameter((p) =>
                {
                    if (direction.HasValue)
                    {
                        p.Add(new RestParameter { Key = "direction", Value = direction });
                    }
                    if (filter.HasValue)
                    {
                        p.Add(new RestParameter { Key = "filter", Value = filter });
                    }
                    if (filter_embeddable == true)
                    {
                        p.Add(new RestParameter { Key = "filter_embeddable", Value = filter_embeddable });
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

            var result = root.Get<Pagination<Video>>();

            if (result.Content.Paging?.Next != null)
            {
                result.Content.NextAction = () => RootAuthorization().Command(result.Content.Paging.Next).Get<Pagination<Video>>();
            }

            if (result.Content.Paging?.Previous != null)
            {
                result.Content.PreviousAction = () => RootAuthorization().Command(result.Content.Paging.Previous).Get<Pagination<Video>>();
            }

            return result;
        }
        #endregion
    }
}