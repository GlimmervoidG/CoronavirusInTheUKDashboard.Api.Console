using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace UkOnsPopulationEstimatesUnofficial.Model
{
    /// <summary>
    /// An Area of the country, which has population assoicated with it.
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Unique code assoicated with the area. Codes should be used to uniquely identify an area.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Common name of the Area.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of Area.
        /// </summary>
        public AreaType Type { get; set; } 

        /// <summary>
        /// Gets the name of the Area sutible for displaying.
        /// </summary>
        /// <returns></returns>
        public string DisplayName()
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Name.ToLower());  
        }
         
        /// <summary>
        /// Contains a list of non overlapping population segments that sum to the total population of the Area.
        /// </summary>
        public List<PopulationCount> Population { get; set;} = new List<PopulationCount>();

        /// <summary>
        /// Full population of Area.
        /// </summary>
        /// <returns></returns>
        public long TotalPopulation()
        {
            return Population.Sum(p => p.Population);
        }

        /// <summary>
        /// Adult (18+) population of an Area.
        /// </summary>
        /// <returns></returns>
        public long AdultPopulation()
        {
            return Population.Where(p=>p.MinAge >= 18).Sum(p => p.Population);
        }

        /// <summary>
        /// Young adult and up (16+) population of an Area.
        /// </summary>
        /// <returns></returns>
        public long SixteenOrMorePopulation()
        {
            return Population.Where(p => p.MinAge >= 16).Sum(p => p.Population);
        }

        /// <summary>
        /// 12+ population of an Area.
        /// </summary>
        /// <returns></returns>
        public long TwelveOrMorePopulation()
        {
            return Population.Where(p => p.MinAge >= 16).Sum(p => p.Population);
        }
    }
}
