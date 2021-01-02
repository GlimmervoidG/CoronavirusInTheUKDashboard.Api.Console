using CoronavirusInTheUKDashboard.Api.Service.Csv.AdmissionsByAge;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CoronavirusInTheUKDashboard.Api.Service.Csv
{
    public class CsvEngine
    {
        public static string Run(AdmissionsByAgeModel model)
        {
            var builder = new StringBuilder();

            using (var writer = new StringWriter(builder))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<AdmissionsByAgeMap>();
                csv.WriteRecords(model.AdmissionsByAge.Records);
            } 
            return builder.ToString();
        }
    }
}
