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
    /// The Buy interaction for a On Demand video.
    /// </summary>
    public class VideoMetadataInteractionBuy
    {
        //        metadata.interactions.buy.currency String
        //The currency code for the current user's region.
        //metadata.interactions.buy.display_price String
        //Formatted price to display to buy an On Demand video.
        //metadata.interactions.buy.download  String
        //The user's download access to this On Demand video:
        //Option descriptions:
        //available - The video is available for download.
        //purchased - The user has purchased the video.
        //restricted - The user isn't permitted to download the video.
        //unavailable - The video isn't available for download.
        //metadata.interactions.buy.drm Boolean
        //Whether the video has DRM.
        //metadata.interactions.buy.link String
        //The URL to buy the On Demand video on Vimeo.
        //metadata.interactions.buy.price Number
        //The numeric value of the price for buying the On Demand video.
        //metadata.interactions.buy.purchase_time String
        //The time in ISO 8601 format when the On Demand video was purchased.
        //metadata.interactions.buy.stream String
        //The user's streaming access to this On Demand video:
        //Option descriptions:
        //available - The video is available for streaming.
        //purchased - The user has purchased the video.
        //restricted - The user isn't permitted to stream the video.
        //unavailable - The video isn't available for streaming
        //metadata.interactions.buy.uri String
        //The product URI to purchase the On Demand video.
    }
}