using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response
{
    public class Pagination
    {
        public string Current { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}
