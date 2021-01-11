using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records.Ages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.AdmissionsByAge
{
    public interface IAdmissionsByAgeQueryTransformer : IQueryTransformer<AdmissionsByAgeRecord> 
    {
    }
}
