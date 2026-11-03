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

namespace VimeoClient.Filter.OnDemand
{
    /// <summary>
    /// The sort direction of the results.
    /// 	asc - Sort the results in ascending order.
    /// 	desc - Sort the results in descending order.
    /// </summary>
    public enum OnDemandDirection
    {
        /// <summary>
        /// Sort the results in ascending order
        /// </summary>
        asc,

        /// <summary>
        /// Sort the results in descending order
        /// </summary>
        desc
    }

    /// <summary>
    /// The type of the page to return.
    /// 	film - The page type is a film.
    /// 	series - The page type is a series.
    /// </summary>
    public enum OnDemandFilter
    {
        /// <summary>
        /// The page type is a film.
        /// </summary>
        film,

        /// <summary>
        /// The page type is a series.
        /// </summary>
        series
    }

    /// <summary>
    /// The way to sort the On Demand pages.
    /// </summary>
    public enum OnDemandPagesSort
    {
        /// <summary>
        /// Sort the results by most recently added page.
        /// </summary>
        added,

        /// <summary>
        /// Sort the results alphabetically.
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by date.
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by time of page modification.
        /// </summary>
        modified_time,

        /// <summary>
        /// Sort the results by page name.
        /// </summary>
        name,

        /// <summary>
        /// Sort the results by time of page publishing (publish.time).
        /// </summary>
        publish__time,

        /// <summary>
        /// Sort the results by content rating.
        /// </summary>
        rating,
    }

    /// <summary>
    /// The attribute by which to filter the On Demand pages of a genre.
    /// </summary>
    public enum OnDemandGenrePagesFilter
    {
        /// <summary>
        /// Return the pages available in the country.
        /// </summary>
        country,

        /// <summary>
        /// Return the pages available in the region of the authenticated user.
        /// </summary>
        my_region
    }

    /// <summary>
    /// The way to sort the On Demand pages of a genre.
    /// </summary>
    public enum OnDemandGenrePagesSort
    {
        /// <summary>
        /// Sort the results alphabetically.
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by date.
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by name.
        /// </summary>
        name,

        /// <summary>
        /// Sort the results by time of publishing (publish.time).
        /// </summary>
        publish__time,

        /// <summary>
        /// Sort the results by number of videos.
        /// </summary>
        videos
    }

    /// <summary>
    /// The type of promotion to return.
    /// </summary>
    public enum OnDemandPromotionFilter
    {
        /// <summary>
        /// Return batch promotions.
        /// </summary>
        batch,

        /// <summary>
        /// Return default promotions.
        /// </summary>
        @default,

        /// <summary>
        /// Return single promotions.
        /// </summary>
        single,

        /// <summary>
        /// Return VIP promotions.
        /// </summary>
        vip
    }

    /// <summary>
    /// The attribute by which to filter the purchases and rentals.
    /// </summary>
    public enum OnDemandPurchasesFilter
    {
        /// <summary>
        /// Return all the purchases.
        /// </summary>
        all,

        /// <summary>
        /// Return the purchases that are expiring soon.
        /// </summary>
        expiring_soon,

        /// <summary>
        /// Return the films.
        /// </summary>
        film,

        /// <summary>
        /// Return the important purchases.
        /// </summary>
        important,

        /// <summary>
        /// Return the rentals.
        /// </summary>
        rented,

        /// <summary>
        /// Return the series.
        /// </summary>
        series,

        /// <summary>
        /// Return the subscriptions.
        /// </summary>
        subscription,

        /// <summary>
        /// Return the unwatched purchases.
        /// </summary>
        unwatched,

        /// <summary>
        /// Return the watched purchases.
        /// </summary>
        watched
    }

    /// <summary>
    /// The way to sort the purchases and rentals.
    /// </summary>
    public enum OnDemandPurchasesSort
    {
        /// <summary>
        /// Sort the results by most recently added.
        /// </summary>
        added,

        /// <summary>
        /// Sort the results alphabetically.
        /// </summary>
        alphabetical,

        /// <summary>
        /// Sort the results by date.
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by name.
        /// </summary>
        name,

        /// <summary>
        /// Sort the results by purchase time.
        /// </summary>
        purchase_time,

        /// <summary>
        /// Sort the results by rating.
        /// </summary>
        rating,

        /// <summary>
        /// Sort the results by release date.
        /// </summary>
        release_date
    }

    /// <summary>
    /// The attribute by which to filter the seasons and the season's videos.
    /// </summary>
    public enum OnDemandSeasonFilter
    {
        /// <summary>
        /// Return the viewable seasons or videos.
        /// </summary>
        viewable
    }

    /// <summary>
    /// The way to sort the seasons.
    /// </summary>
    public enum OnDemandSeasonSort
    {
        /// <summary>
        /// Sort the results by date.
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by the manual order.
        /// </summary>
        manual
    }

    /// <summary>
    /// The attribute by which to filter the videos of an On Demand page.
    /// </summary>
    public enum OnDemandVideoFilter
    {
        /// <summary>
        /// Return all the videos.
        /// </summary>
        all,

        /// <summary>
        /// Return the purchasable videos.
        /// </summary>
        buy,

        /// <summary>
        /// Return the videos that are expiring soon.
        /// </summary>
        expiring_soon,

        /// <summary>
        /// Return the extra videos.
        /// </summary>
        extra,

        /// <summary>
        /// Return the main videos.
        /// </summary>
        main,

        /// <summary>
        /// Return the rentable videos.
        /// </summary>
        rent,

        /// <summary>
        /// Return the trailer.
        /// </summary>
        trailer,

        /// <summary>
        /// Return the unwatched videos.
        /// </summary>
        unwatched,

        /// <summary>
        /// Return the viewable videos.
        /// </summary>
        viewable,

        /// <summary>
        /// Return the watched videos.
        /// </summary>
        watched
    }

    /// <summary>
    /// The way to sort the videos of an On Demand page or season.
    /// </summary>
    public enum OnDemandVideoSort
    {
        /// <summary>
        /// Sort the results by date.
        /// </summary>
        date,

        /// <summary>
        /// Sort the results by the default order.
        /// </summary>
        @default,

        /// <summary>
        /// Sort the results by episode (pages only).
        /// </summary>
        episode,

        /// <summary>
        /// Sort the results by the manual order.
        /// </summary>
        manual,

        /// <summary>
        /// Sort the results by name.
        /// </summary>
        name,

        /// <summary>
        /// Sort the results by purchase time.
        /// </summary>
        purchase_time,

        /// <summary>
        /// Sort the results by release date.
        /// </summary>
        release_date
    }
}
