using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackQueries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackJustVaccineQueries
{
    public class LookbackJustVaccineModel : BaseModel
    {
        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }
         
        [StructureMetric(StructureMetrics.newPeopleVaccinatedFirstDoseByPublishDate)]
        public long? FirstDose_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedFirstDoseByPublishDate)]
        public long? FirstDose_Cumulative { get; set; }
         

        [StructureMetric(StructureMetrics.newPeopleVaccinatedSecondDoseByPublishDate)]
        public long? SecondDose_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedSecondDoseByPublishDate)]
        public long? SecondDose_Cumulative { get; set; }

        [StructureMetric(StructureMetrics.newPeopleVaccinatedThirdInjectionByPublishDate)]
        public long? ThirdDose_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedThirdInjectionByPublishDate)]
        public long? ThirdDose_Cumulative { get; set; }
    }
}
