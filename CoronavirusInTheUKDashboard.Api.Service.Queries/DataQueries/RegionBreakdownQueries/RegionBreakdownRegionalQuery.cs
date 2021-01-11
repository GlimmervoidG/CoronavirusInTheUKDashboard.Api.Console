using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.TrendsPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries
{
    public class RegionBreakdownRegionalQuery : QueryBase, IRegionBreakdownRegionalQuery
    {
        public IQuery<RegionBreakdownQueryModel> Query { get; set; }
        public RegionBreakdownRegionalQuery(IQuery<RegionBreakdownQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<RegionBreakdownQueryModel> DoQuery()
        {
            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.region),
                    Date = new DateFilter(TargetDate)
                },

            };
            return Query.DoQuery();
        }


    }
}
