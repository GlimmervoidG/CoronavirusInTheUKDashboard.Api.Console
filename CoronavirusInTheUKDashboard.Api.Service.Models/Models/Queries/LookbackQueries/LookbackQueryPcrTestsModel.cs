using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackQueries
{
    public class LookbackQueryPcrTestsModel
    {
        [StructureMetric("newPCRTestsByPublishDate")]
        public long? Daily { get; set; }

        [StructureMetric("cumPCRTestsByPublishDate")]
        public long? Cumulative { get; set; }
    }
}
