using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackEightDayQueries; 
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackEightDayQueries
{
    public class LookbackEightDayQueryTransformer
    {
        public DateTime SearchDate { get; set; }
        public SummationResult QueryAndTransform()
        {
            var query = new LookbackEightDayQuery() { SearchDate = SearchDate };
            var result = query.DoQuery();

            var cases = new List<SimpleRecord>(); 
            var deaths = new List<SimpleRecord>();  

            var casesPercentageIncrease = new List<SimplePercentageRecord>();
            var deathsPercentageIncrease = new List<SimplePercentageRecord>();
            var positivityRate = new List<SimplePercentageRecord>();

            var targetDate = SearchDate.AddDays(-10).Date;

            var lastNineDays = result.Data.Where(r => r.Date >= targetDate && r.Date <= SearchDate).OrderByDescending(r => r.Date).ToList();

            for (var i = 0; i < 9; i++)
            {
                var dataItem = lastNineDays[i];
                var dataItemDaybefore = lastNineDays[i + 1];

                if (dataItem.Deaths.Daily.HasValue && dataItemDaybefore.Deaths.Cumulative.HasValue)
                {

                    deaths.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = dataItem.Deaths.Daily
                    });

                    double percentageIncreaseDeaths = ((double)dataItem.Deaths.Daily / (double)dataItemDaybefore.Deaths.Cumulative) * 100;
                    deathsPercentageIncrease.Add(new SimplePercentageRecord()
                    {
                        Date = dataItem.Date,
                        Value = percentageIncreaseDeaths
                    });

                }
                else
                {
                    deaths.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = null
                    });
                    deathsPercentageIncrease.Add(new SimplePercentageRecord()
                    {
                        Date = dataItem.Date,
                        Value = null
                    });

                }

                if (dataItem.Cases.Daily.HasValue && dataItemDaybefore.Cases.Cumulative.HasValue)
                {

                    cases.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = dataItem.Cases.Daily
                    });

                    double percentageIncreasecases = ((double)dataItem.Cases.Daily / (double)dataItemDaybefore.Cases.Cumulative) * 100;
                    casesPercentageIncrease.Add(new SimplePercentageRecord()
                    {
                        Date = dataItem.Date,
                        Value = percentageIncreasecases
                    });

                }
                else
                {
                    cases.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = null
                    });
                    casesPercentageIncrease.Add(new SimplePercentageRecord()
                    {
                        Date = dataItem.Date,
                        Value = null
                    });

                }

                if (dataItem.VirusTests.Daily.HasValue && dataItem.Cases.Daily.HasValue)
                {
                    double positivity = ((double)dataItem.Cases.Daily.Value / (double)dataItem.VirusTests.Daily.Value) * 100;

                    positivityRate.Add(new SimplePercentageRecord()
                    {
                        Date = dataItem.Date,
                        Value = positivity
                    });


                }
                else
                {
                    positivityRate.Add(new SimplePercentageRecord()
                    {
                        Date = dataItem.Date,
                        Value = null
                    });
                }
            }

            // Remove the extra item
            cases.Remove(cases.Last());
            deaths.Remove(deaths.Last());
            casesPercentageIncrease.Remove(casesPercentageIncrease.Last());
            deathsPercentageIncrease.Remove(deathsPercentageIncrease.Last());

            // Round out the doubles
            Round(casesPercentageIncrease);
            Round(deathsPercentageIncrease);
            Round(positivityRate);

            // Populate the low day flats
            SetLowDay(cases.ConvertAll(x => (BaseSimpleRecord)x));
            SetLowDay(deaths.ConvertAll(x => (BaseSimpleRecord)x));
            SetLowDay(casesPercentageIncrease.ConvertAll(x => (BaseSimpleRecord)x));
            SetLowDay(deathsPercentageIncrease.ConvertAll(x => (BaseSimpleRecord)x));
            SetLowDay(positivityRate.ConvertAll(x => (BaseSimpleRecord)x));

            var todayCases = cases[0];
            var todayDeaths = deaths[0];
            var todayCasesPercentageIncrease = casesPercentageIncrease[0];
            var todayDeathsPercentageIncrease = deathsPercentageIncrease[0];
            var todayPositivityRate = positivityRate[1];
            var yesterdayCases = cases[1];
            var yesterdayDeaths = deaths[1];
            var yesterdayCasesPercentageIncrease = casesPercentageIncrease[1];
            var yesterdayDeathsPercentageIncrease = deathsPercentageIncrease[1];
            var yesterdayPositivityRate = positivityRate[2];

            var casesChange = CalculateChange(todayCases, yesterdayCases);
            var deathsChange = CalculateChange(todayDeaths, yesterdayDeaths);
            var casesPercentageIncreaseChange = CalculateChange(todayCasesPercentageIncrease, yesterdayCasesPercentageIncrease);
            var deathsPercentageIncreaseChange = CalculateChange(todayDeathsPercentageIncrease, yesterdayDeathsPercentageIncrease);
            var positivityRateChange = CalculateChange(todayPositivityRate, yesterdayPositivityRate); 

            // Reorder from oldest to newest
            cases = cases.OrderBy(r => r.Date).ToList();
            deaths = deaths.OrderBy(r => r.Date).ToList();
            casesPercentageIncrease = casesPercentageIncrease.OrderBy(r => r.Date).ToList();
            deathsPercentageIncrease = deathsPercentageIncrease.OrderBy(r => r.Date).ToList();
            positivityRate = positivityRate.OrderBy(r => r.Date).ToList();

            return new SummationResult()
            {
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackEightDayQuery_Name, Url = result.Url }
                },
                Cases = cases,
                Deaths = deaths,
                CasesPercentageIncrease = casesPercentageIncrease,
                DeathsPercentageIncrease = deathsPercentageIncrease,
                PositivityRate = positivityRate,
                TodayCases = todayCases,
                TodayDeaths = todayDeaths,
                TodayCasesPercentageIncrease = todayCasesPercentageIncrease,
                TodayDeathsPercentageIncrease = todayDeathsPercentageIncrease,
                TodayPositivityRate = todayPositivityRate,
                YesterdayCases =yesterdayCases,
                YesterdayDeaths = yesterdayDeaths,
                YesterdayCasesPercentageIncrease = yesterdayCasesPercentageIncrease,
                YesterdayDeathsPercentageIncrease = yesterdayDeathsPercentageIncrease,
                YesterdayPositivityRate = yesterdayPositivityRate,
                CasesChange = casesChange,
                CasesPercentageIncreaseChange = casesPercentageIncreaseChange,
                DeathsChange = deathsChange,
                DeathsPercentageIncreaseChange = deathsPercentageIncreaseChange,
                PositivityRateChange = positivityRateChange,
            };
        }


        private Change CalculateChange(SimpleRecord today, SimpleRecord yesterday)
        {
            if (!today.Value.HasValue)
            {
                return Change.NotUpdated;
            }
            else if (today.Value > yesterday.Value)
            {
                return Change.More;
            }
            else if (today.Value < yesterday.Value)
            {
                return Change.Less;
            }
            else
            {
                return Change.Equal;
            }
        }

        private Change CalculateChange(SimplePercentageRecord today, SimplePercentageRecord yesterday)
        {
            if (!today.Value.HasValue)
            {
                return Change.NotUpdated;
            }
            else if (today.Value > yesterday.Value)
            {
                return Change.More;
            }
            else if (today.Value < yesterday.Value)
            {
                return Change.Less;
            }
            else
            {
                return Change.Equal;
            }
        }

        private void Round(List<SimplePercentageRecord> list)
        {
            foreach (var item in list)
            {
                if (item.Value.HasValue)
                {
                    item.Value = Math.Round(item.Value.Value, 1);
                }
            } 
        }
        private void SetLowDay(List<BaseSimpleRecord> list)
        {
            foreach (var item in list)
            {
                item.IsLowDay = (item.Date.DayOfWeek == DayOfWeek.Sunday || item.Date.DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}
