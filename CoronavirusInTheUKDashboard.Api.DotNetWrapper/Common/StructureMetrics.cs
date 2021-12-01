using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common
{
    public enum StructureMetrics
    {

        [MetricDescription("Area type as string",
        "",
        "")]
        areaType,

        [Description("Area name as string")]
        [MetricDescription("Area name as string",
        "",
        "")]
        areaName,

        [Description("Area Code as string")]
        [MetricDescription("Area Code as string",
        "",
        "")]
        areaCode,

        [Description("Date as string [YYYY-MM-DD]")]
        [MetricDescription("Date as string [YYYY-MM-DD]",
        "",
        "")]
        date,

        [Description("Unique ID as string")]
        [MetricDescription("nique ID as string",
        "",
        "")]
        hash,

        [MetricDescription("Capacity pillar 4",
        "Reported testing capacity for pillar 4 (COVID-19 testing for national surveillance).    The reported capacity on a given date is the same as the number of tests processed by pillar 4 on that day.",
        "https://coronavirus.data.gov.uk/metrics/doc/capacityPillarFour")]
        capacityPillarFour,

        [MetricDescription("Capacity pillar 1",
        "Projected testing capacity for pillar 1 (NHS and UKHSA COVID-19 testing).    Testing capacity is an estimate from labs of how many lab-based tests they have capacity to carry out each day, based on availability of staff and resources.",
        "https://coronavirus.data.gov.uk/metrics/doc/capacityPillarOne")]
        capacityPillarOne,

        [MetricDescription("Capacity for pillars 1 and 2",
        "Projected testing capacity for pillar 1 (NHS and UKHSA COVID-19 testing) and pillar 2 (COVID-19 testing under the UK government testing programme).   Testing capacity is an estimate from labs of how many lab-based tests they can carry out each day based on availability of staff and resources.",
        "https://coronavirus.data.gov.uk/metrics/doc/capacityPillarOneTwo")]
        capacityPillarOneTwo,

        [MetricDescription("Capacity pillar 3",
        "Projected testing capacity for pillar 3 (antibody serology testing to show if people have antibodies from past infection with COVID-19).   Testing capacity is an estimate from labs of how many lab-based tests they can carry out each day based on availability of staff and resources.",
        "https://coronavirus.data.gov.uk/metrics/doc/capacityPillarThree")]
        capacityPillarThree,

        [MetricDescription("Capacity pillar 2",
        "Capacity pillar 2",
        "https://coronavirus.data.gov.uk/metrics/doc/capacityPillarTwo")]
        capacityPillarTwo,

        [MetricDescription("Change in new cases by specimen date",
        "Latest daily change in the number of new cases (people who have had at least one positive COVID-19 test result) reported. The change includes newly-reported cases, and adjustments to previously-reported cases - these may go up or down. Data are presented by the date the sample was taken from the person being tested. These are shown together with the daily numbers of new cases that have already been reported to provide a breakdown of newly-reported and previously-reported cases.",
        "https://coronavirus.data.gov.uk/metrics/doc/changeInNewCasesBySpecimenDate")]
        changeInNewCasesBySpecimenDate,

        [MetricDescription("COVID occupied mechanical ventilator beds",
        "The number of COVID-19 patients in mechanical ventilated beds.",
        "https://coronavirus.data.gov.uk/metrics/doc/covidOccupiedMVBeds")]
        covidOccupiedMVBeds,

        [MetricDescription("Cumulative admissions",
        "Total number of patients admitted to hospital with COVID-19 since the start of the pandemic.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumAdmissions")]
        cumAdmissions,

        [MetricDescription("Cumulative admissions by age",
        "Total number of patients admitted to hospital with COVID-19 since the start of the pandemic, by age.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumAdmissionsByAge")]
        cumAdmissionsByAge,

        [MetricDescription("Cumulative antibody tests by publish date",
        "Total number of confirmed positive, negative or void COVID-19 antibody test results since the start of the pandemic. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumAntibodyTestsByPublishDate")]
        cumAntibodyTestsByPublishDate,

        [MetricDescription("Cumulative cases by publish date",
        "Total number of cases (people who have had at least one positive COVID-19 test result) since the start of the pandemic. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumCasesByPublishDate")]
        cumCasesByPublishDate,

        [MetricDescription("Cumulative cases by publish date rate",
        "Rate per 100,000 people of the total number of cases (people who have had at least one positive COVID-19 test result) since the start of the pandemic. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumCasesByPublishDateRate")]
        cumCasesByPublishDateRate,

        [MetricDescription("Cumulative cases by specimen date",
        "Total number of cases (people who have had at least one positive COVID-19 test result) since the start of the pandemic. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumCasesBySpecimenDate")]
        cumCasesBySpecimenDate,

        [MetricDescription("Cumulative cases by specimen date rate",
        "Rate per 100,000 people of the total number of cases (people who have had at least one positive COVID-19 test result) since the start of the pandemic. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumCasesBySpecimenDateRate")]
        cumCasesBySpecimenDateRate,

        [MetricDescription("Cumulative cases LFD confirmed by PCR by specimen date",
        "Total number of cases (people who have had at least one positive COVID-19 test result) identified by a positive rapid lateral flow (LFD) test and confirmed by a positive polymerase chain reaction (PCR) test taken within 3 days. Data are shown by the date the LFD test was taken.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumCasesLFDConfirmedPCRBySpecimenDate")]
        cumCasesLFDConfirmedPCRBySpecimenDate,

        [MetricDescription("Cumulative cases LFD-only by specimen date",
        "Total number of cases (people who have had at least one positive COVID-19 test result) identified by a positive rapid lateral flow (LFD) test and not confirmed by a positive polymerase chain reaction (PCR) test within 3 days since the start of the pandemic. Data are shown by the date the LFD test was taken.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumCasesLFDOnlyBySpecimenDate")]
        cumCasesLFDOnlyBySpecimenDate,

        [MetricDescription("Cumulative cases PCR only by specimen date",
        "Total number of cases (people who have had at least one positive COVID-19 test result) identified by a positive polymerase chain reaction (PCR) test, excluding people who had a positive rapid lateral flow (LFD) test within 3 days before the positive PCR test since the start of the pandemic. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumCasesPCROnlyBySpecimenDate")]
        cumCasesPCROnlyBySpecimenDate,

        [MetricDescription("Cumulative daily national statistics office deaths by death date",
        "Total number of deaths of people whose death certificate mentioned COVID-19 as one of the causes since the start of the pandemic. Data are reported by date of death. There is a lag in reporting of at least 11 days because the data are based on death registrations.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDailyNsoDeathsByDeathDate")]
        cumDailyNsoDeathsByDeathDate,

        [MetricDescription("Cumulative deaths within 28 days of a positive test by death date",
        "Total number people who died within 28 days of their first positive test for COVID-19 since the start of the pandemic. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeaths28DaysByDeathDate")]
        cumDeaths28DaysByDeathDate,

        [MetricDescription("Cumulative deaths within 28 days of a positive test rate by death date",
        "Rate per 100,000 people of the total number of people who died within 28 days of their first positive test for COVID-19 since the start of the pandemic. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeaths28DaysByDeathDateRate")]
        cumDeaths28DaysByDeathDateRate,

        [MetricDescription("Cumulative deaths within 28 days of a positive test by publish date",
        "Total number of people who died within 28 days of their first positive test for COVID-19 since the start of the pandemic. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeaths28DaysByPublishDate")]
        cumDeaths28DaysByPublishDate,

        [MetricDescription("Cumulative deaths within 28 days of a positive test rate by publish date",
        "Rate per 100,000 people of the total number of people who died within 28 days of their first positive test for COVID-19 since the start of the pandemic. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeaths28DaysByPublishDateRate")]
        cumDeaths28DaysByPublishDateRate,

        [MetricDescription("Cumulative deaths within 60 days of a positive test by death date",
        "Total number of people who either died within 60 days of their first positive test for COVID-19 or have COVID-19 mentioned on their death certificate, since the start of the pandemic. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeaths60DaysByDeathDate")]
        cumDeaths60DaysByDeathDate,

        [MetricDescription("Cumulative deaths within 60 days of a positive test rate by death date",
        "Rate per 100,000 people of the total number of people who either died within 60 days of their first positive test for COVID-19 or have COVID-19 mentioned on their death certificate, since the start of the pandemic. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeaths60DaysByDeathDateRate")]
        cumDeaths60DaysByDeathDateRate,

        [MetricDescription("Cumulative deaths within 60 days of a positive test by publish date",
        "Total number of people who either died within 60 days of their first positive test for COVID-19 or have COVID-19 mentioned on their death certificate, since the start of the pandemic. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeaths60DaysByPublishDate")]
        cumDeaths60DaysByPublishDate,

        [MetricDescription("Cumulative deaths within 60 days of a positive test rate by publish date",
        "Rate per 100,000 people of the total number of people who either died within 60 days of their first positive test for COVID-19 or have COVID-19 mentioned on their death certificate, since the start of the pandemic. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeaths60DaysByPublishDateRate")]
        cumDeaths60DaysByPublishDateRate,

        [MetricDescription("Cumulative deaths by death date",
        "Cumulative deaths by death date",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeathsByDeathDate")]
        cumDeathsByDeathDate,

        [MetricDescription("Cumulative deaths by death date rate",
        "Cumulative deaths by death date rate",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeathsByDeathDateRate")]
        cumDeathsByDeathDateRate,

        [MetricDescription("Cumulative deaths by publish date",
        "Cumulative deaths by publish date",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeathsByPublishDate")]
        cumDeathsByPublishDate,

        [MetricDescription("Cumulative deaths by publish date rate",
        "Cumulative deaths by publish date rate",
        "https://coronavirus.data.gov.uk/metrics/doc/cumDeathsByPublishDateRate")]
        cumDeathsByPublishDateRate,

        [MetricDescription("Cumulative LFD tests",
        "Total number of confirmed positive, negative or void rapid lateral flow (LFD) test results for COVID-19 reported since the start of the pandemic.   Lateral flow tests give results without needing to go to a laboratory, so results are reported online by people who have taken the tests. Because of this, not all test results may be reported.  Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumLFDTestsBySpecimenDate")]
        cumLFDTestsBySpecimenDate,

        [MetricDescription("Cumulative Office for National Statistics deaths by registration date",
        "Total number of deaths of people whose death certificate mentioned COVID-19 as one of the causes since the start of the pandemic. Data are reported by the date the death was registered. There is a lag in reporting of at least 11 days because the data are based on death registrations.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumOnsDeathsByRegistrationDate")]
        cumOnsDeathsByRegistrationDate,

        [MetricDescription("Cumulative ONS deaths by registration date rate",
        "Rate per 100,000 people of the total number of deaths of people whose death certificate mentioned COVID-19 as one of the causes since the start of the pandemic. Data are reported by the date the death was registered. There is a lag in reporting of at least 11 days because the data are based on death registrations.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumOnsDeathsByRegistrationDateRate")]
        cumOnsDeathsByRegistrationDateRate,

        [MetricDescription("Cumulative PCR tests by publish date",
        "Total number of confirmed positive, negative or void polymerase chain reaction (PCR) test results for COVID-19 since the start of the pandemic.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPCRTestsByPublishDate")]
        cumPCRTestsByPublishDate,

        [MetricDescription("Total PCR tests by specimen date",
        "Total number of positive, negative or void COVID-19 lab-based virus test results (excludes LFD tests). Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPCRTestsBySpecimenDate")]
        cumPCRTestsBySpecimenDate,

        [MetricDescription("Cumulative people vaccinated booster dose by publish date",
        "Total number of people who have received a top-up COVID-19 booster vaccination. These are currently offered to people at highest risk from COVID-19 who received their second dose at least 6 months ago, to give them longer-term protection. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPeopleVaccinatedBoosterDoseByPublishDate")]
        cumPeopleVaccinatedBoosterDoseByPublishDate,

        [MetricDescription("Cumulative people vaccinated 1st dose by publish date",
        "Total number of people who have received a first dose COVID-19 vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPeopleVaccinatedFirstDoseByPublishDate")]
        cumPeopleVaccinatedFirstDoseByPublishDate,

        [MetricDescription("Cumulative people vaccinated 1st dose by vaccination date",
        "Total number of people that have received a first dose COVID-19 vaccination. Data are shown by the date the vaccination was given.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPeopleVaccinatedFirstDoseByVaccinationDate")]
        cumPeopleVaccinatedFirstDoseByVaccinationDate,

        [MetricDescription("Cumulative people vaccinated 2nd dose by publish date",
        "Total number of people that have received a 2nd dose COVID-19 vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPeopleVaccinatedSecondDoseByPublishDate")]
        cumPeopleVaccinatedSecondDoseByPublishDate,

        [MetricDescription("Cumulative people vaccinated 2nd dose by vaccination date",
        "Total number of people that have received a 2nd dose COVID-19 vaccination. Data are shown by the date the vaccination was given.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPeopleVaccinatedSecondDoseByVaccinationDate")]
        cumPeopleVaccinatedSecondDoseByVaccinationDate,

        [MetricDescription("Cumulative people vaccinated 3rd dose by publish date",
        "Total number of people who have received a 3rd dose COVID-19 vaccination. These are currently offered to people over 12 with severely weakened immune systems. Unlike boosters, third doses are consisted part of your primary vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPeopleVaccinatedThirdDoseByPublishDate")]
        cumPeopleVaccinatedThirdDoseByPublishDate,

        [MetricDescription("Cumulative people vaccinated with a booster dose plus new people vaccinated with a third dose by publish date",
        "Total number of people who have received either a booster dose or a 3rd dose COVID-19 vaccination. Booster doses are currently offered to people at highest risk from COVID-19 who received their second dose at least 6 months ago, to give them longer-term protection. 3rd doses are currently offered to people over 12 with severely weakened immune systems. Unlike boosters, third doses are consisted part of your primary vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPeopleVaccinatedThirdInjectionByPublishDate")]
        cumPeopleVaccinatedThirdInjectionByPublishDate,

        [MetricDescription("Cumulative pillar 4 tests by publish date",
        "Total number of confirmed positive, negative or void COVID-19 tests conducted under pillar 4 (COVID-19 testing for national surveillance) since the start of the pandemic. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPillarFourTestsByPublishDate")]
        cumPillarFourTestsByPublishDate,

        [MetricDescription("Cumulative pillar 1 tests by publish date",
        "Total number of confirmed positive, negative or void COVID-19 tests conducted under pillar 1 (NHS and UKHSA COVID-19 testing) since the start of the pandemic. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPillarOneTestsByPublishDate")]
        cumPillarOneTestsByPublishDate,

        [MetricDescription("Cumulative pillars 1 and 2 tests by publish date",
        "Total number of confirmed positive, negative or void COVID-19 tests conducted under pillar 1 (NHS and UKHSA COVID-19 testing) and pillar 2 (the UK government COVID-19 testing programme) since the start of the pandemic. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPillarOneTwoTestsByPublishDate")]
        cumPillarOneTwoTestsByPublishDate,

        [MetricDescription("Cumulative pillar 3 tests by publish date",
        "Total number of confirmed positive, negative or void COVID-19 antibody tests conducted under pillar 3 (antibody serology testing) since the start of the pandemic. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPillarThreeTestsByPublishDate")]
        cumPillarThreeTestsByPublishDate,

        [MetricDescription("Cumulative pillar 2 tests by publish date",
        "Total number of confirmed positive, negative or void COVID-19 tests conducted under pillar 2 (the UK government COVID-19 testing programme) since the start of the pandemic. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumPillarTwoTestsByPublishDate")]
        cumPillarTwoTestsByPublishDate,

        [MetricDescription("Cumulative tests by publish date",
        "Total number of confirmed positive, negative or void COVID-19 test results, including both virus and antibody tests, since the start of the pandemic. Tests are counted at the time they are processed.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumTestsByPublishDate")]
        cumTestsByPublishDate,

        [MetricDescription("Cumulative percentage of people vaccinated with a booster dose by publish date",
        "Percentage of people aged 12 and over who have received a top-up COVID-19 booster vaccination. These are currently offered to people at highest risk from COVID-19 who received their second dose at least 6 months ago, to give them longer-term protection. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumVaccinationBoosterDoseUptakeByPublishDatePercentage")]
        cumVaccinationBoosterDoseUptakeByPublishDatePercentage,

        [MetricDescription("Cumulative vaccination 1st dose uptake by publish date percentage",
        "Percent of people aged 12 and over that have received a 1st dose COVID-19 vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumVaccinationFirstDoseUptakeByPublishDatePercentage")]
        cumVaccinationFirstDoseUptakeByPublishDatePercentage,

        [MetricDescription("Cumulative percentage of people vaccinated with a first dose by vaccination date",
        "Percent of people aged 12 and over that have received a 1st dose COVID-19 vaccination. Data are shown by the date the vaccination was given.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumVaccinationFirstDoseUptakeByVaccinationDatePercentage")]
        cumVaccinationFirstDoseUptakeByVaccinationDatePercentage,

        [MetricDescription("Cumulative vaccination 2nd dose uptake by publish date percentage",
        "Percent of people aged 12 and over that have received a 2nd dose COVID-19 vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumVaccinationSecondDoseUptakeByPublishDatePercentage")]
        cumVaccinationSecondDoseUptakeByPublishDatePercentage,

        [MetricDescription("Cumulative percentage of second dose vaccination uptake by vaccination date",
        "Percent of people aged 12 and over that have received a 2nd dose COVID-19 vaccination. Data are shown by the date the second dose vaccination was given.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumVaccinationSecondDoseUptakeByVaccinationDatePercentage")]
        cumVaccinationSecondDoseUptakeByVaccinationDatePercentage,

        [MetricDescription("Cumulative percentage of people vaccinated with a booster dose plus people vaccinated with third dose by publish date",
        "Percentage of people aged 12 and over who have received either a booster dose or a 3rd dose COVID-19 vaccination. Booster doses are currently offered to people at highest risk from COVID-19 who received their second dose at least 6 months ago, to give them longer-term protection. 3rd doses are currently offered to people over 12 with severely weakened immune systems. Unlike boosters, third doses are consisted part of your primary vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumVaccinationThirdInjectionUptakeByPublishDatePercentage")]
        cumVaccinationThirdInjectionUptakeByPublishDatePercentage,

        [MetricDescription("Cumulative vaccines given by publish date",
        "Percent of people aged 16 and over that have received a second dose COVID-19 vaccination since the start of the pandemic. A complete COVID-19 vaccination course is 2 doses given at least 21 days apart. Data are shown by the date the second dose vaccination was given.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumVaccinesGivenByPublishDate")]
        cumVaccinesGivenByPublishDate,

        [MetricDescription("Cumulative virus tests",
        "Total number of confirmed positive, negative or void COVID-19 virus test results since the start of the pandemic. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumVirusTestsByPublishDate")]
        cumVirusTestsByPublishDate,

        [MetricDescription("Total virus tests by specimen date",
        "Total number of positive, negative or void COVID-19 virus test results (including PCR and LFD tests). This is a count of test results and may include more than one test per person. Data are shown by the date the sample was taken from the person being tested.  Data for the most recent days are considered incomplete as it can take time for tests to have an outcome and be recorded on relevant lab systems. Due to different reporting routes, samples can sometimes be recorded twice.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumVirusTestsBySpecimenDate")]
        cumVirusTestsBySpecimenDate,

        [MetricDescription("Cumulative weekly national statistics office deaths by registration date",
        "Total number of deaths of people whose death certificate mentioned COVID-19 as one of the causes since the start of the pandemic, reported weekly. Data are reported by the date the death was registered. There is a lag in reporting of at least 11 days because the data are based on death registrations.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumWeeklyNsoDeathsByRegDate")]
        cumWeeklyNsoDeathsByRegDate,

        [MetricDescription("Cumulative weekly national statistics office deaths by registration date rate",
        "Rate per 100,000 people of the total number of deaths of people whose death certificate mentioned COVID-19 as one of the causes since the start of the pandemic, reported weekly. Data are reported by the date the death was registered. There is a lag in reporting of at least 11 days because the data are based on death registrations.",
        "https://coronavirus.data.gov.uk/metrics/doc/cumWeeklyNsoDeathsByRegDateRate")]
        cumWeeklyNsoDeathsByRegDateRate,

        [MetricDescription("Female cases",
        "Total number of female cases (people who have had at least one positive COVID-19 test result) since the start of the pandemic, by age. Some test results have missing age or sex, so the sum of the subgroups does not equal the total cases for the area.",
        "https://coronavirus.data.gov.uk/metrics/doc/femaleCases")]
        femaleCases,

        [MetricDescription("Female deaths within 28 days of a positive test",
        "Total number of females who had a positive test for COVID-19 and died within 28 days of their first positive test since the start of the pandemic, by age. Some records have missing age or sex, so the sum of the subgroups does not equal the total deaths for the area.",
        "https://coronavirus.data.gov.uk/metrics/doc/femaleDeaths28Days")]
        femaleDeaths28Days,

        [MetricDescription("Hospital cases",
        "Daily numbers of confirmed COVID-19 patients in hospital.",
        "https://coronavirus.data.gov.uk/metrics/doc/hospitalCases")]
        hospitalCases,

        [MetricDescription("Male cases",
        "Total number of male cases (people who have had at least one positive COVID-19 test result) since the start of the pandemic, by age. Some test results have missing age or sex, so the sum of the subgroups does not equal the total cases for the area.",
        "https://coronavirus.data.gov.uk/metrics/doc/maleCases")]
        maleCases,

        [MetricDescription("Male deaths within 28 days of a positive test",
        "Total number of males who had a positive test for COVID-19 and died within 28 days of their first positive test since the start of the pandemic, by age. Some records have missing age or sex, so the sum of the subgroups does not equal the total deaths for the area.",
        "https://coronavirus.data.gov.uk/metrics/doc/maleDeaths28Days")]
        maleDeaths28Days,

        [MetricDescription("New admissions",
        "Daily number of new admissions to hospital of patients with COVID-19.",
        "https://coronavirus.data.gov.uk/metrics/doc/newAdmissions")]
        newAdmissions,

        [MetricDescription("New admissions change",
        "The difference between the number of patients admitted to hospital with COVID-19 during the latest 7-day period and the number for the previous, non-overlapping, 7-day period.",
        "https://coronavirus.data.gov.uk/metrics/doc/newAdmissionsChange")]
        newAdmissionsChange,

        [MetricDescription("New admissions change percentage",
        "The percentage change in the number of patients admitted to hospital with COVID-19 during the latest 7-day period, reported as a percentage of the number for the previous, non-overlapping, 7-day period, by date reported.",
        "https://coronavirus.data.gov.uk/metrics/doc/newAdmissionsChangePercentage")]
        newAdmissionsChangePercentage,

        [MetricDescription("New admissions direction",
        "The direction of the change in the number of new patients admitted to hospital with COVID-19 during the latest 7-day period compared to the previous, non-overlapping, 7-day period.   Positive changes (shown with an up arrow) mean numbers are increasing. Negative changes (shown with a down arrow) mean numbers are decreasing.",
        "https://coronavirus.data.gov.uk/metrics/doc/newAdmissionsDirection")]
        newAdmissionsDirection,

        [MetricDescription("New admissions rolling rate",
        "Rate of new patients admitted to hospital with COVID-19 per 100,000 people in the rolling 7-day period ending on the dates shown.",
        "https://coronavirus.data.gov.uk/metrics/doc/newAdmissionsRollingRate")]
        newAdmissionsRollingRate,

        [MetricDescription("New admissions rolling sum",
        "The number of new patients admitted to hospital with COVID-19 within rolling 7-day periods.",
        "https://coronavirus.data.gov.uk/metrics/doc/newAdmissionsRollingSum")]
        newAdmissionsRollingSum,

        [MetricDescription("New antibody tests by publish date",
        "Daily numbers of new confirmed positive, negative or void COVID-19 antibody test results. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newAntibodyTestsByPublishDate")]
        newAntibodyTestsByPublishDate,

        [MetricDescription("New cases by publish date",
        "Daily numbers of new cases (people who have had at least one positive COVID-19 test result). Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesByPublishDate")]
        newCasesByPublishDate,

        [MetricDescription("New cases by publish date change",
        "The difference between the number of new cases (people who have had at least one positive COVID-19 test result) during the latest 7-day period and the number for the previous, non-overlapping, 7-day period. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesByPublishDateChange")]
        newCasesByPublishDateChange,

        [MetricDescription("New cases percentage change by publish date",
        "The percentage change in the number of new cases (people who have had at least one positive COVID-19 test result) during the latest 7-day period, as a percentage of the number for the previous, non-overlapping 7-day period. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesByPublishDateChangePercentage")]
        newCasesByPublishDateChangePercentage,

        [MetricDescription("New cases by publish date direction",
        "The direction of the change in the number of new cases (people who have had at least one positive COVID-19 test result) during the latest 7-day period compared to the previous, non-overlapping, 7-day period. Data are shown by the date the figures appeared in the published totals.   Positive changes (shown with an up arrow) mean numbers are increasing. Negative changes (shown with a down arrow) mean numbers are decreasing.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesByPublishDateDirection")]
        newCasesByPublishDateDirection,

        [MetricDescription("New cases by publish date rolling sum",
        "The number of new cases (people who have had at least one positive COVID-19 test result) within rolling 7-day periods. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesByPublishDateRollingSum")]
        newCasesByPublishDateRollingSum,

        [MetricDescription("New cases by specimen date",
        "Daily numbers of new cases (people who have had at least one positive COVID-19 test result). Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesBySpecimenDate")]
        newCasesBySpecimenDate,

        [MetricDescription("New cases by specimen date age demographics",
        "Age and sex breakdown of the daily numbers of new cases (people who have had at least one positive COVID-19 test result). Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesBySpecimenDateAgeDemographics")]
        newCasesBySpecimenDateAgeDemographics,

        [MetricDescription("New cases by specimen date change",
        "The difference between the number of new cases (people who have had at least one positive COVID-19 test result) during the latest 7-day period and the number for the previous, non-overlapping, 7-day period. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesBySpecimenDateChange")]
        newCasesBySpecimenDateChange,

        [MetricDescription("New cases percentage change by specimen date",
        "The percentage change in the number of new cases (people who have had at least one positive COVID-19 test result) during the latest 7-day period, as a percentage of the number for the previous, non-overlapping, 7-day period. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesBySpecimenDateChangePercentage")]
        newCasesBySpecimenDateChangePercentage,

        [MetricDescription("New cases by specimen date direction",
        "The direction of the change in the number of new cases (people who have had at least one positive COVID-19 test result) during the latest 7-day period compared to the previous, non-overlapping 7-day period. Data are shown by the date the sample was taken from the person being tested.  Positive changes (shown with an up arrow) mean numbers are increasing. Negative changes (shown with a down arrow) mean numbers are decreasing.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesBySpecimenDateDirection")]
        newCasesBySpecimenDateDirection,

        [MetricDescription("New cases rolling rate by specimen date",
        "Rate per 100,000 people of the number of new cases (people who have had at least one positive COVID-19 test result) in the rolling 7-day period ending on the dates shown. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesBySpecimenDateRollingRate")]
        newCasesBySpecimenDateRollingRate,

        [MetricDescription("New cases by specimen date rolling sum",
        "The number of new cases (people who have had at least one positive COVID-19 test result) within rolling 7-day periods. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesBySpecimenDateRollingSum")]
        newCasesBySpecimenDateRollingSum,

        [MetricDescription("New cases LFD confirmed by PCR by specimen date",
        "Daily number of new cases (people who have had at least one positive COVID-19 test result) identified by a positive rapid lateral flow (LFD) test and confirmed by a positive polymerase chain reaction (PCR) test taken within 3 days. Data are shown by the date the LFD test was taken.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesLFDConfirmedPCRBySpecimenDate")]
        newCasesLFDConfirmedPCRBySpecimenDate,

        [MetricDescription("New cases LFD confirmed by PCR rolling rate by specimen date",
        "Rate per 100,000 people of the number of new cases (people who have had at least one positive COVID-19 test result) identified by a positive rapid lateral flow (LFD) test and confirmed by a positive polymerase chain reaction (PCR) test taken within 3 days in the rolling 7-day period ending on the date shown. Data are shown by the date the LFD test was taken.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesLFDConfirmedPCRBySpecimenDateRollingRate")]
        newCasesLFDConfirmedPCRBySpecimenDateRollingRate,

        [MetricDescription("New cases LFD confirmed by PCR rolling sum by specimen date",
        "The number of new cases (people who have had at least one positive COVID-19 test result) identified by a positive rapid lateral flow (LFD) test and confirmed by a positive polymerase chain reaction (PCR) test taken within 3 days, within rolling 7-day periods. Data are shown by the date the LFD test was taken.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesLFDConfirmedPCRBySpecimenDateRollingSum")]
        newCasesLFDConfirmedPCRBySpecimenDateRollingSum,

        [MetricDescription("New cases LFD only by specimen date",
        "Daily numbers of new cases (people who have had at least one positive COVID-19 test result) identified by a rapid lateral flow (LFD) test and not confirmed by a positive polymerase chain reaction (PCR) test within 3 days. Data are shown by the date the LFD test was taken.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesLFDOnlyBySpecimenDate")]
        newCasesLFDOnlyBySpecimenDate,

        [MetricDescription("New cases LFD only rolling rate by specimen date",
        "Rate per 100,000 people of the number of new cases (people who have had at least one positive COVID-19 test result) identified by a positive rapid lateral flow (LFD) test and not confirmed by a positive polymerase chain reaction (PCR) test taken within 3 days in the rolling 7-day period ending on the date shown. Data are shown by the date the LFD test was taken.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesLFDOnlyBySpecimenDateRollingRate")]
        newCasesLFDOnlyBySpecimenDateRollingRate,

        [MetricDescription("New cases LFD only rolling sum by specimen date",
        "The number of new cases (people who have had at least one positive COVID-19 test result) that were identified by a positive rapid lateral flow (LFD) test and were not confirmed by a positive polymerase chain reaction (PCR) test taken within 3 days, within rolling 7-day periods. Data are shown by the date the lateral flow test was taken.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesLFDOnlyBySpecimenDateRollingSum")]
        newCasesLFDOnlyBySpecimenDateRollingSum,

        [MetricDescription("New cases PCR only by specimen date",
        "Daily numbers of new cases (people who have had at least one positive COVID-19 test result) identified by a positive polymerase chain reaction (PCR) test, excluding people who had a positive rapid lateral flow (LFD) test within 3 days before the positive PCR test. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesPCROnlyBySpecimenDate")]
        newCasesPCROnlyBySpecimenDate,

        [MetricDescription("New cases PCR only by specimen date rolling rate",
        "Rate per 100,000 people of the number of new cases (people who have had at least one positive COVID-19 test result) identified by a positive polymerase chain reaction (PCR) test, excluding people who had a positive rapid lateral flow (LFD) test within 3 days before the positive PCR test, in the rolling 7-day period ending on the dates shown. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesPCROnlyBySpecimenDateRollingRate")]
        newCasesPCROnlyBySpecimenDateRollingRate,

        [MetricDescription("New cases PCR only by specimen date rolling sum",
        "The number of new cases (people who have had at least one positive COVID-19 test result)  identified by a positive polymerase chain reaction (PCR) test, excluding people who had a positive rapid lateral flow (LFD) test within 3 days before the positive PCR test, within rolling 7-day periods. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newCasesPCROnlyBySpecimenDateRollingSum")]
        newCasesPCROnlyBySpecimenDateRollingSum,

        [MetricDescription("New daily national statistics office deaths by death date",
        "Daily numbers of deaths of people whose death certificate mentioned COVID-19 as one of the causes. Data are reported by date of death. There is a lag in reporting of at least 11 days because the data are based on death registrations.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDailyNsoDeathsByDeathDate")]
        newDailyNsoDeathsByDeathDate,

        [MetricDescription("New deaths within 28 days of a positive test by death date",
        "Daily numbers of people who died within 28 days of their first positive test for COVID-19. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByDeathDate")]
        newDeaths28DaysByDeathDate,

        [MetricDescription("New deaths 28 days by death date age demographics",
        "Daily numbers of people who died within 28 days of their first positive test for COVID-19, broken down by age and sex. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByDeathDateAgeDemographics")]
        newDeaths28DaysByDeathDateAgeDemographics,

        [MetricDescription("New deaths within 28 days of a positive test rate by death date",
        "Rate per 100,000 people of the daily numbers of people who died within 28 days of their first positive test COVID-19. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByDeathDateRate")]
        newDeaths28DaysByDeathDateRate,

        [MetricDescription("New deaths within 28 days of a positive test rolling rate by death date",
        "Rate per 100,000 people of the number of people who died within 28 days of their first positive test for COVID-19 in the rolling 7-day period ending on the dates shown. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByDeathDateRollingRate")]
        newDeaths28DaysByDeathDateRollingRate,

        [MetricDescription("New deaths within 28 days of a positive test rolling sum test by death date",
        "The number of people who died within 28 days of their first positive test for COVID-19 within rolling 7-day periods. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByDeathDateRollingSum")]
        newDeaths28DaysByDeathDateRollingSum,

        [MetricDescription("New deaths 28 days of a positive test by publish date",
        "Daily numbers of people who died within 28 days of their first positive test for COVID-19. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByPublishDate")]
        newDeaths28DaysByPublishDate,

        [MetricDescription("New deaths within 28 days of a positive test by publish date change",
        "The difference between the number of people who died within 28 days of their first positive test for COVID-19 during the latest 7-day period and the number for the previous, non-overlapping, 7-day period. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByPublishDateChange")]
        newDeaths28DaysByPublishDateChange,

        [MetricDescription("New deaths within 28 days of a positive test change percentage by publish date",
        "The percentage change in the number of people who died within 28 days of their first positive test for COVID-19 during the latest 7-day period, as a percentage of the number for the previous, non-overlapping, 7-day period. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByPublishDateChangePercentage")]
        newDeaths28DaysByPublishDateChangePercentage,

        [MetricDescription("New deaths within 28 days of a positive test direction by publish date",
        "The direction of the change in the number of people who died within 28 days of their first positive test for COVID-19 during the latest 7-day period compared to the previous, non-overlapping, 7-day period. Data are shown by the date the figures appeared in the published totals.  Positive changes (shown with an up arrow) mean numbers are increasing. Negative changes (shown with a down arrow) mean numbers are decreasing.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByPublishDateDirection")]
        newDeaths28DaysByPublishDateDirection,

        [MetricDescription("New deaths within 28 days of a positive test rolling sum by publish date",
        "The number of people who died within 28 days of their first positive test for COVID-19 within rolling 7-day periods. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths28DaysByPublishDateRollingSum")]
        newDeaths28DaysByPublishDateRollingSum,

        [MetricDescription("New deaths within 60 days of a positive test by death date",
        "Daily numbers of people who either died within 60 days of their first positive test for COVID-19 or have COVID-19 mentioned on their death certificate. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths60DaysByDeathDate")]
        newDeaths60DaysByDeathDate,

        [MetricDescription("New deaths within 60 days of a positive test rate by death date",
        "Rate per 100,000 people of the daily number of deaths of people who had a positive test for COVID-19 and either died within 60 days of their first positive test or have COVID-19 mentioned on their death certificate. Data are shown by the dates the deaths occurred.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths60DaysByDeathDateRate")]
        newDeaths60DaysByDeathDateRate,

        [MetricDescription("New deaths within 60 days of a positive test rolling rate by death date",
        "Rate per 100,000 people of the number of people who either died within 60 days of their first positive test for COVID-19 or have COVID-19 mentioned on their death certificate in the rolling 7-day period ending on the dates shown. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths60DaysByDeathDateRollingRate")]
        newDeaths60DaysByDeathDateRollingRate,

        [MetricDescription("New deaths within 60 days of a positive test rolling sum by death date",
        "The number of people who either died within 60 days of their first positive test for COVID-19 or have COVID-19 mentioned on their death certificate within rolling 7-day periods. Data are shown by date of death.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths60DaysByDeathDateRollingSum")]
        newDeaths60DaysByDeathDateRollingSum,

        [MetricDescription("New deaths within 60 days of a positive test by publish date",
        "Daily numbers of people who either died within 60 days of their first positive test for COVID-19 or have COVID-19 mentioned on their death certificate. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeaths60DaysByPublishDate")]
        newDeaths60DaysByPublishDate,

        [MetricDescription("New deaths by death date",
        "New deaths by death date",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeathsByDeathDate")]
        newDeathsByDeathDate,

        [MetricDescription("New deaths by death date rate",
        "New deaths by death date rate",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeathsByDeathDateRate")]
        newDeathsByDeathDateRate,

        [MetricDescription("New deaths by death date rolling rate",
        "New deaths by death date rolling rate",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeathsByDeathDateRollingRate")]
        newDeathsByDeathDateRollingRate,

        [MetricDescription("New deaths by death date rolling sum",
        "New deaths by death date rolling sum",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeathsByDeathDateRollingSum")]
        newDeathsByDeathDateRollingSum,

        [MetricDescription("New deaths by publish date",
        "New deaths by publish date",
        "https://coronavirus.data.gov.uk/metrics/doc/newDeathsByPublishDate")]
        newDeathsByPublishDate,

        [MetricDescription("New LFD tests",
        "Daily numbers of new confirmed positive, negative or void rapid lateral flow (LFD) test results for COVID-19. Lateral flow tests give results without needing to go to a laboratory, so results are reported online by people who have taken the tests. Because of this, not all test results may be reported. Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newLFDTestsBySpecimenDate")]
        newLFDTestsBySpecimenDate,

        [MetricDescription("New Office for National Statistics deaths by registration date",
        "Daily numbers of deaths of people whose death certificate mentioned COVID-19 as one of the causes. Data are reported by the dates the deaths were registered. There is a lag in reporting of at least 11 days because the data are based on death registrations.",
        "https://coronavirus.data.gov.uk/metrics/doc/newOnsDeathsByRegistrationDate")]
        newOnsDeathsByRegistrationDate,

        [MetricDescription("New PCR tests by publish date",
        "Daily numbers of new confirmed positive, negative or void polymerase chain reaction (PCR) test results. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPCRTestsByPublishDate")]
        newPCRTestsByPublishDate,

        [MetricDescription("New PCR tests by publish date change",
        "New PCR tests by publish date change",
        "https://coronavirus.data.gov.uk/metrics/doc/newPCRTestsByPublishDateChange")]
        newPCRTestsByPublishDateChange,

        [MetricDescription("New PCR tests by publish date change percentage",
        "The percentage change in the number of new confirmed positive, negative or void polymerase chain reaction (PCR) test results during the latest 7-day period, as a percentage of the number for the previous, non-overlapping 7-day period. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPCRTestsByPublishDateChangePercentage")]
        newPCRTestsByPublishDateChangePercentage,

        [MetricDescription("New PCR tests by publish date direction",
        "The direction of the change in the number of new confirmed positive, negative or void polymerase chain reaction (PCR) test results during the latest 7-day period compared to the previous, non-overlapping, 7-day period. Data are shown by the date the figures appeared in the published totals.    Positive changes (shown with an up arrow) mean numbers are increasing. Negative changes (shown with a down arrow) mean numbers are decreasing.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPCRTestsByPublishDateDirection")]
        newPCRTestsByPublishDateDirection,

        [MetricDescription("New PCR tests by publish date rolling sum",
        "The number of new confirmed positive, negative or void polymerase chain reaction (PCR) test results within rolling 7-day periods. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPCRTestsByPublishDateRollingSum")]
        newPCRTestsByPublishDateRollingSum,

        [MetricDescription("New PCR tests by specimen date",
        "Total number of positive, negative or void COVID-19 lab-based virus test results (excludes LFD tests). Data are shown by the date the sample was taken from the person being tested.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPCRTestsBySpecimenDate")]
        newPCRTestsBySpecimenDate,

        [MetricDescription("New people receiving 1st dose",
        "New people receiving 1st dose",
        "https://coronavirus.data.gov.uk/metrics/doc/newPeopleReceivingFirstDose")]
        newPeopleReceivingFirstDose,

        [MetricDescription("New people receiving 2nd dose",
        "New people receiving 2nd dose",
        "https://coronavirus.data.gov.uk/metrics/doc/newPeopleReceivingSecondDose")]
        newPeopleReceivingSecondDose,

        [MetricDescription("New people vaccinated with a booster dose by publish date",
        "Daily numbers of new people who have received a top-up COVID-19 booster vaccination. These are currently offered to people at highest risk from COVID-19 who received their second dose at least 6 months ago, to give them longer-term protection. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPeopleVaccinatedBoosterDoseByPublishDate")]
        newPeopleVaccinatedBoosterDoseByPublishDate,

        [MetricDescription("New people vaccinated 1st dose by publish date",
        "Daily numbers of new people that have received a 1st dose COVID-19 vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPeopleVaccinatedFirstDoseByPublishDate")]
        newPeopleVaccinatedFirstDoseByPublishDate,

        [MetricDescription("New people vaccinated with a first dose by vaccination date",
        "Daily numbers of new people that have received a 1st dose COVID-19 vaccination. Data are shown by the date the vaccination was given.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPeopleVaccinatedFirstDoseByVaccinationDate")]
        newPeopleVaccinatedFirstDoseByVaccinationDate,

        [MetricDescription("New people vaccinated 2nd dose by publish date",
        "Daily numbers of new people that have received a 2nd dose COVID-19 vaccination.  Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPeopleVaccinatedSecondDoseByPublishDate")]
        newPeopleVaccinatedSecondDoseByPublishDate,

        [MetricDescription("New people vaccinated with a second dose by vaccination date",
        "Daily numbers of new people that have received a 2nd dose COVID-19 vaccination.  Data are shown by the date the second dose vaccination was given.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPeopleVaccinatedSecondDoseByVaccinationDate")]
        newPeopleVaccinatedSecondDoseByVaccinationDate,

        [MetricDescription("New people vaccinated with a third dose by publish date",
        "Daily numbers of new people who have received a 3rd dose vaccination. These are currently offered to people over 12 with severely weakened immune systems. Unlike boosters, third doses are consisted part of your primary vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPeopleVaccinatedThirdDoseByPublishDate")]
        newPeopleVaccinatedThirdDoseByPublishDate,

        [MetricDescription("New people vaccinated with a booster dose plus new people vaccinated with a third dose by publish date",
        "Daily numbers of new people who have received either a booster dose or a 3rd dose COVID-19 vaccination.   Booster doses are currently offered to people at highest risk from COVID-19 who received their second dose at least 6 months ago, to give them longer-term protection.   3rd doses are currently offered to people over 12 with severely weakened immune systems. Unlike boosters, third doses are consisted part of your primary vaccination. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPeopleVaccinatedThirdInjectionByPublishDate")]
        newPeopleVaccinatedThirdInjectionByPublishDate,

        [MetricDescription("New pillar 4 tests by publish date",
        "Daily numbers of new confirmed positive, negative or void COVID-19 tests conducted under pillar 4 (COVID-19 testing for national surveillance). Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPillarFourTestsByPublishDate")]
        newPillarFourTestsByPublishDate,

        [MetricDescription("New pillar 1 tests by publish date",
        "Daily numbers of new confirmed positive, negative or void COVID-19 tests conducted under pillar 1 (NHS and UKHSA COVID-19 testing). Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPillarOneTestsByPublishDate")]
        newPillarOneTestsByPublishDate,

        [MetricDescription("New pillars 1 and 2 tests by publish date",
        "Daily numbers of new confirmed positive, negative or void COVID-19 tests conducted under pillar 1 (NHS and UKHSA COVID-19 testing) and pillar 2 (the UK government COVID-19 testing programme). Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPillarOneTwoTestsByPublishDate")]
        newPillarOneTwoTestsByPublishDate,

        [MetricDescription("New pillar 3 tests by publish date",
        "Daily numbers of new confirmed positive, negative or void COVID-19 antibody tests conducted under pillar 3 (antibody serology testing). Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPillarThreeTestsByPublishDate")]
        newPillarThreeTestsByPublishDate,

        [MetricDescription("New pillar 2 tests by publish date",
        "Daily numbers of new confirmed positive, negative or void COVID-19 tests conducted under pillar 2 (the UK government COVID-19 testing programme). Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newPillarTwoTestsByPublishDate")]
        newPillarTwoTestsByPublishDate,

        [MetricDescription("New tests by publish date",
        "Daily numbers of new confirmed positive, negative or void COVID-19 virus test results, including both virus and antibody tests. Tests are counted at the time they are processed.",
        "https://coronavirus.data.gov.uk/metrics/doc/newTestsByPublishDate")]
        newTestsByPublishDate,

        [MetricDescription("New vaccines given by publish date",
        "Daily numbers of new vaccines (all doses) given since the start of the pandemic. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newVaccinesGivenByPublishDate")]
        newVaccinesGivenByPublishDate,

        [MetricDescription("New virus tests",
        "Daily numbers of new confirmed positive, negative or void COVID-19 virus test results. Data are shown by the date the figures appeared in the published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/newVirusTestsByPublishDate")]
        newVirusTestsByPublishDate,

        [MetricDescription("New virus tests by specimen date",
        "Daily number of positive, negative or void COVID-19 virus test results (including PCR and LFD tests). This is a count of test results and may include more than one test per person. Data are shown by the date the sample was taken from the person being tested.  Data for the most recent days are considered incomplete as it can take time for tests to have an outcome and be recorded on relevant lab systems. Due to different reporting routes, samples can sometimes be recorded twice.",
        "https://coronavirus.data.gov.uk/metrics/doc/newVirusTestsBySpecimenDate")]
        newVirusTestsBySpecimenDate,

        [MetricDescription("New virus tests change",
        "The difference between the number of new confirmed positive, negative or void COVID-19 virus test results during the latest 7-day period and the number for the previous, non-overlapping, 7-day period. Tests are counted at the time they are processed.",
        "https://coronavirus.data.gov.uk/metrics/doc/newVirusTestsChange")]
        newVirusTestsChange,

        [MetricDescription("New virus tests change percentage",
        "The percentage change in the number of new confirmed positive, negative or void COVID-19 virus test results during the latest 7-day period, as a percentage of the number for the previous, non-overlapping 7-day period. Tests are counted at the time they are processed.",
        "https://coronavirus.data.gov.uk/metrics/doc/newVirusTestsChangePercentage")]
        newVirusTestsChangePercentage,

        [MetricDescription("New virus tests direction",
        "The direction of the change in the number of new confirmed positive, negative or void COVID-19 virus test results during the latest 7-day period compared to the previous, non-overlapping, 7-day period. Tests are counted at the time they are processed.   Positive changes (shown with an up arrow) mean numbers are increasing. Negative changes (shown with a down arrow) mean numbers are decreasing.",
        "https://coronavirus.data.gov.uk/metrics/doc/newVirusTestsDirection")]
        newVirusTestsDirection,

        [MetricDescription("New virus tests rolling sum",
        "The number of new confirmed positive, negative or void COVID-19 virus test results within rolling 7-day periods. Tests are counted at the time they are processed.",
        "https://coronavirus.data.gov.uk/metrics/doc/newVirusTestsRollingSum")]
        newVirusTestsRollingSum,

        [MetricDescription("New weekly national statistics office deaths by registration date",
        "Weekly numbers of deaths of people whose death certificate mentioned COVID-19 as one of the causes. Data are reported by the date the death was registered. There is a lag in reporting of at least 11 days because the data are based on death registrations.",
        "https://coronavirus.data.gov.uk/metrics/doc/newWeeklyNsoDeathsByRegDate")]
        newWeeklyNsoDeathsByRegDate,

        [MetricDescription("Planned antibody capacity by publish date",
        "Estimated daily capacity for antibody serology testing reported by laboratories. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/plannedAntibodyCapacityByPublishDate")]
        plannedAntibodyCapacityByPublishDate,

        [MetricDescription("Planned capacity by publish date",
        "Estimated daily capacity for testing reported by laboratories across all pillars of the UK government's mass testing programme.    Testing capacity is an estimate from labs of how many lab-based tests they can carry out each day based on availability of staff and resources. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/plannedCapacityByPublishDate")]
        plannedCapacityByPublishDate,

        [MetricDescription("Planned PCR capacity by publish date",
        "Estimated daily capacity for polymerase chain reaction (PCR) testing reported by laboratories across all pillars of the UK government's mass testing programme. Testing capacity is an estimate from labs of how many lab-based tests they can carry out each day based on availability of staff and resources. Data are shown by the date the figures appeared in published totals.",
        "https://coronavirus.data.gov.uk/metrics/doc/plannedPCRCapacityByPublishDate")]
        plannedPCRCapacityByPublishDate,

        [MetricDescription("Previously reported new cases by specimen date",
        "Daily numbers of new cases (people who have had at least one positive COVID-19 test result) that have already been reported. Data are shown by the date the sample was taken from the person being tested.  These are shown together with the latest daily change in new cases to provide a breakdown of newly-reported and previously-reported cases.",
        "https://coronavirus.data.gov.uk/metrics/doc/previouslyReportedNewCasesBySpecimenDate")]
        previouslyReportedNewCasesBySpecimenDate,

        [MetricDescription("Maximum transmission growth rate",
        "# The estimated R value (transmission rate) and daily infection growth rate   The reproduction number (R) is the average number of secondary infections produced by a single infected person. The infection growth rate is an approximation of the percentage change in the number of infections each day and indicates how quickly the number of infections is changing. Both estimates are shown as ranges, from minimum to maximum.",
        "https://coronavirus.data.gov.uk/metrics/doc/transmissionRateGrowthRateMax")]
        transmissionRateGrowthRateMax,

        [MetricDescription("Transmission rate growth rate min",
        "# The estimated R value (transmission rate) and daily infection growth rate   The reproduction number (R) is the average number of secondary infections produced by a single infected person. The infection growth rate is an approximation of the percentage change in the number of infections each day and indicates how quickly the number of infections is changing. Both estimates are shown as ranges, from minimum to maximum.",
        "https://coronavirus.data.gov.uk/metrics/doc/transmissionRateGrowthRateMin")]
        transmissionRateGrowthRateMin,

        [MetricDescription("Maximum transmission rate (R)",
        "# The estimated R value (transmission rate) and daily infection growth rate   The reproduction number (R) is the average number of secondary infections produced by a single infected person. The infection growth rate is an approximation of the percentage change in the number of infections each day and indicates how quickly the number of infections is changing. Both estimates are shown as ranges, from minimum to maximum.",
        "https://coronavirus.data.gov.uk/metrics/doc/transmissionRateMax")]
        transmissionRateMax,

        [MetricDescription("Minimum transmission rate (R)",
        "# The estimated R value (transmission rate) and daily infection growth rate   The reproduction number (R) is the average number of secondary infections produced by a single infected person. The infection growth rate is an approximation of the percentage change in the number of infections each day and indicates how quickly the number of infections is changing. Both estimates are shown as ranges, from minimum to maximum.",
        "https://coronavirus.data.gov.uk/metrics/doc/transmissionRateMin")]
        transmissionRateMin,

        [MetricDescription("Unique case positivity by specimen date rolling sum",
        "The percentage of people who took a polymerase chain reaction (PCR) test for COVID-19 in rolling 7-day periods who had at least one positive COVID-19 PCR test result in the same 7 days. Data are shown by the date the sample was taken from the person being tested. People who tested more than once in the 7-day period are only counted once in the denominator, and people with more than one positive test result in the period are only counted once in the numerator.",
        "https://coronavirus.data.gov.uk/metrics/doc/uniqueCasePositivityBySpecimenDateRollingSum")]
        uniqueCasePositivityBySpecimenDateRollingSum,

        [MetricDescription("Unique people tested by specimen date rolling sum",
        "The number of people who took a polymerase chain reaction (PCR) test for COVID-19 within rolling 7-day periods. Data are presented by the date the sample was taken from the person being tested. People who tested more than once during the 7-day period are only counted once.",
        "https://coronavirus.data.gov.uk/metrics/doc/uniquePeopleTestedBySpecimenDateRollingSum")]
        uniquePeopleTestedBySpecimenDateRollingSum,

        [MetricDescription("Vaccinations age demographics breakdown",
        "Vaccinations age demographics breakdown",
        "https://coronavirus.data.gov.uk/metrics/doc/vaccinationsAgeDemographics")]
        vaccinationsAgeDemographics,

        [MetricDescription("Vaccination register (NIMS) population by vaccination date",
        "Vaccination register (NIMS) population by vaccination date",
        "https://coronavirus.data.gov.uk/metrics/doc/VaccineRegisterPopulationByVaccinationDate")]
        VaccineRegisterPopulationByVaccinationDate,

        [MetricDescription("Weekly people vaccinated 1st dose by vaccination date",
        "Weekly people vaccinated 1st dose by vaccination date",
        "https://coronavirus.data.gov.uk/metrics/doc/weeklyPeopleVaccinatedFirstDoseByVaccinationDate")]
        weeklyPeopleVaccinatedFirstDoseByVaccinationDate,

        [MetricDescription("Weekly people vaccinated 2nd dose by vaccination date",
        "Weekly people vaccinated 2nd dose by vaccination date",
        "https://coronavirus.data.gov.uk/metrics/doc/weeklyPeopleVaccinatedSecondDoseByVaccinationDate")]
        weeklyPeopleVaccinatedSecondDoseByVaccinationDate

    }
}
