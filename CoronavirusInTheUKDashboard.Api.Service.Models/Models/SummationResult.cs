using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models
{
    public class SummationResult : BaseRecord
    {
        public List<SimpleRecord> Cases { get; set; }
        public List<SimpleRecord> Deaths { get; set; }
        public List<SimpleRecord> FirstDoses { get; set; }
        public List<SimpleRecord> SecondDoses { get; set; }
        public List<SimpleRecord> TotalDoses { get; set; }
        public List<SimplePercentageRecord> CasesPercentageIncrease { get; set; }
        public List<SimplePercentageRecord> DeathsPercentageIncrease { get; set; }
        public List<SimplePercentageRecord> PositivityRate { get; set; }

        public Change CasesChange { get; set; }
        public Change CasesPercentageIncreaseChange { get; set; }
        public Change DeathsChange { get; set; }
        public Change DeathsPercentageIncreaseChange { get; set; }
        public Change FirstDoseChange { get; set; }
        public Change SecondDoseChange { get; set; }
        public Change TotalDoseChange { get; set; }
        public Change PositivityRateChange { get; set; }


        public SimpleRecord TodayCases { get; set; }
        public SimpleRecord TodayDeaths { get; set; }
        public SimpleRecord TodayFirstDose { get; set; }
        public SimpleRecord TodaySecondDose { get; set; }
        public SimpleRecord TodayTotalDose { get; set; }
        public SimplePercentageRecord TodayCasesPercentageIncrease { get; set; }
        public SimplePercentageRecord TodayDeathsPercentageIncrease { get; set; }
        public SimplePercentageRecord TodayPositivityRate { get; set; }


        public SimpleRecord YesterdayCases { get; set; }
        public SimpleRecord YesterdayDeaths { get; set; }
        public SimpleRecord YesterdayFirstDose { get; set; }
        public SimpleRecord YesterdaySecondDose { get; set; }
        public SimpleRecord YesterdayTotalDose { get; set; }
        public SimplePercentageRecord YesterdayCasesPercentageIncrease { get; set; }
        public SimplePercentageRecord YesterdayDeathsPercentageIncrease { get; set; }
        public SimplePercentageRecord YesterdayPositivityRate { get; set; }

    }
}
