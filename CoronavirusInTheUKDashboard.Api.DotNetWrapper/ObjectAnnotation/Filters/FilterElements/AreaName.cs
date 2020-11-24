using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters
{
    public class AreaName
    {
        public AreaName(string customTarget)
        {
            Value = customTarget;
        }

        public string Value { get; }
    }
}
