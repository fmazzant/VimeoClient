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
    /// API App Webhook (Vimeo schema: api-app-webhook).
    /// </summary>
    public class AppWebhook
    {
        /// <summary>
        /// The URI of the API app for which the webhook is created.
        /// </summary>
        [JsonPropertyName("app_uri")]
        public double? AppUri { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the webhook was created.
        /// </summary>
        [JsonPropertyName("created_on")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the webhook was most recently disabled. If this field isn't present in the response, the webhook isn't disabled.
        /// </summary>
        [JsonPropertyName("disabled_on")]
        public string DisabledOn { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the webhook was most recently enabled. If this field doesn't appear in the response, the webhook is disabled.
        /// </summary>
        [JsonPropertyName("enabled_on")]
        public string EnabledOn { get; set; }

        /// <summary>
        /// The failure error rate at the time that the webhook was most recently disabled. If this field doesn't appear in the response, the webhook wasn't disabled after being active.
        /// </summary>
        [JsonPropertyName("failure_rate_before_disabling")]
        public double? FailureRateBeforeDisabling { get; set; }

        /// <summary>
        /// Whether the webhook is activated.
        /// </summary>
        [JsonPropertyName("is_enabled")]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the last request to the webhook URL was made before the webhook was disabled. If this field doesn't appear in the response, the webhook wasn't disabled after being active.
        /// </summary>
        [JsonPropertyName("last_request_time_before_disabling")]
        public string LastRequestTimeBeforeDisabling { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the webhook was most recently modified.
        /// </summary>
        [JsonPropertyName("modified_on")]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// The number of requests that were executed before the webhook was most recently disabled. If this field doesn't appear in the response, the webhook wasn't disabled after being active.
        /// </summary>
        [JsonPropertyName("requests_executed_before_disabling")]
        public double? RequestsExecutedBeforeDisabling { get; set; }

        /// <summary>
        /// The number of requests that failed before the webhook was most recently disabled. If this field doesn't appear in the response, the webhook wasn't disabled after being active.
        /// </summary>
        [JsonPropertyName("requests_failed_before_disabling")]
        public double? RequestsFailedBeforeDisabling { get; set; }

        /// <summary>
        /// The secret key that is passed on webhook payloads. If this field isn't present in the response, no secret key is passed.
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// The time period in seconds over which requests were executed before the webhook was most recently disabled. If this field doesn't appear in the response, the webhook wasn't disabled after being active.
        /// </summary>
        [JsonPropertyName("time_period_failure_rate")]
        public double? TimePeriodFailureRate { get; set; }

        /// <summary>
        /// The URI of the webhook.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The type of event that triggers the webhook.
        /// </summary>
        [JsonPropertyName("webhook_type")]
        public string WebhookType { get; set; }

        /// <summary>
        /// The URL to which data is sent when the webhook is triggered.
        /// </summary>
        [JsonPropertyName("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }
}
