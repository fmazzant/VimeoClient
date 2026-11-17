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

namespace Microsoft.Extensions.DependencyInjection
{
    using Mafesoft.VimeoClient;
    using Mafesoft.VimeoClient.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using System;

    /// <summary>
    /// Registers the Vimeo client in the dependency injection (issue #17).
    /// </summary>
    public static class VimeoServiceCollectionExtensions
    {
        /// <summary>
        /// Registers <see cref="Vimeo"/> and <see cref="IVimeo"/> as singletons, configured by <paramref name="configure"/>,
        /// and the interfaces of the sections (<see cref="IVimeoVideos"/>, <see cref="IVimeoUsers"/>, ...), so a class can
        /// receive only the section it uses.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configure">Sets the access token and the other <see cref="VimeoProperties"/>.</param>
        /// <returns>The same service collection.</returns>
        /// <example>
        /// <code>
        /// builder.Services.AddVimeoClient(options => options.AccessToken = builder.Configuration["Vimeo:AccessToken"]);
        /// </code>
        /// </example>
        public static IServiceCollection AddVimeoClient(this IServiceCollection services, Action<VimeoProperties> configure)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            return services.AddVimeoClient(_ =>
            {
                var properties = new VimeoProperties();
                configure(properties);
                return properties;
            });
        }

        /// <summary>
        /// Registers <see cref="Vimeo"/> and <see cref="IVimeo"/> as singletons, with the <see cref="VimeoProperties"/>
        /// read from a configuration section, and the interfaces of the sections.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The section with the properties, for example <c>builder.Configuration.GetSection("Vimeo")</c>:
        /// AccessToken, ClientId, ClientSecret, ApiVersion, MaxRetries, RetryDelay, ValidCertificates...</param>
        /// <param name="configure">Changes the properties after they are read (optional).</param>
        /// <returns>The same service collection.</returns>
        /// <example>
        /// <code>
        /// // appsettings.json: { "Vimeo": { "AccessToken": "...", "MaxRetries": 3 } }
        /// builder.Services.AddVimeoClient(builder.Configuration.GetSection("Vimeo"));
        /// </code>
        /// </example>
        public static IServiceCollection AddVimeoClient(this IServiceCollection services, IConfiguration configuration, Action<VimeoProperties> configure = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            return services.AddVimeoClient(_ =>
            {
                var properties = new VimeoProperties();
                configuration.Bind(properties);
                configure?.Invoke(properties);
                return properties;
            });
        }

        private static IServiceCollection AddVimeoClient(this IServiceCollection services, Func<IServiceProvider, VimeoProperties> properties)
        {
            services.TryAddSingleton(properties);
            services.TryAddSingleton(provider => new Vimeo(provider.GetRequiredService<VimeoProperties>()));
            services.TryAddSingleton<IVimeo>(provider => provider.GetRequiredService<Vimeo>());

            // The sections: Vimeo creates a new, lightweight object for each of them.
            services.TryAddTransient<IVimeoMe>(provider => provider.GetRequiredService<IVimeo>().Me);
            services.TryAddTransient<IVimeoUsers>(provider => provider.GetRequiredService<IVimeo>().Users);
            services.TryAddTransient<IVimeoAPIInformation>(provider => provider.GetRequiredService<IVimeo>().APIInformation);
            services.TryAddTransient<IVimeoAnalytics>(provider => provider.GetRequiredService<IVimeo>().Analytics);
            services.TryAddTransient<IVimeoWebhooks>(provider => provider.GetRequiredService<IVimeo>().Webhooks);
            services.TryAddTransient<IVimeoFiles>(provider => provider.GetRequiredService<IVimeo>().Files);
            services.TryAddTransient<IVimeoPayments>(provider => provider.GetRequiredService<IVimeo>().Payments);
            services.TryAddTransient<IVimeoSearch>(provider => provider.GetRequiredService<IVimeo>().Search);
            services.TryAddTransient<IVimeoTeams>(provider => provider.GetRequiredService<IVimeo>().Teams);
            services.TryAddTransient<IVimeoAuthenticationExtras>(provider => provider.GetRequiredService<IVimeo>().AuthenticationExtras);
            services.TryAddTransient<IVimeoCategories>(provider => provider.GetRequiredService<IVimeo>().Categories);
            services.TryAddTransient<IVimeoChannels>(provider => provider.GetRequiredService<IVimeo>().Channels);
            services.TryAddTransient<IVimeoEmbedPresets>(provider => provider.GetRequiredService<IVimeo>().EmbedPresets);
            services.TryAddTransient<IVimeoFolders>(provider => provider.GetRequiredService<IVimeo>().Folders);
            services.TryAddTransient<IVimeoGroups>(provider => provider.GetRequiredService<IVimeo>().Groups);
            services.TryAddTransient<IVimeoLikes>(provider => provider.GetRequiredService<IVimeo>().Likes);
            services.TryAddTransient<IVimeoLive>(provider => provider.GetRequiredService<IVimeo>().Live);
            services.TryAddTransient<IVimeoOnDemand>(provider => provider.GetRequiredService<IVimeo>().OnDemand);
            services.TryAddTransient<IVimeoPortfolios>(provider => provider.GetRequiredService<IVimeo>().Portfolios);
            services.TryAddTransient<IVimeoShowCases>(provider => provider.GetRequiredService<IVimeo>().ShowCases);
            services.TryAddTransient<IVimeoTags>(provider => provider.GetRequiredService<IVimeo>().Tags);
            services.TryAddTransient<IVimeoTeamMembers>(provider => provider.GetRequiredService<IVimeo>().TeamMembers);
            services.TryAddTransient<IVimeoVideos>(provider => provider.GetRequiredService<IVimeo>().Videos);
            services.TryAddTransient<IVimeoWatchLaterQueue>(provider => provider.GetRequiredService<IVimeo>().WatchLaterQueue);
            services.TryAddTransient<IVimeoCommonFormatsParameters>(provider => provider.GetRequiredService<IVimeo>().CommonFormatsParameters);
            return services;
        }
    }
}
