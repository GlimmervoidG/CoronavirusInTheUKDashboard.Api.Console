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

        [StructureMetric("newVirusTests")]
        public long? VirusTests_Daily { get; set; }

        [StructureMetric("cumVirusTests")]
        public long? VirusTests_Cumulative { get; set; }


        //[Structure]
        //public LookbackEightDayQueryDeathsModel Deaths { get; set; }

        [StructureMetric(StructureMetrics.newDeaths28DaysByPublishDate)]
        public long? Deaths_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumDeaths28DaysByPublishDate)]
        public long? Deaths_Cumulative { get; set; }


        //[Structure]
        //public LookbackEightDayQueryCasesModel Cases { get; set; }

        [StructureMetric(StructureMetrics.newCasesByPublishDate)]
        public long? Cases_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumCasesByPublishDate)]
        public long? Cases_Cumulative { get; set; }

        //[Structure]
        //public LookbackEightDayQueryFirstDoseModel FirstDoses { get; set; }
        [StructureMetric("newPeopleVaccinatedFirstDoseByPublishDate")]
        public long? FirstDoses_Daily { get; set; }

        [StructureMetric("cumPeopleVaccinatedFirstDoseByPublishDate")]
        public long? FirstDoses_Cumulative { get; set; }

        //[Structure]
        //public LookbackEightDayQuerySecondDoseModel SecondDoses { get; set; }

        [StructureMetric("newPeopleVaccinatedSecondDoseByPublishDate")]
        public long? SecondDoses_Daily { get; set; }

        [StructureMetric("cumPeopleVaccinatedSecondDoseByPublishDate")]
        public long? SecondDoses_Cumulative { get; set; }

        //[Structure]
        //public LookbackEightDayQueryTotalDosesModel TotalDoses { get; set; }

        [StructureMetric("newVaccinesGivenByPublishDate")]
        public long? TotalDoses_Daily { get; set; }

        [StructureMetric("cumVaccinesGivenByPublishDate")]
        public long? TotalDoses_Cumulative { get; set; }



    }
}
