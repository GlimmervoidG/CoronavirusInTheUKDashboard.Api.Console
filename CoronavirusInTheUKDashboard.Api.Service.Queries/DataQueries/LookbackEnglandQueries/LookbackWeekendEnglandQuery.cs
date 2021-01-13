using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackQueries
{
    public class LookbackWeekendEnglandQuery : QueryBase, ILookbackWeekendEnglandQuery
    {
        public IQuery<LookbackEnglandQueryModel> Query { get; set; }
        public LookbackWeekendEnglandQuery(IQuery<LookbackEnglandQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<LookbackEnglandQueryModel> DoQuery()
        {

            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.nation),
                    AreaName = new AreaName("England"),
                },

            };
            return Query.DoQuery();
        }


    }
}
