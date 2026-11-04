namespace Mafesoft.VimeoClient.Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json.Serialization;
    using System.Threading;
    using Mafesoft.VimeoClient.Filter.Analytics;
    using Mafesoft.VimeoClient.Body.OnDemand;

    public class ToVimeoValueTests
    {
        [Fact]
        public void Null_IsNull() => Assert.Null(VimeoRestBuilderExtensions.ToVimeoValue(null));

        [Theory]
        [InlineData(true, "true")]
        [InlineData(false, "false")]
        public void Booleans_AreLowerCase(bool value, string expected)
            => Assert.Equal(expected, VimeoRestBuilderExtensions.ToVimeoValue(value));

        [Fact]
        public void Enums_UseTheirName()
            => Assert.Equal("embed_domain", VimeoRestBuilderExtensions.ToVimeoValue(AnalyticsDimension.embed_domain));

        [Fact]
        public void Enums_WithAReservedName_DropTheEscape()
            => Assert.Equal("default", VimeoRestBuilderExtensions.ToVimeoValue(AnalyticsSort.@default));

        [Fact]
        public void Enums_StartingWithADigit_DropTheLeadingUnderscore()
            => Assert.Equal("1_week", VimeoRestBuilderExtensions.ToVimeoValue(OnDemandRentPeriod._1_week));

        [Fact]
        public void StringArrays_AreCommaSeparated()
            => Assert.Equal("title,tags", VimeoRestBuilderExtensions.ToVimeoValue(new[] { "title", "tags" }));

        [Fact]
        public void Numbers_UseTheInvariantCulture()
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");
                Assert.Equal("1.5", VimeoRestBuilderExtensions.ToVimeoValue(1.5));
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = culture;
            }
        }
    }

    public class VimeoPayloadTests
    {
        private sealed class Sample
        {
            [JsonPropertyName("display_name")]
            public string DisplayName { get; set; }

            public int Count { get; set; }

            [JsonIgnore]
            public string Ignored { get; set; } = "ignored";

            public string NotSet { get; set; }

            public List<string> Tags { get; set; }

            public AnalyticsDirection? Direction { get; set; }
        }

        [Fact]
        public void Set_SkipsNullValues()
        {
            var payload = new VimeoPayload().Set("name", "x").Set("empty", null);

            Assert.True(payload.ContainsKey("name"));
            Assert.False(payload.ContainsKey("empty"));
        }

        [Fact]
        public void Set_WithADottedPath_CreatesNestedObjects()
        {
            var payload = new VimeoPayload().Set("upload.approach", "tus").Set("upload.size", "100");

            var upload = Assert.IsType<VimeoPayload>(payload["upload"]);
            Assert.Equal("tus", upload["approach"]);
            Assert.Equal("100", upload["size"]);
        }

        [Fact]
        public void Set_ConvertsEnumsToTheirVimeoValue()
        {
            var payload = new VimeoPayload().Set("direction", AnalyticsDirection.desc);

            Assert.Equal("desc", payload["direction"]);
        }

        [Fact]
        public void FromObject_UsesTheJsonNamesAndSkipsIgnoredAndNullProperties()
        {
            var payload = VimeoPayload.FromObject(new Sample
            {
                DisplayName = "My name",
                Count = 3,
                Tags = new List<string> { "a", "b" },
                Direction = AnalyticsDirection.asc,
            });

            Assert.Equal("My name", payload["display_name"]);
            Assert.Equal(3, payload["Count"]);
            Assert.Equal(new object[] { "a", "b" }, payload["Tags"]);
            Assert.Equal("asc", payload["Direction"]);
            Assert.False(payload.ContainsKey("Ignored"));
            Assert.False(payload.ContainsKey("NotSet"));
        }

        [Fact]
        public void FromObject_OfNull_IsEmpty() => Assert.Empty(VimeoPayload.FromObject(null));
    }
}
