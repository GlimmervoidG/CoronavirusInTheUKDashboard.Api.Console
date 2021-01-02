using CommandLine;
using CoronavirusInTheUKDashboard.Api.Service.Csv;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Templating;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.AdmissionsQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackLfdTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.NoneDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service
{
    public class Generator
    {

        public static void GeneratePosts(string[] args)
        {
            {
                Parser.Default.ParseArguments<GeneratorOptions>(args)
                       .WithParsed<GeneratorOptions>(o =>
                       {
                           GeneratePosts(o);

                       }).WithNotParsed<GeneratorOptions>(o => {
                           throw new Exception("Arugment exception.");
                       });
            }
        }

        private static void GeneratePosts(GeneratorOptions options)
        {

             
            DateTime trueNow = DateTime.Now;
            DateTime searchDate = trueNow.Date.AddDays(0);

            // Work out the date we should serach for.
            if (!string.IsNullOrEmpty(options.TargetDate))
            {
                searchDate = DateTime.Parse(options.TargetDate);
            }

            foreach( var post in options.PostTypes)
            {
                OutputPost(options, post, searchDate, trueNow);
            }

            return;
        }

        private static void OutputPost(GeneratorOptions options, PostTypes type, DateTime searchDate, DateTime trueNow)
        {
            var result = "";
            switch (type)
            {
                case PostTypes.MainPost:
                    result = GetMainPost(searchDate, options.UseExternalArchiveSite);
                    break;
                case PostTypes.TrendsPost:
                    result = GetTrendsPost(searchDate, options.UseExternalArchiveSite);
                    break;
                case PostTypes.AdmissionsByAge:
                    result = AdmissionsByAgePost(searchDate, options.UseExternalArchiveSite);
                    break;
            }

            if (String.IsNullOrWhiteSpace(options.DirectoryOutput))
            {
                Console.WriteLine(result);
            }
            else
            {
                var fileName = string.Empty;
                if (String.IsNullOrWhiteSpace(options.FileName))
                {
                    fileName = string.Format($"uk-covid-{trueNow:yyyy-MM-dd_HH-mm-ss}_{type}.txt");
                }
                else
                {
                    fileName = options.FileName;
                }

                var fullOutput = Path.Join(options.DirectoryOutput, fileName);
                Directory.CreateDirectory(options.DirectoryOutput);
                System.IO.File.WriteAllText(fullOutput, result);
            }
        }


        private static string GetMainPost(DateTime searchData, bool doArchive)
        {
            var titleTransformer = new TitleTransformer() { SearchDate = searchData };
            var title = titleTransformer.QueryAndTransform();
            var dailyTransformer = new DailyQueryTransformer() { SearchDate = searchData };
            var daily = dailyTransformer.QueryAndTransform();

            var normalDays = new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            var catchUpDays = new List<DayOfWeek>() { DayOfWeek.Monday };

            Result<StandardRecord> testing = null;
            Result<StandardRecord> testingLfd = null;
            if (normalDays.Contains(searchData.DayOfWeek))
            {
                var testingTransformer = new LookbackTestingQueryTransformer() { SearchDate = searchData };
                testing = testingTransformer.QueryAndTransform();

                var testingLfdTransformer = new LookbackLfdTestingEnglandQueryTransformer() { SearchDate = searchData };
                testingLfd = testingLfdTransformer.QueryAndTransform();
            }
            Result<StandardRecord> testingWeekend = null;
            Result<StandardRecord> testingWeekendLfd = null;
            if (catchUpDays.Contains(searchData.DayOfWeek))
            {
                var testingWeekendTransformer = new LookbackTestingWeekendQueryTransformer() { SearchDate = searchData };
                testingWeekend = testingWeekendTransformer.QueryAndTransform();

                var testingLfdTransformer = new LookbackLfdTestingWeekendEnglandQueryTransformer() { SearchDate = searchData };
                testingWeekendLfd = testingLfdTransformer.QueryAndTransform();
            }

            var nonDailyTransformer = new NoneDailyQueryTransformer() { SearchDate = searchData };
            var nonDaily = nonDailyTransformer.QueryAndTransform();

            var queryRecords = new List<QueryRecord>()
                .Union(daily?.QueryRecords != null ? daily?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(testing?.QueryRecords != null ? testing?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(testingLfd?.QueryRecords != null ? testingLfd?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(testingWeekend?.QueryRecords != null ? testingWeekend?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(testingWeekendLfd?.QueryRecords != null ? testingWeekendLfd?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(nonDaily?.QueryRecords != null ? nonDaily?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .ToList();

            var archiveTransformer = new ArchiveQueryTransformer() { ArchiveDate = DateTime.Now.Date };
            if (doArchive)
            {
                archiveTransformer.QueryAndTransform(queryRecords);
            }

            var model = new MainPostModel()
            {
                SearchDate = searchData,
                Title = title,
                DailyResult = daily,
                LookbackTestingResult = testing,
                LookbackTestingWeekendResult = testingWeekend,
                LookbackLfdTestingEnglandResult = testingLfd,
                LookbackLfdTestingWeekendEnglandResult = testingWeekendLfd,
                NoneDailyQueryResult = nonDaily,
                ArchiveInformation = queryRecords
            };

            var trendsPost = Engine.Run(model).Result;
            return trendsPost;
        }

        private static string GetTrendsPost(DateTime searchData, bool doArchive)
        {

            var eightDayTransform = new LookbackEightDayQueryTransformer() { SearchDate = searchData };
            var eighDays = eightDayTransform.QueryAndTransform();

            var overviewBreakdownTransformer = new RegionBreakdownOverviewQueryTransformer() { SearchDate = searchData };
            var overviewBreakdown = overviewBreakdownTransformer.QueryAndTransform();

            var nationalBreakdownTransformer = new RegionBreakdownNationalQueryTransformer() { SearchDate = searchData };
            var nationalBreakdown = nationalBreakdownTransformer.QueryAndTransform();

            var regionalBreakdownTransformer = new RegionBreakdownRegionQueryTransformer() { SearchDate = searchData };
            var regionalBreakdown = regionalBreakdownTransformer.QueryAndTransform();

            var queryRecords = new List<QueryRecord>()
               .Union(eighDays?.QueryRecords != null ? eighDays?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(overviewBreakdown?.QueryRecords != null ? overviewBreakdown?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(nationalBreakdown?.QueryRecords != null ? nationalBreakdown?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(regionalBreakdown?.QueryRecords != null ? regionalBreakdown?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .ToList();

            var archiveTransformer = new ArchiveQueryTransformer() { ArchiveDate = DateTime.Now.Date };
            if (doArchive)
            {
                archiveTransformer.QueryAndTransform(queryRecords);
            }

            var model = new TrendsPostModel()
            {
                SearchDate = searchData,
                EightDayLookback = eighDays,
                NationalRates = nationalBreakdown,
                OverviewRates = overviewBreakdown,
                RegionRates = regionalBreakdown,
                ArchiveInformation = queryRecords
            };

            var trendsPost = Engine.Run(model).Result;
            return trendsPost;
        }

        public static string AdmissionsByAgePost(DateTime searchData, bool doArchive)
        {
            var transform = new AdmissionsByAgeQueryTransformer() { SearchDate = searchData };
            var result = transform.QueryAndTransform();

            var model = new AdmissionsByAgeModel()
            {
                SearchDate = searchData, 
                AdmissionsByAge = result
            };

            var post = CsvEngine.Run(model);
         
            return post; 
        }


    }
}
