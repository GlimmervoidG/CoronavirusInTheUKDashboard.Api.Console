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

        //[Structure]
        //public LookbackQueryPillar1Model Pillar1 { get; set; }

        [StructureMetric(StructureMetrics.newPillarOneTestsByPublishDate)]
        public long? Pillar1_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPillarOneTestsByPublishDate)]
        public long? Pillar1_Cumulative { get; set; }

        //[Structure]
        //public LookbackQueryPillar2Model Pillar2 { get; set; }

        [StructureMetric(StructureMetrics.newPillarTwoTestsByPublishDate)]
        public long? Pillar2_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPillarTwoTestsByPublishDate)]
        public long? Pillar2_Cumulative { get; set; }


        //[Structure]
        //public LookbackQueryPillar3Model Pillar3 { get; set; }

        [StructureMetric(StructureMetrics.newPillarThreeTestsByPublishDate)]
        public long? Pillar3_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPillarThreeTestsByPublishDate)]
        public long? Pillar3_Cumulative { get; set; }

        //[Structure]
        //public LookbackQueryPillar4Model Pillar4 { get; set; }

        [StructureMetric(StructureMetrics.newPillarFourTestsByPublishDate)]
        public long? Pillar4_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumPillarFourTestsByPublishDate)]
        public long? Pillar4_Cumulative { get; set; }

        //[Structure]
        //public LookbackQueryPcrTestsModel PcrTests { get; set; }

        [StructureMetric("newPCRTestsByPublishDate")]
        public long? PcrTests_Daily { get; set; }

        [StructureMetric("cumPCRTestsByPublishDate")]
        public long? PcrTests_Cumulative { get; set; }

        //[Structure]
        //public LookbackQueryAllTestsModel PillarAll { get; set; }

        [StructureMetric(StructureMetrics.newTestsByPublishDate)]
        public long? PillarAll_Daily { get; set; }

        [StructureMetric(StructureMetrics.cumTestsByPublishDate)]
        public long? PillarAll_Cumulative { get; set; }

    }
}
