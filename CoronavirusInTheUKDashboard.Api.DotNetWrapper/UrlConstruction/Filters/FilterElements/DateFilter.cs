using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Filters.FilterElements
{
    public class DateFilter : FilterPart
    {
        public static AreaTypeFilter Create(DateTime date)
        {
            return new AreaTypeFilter() { Value = $"{date:yyyy-MM-dd}" };
        }

        public override string ToString()
        {
            return $"{FilterMetrics.date}={Value}";
        }
    }
}
