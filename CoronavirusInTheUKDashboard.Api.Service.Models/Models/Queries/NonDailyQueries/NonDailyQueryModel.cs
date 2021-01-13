using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.NonDailyQueries
{
    public class NonDailyQueryModel : BaseModel
    { 
        
        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }


        [StructureMetric(StructureMetrics.plannedCapacityByPublishDate)]
        public long? Capacity { get; set; }


        [StructureMetric("plannedPCRCapacityByPublishDate")]
        public long? CapacityPCR { get; set; }


        [StructureMetric(StructureMetrics.hospitalCases)]
        public long? PatientsInHospital { get; set; }


        [StructureMetric(StructureMetrics.covidOccupiedMVBeds)]
        public long? PatientsInVentilatorBeds { get; set; }


        [StructureMetric(StructureMetrics.cumAdmissions)]
        public long? PatientsAdmitted { get; set; }


        [StructureMetric("newOnsDeathsByRegistrationDate")]
        public long? WeeklyOnsDeaths { get; set; }

        [StructureMetric("cumOnsDeathsByRegistrationDate")]
        public long? TotalOnsDeaths { get; set; }

        [StructureMetric("weeklyPeopleVaccinatedFirstDoseByVaccinationDate")]
        public long? WeeklyFirstDose { get; set; }

        [StructureMetric("cumPeopleVaccinatedFirstDoseByVaccinationDate")]
        public long? TotalFirstDose { get; set; }

        [StructureMetric("weeklyPeopleVaccinatedSecondDoseByVaccinationDate")]
        public long? WeeklySecondDose { get; set; }

        [StructureMetric("cumPeopleVaccinatedSecondDoseByVaccinationDate")]
        public long? TotalSecondDose { get; set; }

    }
}
