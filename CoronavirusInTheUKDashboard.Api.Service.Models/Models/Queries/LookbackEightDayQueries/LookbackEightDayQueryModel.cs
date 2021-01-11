using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackEightDayQueries
{
    public class LookbackEightDayQueryModel : BaseModel
    {

        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }

        [Structure]
        public LookbackEightDayQueryVirusTestsModel VirusTests { get; set; }
        [Structure]
        public LookbackEightDayQueryDeathsModel Deaths { get; set; }

        [Structure]
        public LookbackEightDayQueryCasesModel Cases { get; set; }

        

    }
}
