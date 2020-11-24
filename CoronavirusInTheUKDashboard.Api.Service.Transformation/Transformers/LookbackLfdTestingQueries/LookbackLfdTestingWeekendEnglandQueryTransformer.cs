using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackLfdTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackTestingQueries; 
using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackLfdTestingQueries
{
    public class LookbackLfdTestingWeekendEnglandQueryTransformer
    {
        public DateTime SearchDate { get; set; }
        public Result<StandardRecord> QueryAndTransform()
        {
            var query = new LookbackLfdTestingWeekendEnglandQuery() { SearchDate = SearchDate };
            var result = query.DoQuery();

            var records = new List<StandardRecord>();

            // Get records from the prevous Friday to yesterday. 
            var dates = GetDatesToSearchFor();

            var relevent = result.Data.Where(d => dates.Contains(d.Date.Date)).OrderBy(d => d.Date).ToList();
            foreach (var item in relevent)
            {
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackTestingQuery_LfdTests
                    ,
                    Date = item.Date
                    ,
                    Daily = item.LfdTests.Daily
                    ,
                    Cumulative = item.LfdTests.Cumulative
                }); 
            }
            return new Result<StandardRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackTestingQuery_Weekend_Lfd_Name, Url = result.Url }
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
