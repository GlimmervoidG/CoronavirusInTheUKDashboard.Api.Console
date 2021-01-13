using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackQueries; 
using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackQueries
{
    public class LookbackQueryTransformer : ILookbackQueryTransformer
    {
        public DateTime TargetDate { get; set; }
        public ILookbackQuery Query { get; set; }
        public LookbackQueryTransformer(ILookbackQuery query)
        {
            Query = query;
        }
        public Result<StandardRecord> QueryAndTransform()
        {
            Query.TargetDate = TargetDate;
            var result = Query.DoQuery();

            var records = new List<StandardRecord>();
            var relevent = result.Data.FirstOrDefault(d => d.Date == TargetDate.AddDays(-1).Date);


            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_FirstDose
                ,
                Date = TargetDate.AddDays(-1).Date
                ,
                Daily = relevent?.FirstDose?.Daily
                ,
                Cumulative = relevent?.FirstDose?.Cumulative
            });

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_SecondDose
                ,
                Date = TargetDate.AddDays(-1).Date
                ,
                Daily = relevent?.SecondDose?.Daily
                ,
                Cumulative = relevent?.SecondDose?.Cumulative
            });

            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_Pillar1
                ,
                Date = TargetDate.AddDays(-1).Date
                ,
                Daily = relevent?.Pillar1?.Daily
                ,
                Cumulative = relevent?.Pillar1?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_Pillar2
                ,
                Date = TargetDate.AddDays(-1).Date
                ,
                Daily = relevent?.Pillar2?.Daily
                ,
                Cumulative = relevent?.Pillar2?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_Pillar3
                ,
                Date = TargetDate.AddDays(-1).Date
                ,
                Daily = relevent?.Pillar3?.Daily
                ,
                Cumulative = relevent?.Pillar3?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_Pillar4
                ,
                Date = TargetDate.AddDays(-1).Date
                ,
                Daily = relevent?.Pillar4?.Daily
                ,
                Cumulative = relevent?.Pillar4?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_PillarAll
                ,
                Date = TargetDate.AddDays(-1).Date
                ,
                Daily = relevent?.PillarAll?.Daily
                ,
                Cumulative = relevent?.PillarAll?.Cumulative
            });
            records.Add(new StandardRecord()
            {
                Name = NameConstants.LookbackQuery_PcrTests
                ,
                Date = TargetDate.AddDays(-1).Date
                ,
                Daily = relevent?.PcrTests?.Daily
                ,
                Cumulative = relevent?.PcrTests?.Cumulative
            });


            return new Result<StandardRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackQuery_Name, Url = result.Url }
                }
            }; 
        }
    }
}
