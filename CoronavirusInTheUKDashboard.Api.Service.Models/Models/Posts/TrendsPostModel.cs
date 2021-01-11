using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models
{
    public class TrendsPostModel : PostModel
    { 
        public SummationResult EightDayLookback { get; set; }
        public Result<RegionRateRecord> OverviewRates { get; set; }
        public Result<RegionRateRecord> NationalRates { get; set; }
        public Result<RegionRateRecord> RegionRates { get; set; }
        public List<QueryRecord> ArchiveInformation { get; set; }
    }
}
