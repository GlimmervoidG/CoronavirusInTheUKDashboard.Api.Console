using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackQueries
{
    public class LookbackQuery : QueryBase, ILookbackQuery
    {
        public IQuery<LookbackQueryModel> Query { get; set; }
        public LookbackQuery(IQuery<LookbackQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<LookbackQueryModel> DoQuery()
        {
            var trueTargetDate = TargetDate.AddDays(0);
            var targetDate = TargetDate.AddDays(-1);
            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.overview),
                    Date = new DateFilter(targetDate)
                },

            };
            return Query.DoQuery();
        }
    }
}
