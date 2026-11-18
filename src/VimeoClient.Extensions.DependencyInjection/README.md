# Mafesoft.VimeoClient.Extensions.DependencyInjection

Registers [Mafesoft.VimeoClient](https://www.nuget.org/packages/Mafesoft.VimeoClient) in the `Microsoft.Extensions`
dependency injection (ASP.NET Core, worker services, MAUI).

```
dotnet add package Mafesoft.VimeoClient.Extensions.DependencyInjection
```

```c#
// appsettings.json: { "Vimeo": { "AccessToken": "...", "MaxRetries": 3 } }
builder.Services.AddVimeoClient(builder.Configuration.GetSection("Vimeo"));

// or in code
builder.Services.AddVimeoClient(options => options.AccessToken = builder.Configuration["Vimeo:AccessToken"]);
```

```c#
public class VideoService(IVimeoVideos videos)          // or IVimeo for the whole client
{
    public Task<RestResult<Video>> GetAsync(int id) => videos.GetSpecificVideoAsync(id);
}
```

- `Vimeo`, `IVimeo` and `VimeoProperties` are singletons; every section has its interface (`IVimeoVideos`,
  `IVimeoUsers`, ...), registered too.
- The interfaces make the client easy to mock in the tests of the application.

See the [documentation](https://github.com/fmazzant/VimeoClient#dependency-injection).
