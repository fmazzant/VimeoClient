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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The parameters sent as JSON body
    /// </summary>
    public interface IPayloadParameters
    {
        /// <summary>
        /// Builds the JSON body
        /// </summary>
        /// <returns></returns>
        VimeoPayload ToPayload();
    }

    /// <summary>
    /// A JSON body built by dotted paths, the null values are skipped.
    /// new VimeoPayload().Set("buy.price.USD", 2.99) produces { "buy": { "price": { "USD": 2.99 } } }
    /// </summary>
    public class VimeoPayload : Dictionary<string, object>
    {
        /// <summary>
        /// Sets a value by dotted path. Null values are ignored, enums are converted to Vimeo values.
        /// </summary>
        /// <param name="path">The dotted path, for instance buy.price.USD</param>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public VimeoPayload Set(string path, object value)
        {
            if (value == null)
            {
                return this;
            }

            if (value is Enum)
            {
                value = VimeoRestBuilderExtensions.ToVimeoValue(value);
            }

            var keys = path.Split('.');
            var current = this;

            for (var i = 0; i < keys.Length - 1; i++)
            {
                if (!(current.TryGetValue(keys[i], out var child) && child is VimeoPayload next))
                {
                    next = new VimeoPayload();
                    current[keys[i]] = next;
                }
                current = next;
            }

            current[keys[keys.Length - 1]] = value;
            return this;
        }

        /// <summary>
        /// Sets a price map by currency (for instance buy.price.USD, buy.price.EUR)
        /// </summary>
        /// <param name="path">The dotted path of the price object</param>
        /// <param name="prices">The prices by currency</param>
        /// <returns></returns>
        public VimeoPayload SetPrices(string path, IDictionary<string, double> prices)
        {
            if (prices == null)
            {
                return this;
            }

            foreach (var price in prices)
            {
                Set($"{path}.{price.Key}", price.Value);
            }
            return this;
        }

        /// <summary>
        /// Flattens the payload in dotted key/value pairs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> Flatten() => Flatten(null, this);

        private static IEnumerable<KeyValuePair<string, string>> Flatten(string prefix, VimeoPayload payload)
        {
            foreach (var item in payload)
            {
                var key = prefix == null ? item.Key : $"{prefix}.{item.Key}";

                if (item.Value is VimeoPayload child)
                {
                    foreach (var pair in Flatten(key, child))
                    {
                        yield return pair;
                    }
                }
                else if (item.Value is IEnumerable values && !(item.Value is string))
                {
                    yield return new KeyValuePair<string, string>(key, string.Join(",", values.Cast<object>().Select(VimeoRestBuilderExtensions.ToVimeoValue)));
                }
                else
                {
                    yield return new KeyValuePair<string, string>(key, VimeoRestBuilderExtensions.ToVimeoValue(item.Value));
                }
            }
        }
    }
}
