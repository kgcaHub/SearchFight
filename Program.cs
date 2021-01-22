using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            using (UseCase.Search _search = new UseCase.Search())
            {
                _search.Figth(args);
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                configuration.Sources.Clear();

                configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configurationRoot = configuration.Build();

                Entity.Google.GoogleConfig _googleConfig = new Entity.Google.GoogleConfig();
                configurationRoot.GetSection("GoogleConfig").Bind(_googleConfig);
                Constants.GoogleConfig = _googleConfig;

                Entity.Bing.BingConfig _bingConfig = new Entity.Bing.BingConfig();
                configurationRoot.GetSection("BingConfig").Bind(_bingConfig);
                Constants.BingConfig = _bingConfig;

                // Constants.GoogleAuthUrl = configurationRoot.GetConnectionString("Google-Auth-Url");
                // Constants.GoogleAuthMail = configurationRoot.GetConnectionString("Google-Auth-Mail");
                // Constants.GoogleAuthPassword = configurationRoot.GetConnectionString("Google-Auth-Password");
                // Constants.GoogleAuthAppId = configurationRoot.GetConnectionString("Google-Auth-AppId");
                // Constants.GoogleSearchUrl = configurationRoot.GetConnectionString("Google-Search-Url");

                // Constants.BingSearchUrl = configurationRoot.GetConnectionString("Bing-Search-Url");
                // Constants.BingSearchApiKey = configurationRoot.GetConnectionString("Bing-Search-ApiKey");


            });
    }
}
