using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts
{
    public class MainPostModel : PostModel
    {
        public TitleResult Title { get; set; }
        public Result<StandardRecord> DailyResult { get; set; }

        public Result<StandardRecord> LookbackResult { get; set; }
        public Result<StandardRecord> LookbackNationalResult { get; set; }

        public Result<StandardRecord> LookbackWeekendNationalResult { get; set; }

        public Result<RecordGroup> LookbackCatchUpResult { get; set; }
        public Result<StandardRecord> LookbackCatchUpNationalResult { get; set; }

        public Result<IrregularRecord> NoneDailyQueryResult { get; set; }

        public List<QueryRecord> ArchiveInformation { get; set; }

    }
}
