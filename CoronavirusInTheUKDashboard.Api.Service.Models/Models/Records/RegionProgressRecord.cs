using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records
{
    public class RegionProgressRecord : BaseRecord
    {
        public long? FirstDoseTotal { get; set; }
        public long? FirstDoseDailyIncrease { get; set; }
        public double? FirstDosePercentageProgress { get; set; }
        public double? FirstDoseIncrease { get; set; }

        public long? SecondDoseTotal { get; set; }
        public long? SecondDoseDailyIncrease { get; set; }
        public double? SecondDosePercentageProgress { get; set; }
        public double? SecondDoseIncrease { get; set; }

        public long? ThirdDoseTotal { get; set; }
        public long? ThirdDoseDailyIncrease { get; set; }
        public double? ThirdDosePercentageProgress { get; set; }
        public double? ThirdDoseIncrease { get; set; }
    }
}