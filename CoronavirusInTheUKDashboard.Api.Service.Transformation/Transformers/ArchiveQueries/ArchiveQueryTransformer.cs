using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Queries.GeneralQueries;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries
{
    public class ArchiveQueryTransformer
    { 
        public DateTime ArchiveDate {get;set;}
        public void QueryAndTransform(List<QueryRecord> records)
        {
            foreach(var record in records)
            {

                for(int i=0; i < 5; i++)
                {
                    try
                    {
                        var query = new ArchiveQuery() { TargetUrl = record.Url };
                        record.ArchiveUrl = query.DoQuery();
                        record.ArchiveDate = ArchiveDate;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Attempt {i} of 5 failed: {ex}");
                    }
                }

            }
        }
    }
}
