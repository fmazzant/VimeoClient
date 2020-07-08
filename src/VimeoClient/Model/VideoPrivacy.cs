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
    /// The video's privacy setting.
    /// </summary>
    public class VideoPrivacy
    {
        //        privacy.add Boolean
        //Whether the video can be added to collections.
        //    privacy.comments    String
        //Who can comment on the video:
        //Option descriptions:
        //anybody - Anyone can comment on the video.
        //contacts - Only contacts can comment on the video.
        //nobody - No one can comment on the video.
        //    privacy.download Boolean
        //The video's download permission setting.
        //    privacy.embed String
        //The video's embed permission setting:
        //Option descriptions:
        //private - The video is private.
        //public - Anyone can embed the video.
        //    privacy.view String
        //The general privacy setting for the video:
        //Option descriptions:
        //anybody - Anyone can view the video.
        //contacts - Only contacts can view the video.
        //disable - Hide from vimeo
        //nobody - No one besides the owner can view the video.
        //password - Anyone with the video's password can view the video.
        //unlisted - Not searchable from vimeo.com
        //users - Only people with a Vimeo account can view the video.
    }
}