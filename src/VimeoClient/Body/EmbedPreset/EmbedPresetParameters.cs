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

namespace Mafesoft.VimeoClient.Body.EmbedPreset
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Mafesoft.VimeoClient.Model;

    /// <summary>
    /// The body to create an embed preset.
    /// </summary>
    public class EmbedPresetParameters : IEditParameters, IPayloadParameters
    {
        /// <summary>
        /// The name of the embed preset.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether to apply the preset to all of the user's videos.
        /// </summary>
        [JsonPropertyName("apply_to_all")]
        public bool? ApplyToAll { get; set; }

        /// <summary>
        /// The embed settings of the preset.
        /// </summary>
        [JsonPropertyName("embed")]
        public EmbedSettings Embed { get; set; }

        /// <summary>
        /// Builds the JSON body: only the values that are set are sent.
        /// </summary>
        /// <returns></returns>
        public VimeoPayload ToPayload() => VimeoPayload.FromObject(this);

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable() => ToPayload().Flatten();
    }
}
