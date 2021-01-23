using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackJustVaccineQueries
{
    public class LookbackCatchUpDoseSecondModel
    {
        [StructureMetric("newPeopleVaccinatedSecondDoseByPublishDate")]
        public long? Daily { get; set; }

        [StructureMetric("cumPeopleVaccinatedSecondDoseByPublishDate")]
        public long? Cumulative { get; set; }
    }
}
