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
    /// Composer Scenes (Vimeo schema: composer-scenes).
    /// </summary>
    public class ComposerScene
    {
        /// <summary>
        /// The collection of graphic items, such as lower thirds, polls, and images, associated with this scene.
        /// </summary>
        [JsonPropertyName("graphics")]
        public ComposerSceneGraphicItem[] Graphics { get; set; }

        /// <summary>
        /// The unique identifier of the scene.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The additional information about the scene.
        /// </summary>
        [JsonPropertyName("meta")]
        public ComposerSceneMeta Meta { get; set; }

        /// <summary>
        /// The name of the scene.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// The additional information about the scene.
    /// </summary>
    public class ComposerSceneMeta
    {
        /// <summary>
        /// If the scene is scheduled to play automatically when stream starts.
        /// </summary>
        [JsonPropertyName("is_scheduled")]
        public bool? IsScheduled { get; set; }
    }

    /// <summary>
    /// ComposerSceneGraphicItem
    /// </summary>
    public class ComposerSceneGraphicItem
    {
        /// <summary>
        /// The unique identifier of the graphic item.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of the graphic item.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
