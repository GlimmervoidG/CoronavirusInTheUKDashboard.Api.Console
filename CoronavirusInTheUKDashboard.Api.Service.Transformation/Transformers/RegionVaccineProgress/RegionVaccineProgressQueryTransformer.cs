using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionVaccineProgressQueries;
using UkOnsPopulationEstimatesUnofficial.Model;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionVaccineProgress
{
    public abstract class RegionVaccineProgressQueryTransformer
    {
        public DateTime TargetDate { get; set; }

        protected string QueryNameToday { get; set; }
        protected string QueryNameYesterday { get; set; }

        public Result<RegionProgressRecord> Transform(List<Area> regions, QueryResponce<RegionVaccineProgressQueryModel> resultToday, QueryResponce<RegionVaccineProgressQueryModel> resultYesterday)
        {

            var records = new List<RegionProgressRecord>();
            var todayRecords = resultToday.Data.Where(d => d.Date == TargetDate.Date.AddDays(-1).Date).ToList();
            var yesterdayRecords = resultYesterday.Data.Where(d => d.Date == TargetDate.AddDays(-2).Date).ToList();
            foreach (var region in regions)
            {
                var today = todayRecords.FirstOrDefault(r => r.Code == region.Code);
                var yesterday = yesterdayRecords.FirstOrDefault(r => r.Code == region.Code);
                var regionStats = region;

                long? firstDoseTotal = null;
                long? firstDoseNew = null;
                double? firstDosePercentageProgress = null;
                double? firstDoseIncrease = null;

                if (today?.FirstDoseNew != null && today?.FirstDoseCum != null)
                {
                    firstDoseTotal = today?.FirstDoseCum;
                    firstDoseNew = today?.FirstDoseNew;
                    firstDosePercentageProgress = ((double)today.FirstDoseCum / (double)regionStats.TwelveOrMorePopulation()) * (double)100;
               
                    if (yesterday?.FirstDoseCum != null)
                    {
                        var percentageYesterday = ((double)yesterday.FirstDoseCum / (double)regionStats.TwelveOrMorePopulation()) * (double)100;
                        firstDoseIncrease = firstDosePercentageProgress - percentageYesterday;
                    }
                }

                long? secondDoseTotal = null;
                long? secondDoseNew = null;
                double? secondDosePercentageProgress = null;
                double? secondDoseIncrease = null;

                if (today?.SecondDoseNew != null && today?.SecondDoseCum != null)
                {
                    secondDoseTotal = today?.SecondDoseCum;
                    secondDoseNew = today?.SecondDoseNew;
                    secondDosePercentageProgress = ((double)today.SecondDoseCum / (double)regionStats.TwelveOrMorePopulation()) * (double)100;

                    if (yesterday?.SecondDoseCum != null)
                    {
                        var percentageYesterday = ((double)yesterday.SecondDoseCum / (double)regionStats.TwelveOrMorePopulation()) * (double)100;
                        secondDoseIncrease = secondDosePercentageProgress - percentageYesterday;
                    }
                }

                long? thirdDoseTotal = null;
                long? thirdDoseNew = null;
                double? thirdDosePercentageProgress = null;
                double? thirdDoseIncrease = null;

                if (today?.ThirdDoseNew != null && today?.ThirdDoseCum != null)
                {
                    thirdDoseTotal = today?.ThirdDoseCum;
                    thirdDoseNew = today?.ThirdDoseNew;
                    thirdDosePercentageProgress = ((double)today.ThirdDoseCum / (double)regionStats.TwelveOrMorePopulation()) * (double)100;

                    if (yesterday?.ThirdDoseCum != null)
                    {
                        var percentageYesterday = ((double)yesterday.ThirdDoseCum / (double)regionStats.TwelveOrMorePopulation()) * (double)100;
                        thirdDoseIncrease = thirdDosePercentageProgress - percentageYesterday;
                    }
                }

                var record = new RegionProgressRecord()
                {
                    Name = region.DisplayName(),
                    Date = TargetDate.Date,
                    FirstDoseTotal = firstDoseTotal,
                    FirstDoseDailyIncrease = firstDoseNew,
                    FirstDosePercentageProgress = firstDosePercentageProgress,
                    FirstDoseIncrease = firstDoseIncrease,

                    SecondDoseTotal = secondDoseTotal,
                    SecondDoseDailyIncrease = secondDoseNew,
                    SecondDosePercentageProgress = secondDosePercentageProgress,
                    SecondDoseIncrease = secondDoseIncrease,

                    ThirdDoseTotal = thirdDoseTotal,
                    ThirdDoseDailyIncrease = thirdDoseNew,
                    ThirdDosePercentageProgress = thirdDosePercentageProgress,
                    ThirdDoseIncrease = thirdDoseIncrease

                };
                records.Add(record);
            }
            records = records.OrderByDescending(r => r.FirstDosePercentageProgress).ToList();

            return new Result<RegionProgressRecord>()
            {
                Records = records,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = QueryNameToday, Url = resultToday.Url }, 
                    new QueryRecord() { Name = QueryNameYesterday, Url = resultYesterday.Url }
                }
            };

        } 
    }
}
