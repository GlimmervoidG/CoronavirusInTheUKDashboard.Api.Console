using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEightDayQueries
{
    public class LookbackEightDayQueryTotalDosesModel
    {
        [StructureMetric("newVaccinesGivenByPublishDate")]
        public long? Daily { get; set; }

        [StructureMetric("cumVaccinesGivenByPublishDate")]
        public long? Cumulative { get; set; }
    }
}
