using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records
{
    public class RegionRateRecord : BaseRecord
    {
        public long? Daily { get; set; }
        public long? Delta { get; set; }
        public double? Rate { get; set; }

    }
}
