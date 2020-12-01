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

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries
{
    public class RegionBreakdownRegionQueryTransformer : RegionBreakdownQueryTransformer
    {

        public Result<RegionRateRecord> QueryAndTransform()
        {

            var queryToday = new RegionBreakdownRegionalQuery() { SearchDate = SearchDate };
            var resultToday = queryToday.DoQuery();

            var queryYesterday = new RegionBreakdownRegionalYesterdayQuery() { SearchDate = SearchDate };
            var resultYesterday = queryYesterday.DoQuery();

            QueryNameToday = NameConstants.RegionBreakdownQuery_Region_Today;
            QueryNameYesterday = NameConstants.RegionBreakdownQuery_Region_Yesterday;

            var regions = PopulationHelper.GetAllAsRegionList().Where(r => r.RegionType == RegionType.EnglishRegion).Select(r => r.Name).ToList();
            return Transform(regions, resultToday, resultYesterday);

        }

    }
}
