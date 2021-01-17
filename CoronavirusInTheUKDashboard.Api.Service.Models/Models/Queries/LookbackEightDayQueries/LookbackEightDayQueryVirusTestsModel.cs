using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEightDayQueries
{
    public class LookbackEightDayQueryVirusTestsModel
    {
        [StructureMetric("newVirusTests")]
        public long? Daily { get; set; }

        [StructureMetric("cumVirusTests")]
        public long? Cumulative { get; set; }
    }
}
