using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackLfdTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackTestingQueries; 
using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackLfdTestingQueries
{
    public class LookbackLfdTestingEnglandQueryTransformer
    {
        public DateTime SearchDate { get; set; }
        public Result<StandardRecord> QueryAndTransform()
        {
            var query = new LookbackLfdTestingEnglandQuery() { SearchDate = SearchDate };
            var result = query.DoQuery();

            var records = new List<StandardRecord>();
            var relevent = result.Data.FirstOrDefault(d => d.Date == SearchDate.AddDays(-1).Date);

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackTestingQuery_LfdTests
                               ,
                Date = SearchDate.Date
                               ,
                Daily = relevent?.LfdTests?.Daily
                               ,
                Cumulative = relevent?.LfdTests?.Cumulative
            });

            return new Result<StandardRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackTestingQuery_Lfd_Name, Url = result.Url }
                }
            };
        }
    }
}
