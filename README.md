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

Every section of the Vimeo API reference is a property of the client.
All the operations of the Vimeo API 3.4 OpenAPI specification are implemented.

| Property | Section | Notes |
|---|---|---|
| `client.Me` / `client.Users` | Users: essentials, feeds, followers, pictures, watch history, LMS packages | `Me` works on the authenticated user |
| `client.Videos` | Videos: essentials, uploads, versions, audio tracks, text tracks, transcripts, thumbnails, chapters, animated thumbnails, fragments, trimming, credits, comments, tags, privacy, AI | |
| `client.Channels` | Channels: essentials, categories, moderators, members, subscriptions, tags, videos | includes comments, credits, thumbnails, privacy and text tracks of channel videos |
| `client.ShowCases` | Showcases (albums): essentials, videos, custom logos and thumbnails | |
| `client.Folders` | Folders (projects): essentials, items, videos | |
| `client.Live` | Live events: essentials, destinations, sessions, graphics, scenes, thumbnails, videos | asynchronous methods (`...Async`) |
| `client.OnDemand` | On Demand: pages, backgrounds, genres, posters, promotions, purchases, regions, seasons, videos | |
| `client.EmbedPresets` | Embed presets: essentials, custom logos, folders, timeline events, videos | |
| `client.Analytics` | Analytics of the user's content | Enterprise plan |
| `client.Webhooks` | API app webhooks | |
| `client.Teams` | Teams: roles, memberships, custom metadata fields | |
| `client.TeamMembers` | Team membership by join code | |
| `client.Payments` | Payment methods, subscriptions, subscription plans | |
| `client.Search` | Federated search of users and workspaces | |
| `client.Files` | Hosted files | |
| `client.Categories`, `client.Groups`, `client.Likes`, `client.Portfolios`, `client.Tags`, `client.WatchLaterQueue` | The other sections of the reference | |
| `client.APIInformation`, `client.AuthenticationExtras`, `client.CommonFormatsParameters` | API specification, tokens, field filtering | |

Methods that return a list use `Pagination<T>`: call `Next()` / `Previous()` to load the other pages.

```c#
var videos = client.OnDemand.GetAllTheVideosOnAnOnDemandPage(ondemandId, per_page: 25);
var next = videos.Content.Next();
```

When the specification does not document a response, the method returns the raw JSON (`JsonElement`);
when it does not document a request body, the method accepts a `VimeoPayload`.
The fields of a response not mapped by the library are available in `AdditionalData`.

### On Demand

```c#
var page = client.OnDemand.MeCreateAnOnDemandPage(new CreateAnOnDemandPageBody
{
    Type = OnDemandPageType.film,
    Name = "My film",
    Description = "...",
    ContentRating = new List<OnDemandContentRating> { OnDemandContentRating.safe },
    Rent = new OnDemandPriceOption { Active = true, Period = OnDemandRentPeriod._1_week, Price = { ["USD"] = 1.99 } }
});
```

### Videos: chapters, animated thumbnails, AI

```c#
var chapter = client.Videos.AddAChapterToAVideo(videoId, new ChapterParameters { Title = "Intro", Timecode = 0 });
var chapters = client.Videos.GetAllTheChaptersOfAVideo(videoId);

var thumbset = client.Videos.CreateASetOfAnimatedThumbnailsForAVideo(videoId, duration: 6, start_time: 10);

// AI: a 202 status code means that the video is still being prepared, retry after a few seconds
var answer = client.Videos.AskAQuestionAboutAVideo(videoId, "What is the video about?");
var metadata = client.Videos.GetAIGeneratedVideoMetadata(videoId); // title, description and tags
var dubbing = client.Videos.StartAIAudioDubbingForAVideo(videoId, language: "it");
```

### Videos: versions, audio tracks, transcripts, fragments, trimming

```c#
// Alternate audio tracks of a version: create it, then upload the file to the returned link
var track = client.Videos.CreateAnAudioTrackForAVideoVersion(videoId, versionId,
    upload_approach: "tus", upload_size: fileSize, language_code: "it-IT", type: "main");
var tracks = client.Videos.GetAllTheAudioTracksOfAVideoVersion(videoId, versionId);
var downloads = client.Videos.GetTheDownloadLinksOfAVideoVersion(videoId, versionId); // raw JSON

// Transcripts
var segments = client.Videos.GetTheTranscriptSegmentsOfATextTrack(videoId, texttrackId);

// Nondestructive trimming and fragments
var trimmed = client.Videos.StartATrimOperationForAVideo(videoId, trim_start: 5, trim_end: 60);
var fragments = client.Videos.GetAllTheFragmentsOfAVideo(videoId);

// Users who can be credited
var candidates = client.Videos.GetTheUsersWhoCanBeCreditedOnAVideo(videoId, query: "john");
```

