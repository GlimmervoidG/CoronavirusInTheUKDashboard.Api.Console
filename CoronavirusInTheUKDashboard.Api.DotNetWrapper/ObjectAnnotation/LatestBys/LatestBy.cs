using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.LatestBys
{
    public class LatestBy
    {
        public LatestBy(StructureMetrics target)
        {
            Value = target.ToString();
        }
        public LatestBy(string customTarget)
        {
            Value = customTarget;
        }

        public string Value { get; }
    }
}
