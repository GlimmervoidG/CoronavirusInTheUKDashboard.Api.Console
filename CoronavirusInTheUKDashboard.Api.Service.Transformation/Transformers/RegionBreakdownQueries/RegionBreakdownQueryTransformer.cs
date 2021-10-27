using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionBreakdownQueries;
using UkOnsPopulationEstimatesUnofficial.Model;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries
{
    public abstract class RegionBreakdownQueryTransformer
    {
        public DateTime TargetDate { get; set; }

        protected string QueryNameToday { get; set; }
        protected string QueryNameYesterday { get; set; }

        public Result<RegionRateRecord> Transform(List<Area> regions, QueryResponce<RegionBreakdownQueryModel> resultToday, QueryResponce<RegionBreakdownQueryModel> resultYesterday)
        {

            var records = new List<RegionRateRecord>();
            var todayRecords = resultToday.Data.Where(d => d.Date == TargetDate.Date).ToList();
            var yesterdayRecords = resultYesterday.Data.Where(d => d.Date == TargetDate.AddDays(-1).Date).ToList();
            foreach (var region in regions)
            {
                var today = todayRecords.FirstOrDefault(r => r.Code == region.Code);
                var yesterday = yesterdayRecords.FirstOrDefault(r => r.Code == region.Code);

                var record = new RegionRateRecord()
                {
                    Name = region.DisplayName(),
                    Date = TargetDate.Date,
                    Daily = today?.DailyCases,
                    Delta = today?.DailyCases - yesterday?.DailyCases
                };
                SetRatio(region, record);
                records.Add(record);
            }
            records = records.OrderByDescending(r => r.Rate).ToList();

            return new Result<RegionRateRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = QueryNameToday, Url = resultToday.Url }, 
                    new QueryRecord() { Name = QueryNameYesterday, Url = resultYesterday.Url }
                }
            };

        }


        private void SetRatio(Area region, RegionRateRecord record)
        {
            if (record.Daily.HasValue)
            { 
                record.Rate = (record.Daily.Value * 100000) / (double)region.TotalPopulation();
            }
            else
            {
                record.Rate = null;
            } 
        }

    }
}
