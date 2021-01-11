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

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries
{
    public class RegionBreakdownNationalQueryTransformer : RegionBreakdownQueryTransformer, IRegionBreakdownNationalQueryTransformer
    {
        public IRegionBreakdownNationalQuery QueryToday { get; set; }
        public IRegionBreakdownNationalYesterdayQuery QueryYesterday { get; set; }
        public RegionBreakdownNationalQueryTransformer(IRegionBreakdownNationalQuery queryToday, IRegionBreakdownNationalYesterdayQuery queryYesterday)
        {
            QueryToday = queryToday;
            QueryYesterday = queryYesterday;
        }

        public Result<RegionRateRecord> QueryAndTransform()
        {
            QueryToday.SearchDate = SearchDate;
            var resultToday = QueryToday.DoQuery();

            QueryYesterday.SearchDate = SearchDate;
            var resultYesterday = QueryYesterday.DoQuery(); 

            QueryNameToday = NameConstants.RegionBreakdownQuery_National_Today;
            QueryNameYesterday = NameConstants.RegionBreakdownQuery_National_Yesterday;

            var regions = PopulationHelper.GetAllAsRegionList().Where(r => r.RegionType == RegionType.HomeNation).Select(r => r.Name).ToList();
            return Transform(regions, resultToday, resultYesterday);
        }
 
    }
}
