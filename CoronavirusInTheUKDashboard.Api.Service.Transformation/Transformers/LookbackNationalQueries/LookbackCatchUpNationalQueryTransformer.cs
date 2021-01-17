using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackNationalQueries
{
    public class LookbackCatchUpNationalQueryTransformer : ILookbackCatchUpEnglandQueryTransformer
    {
        public DateTime TargetDate { get; set; }
        public ILookbackCatchUpEnglandQuery Query { get; set; }
        public ILogger<LookbackCatchUpNationalQueryTransformer> Logger { get; set; }

        public LookbackCatchUpNationalQueryTransformer(ILookbackCatchUpEnglandQuery query,
            ILogger<LookbackCatchUpNationalQueryTransformer> logger)
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

            // Get records from the prevous Friday to yesterday. 
            var dates = GetDatesToSearchFor().OrderBy(d => d.Date);

            foreach (var date in dates)
            {
                var relevent = result.Data.FirstOrDefault(d => d.Date == date.Date);

                records.Add(new StandardRecord()
                {
                    Name = NameConstants.LookbackQuery_LfdTests,
                    Date = date.Date,
                    Daily = relevent?.LfdTests?.Daily,
                    Cumulative = relevent?.LfdTests?.Cumulative
                });
            }

            return new Result<StandardRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackQuery_Weekend_Lfd_Name, Url = result.Url }
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
