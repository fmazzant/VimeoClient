namespace Mafesoft.VimeoClient.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Mafesoft.VimeoClient.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// IVimeo, the interfaces of the sections and AddVimeoClient (issue #17).
    /// </summary>
    public class InterfaceAndDependencyInjectionTests
    {
        private static IEnumerable<PropertyInfo> Sections() => typeof(Vimeo)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.Name != nameof(Vimeo.Properties));

        public static TheoryData<string> SectionNames()
        {
            var data = new TheoryData<string>();
            foreach (var section in Sections())
            {
                data.Add(section.Name);
            }
            return data;
        }

        [Fact]
        public void IVimeo_HasEverySectionOfVimeo()
        {
            foreach (var section in Sections())
            {
                var property = typeof(IVimeo).GetProperty(section.Name);
                Assert.NotNull(property);
                Assert.Equal("I" + section.PropertyType.Name, property.PropertyType.Name);
                Assert.True(property.PropertyType.IsAssignableFrom(section.PropertyType));
            }
        }

        [Theory]
        [MemberData(nameof(SectionNames))]
        public void EverySection_ImplementsItsInterface_WithEveryPublicMethod(string name)
        {
            var type = typeof(Vimeo).GetProperty(name).PropertyType;
            var contract = type.GetInterface("I" + type.Name);
            Assert.NotNull(contract);

            // Regenerate the interfaces with `dotnet run tools/GenerateInterfaces.cs` when this fails.
            var implemented = new HashSet<MethodInfo>(type.GetInterfaceMap(contract).TargetMethods);
            var missing = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(m => m.IsVirtual && !m.IsSpecialName && !implemented.Contains(m))
                .Select(m => m.ToString())
                .ToList();
            Assert.Empty(missing);
        }

        [Fact]
        public void Vimeo_ImplementsIVimeo_WithEveryPublicMethod()
        {
            var implemented = new HashSet<MethodInfo>(typeof(Vimeo).GetInterfaceMap(typeof(IVimeo)).TargetMethods);
            var missing = typeof(Vimeo).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(m => m.IsVirtual && !m.IsSpecialName && m.Name != nameof(Vimeo.RootAuthorization) && !implemented.Contains(m))
                .Select(m => m.ToString())
                .ToList();
            Assert.Empty(missing);
        }

        [Fact]
        public void IVimeo_ReturnsTheSectionsOfTheClient()
        {
            IVimeo client = new Vimeo(new VimeoProperties { AccessToken = "token" });

            Assert.IsType<VimeoVideos>(client.Videos);
            Assert.Same(client.Properties, ((VimeoVideos)client.Videos).Properties);
            Assert.Equal("token", client.Properties.AccessToken);
        }

        [Fact]
        public void AddVimeoClient_WithAnAction_RegistersOneClient()
        {
            using var provider = new ServiceCollection()
                .AddVimeoClient(options =>
                {
                    options.AccessToken = "token";
                    options.MaxRetries = 2;
                })
                .BuildServiceProvider();

            var vimeo = provider.GetRequiredService<Vimeo>();
            Assert.Same(vimeo, provider.GetRequiredService<IVimeo>());
            Assert.Same(vimeo.Properties, provider.GetRequiredService<VimeoProperties>());
            Assert.Equal("token", vimeo.Properties.AccessToken);
            Assert.Equal(2, vimeo.Properties.MaxRetries);
        }

        [Fact]
        public void AddVimeoClient_WithAConfigurationSection_BindsTheProperties()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Vimeo:AccessToken"] = "from-config",
                    ["Vimeo:ApiVersion"] = "3.4",
                    ["Vimeo:MaxRetries"] = "3",
                    ["Vimeo:RetryDelay"] = "00:00:02",
                    ["Vimeo:ValidCertificates:0"] = "ABC",
                })
                .Build();

            using var provider = new ServiceCollection()
                .AddVimeoClient(configuration.GetSection("Vimeo"), options => options.ClientId = "set-in-code")
                .BuildServiceProvider();

            var properties = provider.GetRequiredService<IVimeo>().Properties;
            Assert.Equal("from-config", properties.AccessToken);
            Assert.Equal(3, properties.MaxRetries);
            Assert.Equal(TimeSpan.FromSeconds(2), properties.RetryDelay);
            Assert.Equal(new[] { "ABC" }, properties.ValidCertificates);
            Assert.Equal("set-in-code", properties.ClientId);
        }

        [Theory]
        [MemberData(nameof(SectionNames))]
        public void AddVimeoClient_RegistersEverySectionInterface(string name)
        {
            using var provider = new ServiceCollection()
                .AddVimeoClient(options => options.AccessToken = "token")
                .BuildServiceProvider();
            var contract = typeof(IVimeo).GetProperty(name).PropertyType;

            var section = provider.GetService(contract);

            Assert.NotNull(section);
            Assert.Equal(typeof(Vimeo).GetProperty(name).PropertyType, section.GetType());
        }

        [Fact]
        public void AddVimeoClient_KeepsAClientRegisteredBefore()
        {
            var fake = new Vimeo(new VimeoProperties { AccessToken = "fake" });
            using var provider = new ServiceCollection()
                .AddSingleton<IVimeo>(fake)
                .AddVimeoClient(options => options.AccessToken = "real")
                .BuildServiceProvider();

            Assert.Same(fake, provider.GetRequiredService<IVimeo>());
            Assert.Equal("fake", ((VimeoVideos)provider.GetRequiredService<IVimeoVideos>()).Properties.AccessToken);
        }

        [Fact]
        public void AddVimeoClient_RejectsNull()
        {
            var services = new ServiceCollection();
            Assert.Throws<ArgumentNullException>(() => services.AddVimeoClient((Action<VimeoProperties>)null));
            Assert.Throws<ArgumentNullException>(() => services.AddVimeoClient((IConfiguration)null));
        }
    }
}
