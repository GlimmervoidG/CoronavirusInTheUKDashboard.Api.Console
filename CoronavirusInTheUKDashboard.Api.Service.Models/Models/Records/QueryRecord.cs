using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records
{
    public class QueryRecord
    {
        public string Name { get; set; }
        public DateTime ArchiveDate { get; set; }
        public string Url { get; set; }
        public string ArchiveUrl { get; set; }

    }
}
