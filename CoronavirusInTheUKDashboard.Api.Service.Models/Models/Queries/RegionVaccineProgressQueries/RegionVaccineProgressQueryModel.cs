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

        [StructureMetric(StructureMetrics.newPeopleVaccinatedFirstDoseByPublishDate)]
        public long? FirstDoseNew { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedFirstDoseByPublishDate)]
        public long? FirstDoseCum { get; set; }

        [StructureMetric(StructureMetrics.newPeopleVaccinatedSecondDoseByPublishDate)]
        public long? SecondDoseNew { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedSecondDoseByPublishDate)]
        public long? SecondDoseCum { get; set; }

        [StructureMetric(StructureMetrics.newPeopleVaccinatedThirdInjectionByPublishDate)]
        public long? ThirdDoseNew { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedThirdInjectionByPublishDate)]
        public long? ThirdDoseCum { get; set; }

    }
}
