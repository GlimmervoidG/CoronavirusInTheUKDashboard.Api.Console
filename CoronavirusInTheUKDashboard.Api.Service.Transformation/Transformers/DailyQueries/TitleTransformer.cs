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
    public class TitleTransformer: ITitleTransformer
    {
        public DateTime TargetDate { get; set; }
        public IDailyQuery Query { get; set; }
        public ILookbackJustVaccineQuery LookbackJustVaccineQuery { get; set; }
        ILogger<TitleTransformer> Logger { get; set; }
        public TitleTransformer(IDailyQuery query,
            ILookbackJustVaccineQuery lookbackQuery,
            ILogger<TitleTransformer> logger)
        {
            Query = query;
            LookbackJustVaccineQuery = lookbackQuery;
            Logger = logger;
        }
        public Result<TitleResult> QueryAndTransform()
        {
            Logger.LogInformation($"Running Query and transform.");
            Query.TargetDate = TargetDate;
            var result = Query.DoQuery();

            LookbackJustVaccineQuery.TargetDate = TargetDate;
            var yesterdayResult = LookbackJustVaccineQuery.DoQuery();

            var relevent = result.Data.Where(d => d.Date == TargetDate).FirstOrDefault();
            var yesterdayRelevent = yesterdayResult.Data.Where(d => d.Date == TargetDate.AddDays(-1).Date).FirstOrDefault();

            var titleResult = new TitleResult()
            {
                TotalCases = new SimpleRecord() 
                { 
                    Date = TargetDate,
                    Value = relevent?.Cases_Cumulative
                },
                TotalDeaths = new SimpleRecord()
                {
                    Date = TargetDate,
                    Value = relevent?.Deaths_Cumulative
                },
                TotalVaccines = new SimpleRecord()
                {
                    Date = TargetDate,
                    Value = yesterdayRelevent?.FirstDose_Cumulative
                },
                Date = TargetDate 
            };

            var list = new List<TitleResult>() { titleResult };

            return new Result<TitleResult>()
            {
                Records = list,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.DailyQuery_Name, Url = result.Url }
                }
            };
             
        }
    }
}
