using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records
{
    public abstract class BaseSimpleRecord : BaseRecord
    {
        public bool IsLowDay { get; set; }
    }
}
