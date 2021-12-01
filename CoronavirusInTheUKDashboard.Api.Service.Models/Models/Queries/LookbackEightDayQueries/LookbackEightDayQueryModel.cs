using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEightDayQueries
{
    public class LookbackEightDayQueryModel : BaseModel
    {

        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }

        //[Structure]
        //public LookbackEightDayQueryVirusTestsModel VirusTests { get; set; }
         
        [StructureMetric(StructureMetrics.newVirusTestsByPublishDate)]
        public long? VirusTests_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumVirusTestsByPublishDate)]
        public long? VirusTests_Cumulative { get; set; }


        //[Structure]
        //public LookbackEightDayQueryDeathsModel Deaths { get; set; }

        [StructureMetric(StructureMetrics.newDeaths28DaysByPublishDate)]
        public long? Deaths_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumDeaths28DaysByPublishDate)]
        public long? Deaths_Cumulative { get; set; }


        [StructureMetric(StructureMetrics.newCasesByPublishDate)]
        public long? Cases_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumCasesByPublishDate)]
        public long? Cases_Cumulative { get; set; }

        [StructureMetric(StructureMetrics.newPeopleVaccinatedFirstDoseByPublishDate)]
        public long? FirstDoses_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedFirstDoseByPublishDate)]
        public long? FirstDoses_Cumulative { get; set; }

        [StructureMetric(StructureMetrics.newPeopleVaccinatedSecondDoseByPublishDate)]
        public long? SecondDoses_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedSecondDoseByPublishDate)]
        public long? SecondDoses_Cumulative { get; set; } 

        [StructureMetric(StructureMetrics.newPeopleVaccinatedThirdInjectionByPublishDate)]
        public long? ThirdDoses_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPeopleVaccinatedThirdInjectionByPublishDate)]
        public long? ThirdDoses_Cumulative { get; set; }

        [StructureMetric(StructureMetrics.newVaccinesGivenByPublishDate)]
        public long? TotalDoses_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumVaccinesGivenByPublishDate)]
        public long? TotalDoses_Cumulative { get; set; }



    }
}
