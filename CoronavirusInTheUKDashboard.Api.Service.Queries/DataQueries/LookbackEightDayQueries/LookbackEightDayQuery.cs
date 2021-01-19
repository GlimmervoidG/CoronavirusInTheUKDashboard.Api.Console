using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackEightDayQueries
{
    public class LookbackEightDayQuery : QueryBase, ILookbackEightDayQuery
    {
        public IQueryEngine<LookbackEightDayQueryModel> Query { get; set; }
        public LookbackEightDayQuery(IQueryEngine<LookbackEightDayQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<LookbackEightDayQueryModel> DoQuery()
        {

            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.overview),
                },

            };

            return Query.DoQuery();
        }


    }
}
