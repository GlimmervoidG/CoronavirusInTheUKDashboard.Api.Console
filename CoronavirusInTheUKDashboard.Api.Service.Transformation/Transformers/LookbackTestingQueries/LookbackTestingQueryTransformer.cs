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
            var relevent = result.Data.FirstOrDefault(d => d.Date == SearchDate.AddDays(-1).Date);
            
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackTestingQuery_Pillar1
                ,
                Date = SearchDate.AddDays(-1).Date
                ,
                Daily = relevent?.Pillar1?.Daily
                ,
                Cumulative = relevent?.Pillar1?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackTestingQuery_Pillar2
                ,
                Date = SearchDate.AddDays(-1).Date
                ,
                Daily = relevent?.Pillar2?.Daily
                ,
                Cumulative = relevent?.Pillar2?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackTestingQuery_Pillar3
                ,
                Date = SearchDate.AddDays(-1).Date
                ,
                Daily = relevent?.Pillar3?.Daily
                ,
                Cumulative = relevent?.Pillar3?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackTestingQuery_Pillar4
                ,
                Date = SearchDate.AddDays(-1).Date
                ,
                Daily = relevent?.Pillar4?.Daily
                ,
                Cumulative = relevent?.Pillar4?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackTestingQuery_PillarAll
                ,
                Date = SearchDate.AddDays(-1).Date
                ,
                Daily = relevent?.PillarAll?.Daily
                ,
                Cumulative = relevent?.PillarAll?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackTestingQuery_PcrTests
                ,
                Date = SearchDate.AddDays(-1).Date
                ,
                Daily = relevent?.PcrTests?.Daily
                ,
                Cumulative = relevent?.PcrTests?.Cumulative
            });

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
