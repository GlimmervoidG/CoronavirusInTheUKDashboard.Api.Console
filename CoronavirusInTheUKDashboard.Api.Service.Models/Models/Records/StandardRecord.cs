using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records
{
    public class StandardRecord : BaseRecord
    {
        public long? Daily { get; set; }
        public long? Cumulative { get; set; }
    }
}
