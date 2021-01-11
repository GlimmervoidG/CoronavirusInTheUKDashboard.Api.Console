using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models
{
    public class TitleResult : BaseRecord
    {
        public SimpleRecord TotalCases { get; set; }
        public SimpleRecord TotalDeaths { get; set; }
    }
}
