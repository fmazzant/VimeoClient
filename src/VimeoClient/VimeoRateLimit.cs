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
    using Mafesoft.RestClient;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http.Headers;

    /// <summary>
    /// The rate limit of the Vimeo API, read from the X-RateLimit-Limit, X-RateLimit-Remaining and X-RateLimit-Reset
    /// headers of a response (https://developer.vimeo.com/guidelines/rate-limiting).
    /// </summary>
    /// <example>
    /// <code>
    /// var result = client.Videos.GetAVideo(123);
    /// VimeoRateLimit limit = result.GetRateLimit();
    /// if (limit != null &amp;&amp; limit.Remaining == 0) { /* wait until limit.Reset */ }
    /// </code>
    /// </example>
    public sealed class VimeoRateLimit
    {
        /// <summary>
        /// The number of requests allowed in the current window (X-RateLimit-Limit), or null.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The number of requests left in the current window (X-RateLimit-Remaining), or null.
        /// </summary>
        public int? Remaining { get; set; }

        /// <summary>
        /// When the window resets (X-RateLimit-Reset, UTC), or null.
        /// </summary>
        public DateTimeOffset? Reset { get; set; }

        /// <summary>
        /// Reads the rate limit headers; null when the response has none of them (or there is no response).
        /// </summary>
        /// <param name="headers">The headers of the response.</param>
        public static VimeoRateLimit FromHeaders(HttpResponseHeaders headers)
        {
            if (headers == null)
            {
                return null;
            }

            var limit = new VimeoRateLimit
            {
                Limit = ReadInt(headers, "X-RateLimit-Limit"),
                Remaining = ReadInt(headers, "X-RateLimit-Remaining"),
                Reset = ReadDate(headers, "X-RateLimit-Reset"),
            };
            return limit.Limit == null && limit.Remaining == null && limit.Reset == null ? null : limit;
        }

        private static string Read(HttpResponseHeaders headers, string name) =>
            headers.TryGetValues(name, out var values) ? values.FirstOrDefault()?.Trim() : null;

        private static int? ReadInt(HttpResponseHeaders headers, string name) =>
            int.TryParse(Read(headers, name), NumberStyles.Integer, CultureInfo.InvariantCulture, out var value) ? value : (int?)null;

        // Vimeo sends a date (2026-11-17T22:00:00+00:00); a number of seconds since 1970 is accepted too.
        private static DateTimeOffset? ReadDate(HttpResponseHeaders headers, string name)
        {
            var text = Read(headers, name);
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            if (long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var seconds))
            {
                return DateTimeOffset.FromUnixTimeSeconds(seconds);
            }
            return DateTimeOffset.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var date)
                ? date.ToUniversalTime()
                : (DateTimeOffset?)null;
        }
    }

    /// <summary>
    /// Reads the rate limit of the Vimeo API from a result.
    /// </summary>
    public static class VimeoRateLimitExtensions
    {
        /// <summary>
        /// The rate limit reported by the response of the request; null when the response has no rate limit headers or
        /// no response was received.
        /// </summary>
        /// <param name="result">The result of a request.</param>
        public static VimeoRateLimit GetRateLimit(this RestResult result) =>
            VimeoRateLimit.FromHeaders(result?.Response?.Headers);
    }
}
