﻿using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.AdmissionsQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.AdmissionsByAge;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.AdmissionsQueries
{
    public class AdmissionsByAgeQuery : QueryBase, IAdmissionsByAgeQuery
    {
        public IQueryEngine<AdmissionsByAgeModel> Query { get; set; }
        public AdmissionsByAgeQuery(IQueryEngine<AdmissionsByAgeModel> query)
        {
            Query = query;
        }
        public QueryResponce<AdmissionsByAgeModel> DoQuery()
        {

            Query.Options = new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(AreaTypeMetrics.nation),
                    AreaName = new AreaName("England")
                }

            };

            return Query.DoQuery();
        }


    }
}
