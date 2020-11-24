using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Examples
{
    public class DailyStatDeathsQuery
    {
        [StructureMetric(StructureMetrics.newDeaths28DaysByPublishDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumDeaths28DaysByPublishDate)]
        public long? Cumulative { get; set; }
    }
}
