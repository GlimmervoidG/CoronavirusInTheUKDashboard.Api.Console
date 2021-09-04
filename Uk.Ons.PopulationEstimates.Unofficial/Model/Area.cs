using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace Uk.Ons.PopulationEstimates.Unofficial.Model
{
    public class Area
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public AreaType Type { get; set; } 

        public string DisplayName()
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Name.ToLower());  
        }
         
        public List<PopulationCount> Population { get; set;} = new List<PopulationCount>();

        public long TotalPopulation()
        {
            return Population.Sum(p => p.Population);
        }
        public long AdultPopulation()
        {
            return Population.Where(p=>p.MinAge >= 18).Sum(p => p.Population);
        }
        public long SixteenOrMorePopulation()
        {
            return Population.Where(p => p.MinAge >= 16).Sum(p => p.Population);
        }
        public long TwelveOrMorePopulation()
        {
            return Population.Where(p => p.MinAge >= 16).Sum(p => p.Population);
        }
    }
}
