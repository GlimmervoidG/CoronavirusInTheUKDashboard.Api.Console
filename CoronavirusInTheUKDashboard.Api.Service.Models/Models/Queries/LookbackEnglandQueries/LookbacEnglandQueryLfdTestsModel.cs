using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEnglandQueries
{
    public class LookbacEnglandQueryLfdTestsModel
    {
        [StructureMetric(StructureMetrics.newLFDTestsBySpecimenDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumLFDTestsBySpecimenDate)]
        public long? Cumulative { get; set; }
    }
}
