using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System.Linq;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.ModelGenerators
{
    public class TrendsPostModelGenerator : IModelGenerator<TrendsPostModel>
    {
        public IOptions Option { get; set; }

        public ILookbackEightDayQueryTransformer LookbackEightDayQueryTransformer { get; set; }

        public IRegionBreakdownOverviewQueryTransformer RegionBreakdownOverviewQueryTransformer { get; set; }

        public IRegionBreakdownNationalQueryTransformer RegionBreakdownNationalQueryTransformer { get; set; }

        public IRegionBreakdownRegionQueryTransformer RegionBreakdownRegionQueryTransformer { get; set; }


        public IRegionVaccineProgressOverviewQueryTransformer RegionVaccineProgressOverviewQueryTransformer { get; set; }
        public IRegionVaccineProgressNationalQueryTransformer RegionVaccineProgressNationalQueryTransformer { get; set; }
        public IRegionVaccineProgressRegionQueryTransformer RegionVaccineProgressRegionQueryTransformer { get; set; }


        public IArchiveTransformer ArchiveQueryTransformer { get; set; }
        private ILogger<TrendsPostModelGenerator> Logger { get; set; }


        public TrendsPostModelGenerator(
            IOptions option,
            ILookbackEightDayQueryTransformer lookbackEightDayQueryTransformer,
            IRegionBreakdownOverviewQueryTransformer regionBreakdownOverviewQueryTransformer,
            IRegionBreakdownNationalQueryTransformer regionBreakdownNationalQueryTransformer,
            IRegionBreakdownRegionQueryTransformer regionBreakdownRegionQueryTransformer,
            IRegionVaccineProgressOverviewQueryTransformer regionVaccineProgressOverviewQueryTransformer,
            IRegionVaccineProgressNationalQueryTransformer regionVaccineProgressNationalQueryTransformer,
            IRegionVaccineProgressRegionQueryTransformer regionVaccineProgressRegionQueryTransformer,
            IArchiveTransformer archiveQueryTransformer,
            ILogger<TrendsPostModelGenerator> logger
            )
        {
            Option = option;
            LookbackEightDayQueryTransformer = lookbackEightDayQueryTransformer;
            RegionBreakdownOverviewQueryTransformer = regionBreakdownOverviewQueryTransformer;
            RegionBreakdownNationalQueryTransformer = regionBreakdownNationalQueryTransformer;
            RegionBreakdownRegionQueryTransformer = regionBreakdownRegionQueryTransformer;

            RegionVaccineProgressOverviewQueryTransformer = regionVaccineProgressOverviewQueryTransformer;
            RegionVaccineProgressNationalQueryTransformer = regionVaccineProgressNationalQueryTransformer;
            RegionVaccineProgressRegionQueryTransformer = regionVaccineProgressRegionQueryTransformer;

            ArchiveQueryTransformer = archiveQueryTransformer;
            Logger = logger;

        }

        public TrendsPostModel GenerateModel()
        {
            var searchData = Option.TargetDate;
            var trueDate = Option.TrueDateTime;
            var doArchive = Option.UseExternalArchiveSite;

            LookbackEightDayQueryTransformer.TargetDate = searchData;
            var eighDays = LookbackEightDayQueryTransformer.QueryAndTransform();


            RegionBreakdownOverviewQueryTransformer.TargetDate = searchData;
            var overviewBreakdown = RegionBreakdownOverviewQueryTransformer.QueryAndTransform();

            RegionBreakdownNationalQueryTransformer.TargetDate = searchData;
            var nationalBreakdown = RegionBreakdownNationalQueryTransformer.QueryAndTransform();

            RegionBreakdownRegionQueryTransformer.TargetDate = searchData;
            var regionalBreakdown = RegionBreakdownRegionQueryTransformer.QueryAndTransform();


            RegionVaccineProgressOverviewQueryTransformer.TargetDate = searchData;
            var overviewVaccineProgress = RegionVaccineProgressOverviewQueryTransformer.QueryAndTransform();

            RegionVaccineProgressNationalQueryTransformer.TargetDate = searchData;
            var nationalVaccineProgress = RegionVaccineProgressNationalQueryTransformer.QueryAndTransform();

            var queryRecords = new List<QueryRecord>()
               .Union(eighDays?.QueryRecords != null ? eighDays?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(overviewBreakdown?.QueryRecords != null ? overviewBreakdown?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(nationalBreakdown?.QueryRecords != null ? nationalBreakdown?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(regionalBreakdown?.QueryRecords != null ? regionalBreakdown?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(overviewVaccineProgress?.QueryRecords != null ? overviewVaccineProgress?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(nationalVaccineProgress?.QueryRecords != null ? nationalVaccineProgress?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .ToList();


            ArchiveQueryTransformer.ArchiveDate = trueDate;
            if (doArchive)
            {
                ArchiveQueryTransformer.QueryAndTransform(queryRecords);
            }

            var model = new TrendsPostModel()
            {
                TargetDate = searchData,
                EightDayLookback = eighDays.Records.First(),
                NationalRates = nationalBreakdown,
                OverviewRates = overviewBreakdown,
                RegionRates = regionalBreakdown,
                OverviewVaccineProgress = overviewVaccineProgress,
                NationalVaccineProgress = nationalVaccineProgress,
                ArchiveInformation = queryRecords
            };

            return model;
        }
    }
}
