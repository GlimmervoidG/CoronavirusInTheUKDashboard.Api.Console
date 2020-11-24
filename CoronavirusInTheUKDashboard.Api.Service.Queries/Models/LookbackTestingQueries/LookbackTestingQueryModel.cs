using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.Models.LookbackTestingQueries
{
    public class LookbackTestingQueryModel
    {

        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }

        [Structure]
        public LookbackTestingQueryPillar1Model Pillar1 { get; set; }
        [Structure]
        public LookbackTestingQueryPillar2Model Pillar2 { get; set; }
        [Structure]
        public LookbackTestingQueryPillar3Model Pillar3 { get; set; }
        [Structure]
        public LookbackTestingQueryPillar4Model Pillar4 { get; set; }
        [Structure]
        public LookbackTestingQueryPcrTestsModel PcrTests { get; set; }
        [Structure]
        public LookbackTestingQueryAllTestsModel PillarAll { get; set; }
 
    }
}
