using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records
{
    public class RegionProgressRecord : BaseRecord
    {
        public long? Total { get; set; }
        public long? DailyIncrease { get; set; }
        public double? PercentageProgress { get; set; }
        public double? Increase { get; set; }
    }
}