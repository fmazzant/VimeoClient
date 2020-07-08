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
    /// 360 spatial data.
    /// </summary>
    public class VideoSpatial
    {
        /// <summary>
        /// 360 director timeline
        /// </summary>
        [JsonPropertyName("comments")]
        public string[] DirectorTimeline { get; set; }

        /// <summary>
        /// The director timeline pitch, from -90 (minimum) to 90 (maximum).
        /// </summary>
        [JsonPropertyName("pitch")]
        public int Pitch { get; set; }

        /// <summary>
        /// The director timeline roll.
        /// </summary>
        [JsonPropertyName("roll")]
        public int Roll { get; set; }

        /// <summary>
        /// The director timeline time code.
        /// </summary>
        [JsonPropertyName("time_code")]
        public int TimeCode { get; set; }

        /// <summary>
        /// The director timeline yaw, from 0 (minimum) to 360 (maximum).
        /// </summary>
        [JsonPropertyName("yaw")]
        public int Yaw { get; set; }

        /// <summary>
        /// The director timeline yaw, from 0 (minimum) to 360 (maximum).
        /// </summary>
        [JsonPropertyName("field_of_view")]
        public int FieldOfView { get; set; }

        /// <summary>
        /// The 360 spatial projection:
        /// Option descriptions:
        ///     cubical - The spatial projection is cubical.
        ///     cylindrical - The spatial projection is cylindrical.
        ///     dome - The spatial projection is dome-shaped.
        ///     equirectangular - The spatial projection is equirectangular.
        ///     pyramid - The spatial projection is pyramid-shaped.
        /// </summary>
        [JsonPropertyName("projection")]
        public string Projection { get; set; }

        /// <summary>
        /// The 360 stereo format:
        /// Option descriptions:
        ///     left-right - The stereo format is left-right.
        ///     mono - The audio is monaural.
        /// </summary>
        [JsonPropertyName("stereo_format")]
        public string StereoFormat { get; set; }

    }
}