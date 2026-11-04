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
    /// Payment Method (Vimeo schema: payment-method).
    /// </summary>
    public class PaymentMethod
    {
        /// <summary>
        /// The ID of the account.
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Information about the card used to make the payment.
        /// </summary>
        [JsonPropertyName("card")]
        public PaymentMethodCard Card { get; set; }

        /// <summary>
        /// The time when the payment method was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The time when the payment method was disabled.
        /// </summary>
        [JsonPropertyName("disabled_at")]
        public string DisabledAt { get; set; }

        /// <summary>
        /// The ID of the payment method.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Whether the payment method is the default payment method for the account.
        /// </summary>
        [JsonPropertyName("is_default")]
        public bool? IsDefault { get; set; }

        /// <summary>
        /// The type of payment method.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The time when the payment method was last updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// Information about the card used to make the payment.
    /// </summary>
    public class PaymentMethodCard
    {
        /// <summary>
        /// The billing address of the card. _This field is deprecated. Use the account bill-to contact instead._
        /// </summary>
        [JsonPropertyName("billing_address")]
        public PaymentMethodCardBillingAddress BillingAddress { get; set; }

        /// <summary>
        /// The bank identification number of the card.
        /// </summary>
        [JsonPropertyName("bin")]
        public string Bin { get; set; }

        /// <summary>
        /// The brand of the card.
        /// </summary>
        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// The name of the cardholder.
        /// </summary>
        [JsonPropertyName("cardholder_name")]
        public string CardholderName { get; set; }

        /// <summary>
        /// The expiration month of the card.
        /// </summary>
        [JsonPropertyName("expiration_month")]
        public double? ExpirationMonth { get; set; }

        /// <summary>
        /// The expiration year of the card.
        /// </summary>
        [JsonPropertyName("expiration_year")]
        public double? ExpirationYear { get; set; }

        /// <summary>
        /// The last four digits of the card.
        /// </summary>
        [JsonPropertyName("last_four_digits")]
        public string LastFourDigits { get; set; }
    }

    /// <summary>
    /// The billing address of the card. _This field is deprecated. Use the account bill-to contact instead._
    /// </summary>
    public class PaymentMethodCardBillingAddress
    {
        /// <summary>
        /// The street address of the billing address. _This field is deprecated. Use the account bill-to contact instead._
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// The city of the billing address. _This field is deprecated. Use the account bill-to contact instead._
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// The country of the billing address. _This field is deprecated. Use the account bill-to contact instead._
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// The postal code of the billing address. _This field is deprecated. Use the account bill-to contact instead._
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The state of the billing address. _This field is deprecated. Use the account bill-to contact instead._
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
