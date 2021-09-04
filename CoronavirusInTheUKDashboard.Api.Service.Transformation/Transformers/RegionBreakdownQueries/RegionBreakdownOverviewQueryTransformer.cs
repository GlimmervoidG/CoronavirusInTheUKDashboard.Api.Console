using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries.Population;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.TrendsPost;
using Uk.Ons.PopulationEstimates.Unofficial;

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


            var list = PopulationDataSet.DataSet().UK().ToList();
            return Transform(list, resultToday, resultYesterday);
        }

    }
}
