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
    using System.Text.Json.Serialization;

    /// <summary>
    /// A custom metadata field defined for a team (custom-metadata-settings).
    /// </summary>
    public class CustomMetadataSetting
    {
        /// <summary>
        /// Default value for the metadata field.
        /// </summary>
        [JsonPropertyName("default")]
        public string Default { get; set; }

        /// <summary>
        /// Optional description of the metadata field.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The unique identifier of the metadata field.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Whether this metadata field is required.
        /// </summary>
        [JsonPropertyName("mandatory")]
        public bool Mandatory { get; set; }

        /// <summary>
        /// The name of the metadata field.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The data type of the metadata field: bool, date, int, multi-select, select, str.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Allowed values for select/multi-select types.
        /// </summary>
        [JsonPropertyName("values")]
        public string[] Values { get; set; }
    }

    /// <summary>
    /// A custom metadata value of a video (custom-metadata-values).
    /// </summary>
    public class CustomMetadataValue
    {
        /// <summary>
        /// Default value.
        /// </summary>
        [JsonPropertyName("default")]
        public string Default { get; set; }

        /// <summary>
        /// Optional description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The unique identifier of the metadata field.
        /// </summary>
        [JsonPropertyName("field_id")]
        public long FieldId { get; set; }

        /// <summary>
        /// The current value for the video.
        /// </summary>
        [JsonPropertyName("field_value")]
        public string FieldValue { get; set; }

        /// <summary>
        /// Whether this metadata field is required.
        /// </summary>
        [JsonPropertyName("mandatory")]
        public bool Mandatory { get; set; }

        /// <summary>
        /// The name of the metadata field.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The data type of the metadata field.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Allowed values for select/multi-select types.
        /// </summary>
        [JsonPropertyName("values")]
        public string[] Values { get; set; }
    }
}
