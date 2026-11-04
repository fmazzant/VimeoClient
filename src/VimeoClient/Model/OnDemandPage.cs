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
    using System.Text.Json.Serialization;

    /// <summary>
    /// The On Demand page representation consists of the following fields.
    /// </summary>
    public class OnDemandPage : VimeoIdentity
    {
        /// <summary>
        /// The background image for the On Demand page on Vimeo.
        /// </summary>
        [JsonPropertyName("background")]
        public Picture Background { get; set; }

        /// <summary>
        /// Information about purchasing this On Demand page.
        /// </summary>
        [JsonPropertyName("buy")]
        public OnDemandPurchaseOption Buy { get; set; }

        /// <summary>
        /// The primary and secondary colors used for rendering this On Demand page.
        /// </summary>
        [JsonPropertyName("colors")]
        public OnDemandColors Colors { get; set; }

        /// <summary>
        /// The content ratings of this On Demand page.
        /// </summary>
        [JsonPropertyName("content_rating")]
        public string[] ContentRating { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the page was created.
        /// </summary>
        [JsonPropertyName("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// A brief explanation of the On Demand page's content.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// A set of information about the episodes of a series.
        /// </summary>
        [JsonPropertyName("episodes")]
        public OnDemandEpisodes Episodes { get; set; }

        /// <summary>
        /// The film's video of this On Demand page, if the type is film.
        /// </summary>
        [JsonPropertyName("film")]
        public Video Film { get; set; }

        /// <summary>
        /// All the genres assigned to this page.
        /// </summary>
        [JsonPropertyName("genres")]
        public OnDemandGenre[] Genres { get; set; }

        /// <summary>
        /// The link to the page on Vimeo.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The page's metadata.
        /// </summary>
        [JsonPropertyName("metadata")]
        public OnDemandMetadata Metadata { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the page was last modified.
        /// </summary>
        [JsonPropertyName("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// A descriptive title of this On Demand page.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The active poster for this On Demand page.
        /// </summary>
        [JsonPropertyName("pictures")]
        public Picture Pictures { get; set; }

        /// <summary>
        /// Information about this On Demand page's preorder.
        /// </summary>
        [JsonPropertyName("preorder")]
        public OnDemandPreorder Preorder { get; set; }

        /// <summary>
        /// Information about this On Demand page's publish status.
        /// </summary>
        [JsonPropertyName("published")]
        public OnDemandPublished Published { get; set; }

        /// <summary>
        /// The rating of this On Demand page.
        /// </summary>
        [JsonPropertyName("rating")]
        public double? Rating { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the page was released.
        /// </summary>
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The year when the page was released.
        /// </summary>
        [JsonPropertyName("release_year")]
        public int? ReleaseYear { get; set; }

        /// <summary>
        /// Information about renting this On Demand page.
        /// </summary>
        [JsonPropertyName("rent")]
        public OnDemandPurchaseOption Rent { get; set; }

        /// <summary>
        /// The SKU of the On Demand page.
        /// </summary>
        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Information about subscribing to this On Demand page.
        /// </summary>
        [JsonPropertyName("subscription")]
        public OnDemandSubscription Subscription { get; set; }

        /// <summary>
        /// The thumbnail of this On Demand page.
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public Picture Thumbnail { get; set; }

        /// <summary>
        /// The trailer of this On Demand page.
        /// </summary>
        [JsonPropertyName("trailer")]
        public Video Trailer { get; set; }

        /// <summary>
        /// The type of this On Demand page: film or series.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The owner of this On Demand page.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    /// <summary>
    /// The primary and secondary colors used for rendering the On Demand page.
    /// </summary>
    public class OnDemandColors
    {
        /// <summary>
        /// The hexadecimal color code for the page's primary color.
        /// </summary>
        [JsonPropertyName("primary")]
        public string Primary { get; set; }

        /// <summary>
        /// The hexadecimal color code for the page's secondary color.
        /// </summary>
        [JsonPropertyName("secondary")]
        public string Secondary { get; set; }
    }

    /// <summary>
    /// Purchase or rent option of an On Demand page or episode.
    /// </summary>
    public class OnDemandPurchaseOption
    {
        /// <summary>
        /// Whether the option is active.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Whether the videos can be downloaded (buy only).
        /// </summary>
        [JsonPropertyName("download")]
        public bool? Download { get; set; }

        /// <summary>
        /// The rental period (rent only), for example 1 week.
        /// </summary>
        [JsonPropertyName("period")]
        public string Period { get; set; }

        /// <summary>
        /// The price by currency code, for example { "USD": 9.99 }.
        /// </summary>
        [JsonPropertyName("price")]
        public Dictionary<string, double?> Price { get; set; }
    }

    /// <summary>
    /// Information about the episodes of a series.
    /// </summary>
    public class OnDemandEpisodes
    {
        /// <summary>
        /// Information about purchasing the episodes.
        /// </summary>
        [JsonPropertyName("buy")]
        public OnDemandPurchaseOption Buy { get; set; }

        /// <summary>
        /// Information about renting the episodes.
        /// </summary>
        [JsonPropertyName("rent")]
        public OnDemandPurchaseOption Rent { get; set; }
    }

    /// <summary>
    /// Information about the On Demand page's preorder.
    /// </summary>
    public class OnDemandPreorder
    {
        /// <summary>
        /// Whether the preorder is active.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the preorder was cancelled.
        /// </summary>
        [JsonPropertyName("cancel_time")]
        public string CancelTime { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the preorder will be published.
        /// </summary>
        [JsonPropertyName("publish_time")]
        public string PublishTime { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the preorder was started.
        /// </summary>
        [JsonPropertyName("time")]
        public string Time { get; set; }
    }

    /// <summary>
    /// Information about the On Demand page's publish status.
    /// </summary>
    public class OnDemandPublished
    {
        /// <summary>
        /// Whether the page has been published.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The time in ISO 8601 format when the page was published.
        /// </summary>
        [JsonPropertyName("time")]
        public string Time { get; set; }
    }

    /// <summary>
    /// Information about subscribing to an On Demand page.
    /// </summary>
    public class OnDemandSubscription
    {
        /// <summary>
        /// Whether the subscription is active.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The URL to subscribe.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The subscription period.
        /// </summary>
        [JsonPropertyName("period")]
        public string Period { get; set; }

        /// <summary>
        /// The price by currency code.
        /// </summary>
        [JsonPropertyName("price")]
        public Dictionary<string, double?> Price { get; set; }
    }

    /// <summary>
    /// The On Demand metadata.
    /// </summary>
    public class OnDemandMetadata
    {
        /// <summary>
        /// The connections (comments, genres, likes, pictures, seasons, trailer, videos...).
        /// </summary>
        [JsonPropertyName("connections")]
        public Dictionary<string, GenericRelatedEntity> Connections { get; set; }

        /// <summary>
        /// The interactions of the authenticated user (buy, rent, subscribe, like...).
        /// </summary>
        [JsonPropertyName("interactions")]
        public Dictionary<string, OnDemandInteraction> Interactions { get; set; }
    }

    /// <summary>
    /// An interaction (buy, rent, subscribe, like...) on an On Demand page.
    /// </summary>
    public class OnDemandInteraction
    {
        /// <summary>
        /// Whether the interaction has been done.
        /// </summary>
        [JsonPropertyName("added")]
        public bool? Added { get; set; }

        /// <summary>
        /// The time in ISO 8601 format of the interaction.
        /// </summary>
        [JsonPropertyName("added_time")]
        public string AddedTime { get; set; }

        /// <summary>
        /// The URL to start the interaction.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The status of the interaction.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The URI of the interaction.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}
