using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackQueries
{
    public class LookbackQueryModel : BaseModel
    {

        [StructureMetric(StructureMetrics.date)]
        public DateTime Date { get; set; }

        [StructureMetric(StructureMetrics.areaName)]
        public string Name { get; set; }

        [StructureMetric(StructureMetrics.areaCode)]
        public string Code { get; set; }

        [Structure]
        public LookbackQueryPillar1Model Pillar1 { get; set; }
        [Structure]
        public LookbackQueryPillar2Model Pillar2 { get; set; }
        [Structure]
        public LookbackQueryPillar3Model Pillar3 { get; set; }
        [Structure]
        public LookbackQueryPillar4Model Pillar4 { get; set; }
        [Structure]
        public LookbackQueryPcrTestsModel PcrTests { get; set; }
        [Structure]
        public LookbackQueryAllTestsModel PillarAll { get; set; }

    }
}
