using CommandLine;
using CoronavirusInTheUKDashboard.Api.Service.Csv;
using CoronavirusInTheUKDashboard.Api.Service.Generators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services;
using CoronavirusInTheUKDashboard.Api.Service.Options;
using CoronavirusInTheUKDashboard.Api.Service.Queries;
using CoronavirusInTheUKDashboard.Api.Service.Templating;
using CoronavirusInTheUKDashboard.Api.Service.Transformation;
using CoronavirusInTheUKDashboard.Api.Service.Writers;
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
                Parser.Default.ParseArguments<CommandLineOptions>(args)
                       .WithParsed<CommandLineOptions>(o =>
                       {
                           Run(o);

                       }).WithNotParsed<CommandLineOptions>(o => {
                           throw new Exception("Arugment exception.");
                       });
            }
        }
        private static void Run(CommandLineOptions options)
        {

            IServiceCollection services = new ServiceCollection();

            services.AddTransformersInternalServices();
            services.AddTemplatingInternalServices();
            services.AddQueriesInternalServices();
            services.AddCsvInternalServices();

            if (WriterOptionsParser.ShouldOutputToConsole(options))
            {
                services.AddConsoleWriterInternalServices();
            }

            if (WriterOptionsParser.ShouldOutputToDirectory(options))
            {
                services.AddDirectoryWriterInternalServices();
            }

            foreach( var type in options.PostTypes)
            {
                switch (type)
                {
                    case PostTypes.MainPost:
                        services.AddMainPostTextGeneratorServices();
                        break;
                    case PostTypes.TrendsPost:
                        services.AddTrendsPostGeneratorServices();
                        break;
                    case PostTypes.AdmissionsByAge:
                        services.AddAdmissionsByAgePostGeneratorServices();
                        break;
                }
            }

            services.AddTransient<IGenerator, Generator>();

            var serviceOptions = ParseCommandlineOptions(options);
            services.AddSingleton<IOptions>(serviceOptions);
            services.AddLogging(configure => configure.AddDebug());

            using (var serviceProvider = services.BuildServiceProvider(true))
            {
               serviceProvider.GetRequiredService<IGenerator>().Run();
            }
        } 

        private static ServiceOptions ParseCommandlineOptions(CommandLineOptions options)
        {

            DateTime trueNow = DateTime.Now;
            DateTime targetDate = trueNow.Date.AddDays(0);

            var serviceOptions = new ServiceOptions();
            serviceOptions.DirectoryOutput = options.DirectoryOutput;
            serviceOptions.FileName = options.FileName;

            if (!string.IsNullOrEmpty(options.TargetDate))
            {
                serviceOptions.TargetDate = DateTime.Parse(options.TargetDate);
            }
            else
            {
                serviceOptions.TargetDate = targetDate;
            }

            serviceOptions.TrueDateTime = trueNow;
            serviceOptions.UseExternalArchiveSite = options.UseExternalArchiveSite;
            return serviceOptions;
        }

    }
}
