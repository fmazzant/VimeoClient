using RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using VimeoClient;

namespace VimeoClientSampleApp
{
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
        static void Main(string[] args)
        {
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

            var vimeoKeys = csv.Load("VimeoKeys.Customer.csv");
            //var vimeoKeys = csv.Load("VimeoKeys.Test.csv");

            var vimeoKey = vimeoKeys.FirstOrDefault();
            var vimeoClient = new CustomVimeoClient(new VimeoProperties
            {
                AccessToken = vimeoKey.AccessToken,
                ClientSecret = vimeoKey.ClientSecret,
                ClientId = vimeoKey.ClientID,
                ValidCertificates = new List<string>() { vimeoKey.Cert }
            });

            var allCategories = vimeoClient.Categories.GetAllCategories();

            Console.WriteLine("press enter to exit.");
            Console.ReadLine();
        }
    }
}
