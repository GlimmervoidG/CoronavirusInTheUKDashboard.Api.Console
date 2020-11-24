using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.LatestBys
{
   public class LatestBy : ApiRequestPart
    {
        public static LatestBy Create(StructureMetrics metric)
        {
            return new LatestBy() { Metric = metric.ToString() };
        }
        public static LatestBy Create(string customTarget)
        {
            return new LatestBy() { Metric = customTarget };
        }

        public string Metric { get; set; }


        public override string ToString()
        {
            return $"latestBy={Metric}";
        }
    }
}
