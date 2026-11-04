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
    using RestClient;
    using Mafesoft.VimeoClient.Model;
    using Mafesoft.VimeoClient.Response;

    /// <summary>
    /// API app webhooks: notifications sent by Vimeo to your URL when an event occurs (video created, transcode complete, live event started...).
    /// https://developer.vimeo.com/api/reference/api-apps
    /// </summary>
    public class VimeoWebhooks
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
        /// Create a new instance of VimeoWebhooks class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoWebhooks(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoWebhooks(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Webhooks ]

        /// <summary>
        /// This method returns every webhook for the specified app.
        /// GET https://api.vimeo.com/apps/{app_id}/webhooks
        /// </summary>
        /// <param name="app_id">The ID of the app that the webhook is associated with.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The list of webhooks was returned.
        /// </returns>
        public virtual RestResult<Pagination<AppWebhook>> GetAllTheWebhooksOfAnApp(long app_id, int? page = null, int? per_page = null) => RootAuthorization()
            .Command($"/apps/{app_id}/webhooks")
            .ListParameters(page: page, per_page: per_page)
            .GetPagination<AppWebhook>(RootAuthorization);

        /// <summary>
        /// This method adds a webhook for the specified app.
        /// POST https://api.vimeo.com/apps/{app_id}/webhooks
        /// </summary>
        /// <param name="app_id">The ID of the app for which the webhook is created.</param>
        /// <param name="webhook_type">
        /// The type of event that triggers the webhook: automatic-thumbnail-available, content-scan-completed, live-event-archive-available,
        /// live-event-clip-created, live-event-deleted, live-event-ended, live-event-started, live-event-updated, registration-created,
        /// registration-deleted, registration-updated, transcript-status-complete, transcript-status-updated, video-created, video-deleted,
        /// video-transcode-complete, video-transcode-fully-playable, video-transcode-playable, video-updated, video-upload-failed.
        /// </param>
        /// <param name="webhook_url">The URL to which data is sent.</param>
        /// <param name="is_enabled">Whether the webhook is activated. The default value is false.</param>
        /// <param name="secret">The secret key that is passed on webhook payloads.</param>
        /// <returns>
        /// 200 OK	The webhook was added.
        /// 400 Bad Request	Error code 3143: the webhook type already exists for the app.
        /// </returns>
        public virtual RestResult<AppWebhook> AddAWebhookForAnApp(long app_id, string webhook_type, string webhook_url, bool? is_enabled = null, string secret = null) => RootAuthorization()
            .Command($"/apps/{app_id}/webhooks")
            .JsonPayload(new VimeoPayload()
                .Set("webhook_type", webhook_type)
                .Set("webhook_url", webhook_url)
                .Set("is_enabled", is_enabled)
                .Set("secret", secret))
            .Post<AppWebhook>();

        /// <summary>
        /// This method returns the specified webhook.
        /// GET https://api.vimeo.com/apps/{app_id}/webhooks/{webhook_id}
        /// </summary>
        /// <param name="app_id">The ID of the app that the webhook is associated with.</param>
        /// <param name="webhook_id">The ID of the webhook.</param>
        /// <returns>
        /// 200 OK	The webhook was returned.
        /// </returns>
        public virtual RestResult<AppWebhook> GetAWebhook(long app_id, long webhook_id) => RootAuthorization()
            .Command($"/apps/{app_id}/webhooks/{webhook_id}")
            .Get<AppWebhook>();

        /// <summary>
        /// This method updates the specified webhook.
        /// PATCH https://api.vimeo.com/apps/{app_id}/webhooks/{webhook_id}
        /// </summary>
        /// <param name="app_id">The ID of the app that the webhook is associated with.</param>
        /// <param name="webhook_id">The ID of the webhook.</param>
        /// <param name="webhook_type">The type of event that triggers the webhook (see <see cref="AddAWebhookForAnApp"/>).</param>
        /// <param name="webhook_url">The URL to which data is sent.</param>
        /// <param name="is_enabled">Whether the webhook is activated.</param>
        /// <param name="secret">The secret key that is passed on webhook payloads.</param>
        /// <returns>
        /// 200 OK	The webhook was updated.
        /// </returns>
        public virtual RestResult<AppWebhook> UpdateAWebhook(long app_id, long webhook_id, string webhook_type = null, string webhook_url = null, bool? is_enabled = null, string secret = null) => RootAuthorization()
            .Command($"/apps/{app_id}/webhooks/{webhook_id}")
            .JsonPayload(new VimeoPayload()
                .Set("webhook_type", webhook_type)
                .Set("webhook_url", webhook_url)
                .Set("is_enabled", is_enabled)
                .Set("secret", secret))
            .Patch<AppWebhook>();

        /// <summary>
        /// This method deletes the specified webhook.
        /// DELETE https://api.vimeo.com/apps/{app_id}/webhooks/{webhook_id}
        /// </summary>
        /// <param name="app_id">The ID of the app that the webhook is associated with.</param>
        /// <param name="webhook_id">The ID of the webhook.</param>
        /// <returns>
        /// 204 No Content	The webhook was deleted.
        /// </returns>
        public virtual RestResult DeleteAWebhook(long app_id, long webhook_id) => RootAuthorization()
            .Command($"/apps/{app_id}/webhooks/{webhook_id}")
            .Delete();

        #endregion
    }
}
