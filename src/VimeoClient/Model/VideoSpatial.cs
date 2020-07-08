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
    /// <summary>
    /// 360 spatial data.
    /// </summary>
    public class VideoSpatial
    {
        //        spatial.director_timeline Array	
        //360 director timeline.
        //  spatial.director_timeline.pitch Number
        //The director timeline pitch, from -90 (minimum) to 90 (maximum).
        //  spatial.director_timeline.roll Number
        //The director timeline roll.
        //  spatial.director_timeline.time_code Number
        //The director timeline time code.
        //  spatial.director_timeline.yaw Number
        //The director timeline yaw, from 0 (minimum) to 360 (maximum).
        //  spatial.field_of_view Number
        //The 360 field of view, from 30 (minimum) to 90 (maximum). The default is 50.
        //  spatial.projection String
        //The 360 spatial projection:
        //Option descriptions:
        //cubical - The spatial projection is cubical.
        //cylindrical - The spatial projection is cylindrical.
        //dome - The spatial projection is dome-shaped.
        //equirectangular - The spatial projection is equirectangular.
        //pyramid - The spatial projection is pyramid-shaped.
        //  spatial.stereo_format String
        //The 360 stereo format:
        //Option descriptions:
        //left-right - The stereo format is left-right.
        //mono - The audio is monaural.
    }
}