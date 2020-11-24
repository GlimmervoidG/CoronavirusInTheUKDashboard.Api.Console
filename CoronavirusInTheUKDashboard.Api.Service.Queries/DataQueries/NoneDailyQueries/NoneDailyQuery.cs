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
using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.NoneDailyQueries;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries
{
    public class NoneDailyQuery : QueryBase
    {
        public QueryResponce<NonDailyQueryModel> DoQuery()
        {
            var quary = new Query<NonDailyQueryModel>()
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
