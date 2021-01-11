using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.ModelGenerators
{
    public class TrendsPostModelGenerator : IModelGenerator<TrendsPostModel>
    {
        public IOptions Option { get; set; }

        public ILookbackEightDayQueryTransformer LookbackEightDayQueryTransformer { get; set; }

        public IRegionBreakdownOverviewQueryTransformer RegionBreakdownOverviewQueryTransformer { get; set; }

        public IRegionBreakdownNationalQueryTransformer RegionBreakdownNationalQueryTransformer { get; set; }

        public IRegionBreakdownRegionQueryTransformer RegionBreakdownRegionQueryTransformer { get; set; }
        public IArchiveTransformer ArchiveQueryTransformer { get; set; }


        public TrendsPostModelGenerator(
            IOptions option,
            ILookbackEightDayQueryTransformer lookbackEightDayQueryTransformer,
            IRegionBreakdownOverviewQueryTransformer regionBreakdownOverviewQueryTransformer,
            IRegionBreakdownNationalQueryTransformer regionBreakdownNationalQueryTransformer,
            IRegionBreakdownRegionQueryTransformer regionBreakdownRegionQueryTransformer,
            IArchiveTransformer archiveQueryTransformer
            )
        {
            Option = option;
            LookbackEightDayQueryTransformer = lookbackEightDayQueryTransformer;
            RegionBreakdownOverviewQueryTransformer = regionBreakdownOverviewQueryTransformer;
            RegionBreakdownNationalQueryTransformer = regionBreakdownNationalQueryTransformer;
            RegionBreakdownRegionQueryTransformer = regionBreakdownRegionQueryTransformer;
            ArchiveQueryTransformer = archiveQueryTransformer;

        }

        public TrendsPostModel GenerateModel()
        {
            var searchData = Option.TargetDate;
            var trueDate = Option.TrueDateTime;
            var doArchive = Option.UseExternalArchiveSite;

            LookbackEightDayQueryTransformer.SearchDate = searchData;
            var eighDays = LookbackEightDayQueryTransformer.QueryAndTransform();


            RegionBreakdownOverviewQueryTransformer.SearchDate = searchData;
            var overviewBreakdown = RegionBreakdownOverviewQueryTransformer.QueryAndTransform();

            RegionBreakdownNationalQueryTransformer.SearchDate = searchData;
            var nationalBreakdown = RegionBreakdownNationalQueryTransformer.QueryAndTransform();

            RegionBreakdownRegionQueryTransformer.SearchDate = searchData;
            var regionalBreakdown = RegionBreakdownRegionQueryTransformer.QueryAndTransform();

            var queryRecords = new List<QueryRecord>()
               .Union(eighDays?.QueryRecords != null ? eighDays?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(overviewBreakdown?.QueryRecords != null ? overviewBreakdown?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(nationalBreakdown?.QueryRecords != null ? nationalBreakdown?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .Union(regionalBreakdown?.QueryRecords != null ? regionalBreakdown?.QueryRecords : Enumerable.Empty<QueryRecord>())
               .ToList();

            ArchiveQueryTransformer.ArchiveDate = trueDate;
            if (doArchive)
            {
                ArchiveQueryTransformer.QueryAndTransform(queryRecords);
            }

            var model = new TrendsPostModel()
            {
                SearchDate = searchData,
                EightDayLookback = eighDays.Records.First(),
                NationalRates = nationalBreakdown,
                OverviewRates = overviewBreakdown,
                RegionRates = regionalBreakdown,
                ArchiveInformation = queryRecords
            };

            return model;
        }
    }
}
