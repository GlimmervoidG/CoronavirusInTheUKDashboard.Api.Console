using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionVaccineProgressQueries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost
{
    public interface IRegionVaccineProgressRegionalQuery : IQuery<RegionVaccineProgressQueryModel>
    {
    }
}
