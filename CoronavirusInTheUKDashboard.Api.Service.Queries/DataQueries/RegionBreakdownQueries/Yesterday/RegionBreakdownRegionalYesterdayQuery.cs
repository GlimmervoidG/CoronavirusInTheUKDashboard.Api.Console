using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries.Yesterday
{
    public class RegionBreakdownRegionalYesterdayQuery : QueryBase
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
                        AreaType = new AreaType(AreaTypeMetrics.region),
                        Date = new DateFilter(targetDate)
                    },

                }
            };
            return quary.DoQuery();
        }


    }
}
