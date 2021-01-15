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
    public class RegionBreakdownNationalQueryTransformer : RegionBreakdownQueryTransformer, IRegionBreakdownNationalQueryTransformer
    {
        public IRegionBreakdownNationalQuery QueryToday { get; set; }
        public IRegionBreakdownNationalYesterdayQuery QueryYesterday { get; set; }
        public ILogger<RegionBreakdownNationalQueryTransformer> Logger { get; set; }
        public RegionBreakdownNationalQueryTransformer(IRegionBreakdownNationalQuery queryToday, IRegionBreakdownNationalYesterdayQuery queryYesterday,
            ILogger<RegionBreakdownNationalQueryTransformer> logger)
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

            QueryNameToday = NameConstants.RegionBreakdownQuery_National_Today;
            QueryNameYesterday = NameConstants.RegionBreakdownQuery_National_Yesterday;

            var regions = PopulationHelper.GetAllAsRegionList().Where(r => r.RegionType == RegionType.HomeNation).Select(r => r.Name).ToList();
            return Transform(regions, resultToday, resultYesterday);
        }
 
    }
}
