using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes
{ 
    [AttributeUsage(AttributeTargets.Property)]
    public class StructureMetricAttribute : Attribute
    {
        public StructureMetricAttribute(StructureMetrics target)
        {
            Metric = target.ToString();
        }

        public StructureMetricAttribute(string customTarget)
        {
            Metric = customTarget;
        }
         
        public string Metric { get; }

    }
}
