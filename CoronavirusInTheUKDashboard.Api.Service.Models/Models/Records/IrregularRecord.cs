using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records
{
    public class IrregularRecord : BaseRecord
    {
        public long? LastReportedTotal { get; set; }

        public bool IsNew { get; set; }

    }
}
