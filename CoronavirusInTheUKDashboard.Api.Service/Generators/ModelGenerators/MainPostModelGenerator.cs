using CoronavirusInTheUKDashboard.Api.Service.Models.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.PostTextGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackLfdTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.ModelGenerators
{
    public class MainPostModelGenerator : IModelGenerator<MainPostModel>
    {
        public IOptions Option { get; set; }

        public ITitleTransformer TitleTransformer { get; set; }

        public IDailyQueryTransformer DailyQueryTransformer  { get; set; }

        public ILookbackTestingQueryTransformer LookbackTestingQueryTransformer  { get; set; }

        public ILookbackLfdTestingEnglandQueryTransformer LookbackLfdTestingEnglandQueryTransformer  { get; set; }

        public ILookbackTestingWeekendQueryTransformer LookbackTestingWeekendQueryTransformer  { get; set; }

        public ILookbackLfdTestingWeekendEnglandQueryTransformer LookbackLfdTestingWeekendEnglandQueryTransformer  { get; set; }

        public INonDailyQueryTransformer NoneDailyQueryTransformer { get; set; }

        public IArchiveTransformer ArchiveQueryTransformer { get; set; }


        public MainPostModelGenerator(
            IOptions option, 
            ITitleTransformer titleTransformer, 
            IDailyQueryTransformer dailyQueryTransformer, 
            ILookbackTestingQueryTransformer lookbackTestingQueryTransformer, 
            ILookbackLfdTestingEnglandQueryTransformer lookbackLfdTestingEnglandQueryTransformer, 
            ILookbackTestingWeekendQueryTransformer lookbackTestingWeekendQueryTransformer, 
            ILookbackLfdTestingWeekendEnglandQueryTransformer lookbackLfdTestingWeekendEnglandQueryTransformer, 
            INonDailyQueryTransformer noneDailyQueryTransformer,
            IArchiveTransformer archiveQueryTransformer)
        {
            Option = option;
            TitleTransformer = titleTransformer;
            DailyQueryTransformer = dailyQueryTransformer;
            LookbackTestingQueryTransformer = lookbackTestingQueryTransformer;
            LookbackLfdTestingEnglandQueryTransformer = lookbackLfdTestingEnglandQueryTransformer;
            LookbackTestingWeekendQueryTransformer = lookbackTestingWeekendQueryTransformer;
            LookbackLfdTestingWeekendEnglandQueryTransformer = lookbackLfdTestingWeekendEnglandQueryTransformer;
            NoneDailyQueryTransformer = noneDailyQueryTransformer;
            ArchiveQueryTransformer = archiveQueryTransformer;
        }

        public MainPostModel GenerateModel()
        {
            var searchData = Option.TargetDate;
            var trueDate = Option.TrueDateTime;
            var doArchive = Option.UseExternalArchiveSite;

            TitleTransformer.SearchDate = searchData;
            var title = TitleTransformer.QueryAndTransform();

            DailyQueryTransformer.SearchDate = searchData;
            var daily = DailyQueryTransformer.QueryAndTransform();

            var normalDays = new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            var catchUpDays = new List<DayOfWeek>() { DayOfWeek.Monday };

            Result<StandardRecord> testing = null;
            Result<StandardRecord> testingLfd = null;
            if (normalDays.Contains(searchData.DayOfWeek))
            {
                LookbackTestingQueryTransformer.SearchDate = searchData;
                testing = LookbackTestingQueryTransformer.QueryAndTransform();

                LookbackLfdTestingEnglandQueryTransformer.SearchDate = searchData;
                testingLfd = LookbackLfdTestingEnglandQueryTransformer.QueryAndTransform(); 
            }

            Result<StandardRecord> testingWeekend = null;
            Result<StandardRecord> testingWeekendLfd = null;
            if (catchUpDays.Contains(searchData.DayOfWeek))
            {
                LookbackTestingWeekendQueryTransformer.SearchDate = searchData;
                testingWeekend = LookbackTestingWeekendQueryTransformer.QueryAndTransform();

                LookbackLfdTestingWeekendEnglandQueryTransformer.SearchDate = searchData;
                testingWeekendLfd = LookbackLfdTestingWeekendEnglandQueryTransformer.QueryAndTransform(); 
            }

            NoneDailyQueryTransformer.SearchDate = searchData;
            var nonDaily = NoneDailyQueryTransformer.QueryAndTransform();
             
            var queryRecords = new List<QueryRecord>()
                .Union(daily?.QueryRecords != null ? daily?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(testing?.QueryRecords != null ? testing?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(testingLfd?.QueryRecords != null ? testingLfd?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(testingWeekend?.QueryRecords != null ? testingWeekend?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(testingWeekendLfd?.QueryRecords != null ? testingWeekendLfd?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(nonDaily?.QueryRecords != null ? nonDaily?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .ToList();

            if (doArchive)
            {
                ArchiveQueryTransformer.ArchiveDate = trueDate;
                ArchiveQueryTransformer.QueryAndTransform(queryRecords);
            }
 
            var model = new MainPostModel()
            {
                SearchDate = searchData,
                Title = title.Records.First(),
                DailyResult = daily,
                LookbackTestingResult = testing,
                LookbackTestingWeekendResult = testingWeekend,
                LookbackLfdTestingEnglandResult = testingLfd,
                LookbackLfdTestingWeekendEnglandResult = testingWeekendLfd,
                NoneDailyQueryResult = nonDaily,
                ArchiveInformation = queryRecords
            };

            return model;

        }
    }
}
