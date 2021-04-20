using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries
{
    public class DailyQueryTransformer : IDailyQueryTransformer
    { 
        public DateTime TargetDate {get;set;}
        public IDailyQuery Query { get; set; }
        ILogger<DailyQueryTransformer> Logger { get; set; }

        public DailyQueryTransformer(IDailyQuery query,
             ILogger<DailyQueryTransformer> logger)
        {
            Query = query;
            Logger = logger;
        }

        public Result<StandardRecord> QueryAndTransform()
        {
            Logger.LogInformation($"Running Query and transform.");
            Query.TargetDate = TargetDate;
            var result = Query.DoQuery();

            var records = new List<StandardRecord>();
            var relevent = result.Data.Where(d => d.Date == TargetDate).FirstOrDefault();

            records.Add(new StandardRecord() { Name = NameConstants.DailyQuery_Deaths, Date = TargetDate, Daily = relevent?.Deaths_Daily, Cumulative = relevent?.Deaths_Cumulative });
            records.Add(new StandardRecord() { Name = NameConstants.DailyQuery_Cases, Date = TargetDate, Daily = relevent?.Cases_Daily, Cumulative = relevent?.Cases_Cumulative });
   
            return new Result<StandardRecord>() { 
                Records = records, 
                QueryRecords = new List<QueryRecord>() { 
                    new QueryRecord() { Name = NameConstants.DailyQuery_Name, Url = result.Url } 
                }
            };
        }
    }
}
