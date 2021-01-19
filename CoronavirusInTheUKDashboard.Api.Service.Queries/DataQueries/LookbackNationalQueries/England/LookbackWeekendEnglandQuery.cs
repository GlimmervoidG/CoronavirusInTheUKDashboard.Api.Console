using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackNationalQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.MainPost;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackNationalQueries.England
{
    public class LookbackWeekendEnglandQuery : QueryBase, ILookbackWeekendEnglandQuery
    {
        public IQueryEngine<LookbackWeekendModel> Query { get; set; }
        public LookbackWeekendEnglandQuery(IQueryEngine<LookbackWeekendModel> query)
        {
            Query = query;
        }
        public QueryResponce<LookbackWeekendModel> DoQuery()
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
