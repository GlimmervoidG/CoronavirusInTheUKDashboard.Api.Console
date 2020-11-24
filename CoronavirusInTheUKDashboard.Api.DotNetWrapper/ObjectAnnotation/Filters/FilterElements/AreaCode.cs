using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters.FilterElements
{
    public class AreaCode
    {
        public AreaCode(string customTarget)
        {
            Value = customTarget;
        }

        public string Value { get; }
    }
}
