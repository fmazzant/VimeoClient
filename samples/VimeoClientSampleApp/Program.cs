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
///

namespace VimeoClientSampleApp
{
    using Mafesoft.RestClient;
    using Mafesoft.VimeoClient;
    using Mafesoft.VimeoClient.Body.Video;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The client can be extended: here every request is written to the console.
    /// </summary>
    public class CustomVimeoClient : Vimeo
    {
        public CustomVimeoClient(VimeoProperties properties)
            : base(properties)
        {
        }

        protected override RestBuilder Root() => base.Root()
            .OnStart((e) => Console.WriteLine($"-> {e.Url}"));
    }

    /// <summary>
    /// VimeoClient sample app.
    ///
    /// The keys are read with dotnet user-secrets or with environment variables, never from a file of the repository:
    ///   dotnet user-secrets set "Vimeo:AccessToken" "your-access-token"
    ///   dotnet user-secrets set "Vimeo:ClientId" "your-client-id"           (optional)
    ///   dotnet user-secrets set "Vimeo:ClientSecret" "your-client-secret"   (optional)
    ///   dotnet user-secrets set "Vimeo:Certificate" "certificate-hash"      (optional, certificate pinning)
    /// or (environment variables): Vimeo__AccessToken, Vimeo__ClientId, Vimeo__ClientSecret, Vimeo__Certificate.
    ///
    /// Usage:
    ///   dotnet run                                  the authenticated user
    ///   dotnet run -- videos                        list the videos, page by page
    ///   dotnet run -- upload path/to/video.mp4      upload a local file (tus approach)
    ///   dotnet run -- upload https://.../video.mp4  upload from a public URL (pull approach)
    ///   dotnet run -- webhook APP_ID PUBLIC_URL     receive the webhooks of an API app
    /// </summary>
    internal static class Program
    {
        static async Task<int> Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Program).Assembly, optional: true)
                .AddEnvironmentVariables()
                .Build();

            var accessToken = configuration["Vimeo:AccessToken"];
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                Console.WriteLine("Set the access token: dotnet user-secrets set \"Vimeo:AccessToken\" \"your-access-token\"");
                Console.WriteLine("or the environment variable Vimeo__AccessToken.");
                return 1;
            }

            var properties = new VimeoProperties
            {
                AccessToken = accessToken,
                ClientId = configuration["Vimeo:ClientId"] ?? string.Empty,
                ClientSecret = configuration["Vimeo:ClientSecret"] ?? string.Empty,
            };

            // Optional certificate pinning: empty = standard TLS validation
            var certificate = configuration["Vimeo:Certificate"];
            if (!string.IsNullOrWhiteSpace(certificate))
            {
                properties.ValidCertificates = new List<string> { certificate };
            }

            var client = new CustomVimeoClient(properties);

            var command = args.Length > 0 ? args[0].ToLowerInvariant() : "me";
            switch (command)
            {
                case "me":
                    return Me(client);
                case "videos":
                    return Videos(client);
                case "upload" when args.Length > 1:
                    return await UploadAsync(client, args[1]);
                case "webhook" when args.Length > 2 && long.TryParse(args[1], out var appId):
                    return await WebhookAsync(client, appId, args[2]);
                default:
                    Console.WriteLine("Usage: dotnet run -- [me | videos | upload FILE_OR_URL | webhook APP_ID PUBLIC_URL]");
                    return 1;
            }
        }

        /// <summary>
        /// The authenticated user.
        /// </summary>
        static int Me(Vimeo client)
        {
            var me = client.Me.GetTheUser();
            if (!Check(me))
            {
                return 1;
            }

            Console.WriteLine($"Authenticated user: {me.Content.Uri}");
            return 0;
        }

        /// <summary>
        /// The videos of the authenticated user, 10 per page: Next() loads the next page.
        /// </summary>
        static int Videos(Vimeo client)
        {
            var page = client.Videos.GetAllTheVideosThatTheUserHasUploaded(per_page: 10);

            while (page != null)
            {
                if (!Check(page))
                {
                    return 1;
                }

                Console.WriteLine($"Page {page.Content.Page} ({page.Content.Total} videos)");
                foreach (var video in page.Content.Data)
                {
                    Console.WriteLine($"  {video.Identity}  {video.Name}  {video.Link}");
                }

                // Next() returns null after the last page
                page = page.Content.Next();
            }

            return 0;
        }

        /// <summary>
        /// Uploads a video: from a public URL with the pull approach (Vimeo downloads the file),
        /// from a local file with the tus approach (the file is sent to the upload link returned by Vimeo).
        /// </summary>
        static async Task<int> UploadAsync(Vimeo client, string fileOrUrl)
        {
            var isUrl = Uri.TryCreate(fileOrUrl, UriKind.Absolute, out var url)
                && (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps);

            if (isUrl)
            {
                var pulled = client.Videos.UploadAVideo(new VideoUploadParameters
                {
                    Approach = VideoUploadApproach.pull,
                    Link = fileOrUrl,
                    Name = Path.GetFileName(url.AbsolutePath),
                });
                if (!Check(pulled))
                {
                    return 1;
                }

                Console.WriteLine($"Vimeo is downloading the video: {pulled.Content.Link}");
                return 0;
            }

            var file = new FileInfo(fileOrUrl);
            if (!file.Exists)
            {
                Console.WriteLine($"File not found: {file.FullName}");
                return 1;
            }

            // 1. Create the video with the tus approach and the size of the file
            var created = client.Videos.UploadAVideo(new VideoUploadParameters
            {
                Approach = VideoUploadApproach.tus,
                Size = file.Length,
                Name = file.Name,
            });
            if (!Check(created))
            {
                return 1;
            }

            // 2. Send the file to the upload link (tus protocol, in a single request)
            using (var http = new HttpClient { Timeout = Timeout.InfiniteTimeSpan })
            using (var stream = file.OpenRead())
            using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), created.Content.Upload.UploadLink))
            {
                request.Headers.Add("Tus-Resumable", "1.0.0");
                request.Headers.Add("Upload-Offset", "0");
                request.Content = new StreamContent(stream);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/offset+octet-stream");

                using (var response = await http.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Upload failed: {(int)response.StatusCode} {response.ReasonPhrase}");
                        return 1;
                    }
                }
            }

            Console.WriteLine($"Video uploaded, Vimeo is transcoding it: {created.Content.Link}");
            return 0;
        }

        /// <summary>
        /// Registers a webhook for an API app and prints the notifications that Vimeo sends to it.
        /// Vimeo must reach PUBLIC_URL: expose the local listener (http://localhost:5000/) with a tunnel.
        /// The webhook is deleted when the app stops (Ctrl+C).
        /// </summary>
        static async Task<int> WebhookAsync(Vimeo client, long appId, string publicUrl)
        {
            var secret = Guid.NewGuid().ToString("N");
            var webhook = client.Webhooks.AddAWebhookForAnApp(appId,
                webhook_type: "video-transcode-complete",
                webhook_url: publicUrl,
                is_enabled: true,
                secret: secret);
            if (!Check(webhook))
            {
                return 1;
            }

            var webhookId = long.Parse(webhook.Content.Uri.Split('/')[^1]);
            Console.WriteLine($"Webhook {webhookId} registered for {publicUrl}, secret {secret}");

            using var stop = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                stop.Cancel();
            };

            using var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/");
            listener.Start();
            Console.WriteLine("Listening on http://localhost:5000/, press Ctrl+C to stop.");

            try
            {
                while (!stop.IsCancellationRequested)
                {
                    var context = await listener.GetContextAsync().WaitAsync(stop.Token);
                    using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                    {
                        // Check that the notification carries the secret of the webhook before trusting it
                        var body = await reader.ReadToEndAsync();
                        Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
                        Console.WriteLine(body);
                    }

                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.Close();
                }
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                listener.Stop();
                client.Webhooks.DeleteAWebhook(appId, webhookId);
                Console.WriteLine($"Webhook {webhookId} deleted.");
            }

            return 0;
        }

        /// <summary>
        /// Writes the error of a failed request.
        /// </summary>
        static bool Check(RestResult result)
        {
            if (result.IsSuccessStatusCode)
            {
                return true;
            }

            Console.WriteLine($"Vimeo returned {(int)result.StatusCode} {result.ReasonPhrase} {result.Exception?.Message}");
            return false;
        }
    }
}
