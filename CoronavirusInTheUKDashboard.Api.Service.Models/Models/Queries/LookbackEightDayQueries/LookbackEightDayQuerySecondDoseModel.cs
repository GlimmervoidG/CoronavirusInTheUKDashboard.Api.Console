using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEightDayQueries
{
    public class LookbackEightDayQuerySecondDoseModel
    {
        [StructureMetric(StructureMetrics.newPeopleVaccinatedSecondDoseByPublishDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedSecondDoseByPublishDate)]
        public long? Cumulative { get; set; }
    }
}
