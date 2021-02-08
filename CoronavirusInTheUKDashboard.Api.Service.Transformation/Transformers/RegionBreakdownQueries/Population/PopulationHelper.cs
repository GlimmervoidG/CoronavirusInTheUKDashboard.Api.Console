using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries.Population
{
    public static class PopulationHelper
    {

        public static List<Region> GetAllAsRegionList(){
           
            // date from Population estimates for the UK, England and Wales, Scotland and Northern Ireland: mid-2019, using April 2020 local authority district codes

            var list = new List<Region>();

            list.Add(new Region() { Name = "United Kingdom", Population = 66796807, AdultPopulation = 52673433, RegionType = RegionType.Overview });
 
            list.Add(new Region() { Name = "England", Population           = 56286961, AdultPopulation = 44263393,  RegionType = RegionType.HomeNation });
            list.Add(new Region() { Name = "Scotland", Population           = 5463300, AdultPopulation = 4434138,   RegionType = RegionType.HomeNation });
            list.Add(new Region() { Name = "Wales", Population              = 3152879, AdultPopulation = 2522940, RegionType = RegionType.HomeNation });
            list.Add(new Region() { Name = "Northern Ireland", Population   = 1893667, AdultPopulation = 1452962, RegionType = RegionType.HomeNation });

            list.Add(new Region() { Name = "East Midlands", Population = 4835928, AdultPopulation = 3833279, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "East of England", Population = 6236072, AdultPopulation = 4889615, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "London", Population = 8961989, AdultPopulation = 6929562,  RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "North East", Population = 2669941, AdultPopulation = 2137884, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "North West", Population = 7341196, AdultPopulation = 5777736, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "South East", Population = 9180135, AdultPopulation = 7210838, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "South West", Population = 5624696, AdultPopulation = 4517219, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "West Midlands", Population = 5934037, AdultPopulation = 4634234, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "Yorkshire and The Humber", Population = 5502967, AdultPopulation = 4333026, RegionType = RegionType.EnglishRegion });

            return list;
        }
    
    }
}
