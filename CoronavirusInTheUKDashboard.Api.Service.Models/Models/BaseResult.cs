using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models
{
    public abstract class BaseResult
    {
        public List<QueryRecord> QueryRecords { get; set; }
    }
}
