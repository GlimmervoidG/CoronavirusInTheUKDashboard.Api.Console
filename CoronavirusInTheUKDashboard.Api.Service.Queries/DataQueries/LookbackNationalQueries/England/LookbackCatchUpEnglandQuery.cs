using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEnglandQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackNationalQueries.England
{
    public class LookbackCatchUpEnglandQuery : QueryBase, ILookbackCatchUpEnglandQuery
    {
        public IQuery<LookbackEnglandQueryModel> Query { get; set; }
        public LookbackCatchUpEnglandQuery(IQuery<LookbackEnglandQueryModel> query)
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