### Channel videos

The channel ID is a string (it can be a numeric ID or a name, for example `staffpicks`);
the video ID can be an `int` or a `string`.

```c#
var comments = client.Channels.GetAllTheCommentsOnAChannelVideo(channelId, videoId);
client.Channels.AddACommentToAChannelVideo(channelId, videoId, "Great video!");
var tracks = client.Channels.GetAllTheTextTracksOfAChannelVideo("staffpicks", videoId);
```

### Live: destinations, graphics, scenes

```c#
var status = await client.Live.GetTheIngestStatusOfAnEventAsync(liveEventId);

// Simulcast destinations
var destinations = await client.Live.GetAllTheAvailableEventDestinationsAsync(); // raw JSON
var destination = await client.Live.UpdateAnEventDestinationAsync(destinationId, is_enabled: true);
var ott = await client.Live.GetAllTheOttDestinationsOfAnEventAsync(userId, liveEventId);

// Composer: video graphics and scenes
var graphic = await client.Live.AddAVideoGraphicsItemToAnEventAsync(liveEventId, videoId);
var scene = await client.Live.CreateASceneForAnEventAsync(liveEventId);
var scenes = await client.Live.GetAllTheScenesOfAnEventAsync(liveEventId);
await client.Live.ResetTheScenesOfAnEventAsync(liveEventId);
```

### Analytics

The Analytics API requires an Enterprise plan and must be enabled for the API app by Vimeo support.

```c#
var stats = client.Analytics.GetAnalyticsForTheAuthenticatedUser(
    AnalyticsDimension.country,
    from: new DateTime(2026, 1, 1),
    to: new DateTime(2026, 1, 31),
    time_interval: AnalyticsTimeInterval.week,
    sort: AnalyticsSort.views,
    direction: AnalyticsDirection.desc);

foreach (var row in stats.Content.Data)
{
    Console.WriteLine($"{row.Country?.Name}: {row.Views} views, {row.TotalTimeWatched}s watched");
}
```

### Webhooks

```c#
var webhook = client.Webhooks.AddAWebhookForAnApp(appId,
    webhook_type: "video-transcode-complete",
    webhook_url: "https://example.com/hook",
    is_enabled: true,
    secret: "my-secret");

var webhooks = client.Webhooks.GetAllTheWebhooksOfAnApp(appId);
client.Webhooks.UpdateAWebhook(appId, webhookId, is_enabled: false);
client.Webhooks.DeleteAWebhook(appId, webhookId);
```

### Teams

```c#
var role = client.Teams.GetTheRoleOfTheUserOnATeam(teamOwnerId);

// Custom metadata fields: omit Id to create, set Id to update, set Id and Delete = true to delete
var fields = client.Teams.CreateUpdateOrDeleteTheCustomMetadataFieldsOfATeam(teamOwnerId, new[]
{
    new CustomMetadataFieldChange { Name = "Department", Type = "select", Mandatory = true, Values = new[] { "Sales", "Engineering" } }
});

client.Teams.UpdateTheOptionsOfACustomMetadataField(teamOwnerId, fieldId, new[]
{
    new CustomMetadataOptionChange { OldValue = "Engineering", NewValue = "R&D" }
});

client.Teams.BackfillACustomMetadataValueAcrossTheVideosOfATeam(teamOwnerId, fieldId, "Sales");
var incomplete = client.Teams.GetTheVideosMissingMandatoryCustomMetadata(teamOwnerId); // raw JSON
```

### Payments, search, files, LMS

```c#
var plan = client.Payments.GetASubscriptionPlan("pro");
var methods = client.Payments.GetAllThePaymentMethods();

var items = client.Search.SearchTheItemsOfAUser(userId, query: "demo", query_fields: new[] { "title", "tags" });

var file = client.Files.GetAFile(publicFileId);

// Zipped proxy package for a learning management system
var package = client.Users.DownloadAnLmsPackageForAVideo(teamOwnerId, videoId, standard: "scorm2004_3rd");
File.WriteAllBytes("course.zip", package.Content);
```

### Other sections

```c#
var folders = client.Folders.GetAllTheFoldersThatBelongToTheUser();
var showcases = client.ShowCases.GetAllTheShowcasesThatBelongToTheUser();
var video = client.Videos.GetSpecificVideo(videoId);
```

The library is in temporary status and it is working in progress.
