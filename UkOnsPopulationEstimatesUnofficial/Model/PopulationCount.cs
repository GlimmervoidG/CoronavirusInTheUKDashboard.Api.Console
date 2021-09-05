using System;
using System.Collections.Generic;
using System.Text;

namespace UkOnsPopulationEstimatesUnofficial.Model
{
    /// <summary>
    /// A population segement associated with an area.
    /// </summary>
    public class PopulationCount
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; } 
        public long Population { get; set; }

    }
}
