using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEightDayQueries
{
    public class LookbackEightDayQueryFirstDoseModel
    {
        [StructureMetric("newPeopleVaccinatedFirstDoseByPublishDate")]
        public long? Daily { get; set; }

        [StructureMetric("cumPeopleVaccinatedFirstDoseByPublishDate")]
        public long? Cumulative { get; set; }
    }
}
