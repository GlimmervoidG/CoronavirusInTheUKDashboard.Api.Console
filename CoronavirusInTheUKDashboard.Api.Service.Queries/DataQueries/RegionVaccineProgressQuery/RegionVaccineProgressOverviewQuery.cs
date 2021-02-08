using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using System;
using System.Collections.Generic;
using System.Text;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionVaccineProgressQueries;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.RegionBreakdownQueries
{
    public class RegionVaccineProgressOverviewQuery : QueryBase, IRegionVaccineProgressOverviewQuery
    {
        public IQueryEngine<RegionVaccineProgressQueryModel> Query { get; set; }
        public RegionVaccineProgressOverviewQuery(IQueryEngine<RegionVaccineProgressQueryModel> query)
        {
            Query = query;
        }
        public QueryResponce<RegionVaccineProgressQueryModel> DoQuery()
        {
            var targetDate = TargetDate.AddDays(-1).Date;
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
