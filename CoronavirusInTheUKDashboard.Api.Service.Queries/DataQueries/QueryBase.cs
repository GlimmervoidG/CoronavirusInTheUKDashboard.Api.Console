using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries
{
    public abstract class QueryBase
    {
        public DateTime TargetDate { get; set; }
    }
}
