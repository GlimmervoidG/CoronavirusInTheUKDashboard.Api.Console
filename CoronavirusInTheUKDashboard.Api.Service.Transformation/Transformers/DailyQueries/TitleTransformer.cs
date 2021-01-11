﻿using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries
{
    public class TitleTransformer: ITitleTransformer
    {
        public DateTime SearchDate { get; set; }
        public IDailyQuery Query { get; set; }
        public TitleTransformer(IDailyQuery query)
        {
            Query = query;
        }
        public Result<TitleResult> QueryAndTransform()
        {
            Query.SearchDate = SearchDate;
            var result = Query.DoQuery();

            var records = new List<StandardRecord>();
            var relevent = result.Data.Where(d => d.Date == SearchDate).FirstOrDefault();

            var titleResult = new TitleResult()
            {
                TotalCases = new SimpleRecord() 
                { 
                    Date = SearchDate,
                    Value = relevent?.Cases?.Cumulative 
                },
                TotalDeaths = new SimpleRecord()
                {
                    Date = SearchDate,
                    Value = relevent?.Deaths?.Cumulative
                },
                TotalVaccines = new SimpleRecord()
                {
                    Date = SearchDate,
                    Value = relevent?.FirstDose?.Cumulative
                },
                Date = SearchDate 
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
