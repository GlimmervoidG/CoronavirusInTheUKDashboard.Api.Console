using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackJustVaccineQueries
{
    public class LookbackCatchUpDoseFirstModel
    {
        [StructureMetric(StructureMetrics.newPeopleVaccinatedFirstDoseByPublishDate)]
        public long? Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedFirstDoseByPublishDate)]
        public long? Cumulative { get; set; }
    }
}
