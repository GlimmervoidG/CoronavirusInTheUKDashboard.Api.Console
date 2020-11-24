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

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries
{
    public class DailyQuery : QueryBase
    {

        public QueryResponce<DailyQueryModel> DoQuery()
        {
            var quary = new Query<DailyQueryModel>()
            {
                Options = new QueryOptions()
                {
                    Filter = new Filter()
                    {
                        AreaType = new AreaType(AreaTypeMetrics.overview),
                        Date = new DateFilter(SearchDate)
                    },

                }
            };
            return quary.DoQuery();
        }


    }
}
