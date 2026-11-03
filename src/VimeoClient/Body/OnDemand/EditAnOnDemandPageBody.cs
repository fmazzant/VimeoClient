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

namespace VimeoClient.Body.OnDemand
{
    using System.Collections.Generic;

    /// <summary>
    /// The body to edit an On Demand page: enable preorders or publish the page.
    /// </summary>
    public class EditAnOnDemandPageBody : IEditParameters, IPayloadParameters
    {
        /// <summary>
        /// The custom string to use in the Vimeo URL of the On Demand page.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Whether to enable preorders on the On Demand page.
        /// </summary>
        public bool? PreorderActive { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the preorder will be published.
        /// </summary>
        public string PreorderPublishTime { get; set; }

        /// <summary>
        /// Whether to publish the On Demand page.
        /// </summary>
        public bool? PublishActive { get; set; }

        /// <summary>
        /// Whether to publish the On Demand page automatically after all the videos finish transcoding.
        /// </summary>
        public bool? PublishWhenReady { get; set; }

        /// <summary>
        /// Builds the JSON body
        /// </summary>
        /// <returns></returns>
        public VimeoPayload ToPayload() => new VimeoPayload()
            .Set("link", Link)
            .Set("preorder.active", PreorderActive)
            .Set("preorder.publish_time", PreorderPublishTime)
            .Set("publish.active", PublishActive)
            .Set("publish_when_ready", PublishWhenReady);

        /// <summary>
        /// Convert object to key value pair enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> ToEnumerable() => ToPayload().Flatten();
    }
}
