using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackTestingQueries; 
using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackTestingQueries
{
    public class LookbackTestingWeekendQueryTransformer
    {
        public DateTime SearchDate { get; set; }
        public Result<StandardRecord> QueryAndTransform()
        {
            var query = new LookbackTestingWeekendQuery() { SearchDate = SearchDate };
            var result = query.DoQuery();

            var records = new List<StandardRecord>();

            // Get records from the prevous Friday to yesterday. 
            var dates = GetDatesToSearchFor().OrderBy(d => d.Date); 

            foreach(var date in dates)
            { 
                var relevent = result.Data.FirstOrDefault(d => d.Date == date.Date);
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackTestingQuery_PcrTests
                    ,
                    Date = date.Date
                    ,
                    Daily = relevent?.PcrTests?.Daily
                    ,
                    Cumulative = relevent?.PcrTests?.Cumulative
                });
            } 
            return new Result<StandardRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackTestingQuery_Weekend_Name, Url = result.Url }
                }
            };
        }

        private List<DateTime> GetDatesToSearchFor()
        {
            var searchTarget = DayOfWeek.Friday;
            var currentSearch = SearchDate.Date;
            var datesToSearchFor = new List<DateTime>();
            while (true)
            {
                currentSearch = currentSearch.AddDays(-1);
                datesToSearchFor.Add(currentSearch);
                if (currentSearch.DayOfWeek == searchTarget)
                {
                    return datesToSearchFor;
                } 
            } 
        }
    }


}
