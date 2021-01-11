using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.DailyQueries
{
    public class DailyQueriesSecondDose
    {
        public long? Daily { get; set; }

        [StructureMetric("cumPeopleVaccinatedSecondDoseByPublishDate")]
        public long? Cumulative { get; set; }
    }
}
