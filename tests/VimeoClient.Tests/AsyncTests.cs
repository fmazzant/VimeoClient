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

namespace Mafesoft.VimeoClient.Tests
{
    using Mafesoft.RestClient;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Mafesoft.VimeoClient.Response;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class AsyncTests
    {
        private const string FirstPage = @"{
            ""total"": 3, ""page"": 1, ""per_page"": 2,
            ""paging"": { ""next"": ""/groups/9/users?page=2"", ""previous"": null },
            ""data"": [ { ""uri"": ""/users/10"" }, { ""uri"": ""/users/11"" } ]
        }";

        private const string SecondPage = @"{
            ""total"": 3, ""page"": 2, ""per_page"": 2,
            ""paging"": { ""next"": null, ""previous"": ""/groups/9/users?page=1"" },
            ""data"": [ { ""uri"": ""/users/12"" } ]
        }";

        /// <summary>
        /// The client and its sections, with the synchronous API methods to compare.
        /// </summary>
        public static IEnumerable<object[]> SyncMethods()
        {
            foreach (var (_, method) in Targets(new FakeVimeo()))
            {
                yield return new object[] { method.DeclaringType.Name, method.Name, Signature(method) };
            }
        }

        [Fact]
        public void EverySynchronousMethod_HasAnAsyncVersion()
        {
            var missing = Targets(new FakeVimeo())
                .Where(t => FindAsync(t.Method) == null)
                .Select(t => $"{t.Method.DeclaringType.Name}.{t.Method.Name}({Signature(t.Method)})")
                .ToList();

            Assert.Empty(missing);
            Assert.True(Targets(new FakeVimeo()).Count() > 450);
        }

        [Theory]
        [MemberData(nameof(SyncMethods))]
        public async Task AsyncVersion_SendsTheSameRequest(string type, string name, string signature)
        {
            var syncClient = new FakeVimeo();
            var asyncClient = new FakeVimeo();
            var (syncTarget, method) = Targets(syncClient).Single(t => t.Method.DeclaringType.Name == type && t.Method.Name == name && Signature(t.Method) == signature);
            var asyncTarget = Targets(asyncClient).First(t => t.Method.DeclaringType.Name == type).Target;
            var asyncMethod = FindAsync(method);

            var syncError = await Run(() => { method.Invoke(syncTarget, Arguments(method.GetParameters())); return Task.CompletedTask; });
            var asyncError = await Run(() => (Task)asyncMethod.Invoke(asyncTarget, Arguments(asyncMethod.GetParameters())));

            Assert.Equal(syncError?.GetType(), asyncError?.GetType());
            Assert.Equal(Describe(syncClient), Describe(asyncClient));
        }

        [Fact]
        public async Task GetSpecificVideoAsync_DeserializesTheVideo()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/videos/5", @"{ ""uri"": ""/videos/5"", ""name"": ""Async"" }");

            var result = await client.Videos.GetSpecificVideoAsync(5);

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal("Async", result.Content.Name);
            Assert.Equal(HttpMethod.Get, client.Handler.Last.Method);
            Assert.Equal("Bearer test-token", client.Handler.Last.Authorization);
        }

        [Fact]
        public async Task DeleteVideoAsync_SendsADelete()
        {
            var client = new FakeVimeo();

            var result = await client.Videos.DeleteVideoAsync(5);

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(HttpMethod.Delete, client.Handler.Last.Method);
            Assert.Equal("/videos/5", client.Handler.Last.Path);
        }

        [Fact]
        public async Task PaginationAsync_WiresTheNavigation()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/groups/9/users", FirstPage);

            var first = await client.Groups.GetAllTheMembersOfAGroupAsync(9, per_page: 2);

            Assert.Equal(2, first.Content.Data.Count);
            Assert.Equal("2", client.Handler.Last.Query["per_page"]);

            client.Handler.Respond("/groups/9/users", SecondPage);
            var second = first.Content.Next();

            Assert.Equal("2", client.Handler.Last.Query["page"]);
            Assert.Equal("/users/12", second.Content.Data.Single().Uri);
            Assert.Null(second.Content.Next());
        }

        [Fact]
        public async Task OverloadAsync_DelegatesToTheAsyncVersion()
        {
            var client = new FakeVimeo();

            await client.Categories.GetASpecificVideoInACategoryAsync("animation", 7);

            Assert.Equal("/categories/animation/videos/7", client.Handler.Last.Path);
        }

        [Fact]
        public async Task TutorialAsync_CallsTheTutorialEndpoint()
        {
            var client = new FakeVimeo();
            client.Handler.Respond("/tutorial", @"{ ""message"": ""ok"" }");

            var result = await client.TutorialAsync();

            Assert.Equal("ok", result.Content.message);
        }

        private static async Task<Exception> Run(Func<Task> action)
        {
            try
            {
                await action();
                return null;
            }
            catch (TargetInvocationException e)
            {
                return e.InnerException;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        private static string Describe(FakeVimeo client) => string.Join("\n", client.Handler.Requests
            .Select(r => $"{r.Method} {r.Uri} {r.ContentType} {r.Body}"));

        /// <summary>The client and the sections exposed by its properties, with their public synchronous API methods.</summary>
        internal static IEnumerable<(object Target, MethodInfo Method)> Targets(Vimeo client)
        {
            var targets = new List<object> { client };
            targets.AddRange(typeof(Vimeo).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.Namespace == "Mafesoft.VimeoClient.Common")
                .Select(p => p.GetValue(client)));

            foreach (var target in targets)
            {
                var type = target is Vimeo ? typeof(Vimeo) : target.GetType();
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(m => typeof(RestResult).IsAssignableFrom(m.ReturnType))
                    .Where(m => m.GetCustomAttribute<ObsoleteAttribute>() == null)
                    .Select(m => m.IsGenericMethodDefinition ? m.MakeGenericMethod(typeof(object)) : m)
                    .OrderBy(m => m.Name).ThenBy(Signature))
                {
                    yield return (target, method);
                }
            }
        }

        /// <summary>The async version: same name plus Async, same parameters (plus an optional trailing CancellationToken).</summary>
        internal static MethodInfo FindAsync(MethodInfo method)
        {
            var types = method.GetParameters().Select(p => p.ParameterType).ToArray();
            return method.DeclaringType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.Name == method.Name + "Async" && typeof(Task).IsAssignableFrom(m.ReturnType))
                .Select(m => m.IsGenericMethodDefinition ? m.MakeGenericMethod(method.GetGenericArguments()) : m)
                .FirstOrDefault(m =>
                {
                    var asyncTypes = m.GetParameters().Select(p => p.ParameterType).ToArray();
                    if (asyncTypes.Length > 0 && asyncTypes.Last() == typeof(CancellationToken))
                    {
                        asyncTypes = asyncTypes.Take(asyncTypes.Length - 1).ToArray();
                    }
                    return asyncTypes.SequenceEqual(types);
                });
        }

        private static string Signature(MethodInfo method) => string.Join(", ", method.GetParameters().Select(p => p.ParameterType.Name));

        private static object[] Arguments(ParameterInfo[] parameters) => parameters.Select(p => Value(p.ParameterType)).ToArray();

        private static object Value(Type type)
        {
            var nullable = Nullable.GetUnderlyingType(type);
            if (nullable != null)
            {
                return Value(nullable);
            }

            if (type == typeof(string)) return "abc";
            if (type == typeof(int)) return 7;
            if (type == typeof(long)) return 8L;
            if (type == typeof(double)) return 1.5;
            if (type == typeof(bool)) return true;
            if (type == typeof(DateTime)) return new DateTime(2026, 1, 2, 3, 4, 5, DateTimeKind.Utc);
            if (type == typeof(CancellationToken)) return CancellationToken.None;
            if (type.IsEnum) return Enum.GetValues(type).GetValue(0);
            if (type == typeof(object)) return "value";

            if (type.IsArray)
            {
                var array = Array.CreateInstance(type.GetElementType(), 1);
                array.SetValue(Value(type.GetElementType()), 0);
                return array;
            }

            if (type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type))
            {
                var arguments = type.GetGenericArguments();
                var concrete = arguments.Length == 2
                    ? typeof(Dictionary<,>).MakeGenericType(arguments)
                    : typeof(List<>).MakeGenericType(arguments);
                return Activator.CreateInstance(concrete);
            }

            return type.GetConstructor(Type.EmptyTypes) != null ? Activator.CreateInstance(type) : null;
        }
    }
}
