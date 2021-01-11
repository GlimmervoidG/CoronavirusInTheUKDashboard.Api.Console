using CommandLine;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service
{
     public class GeneratorService
    {
        public static void Run(string[] args)
        {
            {
                Parser.Default.ParseArguments<GeneratorOptions>(args)
                       .WithParsed<GeneratorOptions>(o =>
                       {
                           Run(o);

                       }).WithNotParsed<GeneratorOptions>(o => {
                           throw new Exception("Arugment exception.");
                       });
            }
        }
        private static void Run(GeneratorOptions options)
        {

            IServiceCollection services = new ServiceCollection();

            //services.AddSingleton<IConfiguration>(configuration);
            //services.AddSingleton<IClient, Client>();
            //services.AddTransient<IArchiver, Archiver>();
            //services.AddTransient<ILocalArchiver, LocalArchiver>();
            //services.AddTransient<IPageParser, PageParser>();
            //services.AddTransient<IStoryRepo, StoryRepo>();
            //services.AddTransient<IRunRepo, RunRepo>();
            //services.AddSingleton<LiteDbContext, LiteDbContext>();
 

            services.AddSingleton<IOptions>(options);
            services.AddLogging(configure => configure.AddDebug());

            using (var serviceProvider = services.BuildServiceProvider(true))
            {
            //    serviceProvider.GetRequiredService<IArchiver>().Run();
            }







        } 

    }
}
