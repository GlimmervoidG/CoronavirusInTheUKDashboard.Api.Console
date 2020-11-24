using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters
{
    public class Filter
    {
        public AreaType AreaType { get; set; }
        public AreaName AreaName { get; set; }
        public AreaCode AreaCode { get; set; }
        public DateFilter Date { get; set; }

    }
}
