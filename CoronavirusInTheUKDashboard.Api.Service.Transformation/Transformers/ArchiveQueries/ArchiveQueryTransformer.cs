using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Queries.GeneralQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Common;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.ArchiveQueries
{
    public class ArchiveQueryTransformer : IArchiveTransformer
    { 
        public DateTime ArchiveDate {get;set;}
        public IArchiveQuery ArchiveQuery { get; set; }

        public ArchiveQueryTransformer(IArchiveQuery archiveQuery)
        {
            ArchiveQuery = archiveQuery;
        }


        public void QueryAndTransform(List<QueryRecord> records)
        {
            foreach(var record in records)
            {

                for(int i=0; i < 5; i++)
                {
                    try
                    {
                        ArchiveQuery.TargetUrl = record.Url;
                        record.ArchiveUrl = ArchiveQuery.DoQuery();
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
