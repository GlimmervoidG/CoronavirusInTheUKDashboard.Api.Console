using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackLfdTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackTestingQueries; 
using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackLfdTestingQueries
{
    public class LookbackLfdTestingEnglandQueryTransformer : ILookbackLfdTestingEnglandQueryTransformer
    {
        public DateTime SearchDate { get; set; }
        public ILookbackLfdTestingEnglandQuery Query { get; set; }
        public LookbackLfdTestingEnglandQueryTransformer(ILookbackLfdTestingEnglandQuery query)
        {
            Query = query;
        }
        public Result<StandardRecord> QueryAndTransform()
        {
            Query.SearchDate = SearchDate; 
            var result = Query.DoQuery();

            var records = new List<StandardRecord>();
            var relevent = result.Data.FirstOrDefault(d => d.Date == SearchDate.AddDays(-1).Date);

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackTestingQuery_LfdTests
                               ,
                Date = SearchDate.AddDays(-1).Date
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
