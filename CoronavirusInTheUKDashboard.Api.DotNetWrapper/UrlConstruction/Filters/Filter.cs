using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Filters
{
    public class Filter : ApiRequestPart
    {
        public static Filter Create()
        {
            return new Filter();
        }

        public List<FilterPart> Parts { get; set; } = new List<FilterPart>();

        public override string ToString()
        {

           return $"filters={string.Join(";", Parts)}"; 
        }
    }
}
