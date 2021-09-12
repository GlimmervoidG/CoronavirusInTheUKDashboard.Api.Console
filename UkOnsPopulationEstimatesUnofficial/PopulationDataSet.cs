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
        /// <summary>
        /// Creates a population dataset for use. 
        /// </summary>
        /// <param name="timeSet"></param>
        /// <returns></returns>
        public static PopulationDataSet DataSet(TimeSet timeSet = TimeSet.Newest)
        {
            return new PopulationDataSet(timeSet);
        }


        /// <summary>
        /// The full list of Areas for the entire UK.
        /// </summary>
        public List<Area> Areas { get; private set; } = new List<Area>(); 

        /// <summary>
        /// Get a list of Areas containing just the UK element. 
        /// </summary>
        /// <returns></returns>
        public List<Area> UK()
        {
            return Areas.Where(a => a.Type == AreaType.Country &&  a.Code == AreaCodes.UK).ToList();
        }

        /// <summary>
        /// Get a list of Areas containing just the home nation elements.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get a list of Areas containing just the English regions.
        /// </summary>
        /// <returns></returns>
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
