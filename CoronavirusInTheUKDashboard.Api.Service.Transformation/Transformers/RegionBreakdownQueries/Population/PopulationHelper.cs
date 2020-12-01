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

            list.Add(new Region() { Name = "United Kingdom", Population = 66796807, RegionType = RegionType.Overview });
 
            list.Add(new Region() { Name = "England", Population           = 56286961, RegionType = RegionType.HomeNation });
            list.Add(new Region() { Name = "Scotland", Population           = 5463300, RegionType = RegionType.HomeNation });
            list.Add(new Region() { Name = "Wales", Population              = 3152879, RegionType = RegionType.HomeNation });
            list.Add(new Region() { Name = "Northern Ireland", Population   = 1893667, RegionType = RegionType.HomeNation });

            list.Add(new Region() { Name = "East Midlands", Population = 4835928, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "East of England", Population = 6236072, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "London", Population = 8961989, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "North East", Population = 2669941, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "North West", Population = 7341196, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "South East", Population = 9180135, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "South West", Population = 5624696, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "West Midlands", Population = 5934037, RegionType = RegionType.EnglishRegion });
            list.Add(new Region() { Name = "Yorkshire and The Humber", Population = 5502967, RegionType = RegionType.EnglishRegion });

            return list;
        }
    
    }
}
