using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models
{
    public class MainPostModel : PostModel
    { 
        public TitleResult Title { get; set; }
        public Result<StandardRecord> DailyResult { get; set; }

        public Result<StandardRecord> LookbackResult { get; set; }
        public Result<StandardRecord> LookbackEnglandResult { get; set; }

        public Result<StandardRecord> LookbackWeekendResult { get; set; }
        public Result<StandardRecord> LookbackWeekendEnglandResult { get; set; }

        public Result<IrregularRecord> NoneDailyQueryResult { get; set; }

        public List<QueryRecord> ArchiveInformation { get; set; }

    }
}
