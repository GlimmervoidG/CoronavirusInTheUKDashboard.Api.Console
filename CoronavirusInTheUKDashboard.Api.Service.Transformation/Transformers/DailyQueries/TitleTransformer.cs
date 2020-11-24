using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;


namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries
{
    public class TitleTransformer
    {
        public DateTime SearchDate { get; set; }
        public TitleResult QueryAndTransform()
        {
            var query = new DailyQuery() { SearchDate = SearchDate };
            var result = query.DoQuery();

            var records = new List<StandardRecord>();
            var relevent = result.Data.Where(d => d.Date == SearchDate).First();

            var titleResult = new TitleResult()
            {
                TotalCases = new SimpleRecord() 
                { 
                    Date = SearchDate,
                    Value = relevent.Cases.Cumulative 
                },
                TotalDeaths = new SimpleRecord()
                {
                    Date = SearchDate,
                    Value = relevent.Deaths.Cumulative
                },
                QueryRecords = new List<QueryRecord>()
            };

            return titleResult;
        }
    }
}
