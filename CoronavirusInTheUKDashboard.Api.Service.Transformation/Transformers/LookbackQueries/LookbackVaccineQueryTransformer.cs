using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.MainPost;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackEnglandQueries
{
    public class LookbackVaccineQueryTransformer : ILookbackVaccineQueryTransformer
    {
        public DateTime TargetDate { get; set; }

        public ILookbackJustVaccineQuery Query { get; set; } 
        public ILogger<LookbackVaccineQueryTransformer> Logger { get; set; } 

        public LookbackVaccineQueryTransformer(
            ILookbackJustVaccineQuery query,
            ILogger<LookbackVaccineQueryTransformer> logger)
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
            var relevent1 = result.Data.FirstOrDefault(d => d.Date == TargetDate.AddDays(-1).Date);

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_FirstDose
                               ,
                Date = TargetDate.AddDays(-1).Date
                               ,
                Daily = relevent1?.FirstDose_Daily
                               ,
                Cumulative = relevent1?.FirstDose_Cumulative
            });

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_SecondDose
                   ,
                Date = TargetDate.AddDays(-1).Date
                   ,
                Daily = relevent1?.SecondDose_Daily
                   ,
                Cumulative = relevent1?.SecondDose_Cumulative
            });

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_ThirdDose
                   ,
                Date = TargetDate.AddDays(-1).Date
                   ,
                Daily = relevent1?.ThirdDose_Daily
                   ,
                Cumulative = relevent1?.ThirdDose_Cumulative
            });

            return new Result<StandardRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackQuery_Vaccine_Name, Url = result.Url }
                }
            };
        }
    }
}
