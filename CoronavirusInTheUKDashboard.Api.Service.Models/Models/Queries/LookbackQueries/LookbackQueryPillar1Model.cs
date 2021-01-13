using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackQueries
{
    public class LookbackQueryPillar1Model
    {
        [StructureMetric(StructureMetrics.newPillarOneTestsByPublishDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPillarOneTestsByPublishDate)]
        public long? Cumulative { get; set; }
    }
}
