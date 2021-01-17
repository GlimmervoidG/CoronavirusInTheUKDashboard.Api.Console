using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.AdmissionsQueries
{
    public class AdmissionsByAgeItemModel
    {
        public string Age { get; set; }
        public double Rate { get; set; }
        public long Value { get; set; }
    }
}
