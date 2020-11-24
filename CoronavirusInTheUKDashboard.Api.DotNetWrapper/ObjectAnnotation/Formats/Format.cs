using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Formats
{
    public class Format
    {
        public Format(FormatOptions target)
        {
            Value = target.ToString();
        }
        public Format(string customTarget)
        {
            Value = customTarget;
        }

        public string Value { get; }
    }
}
