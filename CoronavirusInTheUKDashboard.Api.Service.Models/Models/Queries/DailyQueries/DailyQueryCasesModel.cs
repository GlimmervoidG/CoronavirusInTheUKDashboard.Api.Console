using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.DailyQueries
{
    public class DailyQueryCasesModel
    {
        [StructureMetric(StructureMetrics.newCasesByPublishDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumCasesByPublishDate)]
        public long? Cumulative { get; set; } 
    }
}
