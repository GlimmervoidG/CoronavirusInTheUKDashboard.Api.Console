using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters
{
    public class AreaType
    {
        public AreaType(AreaTypeMetrics target)
        {
            Value = target.ToString();
        }
        public AreaType(string customTarget)
        {
            Value = customTarget;
        }

        public string Value { get; }
    }
}
