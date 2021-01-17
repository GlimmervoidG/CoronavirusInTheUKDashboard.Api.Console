using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.RegionBreakdownQueries.Yesterday
{
    public class RegionBreakdownRegionalYesterdayQuery : QueryBase, IRegionBreakdownRegionalYesterdayQuery
    {
        public IQuery<RegionBreakdownQueryModel> Query { get; set; }
        public RegionBreakdownRegionalYesterdayQuery(IQuery<RegionBreakdownQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<RegionBreakdownQueryModel> DoQuery()
        {
            var targetDate = TargetDate.AddDays(-1).Date;
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
