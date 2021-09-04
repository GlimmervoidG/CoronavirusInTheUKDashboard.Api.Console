using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using Uk.Ons.PopulationEstimates.Unofficial.Helper;
using Uk.Ons.PopulationEstimates.Unofficial.Model;

namespace Uk.Ons.PopulationEstimates.Unofficial
{
    public class PopulationDataSet
    {
        public static PopulationDataSet DataSet(TimeSet timeSet = TimeSet.Newest)
        {
            return new PopulationDataSet(timeSet);
        }


        public List<Area> Areas { get; set; } = new List<Area>(); 

        public List<Area> UK()
        {
            return Areas.Where(a => a.Type == AreaType.Country &&  a.Name == "UNITED KINGDOM").ToList();
        }

        public List<Area> HomeNations()
        {
            return Areas.Where(a => a.Type == AreaType.Country &&
            (
                a.Name == "ENGLAND" ||
                a.Name == "SCOTLAND" ||
                a.Name == "WALES" ||
                a.Name == "NORTHERN IRELAND"

            )).ToList();
        }
        public List<Area> EnglishRegions()
        {
            return Areas.Where(a => a.Type == AreaType.Region).ToList();
        }

        private PopulationDataSet(TimeSet timeSet)
        { 
            LoadData(timeSet); 
        }

        private void LoadData(TimeSet timeSet)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = GetDataResource(timeSet);


            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<AgeFileMap>();
                    var records = csv.GetRecords<Area>();

                    foreach (var record in records)
                    {
                        Areas.Add(record);
                    } 
                }
            }

        }
        private string GetDataResource(TimeSet timeSet)
        {
            if (timeSet == TimeSet.Newest)
            {
                timeSet = TimeSet.Mid2020;
            }
            return $"Uk.Ons.PopulationEstimates.Unofficial.Data.Data_{timeSet}.csv"; 
        }


    }
}
