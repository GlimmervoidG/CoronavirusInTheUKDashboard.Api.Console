using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.DailyQueries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.NoneDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.RegionBreakdownQueries;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries.Yesterday
{
    public class RegionBreakdownOverviewYesterdayQuery : QueryBase
    {
        public QueryResponce<RegionBreakdownQueryModel> DoQuery()
        {
            var targetDate = SearchDate.AddDays(-1).Date;
            var quary = new Query<RegionBreakdownQueryModel>()
            {
                Options = new QueryOptions()
                {
                    Filter = new Filter()
                    {
                        AreaType = new AreaType(AreaTypeMetrics.overview),
                        Date = new DateFilter(targetDate)
                    },

                }
            };
            return quary.DoQuery();
        }


    }
}
