using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.Models.LookbackTestingQueries
{
    public class LookbackTestingQueryPillar1Model
    {
        [StructureMetric(StructureMetrics.newPillarOneTestsByPublishDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPillarOneTestsByPublishDate)]
        public long? Cumulative { get; set; }
    }
}
