﻿using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries
{
    public class DailyQueryTransformer
    { 
        public DateTime SearchDate {get;set;}
        public Result<StandardRecord> QueryAndTransform()
        {
            var query = new DailyQuery() { SearchDate = SearchDate };
            var result = query.DoQuery();

            var records = new List<StandardRecord>();
            var relevent = result.Data.Where(d => d.Date == SearchDate).ToList();
            foreach (var item in relevent)
            {
                records.Add(new StandardRecord() { Name = NameConstants.DailyQuery_Deaths, Date = item.Date, Daily = item.Deaths.Daily, Cumulative = item.Deaths.Cumulative });
                records.Add(new StandardRecord() {Name = NameConstants.DailyQuery_Cases,  Date = item.Date, Daily = item.Cases.Daily, Cumulative = item.Cases.Cumulative });
            }
            return new Result<StandardRecord>() { 
                Records = records, 
                QueryRecords = new List<QueryRecord>() { 
                    new QueryRecord() { Name = NameConstants.DailyQuery_Name, Url = result.Url } 
                }
            };
        }
    }
}