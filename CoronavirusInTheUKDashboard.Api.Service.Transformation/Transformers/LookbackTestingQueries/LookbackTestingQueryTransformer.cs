using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackTestingQueries; 
using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackTestingQueries
{
    public class LookbackTestingQueryTransformer
    {
        public DateTime SearchDate { get; set; }
        public Result<StandardRecord> QueryAndTransform()
        {
            var query = new LookbackTestingQuery() { SearchDate = SearchDate };
            var result = query.DoQuery();

            var records = new List<StandardRecord>();
            var relevent = result.Data.Where(d => d.Date == SearchDate.AddDays(-1).Date).ToList();
            foreach (var item in relevent)
            { 
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackTestingQuery_Pillar1
                    ,
                    Date = item.Date
                    ,
                    Daily = item.Pillar1.Daily
                    ,
                    Cumulative = item.Pillar1.Cumulative
                });
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackTestingQuery_Pillar2
                    ,
                    Date = item.Date
                    ,
                    Daily = item.Pillar2.Daily
                    ,
                    Cumulative = item.Pillar2.Cumulative
                });
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackTestingQuery_Pillar3
                    ,
                    Date = item.Date
                    ,
                    Daily = item.Pillar3.Daily
                    ,
                    Cumulative = item.Pillar3.Cumulative
                });
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackTestingQuery_Pillar4
                    ,
                    Date = item.Date
                    ,
                    Daily = item.Pillar4.Daily
                    ,
                    Cumulative = item.Pillar4.Cumulative
                });
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackTestingQuery_PillarAll
                    ,
                    Date = item.Date
                    ,
                    Daily = item.PillarAll.Daily
                    ,
                    Cumulative = item.PillarAll.Cumulative
                });
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackTestingQuery_PcrTests
                    ,
                    Date = item.Date
                    ,
                    Daily = item.PcrTests.Daily
                    ,
                    Cumulative = item.PcrTests.Cumulative
                });

            }
            return new Result<StandardRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackTestingQuery_Name, Url = result.Url }
                }
            }; 
        }
    }
}
