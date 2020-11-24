using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements
{
    public class DateFilter
    {
        public DateFilter(DateTime customTarget)
        {
            Value = $"{customTarget:yyyy-MM-dd}"; 
        }

        public string Value { get; }
    }
}
