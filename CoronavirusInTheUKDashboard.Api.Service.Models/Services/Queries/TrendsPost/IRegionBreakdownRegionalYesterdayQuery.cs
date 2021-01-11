using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.RegionBreakdownQueries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.TrendsPost
{
    public interface IRegionBreakdownRegionalYesterdayQuery : IQuery<RegionBreakdownQueryModel>
    {
    }
}
