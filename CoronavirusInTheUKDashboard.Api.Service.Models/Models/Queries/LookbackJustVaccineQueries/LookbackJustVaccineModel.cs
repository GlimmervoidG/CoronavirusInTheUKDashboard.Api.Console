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


        [Structure]
        public LookbackCatchUpDoseFirstModel FirstDose { get; set; }

        [Structure]
        public LookbackCatchUpDoseSecondModel SecondDose { get; set; }
    }
}
