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
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Mafesoft.VimeoClient.Tests.Infrastructure;

    public class CancellationTests
    {
        /// <summary>
        /// Every public asynchronous method of the client and of its sections.
        /// </summary>
        public static IEnumerable<object[]> AsyncMethods()
        {
            foreach (var (_, method) in AsyncTargets(new FakeVimeo()))
            {
                yield return new object[] { method.DeclaringType.Name, method.Name, Signature(method) };
            }
        }

        [Fact]
        public void EveryAsyncMethod_AcceptsACancellationToken()
        {
            var methods = AsyncTargets(new FakeVimeo()).Select(t => t.Method).ToList();

            var missing = methods
                .Where(m => !HasToken(m))
                // a params array must stay the last parameter: an overload with the token must exist
                .Where(m => !(m.GetParameters().LastOrDefault()?.IsDefined(typeof(ParamArrayAttribute)) == true
                    && methods.Any(o => o.Name == m.Name && HasToken(o) && o.GetParameters().Length == m.GetParameters().Length + 1)))
                .Select(m => $"{m.DeclaringType.Name}.{m.Name}({Signature(m)})")
                .ToList();

            Assert.Empty(missing);
            Assert.True(methods.Count > 500);
        }

        [Fact]
        public void TheCancellationToken_IsOptional()
        {
            var required = AsyncTargets(new FakeVimeo()).Select(t => t.Method)
                .Where(HasToken)
                .Where(m => !m.GetParameters().Last().IsOptional)
                .Where(m => !m.DeclaringType.GetMethods().Any(o => o.Name == m.Name && o != m
                    && o.GetParameters().LastOrDefault()?.IsDefined(typeof(ParamArrayAttribute)) == true))
                .Select(m => $"{m.DeclaringType.Name}.{m.Name}({Signature(m)})")
                .ToList();

            Assert.Empty(required);
        }

        [Theory]
        [MemberData(nameof(AsyncMethods))]
        public async Task ACanceledToken_CancelsTheRequest(string type, string name, string signature)
        {
            var client = new FakeVimeo();
            var (target, method) = AsyncTargets(client).Single(t => t.Method.DeclaringType.Name == type && t.Method.Name == name && Signature(t.Method) == signature);
            if (!HasToken(method))
            {
                return; // params overload without token: covered by its overload with the token
            }

            using var source = new CancellationTokenSource();
            source.Cancel();
            var arguments = method.GetParameters().Select(p => p.ParameterType == typeof(CancellationToken) ? (object)source.Token : AsyncTests.Value(p.ParameterType)).ToArray();

            var result = await Invoke(target, method, arguments);

            Assert.True(result == null || result.IsCancellationRequested, "the request was not canceled");
        }

        [Fact]
        public async Task GetSpecificVideoAsync_WithACanceledToken_IsCanceled()
        {
            var client = new FakeVimeo();
            using var source = new CancellationTokenSource();
            source.Cancel();

            var result = await client.Videos.GetSpecificVideoAsync(5, source.Token);

            Assert.True(result.IsCancellationRequested);
            Assert.False(result.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetSpecificVideoAsync_WithoutToken_SendsTheRequest()
        {
            var client = new FakeVimeo();

            await client.Videos.GetSpecificVideoAsync(5);

            Assert.Equal("/videos/5", client.Handler.Last.Path);
        }

        /// <summary>Invokes the method: the result, or null when the cancellation is thrown as OperationCanceledException.</summary>
        private static async Task<RestResult> Invoke(object target, MethodInfo method, object[] arguments)
        {
            try
            {
                var task = (Task)method.Invoke(target, arguments);
                await task;
                return (RestResult)task.GetType().GetProperty("Result").GetValue(task);
            }
            catch (OperationCanceledException)
            {
                return null;
            }
        }

        private static bool HasToken(MethodInfo method) => method.GetParameters().LastOrDefault()?.ParameterType == typeof(CancellationToken);

        private static string Signature(MethodInfo method) => string.Join(", ", method.GetParameters().Select(p => p.ParameterType.Name));

        private static IEnumerable<(object Target, MethodInfo Method)> AsyncTargets(Vimeo client)
        {
            var targets = new List<object> { client };
            targets.AddRange(typeof(Vimeo).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.Namespace == "Mafesoft.VimeoClient.Common")
                .Select(p => p.GetValue(client)));

            foreach (var target in targets)
            {
                var type = target is Vimeo ? typeof(Vimeo) : target.GetType();
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(m => typeof(Task).IsAssignableFrom(m.ReturnType))
                    .Select(m => m.IsGenericMethodDefinition ? m.MakeGenericMethod(typeof(object)) : m)
                    .OrderBy(m => m.Name).ThenBy(Signature))
                {
                    yield return (target, method);
                }
            }
        }
    }
}
