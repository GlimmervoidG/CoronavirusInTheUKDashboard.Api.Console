using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.TrendsPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries.Yesterday
{
    public class RegionBreakdownOverviewYesterdayQuery : QueryBase, IRegionBreakdownOverviewYesterdayQuery
    {
        public IQuery<RegionBreakdownQueryModel> Query { get; set; }
        public RegionBreakdownOverviewYesterdayQuery(IQuery<RegionBreakdownQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<RegionBreakdownQueryModel> DoQuery()
        {
            var targetDate = TargetDate.AddDays(-1).Date;
            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.overview),
                    Date = new DateFilter(targetDate)
                },

            }; 
            return Query.DoQuery();
        }


    }
}
