using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response
{
    public class QueryResponce<G>
    {
        public string Url { get; set; }
        public long Length { get; set; }
        public long MaxPageLimit { get; set; }

        public List<G> Data { get; set; }
        public Pagination Pagination { get; set; }
 
    }
}
