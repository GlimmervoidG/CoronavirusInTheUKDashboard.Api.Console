using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackQueries
{
    public class LookbacEnglandQueryLfdTestsModel
    {
        [StructureMetric("newLFDTests")]
        public long? Daily { get; set; }

        [StructureMetric("cumLFDTests")]
        public long? Cumulative { get; set; }
    }
}
