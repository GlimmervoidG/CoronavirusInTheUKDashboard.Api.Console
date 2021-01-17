using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers
{
    public interface IArchiveTransformer
    {
        public DateTime ArchiveDate { get; set; }
        void QueryAndTransform(List<QueryRecord> records);
    }
}
