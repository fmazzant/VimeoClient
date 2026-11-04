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
    using System;
    using System.Collections.Generic;
    using VimeoClient.Response;

    /// <summary>
    /// Fluent helpers shared by every Vimeo section.
    /// They keep the "RootAuthorization().Command(...).Get()" style while removing repeated code
    /// (optional query parameters, form url encoded bodies and pagination wiring).
    /// </summary>
    public static class VimeoRestBuilderExtensions
    {
        /// <summary>
        /// Adds a query parameter only when the value is set (not null and not an empty string).
        /// Enum values are converted with <see cref="ToVimeoValue(object)"/>.
        /// </summary>
        /// <param name="root">The rest builder</param>
        /// <param name="key">The parameter's name</param>
        /// <param name="value">The parameter's value</param>
        /// <returns></returns>
        public static RestBuilder OptionalParameter(this RestBuilder root, string key, object value)
        {
            var vimeoValue = ToVimeoValue(value);
            return string.IsNullOrEmpty(vimeoValue) ? root : root.Parameter(key, vimeoValue);
        }

        /// <summary>
        /// Adds the standard Vimeo list parameters: direction, filter, page, per_page, query and sort.
        /// </summary>
        /// <returns></returns>
        public static RestBuilder ListParameters(this RestBuilder root,
            object direction = null,
            object filter = null,
            int? page = null,
            int? per_page = null,
            string query = null,
            object sort = null) => root
            .OptionalParameter("direction", direction)
            .OptionalParameter("filter", filter)
            .OptionalParameter("page", page)
            .OptionalParameter("per_page", per_page)
            .OptionalParameter("query", query)
            .OptionalParameter("sort", sort);

        /// <summary>
        /// Sends the edit parameters as form url encoded body, skipping the null values.
        /// </summary>
        /// <param name="root">The rest builder</param>
        /// <param name="parameters">The body parameters</param>
        /// <returns></returns>
        public static RestBuilder FormUrlEncoded(this RestBuilder root, IEditParameters parameters) => root
            .FormUrlEncoded(true, (pars) =>
            {
                if (parameters == null)
                {
                    return;
                }

                foreach (var item in parameters.ToEnumerable())
                {
                    if (item.Value != null)
                    {
                        pars.Add(item.Key, item.Value);
                    }
                }
            });

        /// <summary>
        /// Sends the parameters as JSON body, skipping the null values.
        /// </summary>
        /// <param name="root">The rest builder</param>
        /// <param name="parameters">The body parameters</param>
        /// <returns></returns>
        public static RestBuilder JsonPayload(this RestBuilder root, IPayloadParameters parameters)
            => root.Payload<Dictionary<string, object>>(parameters?.ToPayload() ?? new VimeoPayload());

        /// <summary>
        /// Sends the object as JSON body only when it is not null.
        /// </summary>
        /// <typeparam name="T">The body's type</typeparam>
        /// <param name="root">The rest builder</param>
        /// <param name="payload">The body</param>
        /// <returns></returns>
        public static RestBuilder OptionalPayload<T>(this RestBuilder root, T payload) where T : class
            => payload == null ? root : root.Payload(payload);

        /// <summary>
        /// Sends a JSON body built from dotted paths, skipping the null values.
        /// </summary>
        /// <param name="root">The rest builder</param>
        /// <param name="payload">The body</param>
        /// <returns></returns>
        public static RestBuilder JsonPayload(this RestBuilder root, VimeoPayload payload)
            => root.Payload<Dictionary<string, object>>(payload ?? new VimeoPayload());

        /// <summary>
        /// Sends a form url encoded body built from key/value pairs, skipping the null values.
        /// </summary>
        /// <param name="root">The rest builder</param>
        /// <param name="values">The body values</param>
        /// <returns></returns>
        public static RestBuilder FormUrlEncoded(this RestBuilder root, params KeyValuePair<string, object>[] values) => root
            .FormUrlEncoded(true, (pars) =>
            {
                foreach (var item in values)
                {
                    var value = ToVimeoValue(item.Value);
                    if (value != null)
                    {
                        pars.Add(item.Key, value);
                    }
                }
            });

        /// <summary>
        /// Executes the GET and wires the Next() and Previous() navigation of the returned page.
        /// </summary>
        /// <typeparam name="T">The item's type</typeparam>
        /// <param name="root">The rest builder</param>
        /// <param name="rootAuthorization">The factory used to build the next and previous calls</param>
        /// <returns></returns>
        public static RestResult<Pagination<T>> GetPagination<T>(this RestBuilder root, Func<RestBuilder> rootAuthorization)
            => root.Get<Pagination<T>>().WithNavigation(rootAuthorization);

        /// <summary>
        /// Wires the Next() and Previous() navigation of a pagination result.
        /// </summary>
        /// <typeparam name="T">The item's type</typeparam>
        /// <param name="result">The result</param>
        /// <param name="rootAuthorization">The factory used to build the next and previous calls</param>
        /// <returns></returns>
        public static RestResult<Pagination<T>> WithNavigation<T>(this RestResult<Pagination<T>> result, Func<RestBuilder> rootAuthorization)
        {
            var paging = result?.Content?.Paging;

            if (paging?.Next != null)
            {
                result.Content.NextAction = () => rootAuthorization()
                    .Command(paging.Next)
                    .GetPagination<T>(rootAuthorization);
            }

            if (paging?.Previous != null)
            {
                result.Content.PreviousAction = () => rootAuthorization()
                    .Command(paging.Previous)
                    .GetPagination<T>(rootAuthorization);
            }

            return result;
        }

        /// <summary>
        /// Converts a value to the string expected by Vimeo.
        /// Booleans become "true"/"false", enums use their name where a double underscore becomes a dot
        /// (for instance publish__time becomes publish.time) and a leading underscore is removed
        /// (for instance _1_week becomes 1_week).
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static string ToVimeoValue(object value)
        {
            switch (value)
            {
                case null:
                    return null;
                case bool b:
                    return b ? "true" : "false";
                case Enum e:
                    return e.ToString().Replace("__", ".").TrimStart('_');
                case string[] array:
                    return string.Join(",", array);
                default:
                    return Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);
            }
        }
    }
}
