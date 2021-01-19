using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records
{
    public class RecordGroup : BaseRecord
    {
        public List<StandardRecord> Records { get; set; } 
    }
}
