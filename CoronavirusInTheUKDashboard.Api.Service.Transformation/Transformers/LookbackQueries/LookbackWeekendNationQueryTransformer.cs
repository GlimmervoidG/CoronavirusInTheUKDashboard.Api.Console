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
    public class LookbackWeekendNationQueryTransformer : ILookbackWeekendNationQueryTransformer
    {
        public DateTime TargetDate { get; set; }
        public ILookbackWeekendEnglandQuery QueryEngland { get; set; }
        public ILookbackWeekendNorthernIrelandQuery QueryNorthenIreland { get; set; }

        public ILogger<LookbackWeekendNationQueryTransformer> Logger { get; set; }


        public LookbackWeekendNationQueryTransformer(ILookbackWeekendEnglandQuery queryEngland,
            ILookbackWeekendNorthernIrelandQuery queryNorthenIreland,
            ILogger<LookbackWeekendNationQueryTransformer> logger)
        {
            QueryEngland = queryEngland;
            QueryNorthenIreland = queryNorthenIreland;
            Logger = logger;
        }
        public Result<StandardRecord> QueryAndTransform()
        {
            Logger.LogInformation($"Running Query and transform.");

            QueryEngland.TargetDate = TargetDate;
            var englandResult = QueryEngland.DoQuery();

            QueryNorthenIreland.TargetDate = TargetDate;
            var niResult = QueryNorthenIreland.DoQuery();


            var records = new List<StandardRecord>();
            var relevent1 = englandResult.Data.FirstOrDefault(d => d.Date == TargetDate.AddDays(-1).Date);

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_FirstDoseEngland
                               ,
                Date = TargetDate.AddDays(-1).Date
                               ,
                Daily = relevent1?.FirstDose?.Daily
                               ,
                Cumulative = relevent1?.FirstDose?.Cumulative
            });

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_SecondDoseEngland
                   ,
                Date = TargetDate.AddDays(-1).Date
                   ,
                Daily = relevent1?.SecondDose?.Daily
                   ,
                Cumulative = relevent1?.SecondDose?.Cumulative
            });

            var relevent2 = niResult.Data.FirstOrDefault(d => d.Date == TargetDate.AddDays(-1).Date);

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_FirstDoseNi
                               ,
                Date = TargetDate.AddDays(-1).Date
                               ,
                Daily = relevent2?.FirstDose?.Daily
                               ,
                Cumulative = relevent2?.FirstDose?.Cumulative
            });

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_SecondDoseNi
                   ,
                Date = TargetDate.AddDays(-1).Date
                   ,
                Daily = relevent2?.SecondDose?.Daily
                   ,
                Cumulative = relevent2?.SecondDose?.Cumulative
            });

            return new Result<StandardRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackQuery_National_England, Url = englandResult.Url }, 
                    new QueryRecord() { Name = NameConstants.LookbackQuery_National_Ni, Url = niResult.Url }
                }
            };
        }
    }
}
