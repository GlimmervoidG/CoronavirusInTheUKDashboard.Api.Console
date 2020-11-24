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

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackEightDayQueries
{
    public class LookbackEightDayQuery : QueryBase
    {
        public QueryResponce<LookbackEightDayQueryModel> DoQuery()
        {
            var quary = new Query<LookbackEightDayQueryModel>()
            {
                Options = new QueryOptions()
                {
                    Filter = new Filter()
                    {
                        AreaType = new AreaType(AreaTypeMetrics.overview),
                    },

                }
            };
            return quary.DoQuery();
        }


    }
}
