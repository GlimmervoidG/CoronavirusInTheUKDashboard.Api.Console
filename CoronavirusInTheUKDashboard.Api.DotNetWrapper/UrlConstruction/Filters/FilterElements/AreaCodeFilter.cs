using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Filters.FilterElements
{
    public class AreaCodeFilter : FilterPart
    {
        public static AreaCodeFilter Create(string areaCode)
        {
            return new AreaCodeFilter() { Value = areaCode };
        }
        public override string ToString()
        {
            return $"{FilterMetrics.areaCode}={Value}";
        }
    }
}
