using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.Models.LookbackLfdTestingQueries
{
    public class LookbackLfdTestingQueryLfdTestsModel
    {
        [StructureMetric("newLFDTests")]
        public long? Daily { get; set; }

        [StructureMetric("cumLFDTests")]
        public long? Cumulative { get; set; }
    }
}
