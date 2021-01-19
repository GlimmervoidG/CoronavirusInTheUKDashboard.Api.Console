using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Queries
{
    public class WebDashboardException : Exception
    {

        public string Url { get; set; }
        public int StatusCode { get; set; }
        public string Responce { get; set; }

        public override string ToString()
        {
            return $"Request ({Url}) failed ({StatusCode}) on, with error: {Responce}";
        }
    }
}
