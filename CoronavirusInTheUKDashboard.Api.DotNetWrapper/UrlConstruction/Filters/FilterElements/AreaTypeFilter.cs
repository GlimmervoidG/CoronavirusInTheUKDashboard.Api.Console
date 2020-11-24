using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Filters.FilterElements
{
    public class AreaTypeFilter : FilterPart
    {

        public static AreaTypeFilter Create(AreaTypeMetrics metric)
        {
            return new AreaTypeFilter() { Value = metric.ToString() };
        } 
         
        public override string ToString()
        {
            return $"{FilterMetrics.areaType}={Value}"; 
        }
    }
}
