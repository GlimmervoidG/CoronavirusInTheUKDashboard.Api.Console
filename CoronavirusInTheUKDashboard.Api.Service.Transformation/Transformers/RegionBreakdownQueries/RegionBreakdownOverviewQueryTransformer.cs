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
    public class RegionBreakdownOverviewQueryTransformer : RegionBreakdownQueryTransformer
    {

        public Result<RegionRateRecord> QueryAndTransform()
        { 
            var queryToday = new RegionBreakdownOverviewQuery() { SearchDate = SearchDate };
            var resultToday = queryToday.DoQuery();

            var queryYesterday = new RegionBreakdownOverviewYesterdayQuery() { SearchDate = SearchDate };
            var resultYesterday = queryYesterday.DoQuery();

            QueryNameToday = NameConstants.RegionBreakdownQuery_Overview_Today;
            QueryNameYesterday = NameConstants.RegionBreakdownQuery_Overview_Yesterday;

            var regions = PopulationHelper.GetAllAsRegionList().Where(r => r.RegionType == RegionType.Overview).Select(r => r.Name).ToList();
            return Transform(regions, resultToday, resultYesterday);
        }

    }
}
