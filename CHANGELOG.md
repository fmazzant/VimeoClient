# Changelog

All notable changes to the `Mafesoft.VimeoClient` package are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.4.1] - 2026-11-14

### Added

- An `...Async` version of every API method of `Vimeo` and of every section (`client.Videos`, `client.Users`,
  `client.OnDemand`, ...): 484 new methods that return a `Task<RestResult<...>>`. The synchronous methods are
  unchanged; the methods that return the non-generic `RestResult` return `Task<RestResult<string>>` in the async
  version, as `VimeoLive` does. `[Obsolete]` methods have no async version.
  ([#12](https://github.com/fmazzant/VimeoClient/issues/12))
- `CancellationToken`: every asynchronous method has an optional `cancellationToken` last parameter, also the
  existing ones of `VimeoLive` and `VimeoAPIInformation`. When the token is canceled the request stops and the result
  has `IsCancellationRequested` set (no exception). `CommonFormatsParameters.SizesAsync` / `BatchAsync` have an extra
  overload `(command, array, CancellationToken)`. ([#13](https://github.com/fmazzant/VimeoClient/issues/13))
- Easier pagination: `Pagination<T>.NextAsync()` / `PreviousAsync()`, `GetAllItems()` (all the targets) and
  `GetAllItemsAsync()` for `await foreach` (.NET Standard 2.1, .NET 8 and later), which load the next pages one at a
  time while the items are read. ([#16](https://github.com/fmazzant/VimeoClient/issues/16))

### Fixed

- The lists of Categories, Channels, Groups, Likes, Users and Watch Later: `Next()` / `Previous()` are available on
  every page; before, the second page had no `Next()`. Same requests as before.
  ([#16](https://github.com/fmazzant/VimeoClient/issues/16))

### Changed

- The section classes are `partial` (the async methods are in separate files).
- CI and CodeQL run on the `release/*` and `release-candidate/*` branches too, not only on `master`.

## [3.4.0.4] - 2026-11-14

No breaking changes.

### Added

- XML documentation for every public type and member, published with the package, so IntelliSense shows it.
  ([#20](https://github.com/fmazzant/VimeoClient/issues/20))
- SourceLink and the symbol package (`.snupkg`): you can step into the library code while debugging.
  ([#21](https://github.com/fmazzant/VimeoClient/issues/21))
- Optional integration tests against the Vimeo API, skipped when `VIMEO_ACCESS_TOKEN` is not set.
  ([#24](https://github.com/fmazzant/VimeoClient/issues/24))

### Changed

- Simpler sample app: the keys are read from `dotnet user-secrets` or environment variables, with the common
  scenarios (authenticated user, videos with pagination, upload, webhooks).
  ([#25](https://github.com/fmazzant/VimeoClient/issues/25))
- Package description updated, empty `Body\Category` folder removed.
  ([#23](https://github.com/fmazzant/VimeoClient/issues/23))
- NuGet workflow: version input on manual runs, the tag must match `<Version>`.
- README: Support section with a PayPal donation link.

[3.4.0.4]: https://github.com/fmazzant/VimeoClient/compare/v3.4.0.3...v3.4.0.4

The versions before 3.4.0.4 are listed in the [GitHub releases](https://github.com/fmazzant/VimeoClient/releases).
