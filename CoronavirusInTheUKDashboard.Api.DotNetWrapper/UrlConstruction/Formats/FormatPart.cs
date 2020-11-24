using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Formats
{
    public class FormatPart : ApiRequestPart
    {
        public static FormatPart Create(FormatOptions type)
        {
            return new FormatPart() { Type = type.ToString() };
        }

        public string Type { get; set; } = FormatOptions.json.ToString();
        public override string ToString()
        { 
            return $"format={Type}";
        }
    }
}
