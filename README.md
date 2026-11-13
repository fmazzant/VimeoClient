# VimeoClient

[![NuGet](https://img.shields.io/nuget/v/Mafesoft.VimeoClient?style=flat-square&label=nuget)](https://www.nuget.org/packages/Mafesoft.VimeoClient)
[![Downloads](https://img.shields.io/nuget/dt/Mafesoft.VimeoClient?style=flat-square&label=downloads)](https://www.nuget.org/packages/Mafesoft.VimeoClient)
[![Build](https://img.shields.io/github/actions/workflow/status/fmazzant/VimeoClient/ci.yml?branch=master&style=flat-square&label=build)](https://github.com/fmazzant/VimeoClient/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue?style=flat-square)](https://github.com/fmazzant/VimeoClient/blob/master/LICENSE)
[![CodeQL](https://img.shields.io/github/actions/workflow/status/fmazzant/VimeoClient/codeql.yml?branch=master&style=flat-square&label=codeql)](https://github.com/fmazzant/VimeoClient/actions/workflows/codeql.yml)
[![.NET](https://img.shields.io/badge/.NET-10%20%7C%208%20%7C%20Standard%202.1%20%7C%20Standard%202.0%20%7C%20Framework%204.6.2%2B-512BD4?style=flat-square)](#)

[![Mafe.VimeoClient downloads](https://img.shields.io/badge/Mafe.VimeoClient%20downloads-2.1k-lightgrey?style=flat-square)](https://www.nuget.org/packages/Mafe.VimeoClient)

VimeoClient is an extensible .NET wrapper for the [Vimeo API 3.4](https://developer.vimeo.com/api/reference). It is built on [Mafesoft.RestClient](https://www.nuget.org/packages/Mafesoft.RestClient) and covers every operation of the Vimeo API 3.4 OpenAPI specification with typed methods, models and parameters.

If VimeoClient is useful to you, consider [supporting the project](#support). ☕

## Why VimeoClient

| Feature | Description |
|---|---|
| Whole Vimeo API 3.4 | Every operation of the OpenAPI specification, grouped by section as in the Vimeo reference (`client.Videos`, `client.Live`, `client.OnDemand`…). See [Sections](#sections) |
| Typed models and parameters | Responses mapped to classes, enums for the documented values, body classes for create and update requests. See [On Demand](#on-demand) |
| Pagination | `Pagination<T>` with `Next()` and `Previous()` to load the other pages. See [Sections](#sections) |
| Nothing lost | Unmapped fields in `AdditionalData`, undocumented responses as raw `JsonElement`, undocumented bodies as `VimeoPayload`. See [Sections](#sections) |
| API version | The `Accept` header asks for the Vimeo API 3.4 by default; another version can be requested with `ApiVersion`. See [Vimeo API version](#vimeo-api-version) |
| Certificate pinning | Standard TLS validation, or validation plus a list of trusted certificate hashes. See [Certificates](#certificates) |
| Latest Vimeo features | Chapters, animated thumbnails, AI (questions, metadata, dubbing), audio tracks, transcripts, trimming, live scenes and destinations, analytics, webhooks, team custom metadata. See [Videos: chapters, animated thumbnails, AI](#videos-chapters-animated-thumbnails-ai) |
| Tested | xUnit tests on every target framework against a fake HTTP handler, run on every push and pull request. See [Tests](#tests) |

### Compared with the other .NET libraries

Vimeo has no official .NET SDK. The other libraries on NuGet cover only a part of the API:

| | VimeoClient | [VimeoDotNet](https://github.com/mfilippov/vimeo-dot-net) | [Skybrud.Social.Vimeo](https://github.com/abjerner/Skybrud.Social.Vimeo) | [Vimeo.Net](https://www.nuget.org/packages/Vimeo.Net) |
|---|---|---|---|---|
| Vimeo API sections | All (25 sections, every operation of the 3.4 specification) | Videos, upload, albums, channels, folders, embed presets, tags, text tracks | Me, users, videos, channels | Not documented |
| Live events, On Demand, webhooks, analytics, teams | ✔ | ✘ | ✘ | Not documented |
| Chapters, AI, audio tracks, transcripts, trimming | ✔ | ✘ | ✘ | Not documented |
| Status | Stable | Stable | Stable | Prerelease (`3.4.0-alpha`, 2023) |
| Targets | .NET 8 and 10, .NET Standard 2.0 and 2.1, .NET Framework 4.6.2+ | .NET Standard 1.3 and 2.0, .NET Framework 4.5 | .NET 8, .NET Standard 2.0 | .NET Standard 2.0 |
| JSON | `System.Text.Json` | Newtonsoft.Json | Skybrud.Essentials | Newtonsoft.Json, RestSharp |
| Unmapped fields kept (`AdditionalData`) | ✔ | Not documented | Raw responses | Not documented |
| Certificate pinning | ✔ | Not documented | Not documented | Not documented |

*Compared in November 2026 on the public repositories and NuGet pages of each library.*

## Requirements

- .NET 8 or 10
- .NET Standard 2.0 or 2.1
- .NET Framework 4.6.2, 4.7.2 or 4.8.1

## Installation

The library is published on NuGet: [Mafesoft.VimeoClient](https://www.nuget.org/packages/Mafesoft.VimeoClient).

```shell
dotnet add package Mafesoft.VimeoClient
```

> **Migrating from `Mafe.VimeoClient`**: since version 3.4.0 the package is `Mafesoft.VimeoClient`
> and the namespaces start with `Mafesoft.VimeoClient` (for example `Mafesoft.VimeoClient.Model`).
> Replace the package reference and change `using VimeoClient...` into `using Mafesoft.VimeoClient...`.

## Usage

Create the client with the credentials of your [Vimeo API app](https://developer.vimeo.com/apps):

```c#
using Mafesoft.VimeoClient;

var client = new Vimeo(new VimeoProperties
{
    AccessToken = "MyAccessToken",
    ClientSecret = "MyClientSecret",
    ClientId = "MyClientId",
    ValidCertificates = new List<string>() { "Vimeo certs" } // optional, see Certificates
});
```

Then call the Vimeo API methods through the client, for example to read the user information:

```c#
var me = client.Me.GetTheUser(); // the authenticated user
var user = client.Users.GetTheUser(userId); // another user
```

## Vimeo API version

Every request sends the header `Accept: application/vnd.vimeo.*+json;version=3.4`.
You can request another version by `VimeoProperties.ApiVersion`:

```c#
var client = new Vimeo(new VimeoProperties
{
    AccessToken = "MyAccessToken",
    ApiVersion = "3.4" // default
});
```

## Package version

The version of the `Mafesoft.VimeoClient` package has three numbers, for example `3.4.0`:

- the first two numbers (`3.4`) identify the Vimeo API version supported by the library;
- the last number (`0`) is for the fixes of the library released for that Vimeo API version: `3.4.0` is the first release for the Vimeo API 3.4, `3.4.1` the next one, and so on.

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

## Sample app

`samples/VimeoClientSampleApp` shows the common scenarios: the authenticated user, the list of the videos with pagination,
the upload of a video (from a local file or a public URL) and the webhooks of an API app.
The keys are read with `dotnet user-secrets` (or the environment variables `Vimeo__AccessToken`, `Vimeo__ClientId`…):

```shell
cd samples/VimeoClientSampleApp
dotnet user-secrets set "Vimeo:AccessToken" "your-access-token"
dotnet run -- videos
dotnet run -- upload path/to/video.mp4
dotnet run -- webhook APP_ID PUBLIC_URL
```

## Tests

The xUnit tests are in `tests/VimeoClient.Tests`. They don't call Vimeo: every request is sent to a fake HTTP handler,
which checks the method, the path, the query string and the body, and returns canned responses.

```shell
dotnet test src/VimeoClient.sln
```

The tests run on `net462`, `net472`, `net481`, `net8.0` and `net10.0`: the .NET Framework targets run only on Windows.

The GitHub Actions pipelines run the tests on every push and pull request (`ci.yml`: .NET 8 and 10 on Linux,
every target on Windows), and the package is published on NuGet only when all the tests pass on every target (`nuget.yml`).

### Integration tests

The integration tests in `tests/VimeoClient.IntegrationTests` call the real Vimeo API, so they notice when Vimeo changes it.
They run only when the `VIMEO_ACCESS_TOKEN` environment variable is set, otherwise they are skipped:

- read-only calls (`Tutorial`, `Me`, videos with pagination, folders) need only the access token;
- the calls that create and delete resources (a folder) run only with `VIMEO_INTEGRATION_WRITE=true`: use a test account.

```shell
export VIMEO_ACCESS_TOKEN=... # never commit the token
dotnet test tests/VimeoClient.IntegrationTests/VimeoClient.IntegrationTests.csproj
```

The `integration.yml` pipeline runs them every Monday and manually, with the `VIMEO_ACCESS_TOKEN` repository secret
and the `VIMEO_INTEGRATION_WRITE` repository variable.

## Support

If VimeoClient saves you time, you can say thanks with a small donation. It is never required, but it helps me keep the project maintained and up to date.

[![Donate](https://img.shields.io/badge/donate-PayPal-00457C?style=flat-square&logo=paypal&logoColor=white)](https://paypal.me/fmazzant)

A star on GitHub, a bug report or a pull request help too. Thank you!

## License

VimeoClient is released under the [MIT License](LICENSE).
