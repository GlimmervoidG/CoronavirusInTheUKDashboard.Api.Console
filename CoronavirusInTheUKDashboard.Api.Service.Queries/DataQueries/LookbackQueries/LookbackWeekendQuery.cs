using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackQueries
{
    public class LookbackWeekendQuery : QueryBase, ILookbackWeekendQuery
    {
        public IQuery<LookbackQueryModel> Query { get; set; }
        public LookbackWeekendQuery(IQuery<LookbackQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<LookbackQueryModel> DoQuery()
        {
            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.overview)
                },

            };
            return Query.DoQuery();
        }
    }
}
