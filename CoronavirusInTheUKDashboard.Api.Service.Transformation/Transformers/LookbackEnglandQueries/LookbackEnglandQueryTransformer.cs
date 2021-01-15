using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackQueries; 
using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;
using Microsoft.Extensions.Logging;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackQueries
{
    public class LookbackEnglandQueryTransformer : ILookbackEnglandQueryTransformer
    {
        public DateTime TargetDate { get; set; }
        public ILookbackEnglandQuery Query { get; set; }
        ILogger<LookbackEnglandQueryTransformer> Logger { get; set; }
        public LookbackEnglandQueryTransformer(ILookbackEnglandQuery query,
            ILogger<LookbackEnglandQueryTransformer> logger)
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
            var relevent = result.Data.FirstOrDefault(d => d.Date == TargetDate.AddDays(-1).Date);

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_LfdTests
                               ,
                Date = TargetDate.AddDays(-1).Date
                               ,
                Daily = relevent?.LfdTests?.Daily
                               ,
                Cumulative = relevent?.LfdTests?.Cumulative
            });

            return new Result<StandardRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackQuery_Lfd_Name, Url = result.Url }
                }
            };
        }
    }
}
