using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using UkOnsPopulationEstimatesUnofficial.Helper;
using UkOnsPopulationEstimatesUnofficial.Model;

namespace UkOnsPopulationEstimatesUnofficial
{
    public class PopulationDataSet
    {
        public static PopulationDataSet DataSet(TimeSet timeSet = TimeSet.Newest)
        {
            return new PopulationDataSet(timeSet);
        }


        public List<Area> Areas { get; private set; } = new List<Area>(); 

        public List<Area> UK()
        {
            return Areas.Where(a => a.Type == AreaType.Country &&  a.Code == AreaCodes.UK).ToList();
        }

        public List<Area> HomeNations()
        {
            return Areas.Where(a => a.Type == AreaType.Country &&
            (
                a.Code == AreaCodes.English ||
                a.Code == AreaCodes.Scotland ||
                a.Code == AreaCodes.Wales ||
                a.Code == AreaCodes.NorthernIreland  

            )).ToList();
        }
        public List<Area> EnglishRegions()
        {
            return Areas.Where(a => a.Type == AreaType.Region).ToList();
        }

        private PopulationDataSet(TimeSet timeSet)
        {
            Areas.Clear();
            Areas.AddRange(DataLoader.LoadData(timeSet)); 
        }




    }
}
