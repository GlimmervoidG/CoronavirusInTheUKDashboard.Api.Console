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
    public class RegionBreakdownRegionQueryTransformer : RegionBreakdownQueryTransformer, IRegionBreakdownRegionQueryTransformer
    {
        public IRegionBreakdownRegionalQuery QueryToday { get; set; }
        public IRegionBreakdownRegionalYesterdayQuery QueryYesterday { get; set; }
        public RegionBreakdownRegionQueryTransformer(IRegionBreakdownRegionalQuery queryToday, IRegionBreakdownRegionalYesterdayQuery queryYesterday)
        {
            QueryToday = queryToday;
            QueryYesterday = queryYesterday;
        }

        public Result<RegionRateRecord> QueryAndTransform()
        {

            QueryToday.TargetDate = TargetDate;
            var resultToday = QueryToday.DoQuery();

            QueryYesterday.TargetDate = TargetDate;
            var resultYesterday = QueryYesterday.DoQuery();

            QueryNameToday = NameConstants.RegionBreakdownQuery_Region_Today;
            QueryNameYesterday = NameConstants.RegionBreakdownQuery_Region_Yesterday;

            var regions = PopulationHelper.GetAllAsRegionList().Where(r => r.RegionType == RegionType.EnglishRegion).Select(r => r.Name).ToList();
            return Transform(regions, resultToday, resultYesterday);

        }

    }
}
