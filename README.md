# VimeoClient

VimeoClient is a extendible .NET wrapper for Vimeo API v3.4.

By Mafe.RestClient library it can be possible to develop a vimeo webapi call.

```c#
VimeoClient.Vimeo client = new VimeoClient.Vimeo(new VimeoProperties
{
    AccessToken = "MyAccessToken",
    ClientSecret = "MyClientSecret",
    ClientId = "MyClientId",
    ValidCertificates = new List<string>() { "Vimeo certs" }
});
```

Now, you are using client to call a Vimeo rest methods. You can access to user information

 ```c#
var user = client.Me.GetTheUser(); //myself
var user = client.Users.GetTheUser(userId); //other users
```

## Vimeo API version

Every request sends the header `Accept: application/vnd.vimeo.*+json;version=3.4`.
You can request another version by `VimeoProperties.ApiVersion`:

```c#
var client = new VimeoClient.Vimeo(new VimeoProperties
{
    AccessToken = "MyAccessToken",
    ApiVersion = "3.4" // default
});
```

## Certificates

- `ValidCertificates` empty: the standard TLS validation is used.
- `ValidCertificates` set: the certificate must be valid **and** its hash must be in the list (pinning).
- `Debug = true` skips the validation: use it only in development (default `false`).

## Sections

```c#
// On Demand
var page = client.OnDemand.MeCreateAnOnDemandPage(new CreateAnOnDemandPageBody
{
    Type = OnDemandPageType.film,
    Name = "My film",
    Description = "...",
    ContentRating = new List<OnDemandContentRating> { OnDemandContentRating.safe },
    Rent = new OnDemandPriceOption { Active = true, Period = OnDemandRentPeriod._1_week, Price = { ["USD"] = 1.99 } }
});

// Pagination
var videos = client.OnDemand.GetAllTheVideosOnAnOnDemandPage(ondemandId, per_page: 25);
var next = videos.Content.Next();

// Analytics (Enterprise plan, enabled for the API app by Vimeo support)
var stats = client.Analytics.GetAnalyticsForTheAuthenticatedUser(
    AnalyticsDimension.country,
    from: new DateTime(2026, 1, 1),
    to: new DateTime(2026, 1, 31),
    time_interval: AnalyticsTimeInterval.week,
    sort: AnalyticsSort.views,
    direction: AnalyticsDirection.desc);

// App webhooks
var webhook = client.Webhooks.AddAWebhookForAnApp(appId, "video-transcode-complete", "https://example.com/hook", is_enabled: true);

// Subscription plans, payment methods, federated search, teams, hosted files
var plan = client.Payments.GetASubscriptionPlan("pro");
var items = client.Search.SearchTheItemsOfAUser(userId, query: "demo");
var fields = client.Teams.GetTheCustomMetadataFieldsOfATeam(teamOwnerId);

// Folders, Portfolios, Showcases, Videos, Live, Channels, Categories, Groups...
var folders = client.Folders.GetAllTheFoldersThatBelongToTheUser();
var showcases = client.ShowCases.GetAllTheShowcasesThatBelongToTheUser();
var video = client.Videos.GetSpecificVideo(videoId);
```

The library is in temporary status and it is working in progress.
