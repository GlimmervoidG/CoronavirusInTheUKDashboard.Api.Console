using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.DailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries
{
    public class DailyQuery : QueryBase, IDailyQuery
    {
        public IQueryEngine<DailyQueryModel> Query { get; set; }
        public DailyQuery(IQueryEngine<DailyQueryModel> query)
        {
            Query = query;
        }

        public QueryResponce<DailyQueryModel> DoQuery()
        {
            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.overview),
                    Date = new DateFilter(TargetDate)
                }

            };
            return Query.DoQuery();
        }


    }
}
