using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.NonDailyQueries
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


        [StructureMetric(StructureMetrics.plannedPCRCapacityByPublishDate)]
        public long? CapacityPCR { get; set; }


        [StructureMetric(StructureMetrics.hospitalCases)]
        public long? PatientsInHospital { get; set; }


        [StructureMetric(StructureMetrics.covidOccupiedMVBeds)]
        public long? PatientsInVentilatorBeds { get; set; }


        [StructureMetric(StructureMetrics.cumAdmissions)]
        public long? PatientsAdmitted { get; set; }


        [StructureMetric(StructureMetrics.newOnsDeathsByRegistrationDate)]
        public long? WeeklyOnsDeaths { get; set; }

        [StructureMetric(StructureMetrics.cumOnsDeathsByRegistrationDate)]
        public long? TotalOnsDeaths { get; set; }

        [StructureMetric(StructureMetrics.weeklyPeopleVaccinatedFirstDoseByVaccinationDate)]
        public long? WeeklyFirstDose { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedFirstDoseByVaccinationDate)]
        public long? TotalFirstDose { get; set; }

        [StructureMetric(StructureMetrics.weeklyPeopleVaccinatedSecondDoseByVaccinationDate)]
        public long? WeeklySecondDose { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedSecondDoseByVaccinationDate)]
        public long? TotalSecondDose { get; set; }

    }
}
