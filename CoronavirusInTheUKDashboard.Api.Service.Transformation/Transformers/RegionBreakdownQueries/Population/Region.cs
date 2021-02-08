using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries.Population;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries.Population
{
    public class Region
    {
        public double Population { get; set; }
        public double AdultPopulation { get; set; }
        public string Name { get; set; }

        public RegionType RegionType { get; set; }
    }
}
