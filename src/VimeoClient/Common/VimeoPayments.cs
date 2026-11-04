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
    using VimeoClient.Model;
    using VimeoClient.Response;

    /// <summary>
    /// Payments: payment methods, subscriptions and subscription plans of the Vimeo payments service.
    /// https://developer.vimeo.com/api/reference/payments
    /// </summary>
    public class VimeoPayments
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
        /// Create a new instance of VimeoPayments class
        /// </summary>
        /// <param name="properties"></param>
        public VimeoPayments(VimeoProperties properties)
           : this(new Vimeo(properties))
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="vimeo"></param>
        public VimeoPayments(Vimeo vimeo)
        {
            Vimeo = vimeo;
            Properties = vimeo.Properties;
        }

        #region [ Payment methods ]

        /// <summary>
        /// This method returns every Vimeo payments service payment method that is available to the authenticated user.
        /// GET https://api.vimeo.com/me/payment_methods
        /// </summary>
        /// <param name="cardmember_name">The name of the card member.</param>
        /// <param name="show_disabled">Whether to return disabled payment methods.</param>
        /// <param name="page">The page number of the results to show.</param>
        /// <param name="per_page">The number of items to show on each page of results, up to a maximum of 100.</param>
        /// <returns>
        /// 200 OK	The list of payments service payment methods was returned.
        /// </returns>
        public virtual RestResult<Pagination<PaymentMethod>> GetAllThePaymentMethods(string cardmember_name = null, bool? show_disabled = null, int? page = null, int? per_page = null) => RootAuthorization()
            .Command("/me/payment_methods")
            .OptionalParameter("cardmember_name", cardmember_name)
            .OptionalParameter("show_disabled", show_disabled)
            .ListParameters(page: page, per_page: per_page)
            .GetPagination<PaymentMethod>(RootAuthorization);

        /// <summary>
        /// This method returns information about the specified Vimeo payments service payment method.
        /// GET https://api.vimeo.com/me/payment_methods/{payment_method_id}
        /// </summary>
        /// <param name="payment_method_id">The ID of the payment method.</param>
        /// <returns>
        /// 200 OK	The payments service payment method information was returned.
        /// </returns>
        public virtual RestResult<PaymentMethod> GetAPaymentMethod(string payment_method_id) => RootAuthorization()
            .Command($"/me/payment_methods/{payment_method_id}")
            .Get<PaymentMethod>();

        /// <summary>
        /// This method deletes the specified Vimeo payments service payment method.
        /// DELETE https://api.vimeo.com/me/payment_methods/{payment_method_id}
        /// </summary>
        /// <param name="payment_method_id">The ID of the payment method.</param>
        /// <returns>
        /// 204 No Content	The payments service payment method was deleted.
        /// </returns>
        public virtual RestResult DeleteAPaymentMethod(string payment_method_id) => RootAuthorization()
            .Command($"/me/payment_methods/{payment_method_id}")
            .Delete();

        #endregion

        #region [ Subscriptions ]

        /// <summary>
        /// This method returns information about the specified Vimeo payments service subscription.
        /// GET https://api.vimeo.com/users/{user_id}/subscriptions/{subscription_id}
        /// </summary>
        /// <param name="user_id">The ID of the user.</param>
        /// <param name="subscription_id">The ID of the subscription.</param>
        /// <returns>
        /// 200 OK	The subscription information was returned.
        /// </returns>
        public virtual RestResult<PaymentSubscription> GetASubscription(string user_id, string subscription_id) => RootAuthorization()
            .Command($"/users/{user_id}/subscriptions/{subscription_id}")
            .Get<PaymentSubscription>();

        /// <summary>
        /// This method returns the specified subscription plan.
        /// GET https://api.vimeo.com/subscription_plans/{tier}
        /// </summary>
        /// <param name="tier">The type of subscription plan: advanced, business, free, live_premium, plus, pro, pro_unlimited, standard, starter.</param>
        /// <returns>
        /// 200 OK	The subscription plan was returned.
        /// </returns>
        public virtual RestResult<SubscriptionPlan> GetASubscriptionPlan(string tier) => RootAuthorization()
            .Command($"/subscription_plans/{tier}")
            .Get<SubscriptionPlan>();

        #endregion
    }
}
