using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackLfdTestingQueries;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackLfdTestingQueries
{
    public class LookbackLfdTestingEnglandQuery : QueryBase, ILookbackLfdTestingEnglandQuery
    {
        public IQuery<LookbackLfdTestingQueryModel> Query { get; set; }
        public LookbackLfdTestingEnglandQuery(IQuery<LookbackLfdTestingQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<LookbackLfdTestingQueryModel> DoQuery()
        {
            var trueTargetDate = TargetDate.AddDays(0);
            var targetDate = TargetDate.AddDays(-1);
            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.nation),
                    AreaName = new AreaName("England"),
                    Date = new DateFilter(targetDate)
                },

            };
            return Query.DoQuery();
        }


    }
}
