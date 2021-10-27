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
         
        [StructureMetric("newPeopleVaccinatedFirstDoseByPublishDate")]
        public long? FirstDose_Daily { get; set; }

        [StructureMetric("cumPeopleVaccinatedFirstDoseByPublishDate")]
        public long? FirstDose_Cumulative { get; set; }
         

        [StructureMetric("newPeopleVaccinatedSecondDoseByPublishDate")]
        public long? SecondDose_Daily { get; set; }

        [StructureMetric("cumPeopleVaccinatedSecondDoseByPublishDate")]
        public long? SecondDose_Cumulative { get; set; }

        [StructureMetric("newPeopleVaccinatedThirdInjectionByPublishDate")]
        public long? ThirdDose_Daily { get; set; }

        [StructureMetric("cumPeopleVaccinatedThirdInjectionByPublishDate")]
        public long? ThirdDose_Cumulative { get; set; }
    }
}
