using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Structure
{
    public class StructureMetric : StructurePart
    {
        public static StructureMetric Create(string name, StructureMetrics metric)
        {
            return new StructureMetric() { Name = name, Metric = metric.ToString() };
        }
        public static StructureMetric Create(string name, string customTarget )
        {
            return new StructureMetric() { Name = name, Metric = customTarget };
        } 

        public string Name { get; set; }
        public string Metric { get; set; }

        public override string ToString()
        {
            var quote = '"';
            return $"{quote}{Name}{quote}:{quote}{Metric}{quote}";
        }
    }
}
