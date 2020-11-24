using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Filters
{
    public abstract class FilterPart : ApiRequestPart
    {
        public string Value { get; set; }
    }
}
