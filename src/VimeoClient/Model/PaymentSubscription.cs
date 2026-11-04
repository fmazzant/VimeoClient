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
    /// Subscription (Vimeo schema: subscription).
    /// </summary>
    public class PaymentSubscription
    {
        /// <summary>
        /// The ID of the account.
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Whether the subscription is set to renew automatically.
        /// </summary>
        [JsonPropertyName("auto_renew")]
        public bool? AutoRenew { get; set; }

        /// <summary>
        /// Whether the user can extend their subscription's expiration date by an additional billing period for the same product tier.
        /// </summary>
        [JsonPropertyName("can_renew_now")]
        public bool? CanRenewNow { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the subscription was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the subscription was disabled.
        /// </summary>
        [JsonPropertyName("disabled_at")]
        public string DisabledAt { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the subscription ended.
        /// </summary>
        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// The ID of the grace period.
        /// </summary>
        [JsonPropertyName("grace_period_id")]
        public string GracePeriodId { get; set; }

        /// <summary>
        /// The ID of the subscription.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Whether the subscription is the latest version.
        /// </summary>
        [JsonPropertyName("is_latest")]
        public bool? IsLatest { get; set; }

        /// <summary>
        /// The ID of the payment method.
        /// </summary>
        [JsonPropertyName("payment_method_id")]
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// An array of plans in the subscription.
        /// </summary>
        [JsonPropertyName("plans")]
        public PaymentSubscriptionPlanItem[] Plans { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the subscription started.
        /// </summary>
        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// The status of the subscription.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The number of the subscription.
        /// </summary>
        [JsonPropertyName("subscription_number")]
        public string SubscriptionNumber { get; set; }

        /// <summary>
        /// The version of the subscription.
        /// </summary>
        [JsonPropertyName("subscription_version")]
        public double? SubscriptionVersion { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the subscription was updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// The vendor of the subscription.
        /// </summary>
        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// PaymentSubscriptionPlanItem
    /// </summary>
    public class PaymentSubscriptionPlanItem
    {
        /// <summary>
        /// The amount of the plan.
        /// </summary>
        [JsonPropertyName("amount")]
        public PaymentSubscriptionPlanItemAmount Amount { get; set; }

        /// <summary>
        /// The ID of the billing plan.
        /// </summary>
        [JsonPropertyName("billing_plan_id")]
        public string BillingPlanId { get; set; }

        /// <summary>
        /// The ID of the billing plan product.
        /// </summary>
        [JsonPropertyName("billing_plan_product_id")]
        public string BillingPlanProductId { get; set; }

        /// <summary>
        /// The type of the billing plan.
        /// </summary>
        [JsonPropertyName("billing_plan_type")]
        public string BillingPlanType { get; set; }

        /// <summary>
        /// The time in 8601 format when the plan was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The ID of the plan.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// An array of items in the plan.
        /// </summary>
        [JsonPropertyName("items")]
        public PaymentSubscriptionPlanItemItemItem[] Items { get; set; }

        /// <summary>
        /// The metadata of the plan.
        /// </summary>
        [JsonPropertyName("metadata")]
        public JsonElement? Metadata { get; set; }

        /// <summary>
        /// The ID of the plan.
        /// </summary>
        [JsonPropertyName("plan_id")]
        public string PlanId { get; set; }

        /// <summary>
        /// The ID of the product.
        /// </summary>
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// The promotional code.
        /// </summary>
        [JsonPropertyName("promo_code")]
        public string PromoCode { get; set; }

        /// <summary>
        /// The ID of the promotional code.
        /// </summary>
        [JsonPropertyName("promo_code_id")]
        public string PromoCodeId { get; set; }

        /// <summary>
        /// The quantity of the plan.
        /// </summary>
        [JsonPropertyName("quantity")]
        public double? Quantity { get; set; }

        /// <summary>
        /// The ID of the subscription plan.
        /// </summary>
        [JsonPropertyName("subscription_plan_id")]
        public string SubscriptionPlanId { get; set; }

        /// <summary>
        /// The number of the subscription plan.
        /// </summary>
        [JsonPropertyName("subscription_plan_number")]
        public string SubscriptionPlanNumber { get; set; }

        /// <summary>
        /// The type of the subscription plan.
        /// </summary>
        [JsonPropertyName("subscription_plan_type")]
        public string SubscriptionPlanType { get; set; }

        /// <summary>
        /// The time in 8601 format when the plan was synced.
        /// </summary>
        [JsonPropertyName("synced_at")]
        public string SyncedAt { get; set; }

        /// <summary>
        /// The time in 8601 format when the plan was updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
    }

    /// <summary>
    /// PaymentSubscriptionPlanItemItemItem
    /// </summary>
    public class PaymentSubscriptionPlanItemItemItem
    {
        /// <summary>
        /// The amount of the item.
        /// </summary>
        [JsonPropertyName("amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// The time in 8601 format when the item was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The time in 8601 format when the item ended.
        /// </summary>
        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// The ID of the item.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The metadata of the item.
        /// </summary>
        [JsonPropertyName("metadata")]
        public JsonElement? Metadata { get; set; }

        /// <summary>
        /// The ID of the price.
        /// </summary>
        [JsonPropertyName("price_id")]
        public string PriceId { get; set; }

        /// <summary>
        /// The quantity of the item.
        /// </summary>
        [JsonPropertyName("quantity")]
        public double? Quantity { get; set; }

        /// <summary>
        /// The time in 8601 format when the item started.
        /// </summary>
        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// The ID of the subscription item.
        /// </summary>
        [JsonPropertyName("subscription_item_id")]
        public string SubscriptionItemId { get; set; }

        /// <summary>
        /// The number of the subscription item.
        /// </summary>
        [JsonPropertyName("subscription_item_number")]
        public string SubscriptionItemNumber { get; set; }

        /// <summary>
        /// The ID of the subscription plan.
        /// </summary>
        [JsonPropertyName("subscription_plan_id")]
        public string SubscriptionPlanId { get; set; }

        /// <summary>
        /// The time in 8601 format when the item was synced.
        /// </summary>
        [JsonPropertyName("synced_at")]
        public string SyncedAt { get; set; }

        /// <summary>
        /// The time in 8601 format when the item was updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
    }

    /// <summary>
    /// Money
    /// </summary>
    public class PaymentSubscriptionPlanItemAmount
    {
        /// <summary>
        /// The amount expressed as a numeral without currency formatting.
        /// </summary>
        [JsonPropertyName("amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// The currency in which the amount is expressed.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The amount expressed as a numeral with currency formatting.
        /// </summary>
        [JsonPropertyName("formatted")]
        public string Formatted { get; set; }

        /// <summary>
        /// The amount expressed as a numeral in the lowest denomination. For example, 12 USD is expressed as 1200.
        /// </summary>
        [JsonPropertyName("unit")]
        public double? Unit { get; set; }
    }
}
