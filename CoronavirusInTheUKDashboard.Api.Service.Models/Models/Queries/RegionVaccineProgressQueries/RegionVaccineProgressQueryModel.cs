using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionVaccineProgressQueries
{
    public class RegionVaccineProgressQueryModel : BaseModel
    {

        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }

        [StructureMetric("newPeopleVaccinatedFirstDoseByPublishDate")]
        public long? FirstDoseNew { get; set; }

        [StructureMetric("cumPeopleVaccinatedFirstDoseByPublishDate")]
        public long? FirstDoseCum { get; set; }

        [StructureMetric("newPeopleVaccinatedSecondDoseByPublishDate")]
        public long? SecondDoseNew { get; set; }

        [StructureMetric("cumPeopleVaccinatedSecondDoseByPublishDate")]
        public long? SecondDoseCum { get; set; }

        [StructureMetric("newPeopleVaccinatedThirdInjectionByPublishDate")]
        public long? ThirdDoseNew { get; set; }

        [StructureMetric("cumPeopleVaccinatedThirdInjectionByPublishDate")]
        public long? ThirdDoseCum { get; set; }

    }
}
