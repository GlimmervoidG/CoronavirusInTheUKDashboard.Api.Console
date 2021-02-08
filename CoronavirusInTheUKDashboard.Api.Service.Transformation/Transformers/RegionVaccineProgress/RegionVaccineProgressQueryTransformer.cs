using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries.Population;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionVaccineProgressQueries;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionVaccineProgress
{
    public abstract class RegionVaccineProgressQueryTransformer
    {
        public DateTime TargetDate { get; set; }

        protected string QueryNameToday { get; set; }
        protected string QueryNameYesterday { get; set; }

        public Result<RegionProgressRecord> Transform(List<string> regions, QueryResponce<RegionVaccineProgressQueryModel> resultToday, QueryResponce<RegionVaccineProgressQueryModel> resultYesterday)
        {

            var records = new List<RegionProgressRecord>();
            var todayRecords = resultToday.Data.Where(d => d.Date == TargetDate.Date.AddDays(-1).Date).ToList();
            var yesterdayRecords = resultYesterday.Data.Where(d => d.Date == TargetDate.AddDays(-2).Date).ToList();
            foreach (var region in regions)
            {
                var today = todayRecords.FirstOrDefault(r => r.Name == region);
                var yesterday = yesterdayRecords.FirstOrDefault(r => r.Name == region);
                var regionStats = GetRegionRecord(region);

                long? firstDoseTotal = null;
                long? firstDoseNew = null;
                double? percentageProgress = null;
                double? increase = null;

                if (today?.FirstDoseNew != null && today?.FirstDoseCum != null)
                {
                    firstDoseTotal = today?.FirstDoseCum;
                    firstDoseNew = today?.FirstDoseNew;
                    percentageProgress = ((double)today.FirstDoseCum / (double)regionStats.AdultPopulation) * (double)100;
               
                    if (yesterday?.FirstDoseCum != null)
                    {
                        var percentageYesterday = ((double)yesterday.FirstDoseCum / (double)regionStats.AdultPopulation) * (double)100;
                        increase = percentageProgress - percentageYesterday;
                    }
                }
                 
                var record = new RegionProgressRecord()
                {
                    Name = region,
                    Date = TargetDate.Date,
                    Total = firstDoseTotal,
                    DailyIncrease = firstDoseNew,
                    PercentageProgress = percentageProgress,
                    Increase = increase
                };
                records.Add(record);
            }
            records = records.OrderByDescending(r => r.PercentageProgress).ToList();

            return new Result<RegionProgressRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = QueryNameToday, Url = resultToday.Url }, 
                    new QueryRecord() { Name = QueryNameYesterday, Url = resultYesterday.Url }
                }
            };

        }


        private Region GetRegionRecord(string name)
        {
            var regions = PopulationHelper.GetAllAsRegionList();
            var area = regions.First(r => r.Name == name);
            return area;
        }


    }
}
