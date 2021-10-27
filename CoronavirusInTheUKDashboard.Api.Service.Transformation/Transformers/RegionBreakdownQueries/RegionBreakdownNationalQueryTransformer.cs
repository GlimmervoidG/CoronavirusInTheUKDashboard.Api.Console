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


            var list = PopulationDataSet.DataSet().HomeNations().ToList();
            return Transform(list, resultToday, resultYesterday);
        }
 
    }
}
