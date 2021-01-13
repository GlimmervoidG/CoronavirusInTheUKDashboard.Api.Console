using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackQueries
{
    public class LookbackQueryAllTestsModel
    {
        [StructureMetric(StructureMetrics.newTestsByPublishDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumTestsByPublishDate)]
        public long? Cumulative { get; set; }
    }
}
