using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records.Ages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models
{
    public class AdmissionsByAgeModel
    {
        public DateTime SearchDate { get; set; } 
        public Result<AdmissionsByAgeRecord> AdmissionsByAge { get; set; } 
    }
}
