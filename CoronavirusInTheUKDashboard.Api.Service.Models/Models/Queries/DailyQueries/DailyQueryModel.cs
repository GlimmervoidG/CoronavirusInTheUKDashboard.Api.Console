using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.DailyQueries
{
    public class DailyQueryModel : BaseModel
    {

        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }

        //[Structure]
        //public DailyQueryCasesModel Cases { get; set; }


        [StructureMetric(StructureMetrics.newCasesByPublishDate)]
        public long? Cases_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumCasesByPublishDate)]
        public long? Cases_Cumulative { get; set; } 

        //[Structure]
        //    public DailyQueryDeathsModel Deaths { get; set; }

        [StructureMetric(StructureMetrics.newDeaths28DaysByPublishDate)]
        public long? Deaths_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumDeaths28DaysByPublishDate)]
        public long? Deaths_Cumulative { get; set; }

    }
}
