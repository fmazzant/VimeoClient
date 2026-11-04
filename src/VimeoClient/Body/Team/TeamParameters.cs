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

namespace Mafesoft.VimeoClient.Body.Team
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A change to a custom metadata field of a team: omit <see cref="Id"/> to create a field,
    /// set it to update the field, set it with <see cref="Delete"/> = true to delete the field.
    /// </summary>
    public class CustomMetadataFieldChange
    {
        /// <summary>
        /// The ID of an existing field. Omit to create a new field.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// When true, combined with id, deletes the field and all values assigned to it.
        /// </summary>
        [JsonPropertyName("delete")]
        public bool? Delete { get; set; }

        /// <summary>
        /// The display name of the field. Required when creating a new field. Up to 255 characters.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The data type of the field: bool, date, int, multi-select, select, str.
        /// Required when creating a new field. Immutable after creation.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Whether videos must have a value for this field. Required when creating a new field.
        /// Can only be relaxed (true to false) after creation.
        /// </summary>
        [JsonPropertyName("mandatory")]
        public bool? Mandatory { get; set; }

        /// <summary>
        /// A short explanation of the field's purpose. Up to 1024 characters.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The value applied by default when a video doesn't specify one.
        /// </summary>
        [JsonPropertyName("default_value")]
        public string DefaultValue { get; set; }

        /// <summary>
        /// The list of allowed values. Required for select and multi-select fields.
        /// </summary>
        [JsonPropertyName("values")]
        public string[] Values { get; set; }
    }

    /// <summary>
    /// A change to the allowed values of a select or multi-select custom metadata field:
    /// rename (old and new value), delete (old value only) or add (new value only).
    /// </summary>
    public class CustomMetadataOptionChange
    {
        /// <summary>
        /// The existing value the operation targets. Required for rename and delete.
        /// </summary>
        [JsonPropertyName("old_value")]
        public string OldValue { get; set; }

        /// <summary>
        /// The replacement value. Required for rename and add.
        /// </summary>
        [JsonPropertyName("new_value")]
        public string NewValue { get; set; }
    }
}
