using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records.Ages;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Csv.AdmissionsByAge
{ 
    public class AdmissionsByAgeMap : ClassMap<AdmissionsByAgeRecord>
    {
        public AdmissionsByAgeMap()
        {
            Map(m => m.Date).Index(0).Name("Date").TypeConverterOption.Format("yyyy-MM-dd"); ;

            Map(m => m.Get0to5.Cumulative).Index(1).Name("0 to 5 Cumulative");
            Map(m => m.Get0to5.New).Index(2).Name("0 to 5 New");
            Map(m => m.Get0to5.Rate).Index(3).Name("0 to 5 Rate");

            Map(m => m.Get6To17.Cumulative).Index(4).Name("6 to 17 Cumulative");
            Map(m => m.Get6To17.New).Index(5).Name("6 to 17 New");
            Map(m => m.Get6To17.Rate).Index(6).Name("6 to 17 Rate");

            Map(m => m.Get18To64.Cumulative).Index(7).Name("18 to 64 Cumulative");
            Map(m => m.Get18To64.New).Index(8).Name("18 to 64 New");
            Map(m => m.Get18To64.Rate).Index(9).Name("18 to 64 Rate");

            Map(m => m.Get65To84.Cumulative).Index(10).Name("65 to 84 Cumulative");
            Map(m => m.Get65To84.New).Index(11).Name("65 to 84 New");
            Map(m => m.Get65To84.Rate).Index(12).Name("65 to 84 Rate");

            Map(m => m.Get85OrMore.Cumulative).Index(13).Name("85+ Cumulative");
            Map(m => m.Get85OrMore.New).Index(14).Name("85+ New");
            Map(m => m.Get85OrMore.Rate).Index(15).Name("85+ Rate"); 
        }
    }
}
