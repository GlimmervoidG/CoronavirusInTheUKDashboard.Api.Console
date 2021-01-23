using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.MainPost;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.ModelGenerators
{
    public class MainPostModelGenerator : IModelGenerator<MainPostModel>
    {
        public IOptions Option { get; set; }

        public ITitleTransformer TitleTransformer { get; set; }

        public IDailyQueryTransformer DailyQueryTransformer  { get; set; }

        public ILookbackQueryTransformer LookbackQueryTransformer  { get; set; }

        public ILookbackNationalQueryTransformer LookbackEnglandQueryTransformer  { get; set; } 

        public ILookbackVaccineQueryTransformer LookbackJustVaccineQueryTransformer { get; set; }

        public ILookbackCatchUpQueryTransformer LookbackCatchUpQueryTransformer  { get; set; }

        public ILookbackCatchUpEnglandQueryTransformer LookbackCatchUpEnglandQueryTransformer  { get; set; }

        public INonDailyQueryTransformer NoneDailyQueryTransformer { get; set; }

        public IArchiveTransformer ArchiveQueryTransformer { get; set; }




        private ILogger<MainPostModelGenerator> Logger { get; set; }


        public MainPostModelGenerator(
            IOptions option,
            ITitleTransformer titleTransformer,
            IDailyQueryTransformer dailyQueryTransformer,
            ILookbackQueryTransformer lookbackQueryTransformer,
            ILookbackNationalQueryTransformer lookbackEnglandQueryTransformer,
            ILookbackCatchUpQueryTransformer lookbackWeekendQueryTransformer,
            ILookbackVaccineQueryTransformer  lookbackVaccineQueryTransformer,
            ILookbackCatchUpEnglandQueryTransformer lookbackWeekendEnglandQueryTransformer, 
            INonDailyQueryTransformer noneDailyQueryTransformer,
            IArchiveTransformer archiveQueryTransformer,
            ILogger<MainPostModelGenerator> logger)
        {
            Option = option;
            TitleTransformer = titleTransformer;
            DailyQueryTransformer = dailyQueryTransformer;
            LookbackQueryTransformer = lookbackQueryTransformer;
            LookbackEnglandQueryTransformer = lookbackEnglandQueryTransformer;
            LookbackJustVaccineQueryTransformer = lookbackVaccineQueryTransformer;
            LookbackCatchUpQueryTransformer = lookbackWeekendQueryTransformer;
            LookbackCatchUpEnglandQueryTransformer = lookbackWeekendEnglandQueryTransformer;
            NoneDailyQueryTransformer = noneDailyQueryTransformer;
            ArchiveQueryTransformer = archiveQueryTransformer;
            Logger = logger;
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
            var weekendDays = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var catchUpDays = new List<DayOfWeek>() { DayOfWeek.Monday };

            LookbackJustVaccineQueryTransformer.TargetDate = searchData;
            Result<StandardRecord> vaccines = LookbackJustVaccineQueryTransformer.QueryAndTransform(); 

            Result<StandardRecord> lookback = null;
            Result<StandardRecord> lookbackNational = null;
            if (normalDays.Contains(searchData.DayOfWeek))
            {
                LookbackQueryTransformer.TargetDate = searchData;
                lookback = LookbackQueryTransformer.QueryAndTransform();

                LookbackEnglandQueryTransformer.TargetDate = searchData;
                lookbackNational = LookbackEnglandQueryTransformer.QueryAndTransform(); 
            } 

            Result<StandardRecord> catchUp = null;
            Result<StandardRecord> catchUpNational = null;
            if (catchUpDays.Contains(searchData.DayOfWeek))
            {
                LookbackCatchUpQueryTransformer.TargetDate = searchData;
                catchUp = LookbackCatchUpQueryTransformer.QueryAndTransform();

                LookbackCatchUpEnglandQueryTransformer.TargetDate = searchData;
                catchUpNational = LookbackCatchUpEnglandQueryTransformer.QueryAndTransform(); 
            }

            NoneDailyQueryTransformer.TargetDate = searchData;
            var nonDaily = NoneDailyQueryTransformer.QueryAndTransform();
             
            var queryRecords = new List<QueryRecord>()
                .Union(daily?.QueryRecords != null ? daily?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(vaccines?.QueryRecords != null ? vaccines?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(lookback?.QueryRecords != null ? lookback?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(lookbackNational?.QueryRecords != null ? lookbackNational?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(vaccines?.QueryRecords != null ? vaccines?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(catchUp?.QueryRecords != null ? catchUp?.QueryRecords : Enumerable.Empty<QueryRecord>())
                .Union(catchUpNational?.QueryRecords != null ? catchUpNational?.QueryRecords : Enumerable.Empty<QueryRecord>())
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
                LookbackResult = lookback,
                LookbackCatchUpResult = catchUp,
                LookbackNationalResult = lookbackNational,
                LookbackVaccines = vaccines,
                LookbackCatchUpNationalResult = catchUpNational,
                NoneDailyQueryResult = nonDaily,
                ArchiveInformation = queryRecords
            };

            return model;

        }
    }
}
