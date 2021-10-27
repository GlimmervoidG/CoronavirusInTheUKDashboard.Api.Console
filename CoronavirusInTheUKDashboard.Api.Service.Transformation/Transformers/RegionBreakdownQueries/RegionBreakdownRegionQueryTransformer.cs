using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.TrendsPost;
using UkOnsPopulationEstimatesUnofficial;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries
{
    public class RegionBreakdownRegionQueryTransformer : RegionBreakdownQueryTransformer, IRegionBreakdownRegionQueryTransformer
    {
        public IRegionBreakdownRegionalQuery QueryToday { get; set; }
        public IRegionBreakdownRegionalYesterdayQuery QueryYesterday { get; set; }

        public ILogger<RegionBreakdownRegionQueryTransformer> Logger { get; set; }
        public RegionBreakdownRegionQueryTransformer(
            IRegionBreakdownRegionalQuery queryToday, 
            IRegionBreakdownRegionalYesterdayQuery queryYesterday, 
            ILogger<RegionBreakdownRegionQueryTransformer> logger)
        {
            QueryToday = queryToday;
            QueryYesterday = queryYesterday;
            Logger = logger;
        }

        public Result<RegionRateRecord> QueryAndTransform()
        {

            Logger.LogInformation($"Running Query and transform.");
            QueryToday.TargetDate = TargetDate;
            var resultToday = QueryToday.DoQuery();

            QueryYesterday.TargetDate = TargetDate;
            var resultYesterday = QueryYesterday.DoQuery();

            QueryNameToday = NameConstants.RegionBreakdownQuery_Region_Today;
            QueryNameYesterday = NameConstants.RegionBreakdownQuery_Region_Yesterday;


            var list = PopulationDataSet.DataSet().EnglishRegions().ToList();
            return Transform(list, resultToday, resultYesterday);

        }

    }
}
