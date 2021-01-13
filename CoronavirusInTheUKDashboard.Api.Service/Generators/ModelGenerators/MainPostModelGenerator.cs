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
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackQueries;
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

        public ILookbackQueryTransformer LookbackQueryTransformer  { get; set; }

        public ILookbackEnglandQueryTransformer LookbackEnglandQueryTransformer  { get; set; }

        public ILookbackWeekendQueryTransformer LookbackWeekendQueryTransformer  { get; set; }

        public ILookbackWeekendEnglandQueryTransformer LookbackWeekendEnglandQueryTransformer  { get; set; }

        public INonDailyQueryTransformer NoneDailyQueryTransformer { get; set; }

        public IArchiveTransformer ArchiveQueryTransformer { get; set; }


        public MainPostModelGenerator(
            IOptions option, 
            ITitleTransformer titleTransformer, 
            IDailyQueryTransformer dailyQueryTransformer, 
            ILookbackQueryTransformer lookbackQueryTransformer, 
            ILookbackEnglandQueryTransformer lookbackEnglandQueryTransformer, 
            ILookbackWeekendQueryTransformer lookbackWeekendQueryTransformer, 
            ILookbackWeekendEnglandQueryTransformer lookbackWeekendEnglandQueryTransformer, 
            INonDailyQueryTransformer noneDailyQueryTransformer,
            IArchiveTransformer archiveQueryTransformer)
        {
            Option = option;
            TitleTransformer = titleTransformer;
            DailyQueryTransformer = dailyQueryTransformer;
            LookbackQueryTransformer = lookbackQueryTransformer;
            LookbackEnglandQueryTransformer = lookbackEnglandQueryTransformer;
            LookbackWeekendQueryTransformer = lookbackWeekendQueryTransformer;
            LookbackWeekendEnglandQueryTransformer = lookbackWeekendEnglandQueryTransformer;
            NoneDailyQueryTransformer = noneDailyQueryTransformer;
            ArchiveQueryTransformer = archiveQueryTransformer;
        }

        public MainPostModel GenerateModel()
        {
            var searchData = Option.TargetDate;
            var trueDate = Option.TrueDateTime;
            var doArchive = Option.UseExternalArchiveSite;

            TitleTransformer.TargetDate = searchData;
            var title = TitleTransformer.QueryAndTransform();

            DailyQueryTransformer.TargetDate = searchData;
            var daily = DailyQueryTransformer.QueryAndTransform();

            var normalDays = new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            var catchUpDays = new List<DayOfWeek>() { DayOfWeek.Monday };

            Result<StandardRecord> testing = null;
            Result<StandardRecord> testingLfd = null;
            if (normalDays.Contains(searchData.DayOfWeek))
            {
                LookbackQueryTransformer.TargetDate = searchData;
                testing = LookbackQueryTransformer.QueryAndTransform();

                LookbackEnglandQueryTransformer.TargetDate = searchData;
                testingLfd = LookbackEnglandQueryTransformer.QueryAndTransform(); 
            }

            Result<StandardRecord> testingWeekend = null;
            Result<StandardRecord> testingWeekendLfd = null;
            if (catchUpDays.Contains(searchData.DayOfWeek))
            {
                LookbackWeekendQueryTransformer.TargetDate = searchData;
                testingWeekend = LookbackWeekendQueryTransformer.QueryAndTransform();

                LookbackWeekendEnglandQueryTransformer.TargetDate = searchData;
                testingWeekendLfd = LookbackWeekendEnglandQueryTransformer.QueryAndTransform(); 
            }

            NoneDailyQueryTransformer.TargetDate = searchData;
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
                TargetDate = searchData,
                Title = title.Records.First(),
                DailyResult = daily,
                LookbackResult = testing,
                LookbackWeekendResult = testingWeekend,
                LookbackEnglandResult = testingLfd,
                LookbackWeekendEnglandResult = testingWeekendLfd,
                NoneDailyQueryResult = nonDaily,
                ArchiveInformation = queryRecords
            };

            return model;

        }
    }
}
