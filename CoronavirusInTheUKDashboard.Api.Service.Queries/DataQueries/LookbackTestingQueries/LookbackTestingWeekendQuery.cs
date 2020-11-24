using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.DailyQueries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.LookbackLfdTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.LookbackTestingQueries;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackTestingQueries
{
    public class LookbackTestingWeekendQuery : QueryBase
    {
        public QueryResponce<LookbackTestingQueryModel> DoQuery()
        {
            var quary = new Query<LookbackTestingQueryModel>()
            {
                Options = new QueryOptions()
                {
                    Filter = new Filter()
                    {
                        AreaType = new AreaType(AreaTypeMetrics.overview)
                    },

                }
            };
            return quary.DoQuery();
        }
    }
}
