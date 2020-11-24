using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records
{
    public abstract class BaseRecord
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
