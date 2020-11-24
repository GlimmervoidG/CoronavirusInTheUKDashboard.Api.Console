using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.Models.LookbackTestingQueries
{
    public class LookbackTestingQueryAllTestsModel
    {
        [StructureMetric(StructureMetrics.newTestsByPublishDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumTestsByPublishDate)]
        public long? Cumulative { get; set; }
    }
}
