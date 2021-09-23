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
        /// <summary>
        /// Inclusive min age for this population segment.
        /// </summary>
        public int MinAge { get; set; }

        /// <summary>
        /// Inclusive max age for this population segment.
        /// </summary>
        public int MaxAge { get; set; } 
        public long Population { get; set; }

    }
}
