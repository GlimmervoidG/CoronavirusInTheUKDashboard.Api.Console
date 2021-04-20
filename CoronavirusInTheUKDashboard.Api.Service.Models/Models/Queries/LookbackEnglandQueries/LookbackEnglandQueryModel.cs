using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEnglandQueries
{
    public class LookbackEnglandQueryModel : BaseModel
    {

        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }

        //[Structure]
        //public LookbacEnglandQueryLfdTestsModel LfdTests { get; set; }

        [StructureMetric("newLFDTests")]
        public long? LfdTests_Daily { get; set; }

        [StructureMetric("cumLFDTests")]
        public long? LfdTests_Cumulative { get; set; }


    }
}
