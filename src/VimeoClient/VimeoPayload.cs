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

namespace Mafesoft.VimeoClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The parameters sent as JSON body
    /// </summary>
    public interface IPayloadParameters
    {
        /// <summary>
        /// Builds the JSON body
        /// </summary>
        /// <returns>The JSON body</returns>
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
        /// <returns>This payload, to chain the calls</returns>
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
        /// <returns>This payload, to chain the calls</returns>
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
        /// Builds a payload from an object: the names come from [JsonPropertyName] (or the property name),
        /// the null values are skipped, enums become Vimeo values and nested objects become nested payloads.
        /// </summary>
        /// <param name="source">The object</param>
        /// <returns>The payload; empty when <paramref name="source"/> is null</returns>
        public static VimeoPayload FromObject(object source)
        {
            var payload = new VimeoPayload();
            if (source == null)
            {
                return payload;
            }

            foreach (var property in source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!property.CanRead || property.GetIndexParameters().Length > 0
                    || property.GetCustomAttribute<JsonIgnoreAttribute>() != null
                    || property.GetCustomAttribute<JsonExtensionDataAttribute>() != null)
                {
                    continue;
                }

                var name = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name;
                var value = ToPayloadValue(property.GetValue(source));
                if (value != null)
                {
                    payload[name] = value;
                }
            }

            return payload;
        }

        private static object ToPayloadValue(object value)
        {
            switch (value)
            {
                case null:
                    return null;
                case string _:
                case bool _:
                case IConvertible _ when !(value is Enum):
                    return value;
                case Enum e:
                    return VimeoRestBuilderExtensions.ToVimeoValue(e);
                case VimeoPayload p:
                    return p;
                case IEnumerable items:
                    return items.Cast<object>().Select(ToPayloadValue).ToArray();
                default:
                    var nested = FromObject(value);
                    return nested.Count == 0 ? null : nested;
            }
        }

        /// <summary>
        /// Flattens the payload in dotted key/value pairs
        /// </summary>
        /// <returns>The dotted key/value pairs, for instance buy.price.USD=2.99</returns>
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
