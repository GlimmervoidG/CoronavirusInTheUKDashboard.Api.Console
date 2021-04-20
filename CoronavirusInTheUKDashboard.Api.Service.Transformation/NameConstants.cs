using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation
{
    public static class NameConstants
    {
        public const string DailyQuery_Title = "Title query";
        public const string DailyQuery_Name = "Daily query";
        public const string DailyQuery_Deaths = "Deaths in all settings (death within 28 days of test)";
        public const string DailyQuery_Cases = "Positive cases (pillars 1, 2 and parts of 4)";

        public const string LookbackQuery_Vaccine_Name = "Lookback Vaccine query";
        public const string LookbackQuery_Name = "Lookback query";
        public const string LookbackQuery_Lfd_Name = "Lookback query (England)";
        public const string LookbackQuery_CatchUp_Name = "Weekend Catch Up Lookback query";
        public const string LookbackQuery_Weekend_Lfd_Name = "Weekend Lookback query (England)";
        public const string LookbackQuery_National_England = "Lookback query (England)";
        public const string LookbackQuery_National_Ni = "Lookback query (Northern Ireland)";

        public const string LookbackQuery_Pillar1 = "Pillar 1 all tests processed";
        public const string LookbackQuery_Pillar2 = "Pillar 2 all tests processed";
        public const string LookbackQuery_Pillar3 = "Pillar 3 all tests processed";
        public const string LookbackQuery_Pillar4 = "Pillar 4 all tests processed";
        public const string LookbackQuery_PillarAll = "All tests processed (pillars 1 to 4)";
        public const string LookbackQuery_PcrTests = "All PCR tests processed (pillars 1, parts of 2 and parts of 4)";
        public const string LookbackQuery_LfdTests = "Lateral flow device tests conducted (England only)";


        public const string LookbackQuery_FirstDoseEngland = "First vaccination dose (England Only)";
        public const string LookbackQuery_SecondDoseEngland = "Second vaccination dose (England Only)";

        public const string LookbackQuery_FirstDoseNi = "First vaccination dose (Northern Ireland Only)";
        public const string LookbackQuery_SecondDoseNi = "Second vaccination dose (Northern Ireland Only)";

        public const string LookbackQuery_FirstDose = "First vaccination dose";
        public const string LookbackQuery_SecondDose = "Second vaccination dose";


        public const string NoneDailyQuery_Name = "Non daily query";
        public const string NoneDailyQuery_Capacity = "Testing capacity (all pillars)";
        public const string NoneDailyQuery_CapacityPCR = "PCR testing capacity (pillars 1, parts of 2 and parts of 4)";
        public const string NoneDailyQuery_PatientsInHospital = "Patients in hospital";
        public const string NoneDailyQuery_PatientsInVentilatorBeds = "Patients in ventilator beds";
        public const string NoneDailyQuery_PatientsAdmitted = "Patients admitted";
        public const string NoneDailyQuery_WeeklyOnsDeaths = "Deaths with COVID-19 on the death certificate in the last week";
        public const string NoneDailyQuery_TotalOnsDeaths = "Deaths with COVID-19 on the death certificate total";
        public const string NoneDailyQuery_WeeklyFirstDose = "First dose vaccinations in the last week";
        public const string NoneDailyQuery_TotalFirstDose = "First dose vaccinations total";
        public const string NoneDailyQuery_WeeklySecondDose = "Second dose vaccinations in the last week";
        public const string NoneDailyQuery_TotalSecondDose = "Second dose vaccinations total";

        public const string LookbackEightDayQuery_Name = "Eight day lookback query";

        public const string RegionBreakdownQuery_Overview_Today = "UK query";
        public const string RegionBreakdownQuery_Overview_Yesterday = "UK query yesterday";

        public const string RegionBreakdownQuery_National_Today = "Home Nations query";
        public const string RegionBreakdownQuery_National_Yesterday = "Home Nations query yesterday";

        public const string RegionBreakdownQuery_Region_Today = "English regions query";
        public const string RegionBreakdownQuery_Region_Yesterday = "English regions query yesterday";

        public const string RegionVaccineProgressQuery_Overview_Today = "UK query (Vaccine)";
        public const string RegionVaccineProgressQuery_Overview_Yesterday = "UK query yesterday (Vaccine)";

        public const string RegionVaccineProgressQuery_National_Today = "Home Nations query (Vaccine)";
        public const string RegionVaccineProgressQuery_National_Yesterday = "Home Nations query yesterday (Vaccine)";

        public const string RegionVaccineProgressQuery_Region_Today = "English regions query (Vaccine)";
        public const string RegionVaccineProgressQuery_Region_Yesterday = "English regions query yesterday (Vaccine)";

        public const string AdmissionsByAge = "Admissions by age";
    }
}
