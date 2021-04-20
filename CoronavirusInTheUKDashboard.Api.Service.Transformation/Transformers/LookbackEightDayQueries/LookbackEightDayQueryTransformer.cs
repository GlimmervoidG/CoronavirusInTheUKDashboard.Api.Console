using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.TrendsPost;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackEightDayQueries
{
    public class LookbackEightDayQueryTransformer : ILookbackEightDayQueryTransformer
    {
        public DateTime TargetDate { get; set; }
        public ILookbackEightDayQuery Query { get; set; }
        ILogger<LookbackEightDayQueryTransformer> Logger { get; set; }
        public LookbackEightDayQueryTransformer(ILookbackEightDayQuery query,
            ILogger<LookbackEightDayQueryTransformer> logger)
        {
            Query = query;
            Logger = logger;
        }

        private List<DateTime> GetWindow()
        {
            var list = new List<DateTime>();
            var date = TargetDate.AddDays(-10).Date;
            while (date <= TargetDate.Date)
            {
                list.Add(date);
                date = date.AddDays(1);
            }
            return list;
        }
        public Result<SummationResult> QueryAndTransform()
        {
            Logger.LogInformation($"Running Query and transform.");
            Query.TargetDate = TargetDate;
            var result = Query.DoQuery();

            var cases = new List<SimpleRecord>(); 
            var deaths = new List<SimpleRecord>();
            var firstDoses = new List<SimpleRecord>();
            var secondDoses = new List<SimpleRecord>();
            var totalDoses = new List<SimpleRecord>();

            var casesPercentageIncrease = new List<SimplePercentageRecord>();
            var deathsPercentageIncrease = new List<SimplePercentageRecord>();
            var positivityRate = new List<SimplePercentageRecord>();
             
            var window = GetWindow().OrderByDescending( d => d);  

            var windowDays = new List<LookbackEightDayQueryModel>();
            foreach(var date in window)
            {
                var day = result.Data.FirstOrDefault(r => r.Date == date);
                if (day != null)
                {
                    windowDays.Add(day);
                } else
                {
                    windowDays.Add(new LookbackEightDayQueryModel()
                    {
                        Date = date,
                        Cases_Daily = null,
                        Cases_Cumulative = null,
                        Deaths_Daily = null,
                        Deaths_Cumulative = null,
                        VirusTests_Daily = null,
                        VirusTests_Cumulative = null,
                        FirstDoses_Daily = null,
                        FirstDoses_Cumulative = null 
                    });
                }
            }
                   
            for (var i = 0; i < 9; i++)
            {
                var dataItem = windowDays[i];
                var dataItemDaybefore = windowDays[i + 1];

                if (dataItem?.Deaths_Daily.HasValue == true && dataItemDaybefore?.Deaths_Cumulative.HasValue == true)
                {

                    deaths.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = dataItem.Deaths_Daily
                    });

                    double percentageIncreaseDeaths = ((double)dataItem.Deaths_Daily / (double)dataItemDaybefore.Deaths_Cumulative) * 100;
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




                if (dataItem?.Cases_Daily.HasValue == true && dataItemDaybefore?.Cases_Cumulative.HasValue == true)
                {

                    cases.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = dataItem.Cases_Daily
                    });

                    double percentageIncreasecases = ((double)dataItem.Cases_Daily / (double)dataItemDaybefore.Cases_Cumulative) * 100;
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


                if (dataItem?.FirstDoses_Daily.HasValue == true)
                {

                    firstDoses.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = dataItem.FirstDoses_Daily
                    }); 

                }
                else
                {
                    firstDoses.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = null
                    });

                }

                if (dataItem?.SecondDoses_Daily.HasValue == true)
                {

                    secondDoses.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = dataItem.SecondDoses_Daily
                    });

                }
                else
                {
                    secondDoses.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = null
                    });

                }

                if (dataItem?.TotalDoses_Daily.HasValue == true)
                {

                    totalDoses.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = dataItem.TotalDoses_Daily
                    });

                }
                else
                {
                    totalDoses.Add(new SimpleRecord()
                    {
                        Date = dataItem.Date,
                        Value = null
                    });

                }

                if (dataItem?.VirusTests_Daily.HasValue == true && dataItem?.Cases_Daily.HasValue == true)
                {
                    double positivity = ((double)dataItem.Cases_Daily.Value / (double)dataItem.VirusTests_Daily.Value) * 100;

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
            SetDoseLowDay(firstDoses.ConvertAll(x => (BaseSimpleRecord)x));
            SetDoseLowDay(secondDoses.ConvertAll(x => (BaseSimpleRecord)x));
            SetDoseLowDay(totalDoses.ConvertAll(x => (BaseSimpleRecord)x));
            SetLowDay(casesPercentageIncrease.ConvertAll(x => (BaseSimpleRecord)x));
            SetLowDay(deathsPercentageIncrease.ConvertAll(x => (BaseSimpleRecord)x));
            SetLowDay(positivityRate.ConvertAll(x => (BaseSimpleRecord)x));

            var todayCases = cases[0];
            var todayDeaths = deaths[0];
            var todayFirstDoses = firstDoses[1];
            var todaySecondDoses = secondDoses[1];
            var todayTotalDoses = totalDoses[1];
            var todayCasesPercentageIncrease = casesPercentageIncrease[0];
            var todayDeathsPercentageIncrease = deathsPercentageIncrease[0];
            var todayPositivityRate = positivityRate[1];
            var yesterdayCases = cases[1];
            var yesterdayDeaths = deaths[1];
            var yesterdayFirstDoses = firstDoses[2];
            var yesterdaySecondDoses = secondDoses[2];
            var yesterdayTotalDoses = totalDoses[2];
            var yesterdayCasesPercentageIncrease = casesPercentageIncrease[1];
            var yesterdayDeathsPercentageIncrease = deathsPercentageIncrease[1];
            var yesterdayPositivityRate = positivityRate[2]; 

            var casesChange = CalculateChange(todayCases, yesterdayCases);
            var deathsChange = CalculateChange(todayDeaths, yesterdayDeaths);
            var firstDoseChange = CalculateChange(todayFirstDoses, yesterdayFirstDoses);
            var secondDoseChange = CalculateChange(todaySecondDoses, yesterdaySecondDoses);
            var totalDoseChange = CalculateChange(todayTotalDoses, yesterdayTotalDoses);
            var casesPercentageIncreaseChange = CalculateChange(todayCasesPercentageIncrease, yesterdayCasesPercentageIncrease);
            var deathsPercentageIncreaseChange = CalculateChange(todayDeathsPercentageIncrease, yesterdayDeathsPercentageIncrease);
            var positivityRateChange = CalculateChange(todayPositivityRate, yesterdayPositivityRate); 

            // Reorder from oldest to newest
            cases = cases.OrderBy(r => r.Date).ToList();
            deaths = deaths.OrderBy(r => r.Date).ToList();
            firstDoses = firstDoses.OrderBy(r => r.Date).ToList();
            secondDoses = secondDoses.OrderBy(r => r.Date).ToList();
            totalDoses = totalDoses.OrderBy(r => r.Date).ToList();
            casesPercentageIncrease = casesPercentageIncrease.OrderBy(r => r.Date).ToList();
            deathsPercentageIncrease = deathsPercentageIncrease.OrderBy(r => r.Date).ToList();
            positivityRate = positivityRate.OrderBy(r => r.Date).ToList();

            var summationResult =  new SummationResult()
            {  
                Date = TargetDate,
                Cases = cases,
                Deaths = deaths,
                FirstDoses = firstDoses,
                SecondDoses = secondDoses,
                TotalDoses = totalDoses,
                CasesPercentageIncrease = casesPercentageIncrease,
                DeathsPercentageIncrease = deathsPercentageIncrease,
                PositivityRate = positivityRate,
                TodayCases = todayCases,
                TodayDeaths = todayDeaths,
                TodayFirstDose = todayFirstDoses,
                TodaySecondDose = todaySecondDoses,
                TodayTotalDose = todayTotalDoses,
                TodayCasesPercentageIncrease = todayCasesPercentageIncrease,
                TodayDeathsPercentageIncrease = todayDeathsPercentageIncrease,
                TodayPositivityRate = todayPositivityRate,
                YesterdayCases =yesterdayCases,
                YesterdayDeaths = yesterdayDeaths,
                YesterdayFirstDose = yesterdayFirstDoses,
                YesterdaySecondDose = yesterdaySecondDoses,
                YesterdayTotalDose = yesterdayTotalDoses,
                YesterdayCasesPercentageIncrease = yesterdayCasesPercentageIncrease,
                YesterdayDeathsPercentageIncrease = yesterdayDeathsPercentageIncrease,
                YesterdayPositivityRate = yesterdayPositivityRate,
                CasesChange = casesChange,
                CasesPercentageIncreaseChange = casesPercentageIncreaseChange,
                DeathsChange = deathsChange,
                DeathsPercentageIncreaseChange = deathsPercentageIncreaseChange,
                FirstDoseChange = firstDoseChange,
                SecondDoseChange = secondDoseChange,
                TotalDoseChange = totalDoseChange,
                PositivityRateChange = positivityRateChange,
            };

            var list = new List<SummationResult>() { summationResult };

            return new Result<SummationResult>()
            {
                Records = list,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.LookbackEightDayQuery_Name, Url = result.Url }
                }
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
        private void SetDoseLowDay(List<BaseSimpleRecord> list)
        {
            foreach (var item in list)
            {
                item.IsLowDay = (item.Date.DayOfWeek == DayOfWeek.Friday || item.Date.DayOfWeek == DayOfWeek.Saturday);
            }
        }
    }
}
