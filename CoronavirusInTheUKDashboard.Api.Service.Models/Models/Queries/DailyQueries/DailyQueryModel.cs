using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.DailyQueries
{
    public class DailyQueryModel : BaseModel
    { 
        
        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }

        [Structure]
        public DailyQueryCasesModel Cases { get; set; }

        [Structure]
        public DailyQueryDeathsModel Deaths { get; set; }

        [Structure]
        public DailyQueriesFirstDose FirstDose { get; set; }

        [Structure]
        public DailyQueriesSecondDose SecondDose { get; set; }

    }
}
