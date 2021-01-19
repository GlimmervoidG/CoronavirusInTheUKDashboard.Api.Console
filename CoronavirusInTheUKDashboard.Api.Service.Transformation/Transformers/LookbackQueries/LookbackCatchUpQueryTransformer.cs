using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackQueries;
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
    public class LookbackCatchUpQueryTransformer : ILookbackCatchUpQueryTransformer
    {
        public DateTime TargetDate { get; set; }
        public ILookbackCatchUpQuery Query { get; set; }
        public ILogger<LookbackCatchUpQueryTransformer> Logger { get; set; }
        public LookbackCatchUpQueryTransformer(ILookbackCatchUpQuery query,
            ILogger<LookbackCatchUpQueryTransformer> logger)
        {
            Query = query;
            Logger = logger;
        }
        public Result<RecordGroup> QueryAndTransform()
        {
            Logger.LogInformation($"Running Query and transform.");
            Query.TargetDate = TargetDate;
            var result = Query.DoQuery();

            // Get records from the prevous Friday to yesterday. 
            var dates = GetDatesToSearchFor().OrderBy(d => d.Date);

            var groups = new List<RecordGroup>();
            var records = new List<StandardRecord>();

            records.Clear();
            foreach (var date in dates)
            {
                var relevent = result.Data.FirstOrDefault(d => d.Date == date.Date);
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackQuery_FirstDose
                    ,
                    Date = date.Date
                    ,
                    Daily = relevent?.FirstDose?.Daily
                    ,
                    Cumulative = relevent?.FirstDose?.Cumulative
                });
            } 
            groups.Add(new RecordGroup() { Records = records.ToList() });

            records.Clear();
            foreach (var date in dates)
            {
                var relevent = result.Data.FirstOrDefault(d => d.Date == date.Date);
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackQuery_SecondDose
                    ,
                    Date = date.Date
                    ,
                    Daily = relevent?.SecondDose?.Daily
                    ,
                    Cumulative = relevent?.SecondDose?.Cumulative
                });
            }
            groups.Add(new RecordGroup() { Records = records.ToList() });

            records.Clear();
            foreach (var date in dates)
            {
                var relevent = result.Data.FirstOrDefault(d => d.Date == date.Date);
                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackQuery_PcrTests
                    ,
                    Date = date.Date
                    ,
                    Daily = relevent?.PcrTests?.Daily
                    ,
                    Cumulative = relevent?.PcrTests?.Cumulative
                });
            }
            groups.Add(new RecordGroup() { Records = records.ToList() });

            return new Result<RecordGroup>()
            {
                Records = groups,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackQuery_Weekend_Name, Url = result.Url }
                }
            };
        }

        private List<DateTime> GetDatesToSearchFor()
        {
            var searchTarget = DayOfWeek.Friday;
            var currentSearch = TargetDate.Date;
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
