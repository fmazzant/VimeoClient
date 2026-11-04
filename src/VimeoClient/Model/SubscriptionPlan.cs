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
    /// Subscription Plans (Vimeo schema: subscription-plans).
    /// </summary>
    public class SubscriptionPlan
    {
        /// <summary>
        /// Information about the currency in which the price of the plan is expressed.
        /// </summary>
        [JsonPropertyName("currency")]
        public SubscriptionPlanCurrency Currency { get; set; }

        /// <summary>
        /// Information about the plan discount.
        /// </summary>
        [JsonPropertyName("discount")]
        public SubscriptionPlanDiscount Discount { get; set; }

        /// <summary>
        /// The SKUs of the plans.
        /// </summary>
        [JsonPropertyName("id")]
        public SubscriptionPlanId Id { get; set; }

        /// <summary>
        /// The URLs and entitlements of the associated products in the store.
        /// </summary>
        [JsonPropertyName("metadata")]
        public SubscriptionPlanMetadata Metadata { get; set; }

        /// <summary>
        /// The name of the plan.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Information about the prices associated with the plan.
        /// </summary>
        [JsonPropertyName("price")]
        public SubscriptionPlanPrice Price { get; set; }

        /// <summary>
        /// The price formatted for the selected locale with the associated currency symbol.
        /// </summary>
        [JsonPropertyName("price_formatted")]
        public SubscriptionPlanPriceFormatted PriceFormatted { get; set; }

        /// <summary>
        /// Information about the plan's promotion.
        /// </summary>
        [JsonPropertyName("promotion")]
        public SubscriptionPlanPromotion Promotion { get; set; }

        /// <summary>
        /// The plan type.
        /// </summary>
        [JsonPropertyName("tier")]
        public string Tier { get; set; }

        /// <summary>
        /// The URI of the plan.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// Information about the plan's promotion.
    /// </summary>
    public class SubscriptionPlanPromotion
    {
        /// <summary>
        /// The promotion code.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The promotion discount percentage.
        /// </summary>
        [JsonPropertyName("discount")]
        public double? Discount { get; set; }

        /// <summary>
        /// The price map of the promotion.
        /// </summary>
        [JsonPropertyName("price")]
        public SubscriptionPlanPromotionPrice Price { get; set; }

        /// <summary>
        /// The price map of the promotion formatted for the selected locale.
        /// </summary>
        [JsonPropertyName("price_formatted")]
        public SubscriptionPlanPromotionPriceFormatted PriceFormatted { get; set; }

        /// <summary>
        /// Information about the URIs associated with the promotion.
        /// </summary>
        [JsonPropertyName("uri")]
        public SubscriptionPlanPromotionUri Uri { get; set; }
    }

    /// <summary>
    /// Information about the URIs associated with the promotion.
    /// </summary>
    public class SubscriptionPlanPromotionUri
    {
        /// <summary>
        /// The URI of the annual promotion.
        /// </summary>
        [JsonPropertyName("annual")]
        public string Annual { get; set; }

        /// <summary>
        /// The URI of the monthly promotion.
        /// </summary>
        [JsonPropertyName("monthly")]
        public string Monthly { get; set; }
    }

    /// <summary>
    /// The price map of the promotion formatted for the selected locale.
    /// </summary>
    public class SubscriptionPlanPromotionPriceFormatted
    {
        /// <summary>
        /// The promotional annual price, charged annually.
        /// </summary>
        [JsonPropertyName("annual")]
        public string Annual { get; set; }

        /// <summary>
        /// The promotional monthly price, charged annually.
        /// </summary>
        [JsonPropertyName("annual_monthly")]
        public string AnnualMonthly { get; set; }

        /// <summary>
        /// The promotional monthly price, charged monthly.
        /// </summary>
        [JsonPropertyName("monthly")]
        public string Monthly { get; set; }
    }

    /// <summary>
    /// The price map of the promotion.
    /// </summary>
    public class SubscriptionPlanPromotionPrice
    {
        /// <summary>
        /// The promotional annual price, charged annually.
        /// </summary>
        [JsonPropertyName("annual")]
        public double? Annual { get; set; }

        /// <summary>
        /// The promotional monthly price, charged annually.
        /// </summary>
        [JsonPropertyName("annual_monthly")]
        public double? AnnualMonthly { get; set; }

        /// <summary>
        /// The promotional monthly price, charged monthly.
        /// </summary>
        [JsonPropertyName("monthly")]
        public double? Monthly { get; set; }
    }

    /// <summary>
    /// The price formatted for the selected locale with the associated currency symbol.
    /// </summary>
    public class SubscriptionPlanPriceFormatted
    {
        /// <summary>
        /// The annual price, charged annually.
        /// </summary>
        [JsonPropertyName("annual")]
        public string Annual { get; set; }

        /// <summary>
        /// The monthly price, charged annually.
        /// </summary>
        [JsonPropertyName("annual_monthly")]
        public string AnnualMonthly { get; set; }

        /// <summary>
        /// The monthly price, charged monthly.
        /// </summary>
        [JsonPropertyName("monthly")]
        public string Monthly { get; set; }

        /// <summary>
        /// The weekly price, charged weekly.
        /// </summary>
        [JsonPropertyName("weekly")]
        public string Weekly { get; set; }
    }

    /// <summary>
    /// Information about the prices associated with the plan.
    /// </summary>
    public class SubscriptionPlanPrice
    {
        /// <summary>
        /// The annual price, charged annually.
        /// </summary>
        [JsonPropertyName("annual")]
        public double? Annual { get; set; }

        /// <summary>
        /// The monthly price, charged annually.
        /// </summary>
        [JsonPropertyName("annual_monthly")]
        public double? AnnualMonthly { get; set; }

        /// <summary>
        /// The monthly price, charged monthly.
        /// </summary>
        [JsonPropertyName("monthly")]
        public double? Monthly { get; set; }

        /// <summary>
        /// The weekly price, charged weekly.
        /// </summary>
        [JsonPropertyName("weekly")]
        public double? Weekly { get; set; }
    }

    /// <summary>
    /// The URLs and entitlements of the associated products in the store.
    /// </summary>
    public class SubscriptionPlanMetadata
    {
        /// <summary>
        /// The URLs and entitlements of the associated products in the store.
        /// </summary>
        [JsonPropertyName("entitlements")]
        public SubscriptionPlanMetadataEntitlements Entitlements { get; set; }

        /// <summary>
        /// -
        /// </summary>
        [JsonPropertyName("interactions")]
        public SubscriptionPlanMetadataInteractions Interactions { get; set; }

        /// <summary>
        /// Whether the product is a bandwidth product.
        /// </summary>
        [JsonPropertyName("is_bandwidth_product")]
        public bool? IsBandwidthProduct { get; set; }

        /// <summary>
        /// Whether the product is a Vimeo payments service product.
        /// </summary>
        [JsonPropertyName("is_ps_plan")]
        public bool? IsPsPlan { get; set; }

        /// <summary>
        /// The tax basis of display prices when the payments service returns a display tax.
        /// </summary>
        [JsonPropertyName("price_tax")]
        public SubscriptionPlanMetadataPriceTax PriceTax { get; set; }

        /// <summary>
        /// Information about the purchased product.
        /// </summary>
        [JsonPropertyName("purchased_product")]
        public SubscriptionPlanMetadataPurchasedProduct PurchasedProduct { get; set; }
    }

    /// <summary>
    /// Information about the purchased product.
    /// </summary>
    public class SubscriptionPlanMetadataPurchasedProduct
    {
        /// <summary>
        /// The display price of the purchased product.
        /// </summary>
        [JsonPropertyName("display_price")]
        public double? DisplayPrice { get; set; }

        /// <summary>
        /// The display price of the purchased product formatted for the selected locale.
        /// </summary>
        [JsonPropertyName("display_price_formatted")]
        public string DisplayPriceFormatted { get; set; }

        /// <summary>
        /// Whether the purchased product is billed as a monthly subscription.
        /// </summary>
        [JsonPropertyName("is_monthly")]
        public bool? IsMonthly { get; set; }

        /// <summary>
        /// Whether the purchased product is billed as a weekly subscription.
        /// </summary>
        [JsonPropertyName("is_weekly")]
        public bool? IsWeekly { get; set; }
    }

    /// <summary>
    /// The tax basis of display prices when the payments service returns a display tax.
    /// </summary>
    public class SubscriptionPlanMetadataPriceTax
    {
        /// <summary>
        /// The resolved display country.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Whether the returned prices include tax.
        /// </summary>
        [JsonPropertyName("included")]
        public bool? Included { get; set; }

        /// <summary>
        /// The display tax basis.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// SubscriptionPlanMetadataInteractions
    /// </summary>
    public class SubscriptionPlanMetadataInteractions
    {
        /// <summary>
        /// -
        /// </summary>
        [JsonPropertyName("purchase")]
        public SubscriptionPlanMetadataInteractionsPurchase Purchase { get; set; }
    }

    /// <summary>
    /// SubscriptionPlanMetadataInteractionsPurchase
    /// </summary>
    public class SubscriptionPlanMetadataInteractionsPurchase
    {
        /// <summary>
        /// The purchase status of the product.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The redirect URIs associated with the plan.
        /// </summary>
        [JsonPropertyName("uri")]
        public SubscriptionPlanMetadataInteractionsPurchaseUri Uri { get; set; }
    }

    /// <summary>
    /// The redirect URIs associated with the plan.
    /// </summary>
    public class SubscriptionPlanMetadataInteractionsPurchaseUri
    {
        /// <summary>
        /// The redirect URI for the annual plan in the user's cart.
        /// </summary>
        [JsonPropertyName("annual")]
        public string Annual { get; set; }

        /// <summary>
        /// The redirect URI for the free trial in the user's cart.
        /// </summary>
        [JsonPropertyName("free_trial")]
        public string FreeTrial { get; set; }

        /// <summary>
        /// The redirect URI for the monthly plan in the user's cart.
        /// </summary>
        [JsonPropertyName("monthly")]
        public string Monthly { get; set; }

        /// <summary>
        /// The redirect URI for the weekly plan in the user's cart.
        /// </summary>
        [JsonPropertyName("weekly")]
        public string Weekly { get; set; }
    }

    /// <summary>
    /// The URLs and entitlements of the associated products in the store.
    /// </summary>
    public class SubscriptionPlanMetadataEntitlements
    {
        /// <summary>
        /// The entitlement plan ID.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The list of entitlement parameters corresponding to the tier.
        /// </summary>
        [JsonPropertyName("params")]
        public SubscriptionPlanMetadataEntitlementsParams Params { get; set; }
    }

    /// <summary>
    /// The list of entitlement parameters corresponding to the tier.
    /// </summary>
    public class SubscriptionPlanMetadataEntitlementsParams
    {
        /// <summary>
        /// AI credits entitlements information.
        /// </summary>
        [JsonPropertyName("ai")]
        public SubscriptionPlanMetadataEntitlementsParamsAi Ai { get; set; }

        /// <summary>
        /// Bandwidth entitlement information.
        /// </summary>
        [JsonPropertyName("bandwidth")]
        public SubscriptionPlanMetadataEntitlementsParamsBandwidth Bandwidth { get; set; }

        /// <summary>
        /// The restricted video storage limit for the tier, formatted as a human-readable byte string (e.g. "1GB", "50GB", "7TB"). Null means unlimited.
        /// </summary>
        [JsonPropertyName("restricted_video_storage_limit")]
        public string RestrictedVideoStorageLimit { get; set; }

        /// <summary>
        /// Team seats entitlement information.
        /// </summary>
        [JsonPropertyName("seats")]
        public SubscriptionPlanMetadataEntitlementsParamsSeats Seats { get; set; }

        /// <summary>
        /// Video storage entitlement information.
        /// </summary>
        [JsonPropertyName("storage")]
        public SubscriptionPlanMetadataEntitlementsParamsStorage Storage { get; set; }

        /// <summary>
        /// The number of team seats included with the tier for the monthly plan.
        /// </summary>
        [JsonPropertyName("team_seats")]
        public double? TeamSeats { get; set; }

        /// <summary>
        /// The amount of video storage for the user's periodic quota for the annual plan. Null means unlimited.
        /// </summary>
        [JsonPropertyName("video_storage_periodic_quota")]
        public string VideoStoragePeriodicQuota { get; set; }

        /// <summary>
        /// The video storage total lifetime cap for the annual plan.
        /// </summary>
        [JsonPropertyName("video_storage_quota_cap")]
        public string VideoStorageQuotaCap { get; set; }

        /// <summary>
        /// The video storage quota period for the annual plan.
        /// </summary>
        [JsonPropertyName("video_storage_quota_period")]
        public string VideoStorageQuotaPeriod { get; set; }

        /// <summary>
        /// The unit of the video storage for the user's periodic quota for the annual plan.
        /// </summary>
        [JsonPropertyName("video_storage_quota_unit")]
        public string VideoStorageQuotaUnit { get; set; }
    }

    /// <summary>
    /// Video storage entitlement information.
    /// </summary>
    public class SubscriptionPlanMetadataEntitlementsParamsStorage
    {
        /// <summary>
        /// The amount of video storage for the user's periodic quota for the annual plan. Null means unlimited.
        /// </summary>
        [JsonPropertyName("periodic_quota")]
        public string PeriodicQuota { get; set; }

        /// <summary>
        /// The video storage total lifetime cap for the annual plan.
        /// </summary>
        [JsonPropertyName("quota_cap")]
        public string QuotaCap { get; set; }

        /// <summary>
        /// The video storage quota period for the annual plan.
        /// </summary>
        [JsonPropertyName("quota_period")]
        public string QuotaPeriod { get; set; }

        /// <summary>
        /// The unit of the video storage for the user's periodic quota for the annual plan.
        /// </summary>
        [JsonPropertyName("quota_unit")]
        public string QuotaUnit { get; set; }
    }

    /// <summary>
    /// Team seats entitlement information.
    /// </summary>
    public class SubscriptionPlanMetadataEntitlementsParamsSeats
    {
        /// <summary>
        /// The number of admin team seats included with the tier.
        /// </summary>
        [JsonPropertyName("admin")]
        public double? Admin { get; set; }

        /// <summary>
        /// The number of authenticated team seats included with the tier.
        /// </summary>
        [JsonPropertyName("authenticated")]
        public double? Authenticated { get; set; }

        /// <summary>
        /// The team seats mode for the user's team.
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// The number of team seats included with the tier for the monthly plan.
        /// </summary>
        [JsonPropertyName("team")]
        public double? Team { get; set; }
    }

    /// <summary>
    /// Bandwidth entitlement information.
    /// </summary>
    public class SubscriptionPlanMetadataEntitlementsParamsBandwidth
    {
        /// <summary>
        /// The amount of bandwidth for the user's period.
        /// </summary>
        [JsonPropertyName("periodic_quota")]
        public string PeriodicQuota { get; set; }

        /// <summary>
        /// The quota period unit for the user's bandwidth quota.
        /// </summary>
        [JsonPropertyName("quota_period")]
        public string QuotaPeriod { get; set; }
    }

    /// <summary>
    /// AI credits entitlements information.
    /// </summary>
    public class SubscriptionPlanMetadataEntitlementsParamsAi
    {
        /// <summary>
        /// The quota period unit for the user's AI credits quota.
        /// </summary>
        [JsonPropertyName("credits_period")]
        public string CreditsPeriod { get; set; }

        /// <summary>
        /// The number of AI credits for the user's period.
        /// </summary>
        [JsonPropertyName("periodic_credits")]
        public double? PeriodicCredits { get; set; }
    }

    /// <summary>
    /// The SKUs of the plans.
    /// </summary>
    public class SubscriptionPlanId
    {
        /// <summary>
        /// The SKU of the annual plan.
        /// </summary>
        [JsonPropertyName("annual")]
        public string Annual { get; set; }

        /// <summary>
        /// The SKU of the monthly plan.
        /// </summary>
        [JsonPropertyName("monthly")]
        public string Monthly { get; set; }

        /// <summary>
        /// The SKU of the weekly plan.
        /// </summary>
        [JsonPropertyName("weekly")]
        public string Weekly { get; set; }
    }

    /// <summary>
    /// Information about the plan discount.
    /// </summary>
    public class SubscriptionPlanDiscount
    {
        /// <summary>
        /// The annual discount.
        /// </summary>
        [JsonPropertyName("annual")]
        public double? Annual { get; set; }
    }

    /// <summary>
    /// Information about the currency in which the price of the plan is expressed.
    /// </summary>
    public class SubscriptionPlanCurrency
    {
        /// <summary>
        /// The ISO code of the associated currency.
        /// </summary>
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The symbol of the associated currency.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}
