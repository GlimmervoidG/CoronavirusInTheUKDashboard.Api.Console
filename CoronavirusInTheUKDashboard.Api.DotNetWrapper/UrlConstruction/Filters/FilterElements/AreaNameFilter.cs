using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Filters.FilterElements
{
    public class AreaNameFilter : FilterPart
    {
        public static AreaNameFilter Create(string areaName)
        {
            return new AreaNameFilter() { Value = areaName };
        }
        public override string ToString()
        {
            return $"{FilterMetrics.areaName}={Value}";
        }
    }
}
