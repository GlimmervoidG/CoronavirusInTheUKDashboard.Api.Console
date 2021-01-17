using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records.Ages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts
{
    public class AdmissionsByAgePostModel : PostModel
    {
        public Result<AdmissionsByAgeRecord> AdmissionsByAge { get; set; }
        public List<QueryRecord> ArchiveInformation { get; set; }
    }
}
