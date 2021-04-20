using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackQueries
{
    public class LookbackNationalQueryTransformer : ILookbackNationalQueryTransformer
    {
        public DateTime TargetDate { get; set; }
        public ILookbackEnglandQuery Query { get; set; }
        ILogger<LookbackNationalQueryTransformer> Logger { get; set; }
        public LookbackNationalQueryTransformer(ILookbackEnglandQuery query,
            ILogger<LookbackNationalQueryTransformer> logger)
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
                Daily = relevent?.LfdTests_Daily
                               ,
                Cumulative = relevent?.LfdTests_Cumulative
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
