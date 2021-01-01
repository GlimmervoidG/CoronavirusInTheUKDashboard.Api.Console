﻿using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.DailyQueries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Queries.Models.AdmissionsQueries;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.AdmissionsQueries
{
    public class AdmissionsByAgeQuery : QueryBase
    {

        public QueryResponce<AdmissionsByAgeModel> DoQuery()
        {
            var quary = new Query<AdmissionsByAgeModel>()
            {
                Options = new QueryOptions()
                {
                    Filter = new Filter()
                    {
                        AreaType = new AreaType(AreaTypeMetrics.nation),
                        AreaName = new AreaName("England")
                    }

                }
            };
            return quary.DoQuery();
        }


    }
}
