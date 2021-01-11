using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Common
{
    public interface IArchiveQuery
    {
        string TargetUrl { get; set; }
        string DoQuery();
    }
}
