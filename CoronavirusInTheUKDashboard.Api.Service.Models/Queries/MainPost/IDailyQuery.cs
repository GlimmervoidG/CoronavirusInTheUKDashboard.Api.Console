using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost
{
    public interface IDailyQuery : IQuery<DailyQueryModel>
    {
    }
}
