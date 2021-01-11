using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements; 
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackTestingQueries
{
    public class LookbackTestingQuery : QueryBase, ILookbackTestingQuery
    {
        public IQuery<LookbackTestingQueryModel> Query { get; set; }
        public LookbackTestingQuery(IQuery<LookbackTestingQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<LookbackTestingQueryModel> DoQuery()
        {
            var trueSearchDate = SearchDate.AddDays(0);
            var searchDate = SearchDate.AddDays(-1);
            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.overview),
                    Date = new DateFilter(searchDate)
                },

            };
            return Query.DoQuery();
        }
    }
}
