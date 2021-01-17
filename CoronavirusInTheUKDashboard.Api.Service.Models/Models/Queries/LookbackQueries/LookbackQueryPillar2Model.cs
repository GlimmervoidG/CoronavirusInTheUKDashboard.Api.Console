using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackQueries
{
    public class LookbackQueryPillar2Model
    {
        [StructureMetric(StructureMetrics.newPillarTwoTestsByPublishDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPillarTwoTestsByPublishDate)]
        public long? Cumulative { get; set; }
    }
}
