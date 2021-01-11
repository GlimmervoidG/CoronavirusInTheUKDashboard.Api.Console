﻿using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries
{
    public class DailyQueryTransformer : IDailyQueryTransformer
    { 
        public DateTime SearchDate {get;set;}

        public IDailyQuery Query { get; set; }
        public DailyQueryTransformer(IDailyQuery query)
        {
            Query = query;
        }

        public Result<StandardRecord> QueryAndTransform()
        {
            Query.SearchDate = SearchDate;
            var result = Query.DoQuery();

            var records = new List<StandardRecord>();
            var relevent = result.Data.Where(d => d.Date == SearchDate).FirstOrDefault();

            records.Add(new StandardRecord() { Name = NameConstants.DailyQuery_Deaths, Date = SearchDate, Daily = relevent?.Deaths?.Daily, Cumulative = relevent?.Deaths?.Cumulative });
            records.Add(new StandardRecord() { Name = NameConstants.DailyQuery_Cases, Date = SearchDate, Daily = relevent?.Cases?.Daily, Cumulative = relevent?.Cases?.Cumulative });
            records.Add(new StandardRecord() { Name = NameConstants.DailyQuery_FirstDose, Date = SearchDate, Daily = relevent?.FirstDose?.Daily, Cumulative = relevent?.FirstDose?.Cumulative });
            records.Add(new StandardRecord() { Name = NameConstants.DailyQuery_SecondDose, Date = SearchDate, Daily = relevent?.SecondDose?.Daily, Cumulative = relevent?.SecondDose?.Cumulative });

            return new Result<StandardRecord>() { 
                Records = records, 
                QueryRecords = new List<QueryRecord>() { 
                    new QueryRecord() { Name = NameConstants.DailyQuery_Name, Url = result.Url } 
                }
            };
        }
    }
}
