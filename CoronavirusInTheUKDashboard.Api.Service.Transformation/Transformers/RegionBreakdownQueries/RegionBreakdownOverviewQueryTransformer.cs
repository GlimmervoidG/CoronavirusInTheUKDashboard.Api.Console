using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries.Yesterday;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries.Population;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.TrendsPost;
using Microsoft.Extensions.Logging;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries
{
    public class RegionBreakdownOverviewQueryTransformer : RegionBreakdownQueryTransformer, IRegionBreakdownOverviewQueryTransformer
    {
        public IRegionBreakdownOverviewQuery QueryToday { get; set; }
        public IRegionBreakdownOverviewYesterdayQuery QueryYesterday { get; set; }
        public ILogger<RegionBreakdownOverviewQueryTransformer> Logger { get; set; }
        public RegionBreakdownOverviewQueryTransformer(IRegionBreakdownOverviewQuery queryToday, IRegionBreakdownOverviewYesterdayQuery queryYesterday, ILogger<RegionBreakdownOverviewQueryTransformer> logger)
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

            QueryNameToday = NameConstants.RegionBreakdownQuery_Overview_Today;
            QueryNameYesterday = NameConstants.RegionBreakdownQuery_Overview_Yesterday;

            var regions = PopulationHelper.GetAllAsRegionList().Where(r => r.RegionType == RegionType.Overview).Select(r => r.Name).ToList();
            return Transform(regions, resultToday, resultYesterday);
        }

    }
}
