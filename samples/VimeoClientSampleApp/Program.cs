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
    using RestClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TinyCsv.Extensions;
    using VimeoClient;

    public class CustomVimeoClient : VimeoClient.Vimeo
    {
        public CustomVimeoClient(VimeoProperties properties)
            : base(properties)
        {
        }

        protected override RestBuilder Root()
        {
            return base.Root()
                .OnStart((e) =>
                {
                    Console.WriteLine(e.Url);
                })
                .OnPreviewContentRequestAsString((json) =>
                {

                })
                .OnPreviewContentResponseAsString((json) =>
                {

                })
                .OnCompleted((e) =>
                {
                    Console.WriteLine("OnCompleted");
                });
        }
    }

    internal static class Program
    {
        static async Task Main(string[] args)
        {
            /// Load keys from csv file with Mafe.TinyCsv
            var csv = new TinyCsv.TinyCsv<VimeoKey>(options =>
            {
                options.HasHeaderRecord = true;
                options.Delimiter = ";";
                options.Columns.AddColumn(x => x.AccessToken);
                options.Columns.AddColumn(x => x.ClientID);
                options.Columns.AddColumn(x => x.ClientSecret);
                options.Columns.AddColumn(x => x.UserToken);
                options.Columns.AddColumn(x => x.Cert);
            });
            var vimeoKeys = await csv.LoadFromFileAsync("../../../../../../VimeoClient.Keys.csv").ToListAsync();

            /// Get first key and create a vimeoClient instance
            var vimeoKey = vimeoKeys.FirstOrDefault();
            var vimeoClient = new CustomVimeoClient(new VimeoProperties
            {
                AccessToken = vimeoKey.AccessToken,
                ClientSecret = vimeoKey.ClientSecret,
                ClientId = vimeoKey.ClientID,
                ValidCertificates = new List<string>() { vimeoKey.Cert }
            });

            /// VimeoClient examples invoking
            var allCategories = vimeoClient.Categories.GetAllCategories();
            var me = vimeoClient.Me.GetTheUser();

            Console.WriteLine("press enter to exit.");
            Console.ReadLine();
        }
    }
}
