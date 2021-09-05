using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using UkOnsPopulationEstimatesUnofficial.Model;

namespace UkOnsPopulationEstimatesUnofficial.Helper
{
    public class DataLoader
    {
        /// <summary>
        /// Loads population data and turns a list of populated Areas.
        /// </summary>
        /// <param name="timeSet"></param>
        /// <returns></returns>
        public static List<Area> LoadData(TimeSet timeSet)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = GetDataResource(timeSet);
            var list = new List<Area>();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<AgeFileMap>();
                    var records = csv.GetRecords<Area>();

                    list.AddRange(records); 
                }
            }
            return list;
        }

        /// <summary>
        /// Get the population data for a given time.
        /// </summary>
        /// <param name="timeSet"></param>
        /// <returns></returns>
        private static string GetDataResource(TimeSet timeSet)
        {
            if (timeSet == TimeSet.Newest)
            {
                timeSet = TimeSet.Mid2020;
            }
            return $"UkOnsPopulationEstimatesUnofficial.Data.Data_{timeSet}.csv";
        }
    }
}
