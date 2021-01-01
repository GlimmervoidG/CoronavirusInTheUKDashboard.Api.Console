using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records.Ages
{
    public class AdmissionsByAgeItemRecord
    {
        public string AgeRange { get; set; }
        public double Rate { get; set; }
        public double Cumulative { get; set; }
        public double New { get; set; }
    }
}
