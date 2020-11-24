using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common
{
    public enum StructureMetrics
    {
        [Description("Area type as string")]
        areaType,

        [Description("Area name as string")]
        areaName,

        [Description("Area Code as string")]
        areaCode,

        [Description("Date as string [YYYY-MM-DD]")]
        date,

        [Description("Unique ID as string")]
        hash,

        [Description("New cases by publish date")]
        newCasesByPublishDate,

        [Description("Cumulative cases by publish date")]
        cumCasesByPublishDate,

        [Description("Rate of cumulative cases by publish date per 100k resident population")]
        cumCasesBySpecimenDateRate,

        [Description("New cases by specimen date")]
        newCasesBySpecimenDate,

        [Description("Cumulative cases by specimen date")]
        cumCasesBySpecimenDate,

        [Description("Male cases (by age)")]
        maleCases,

        [Description("Female cases (by age)")]
        femaleCases,

        [Description("New pillar one tests by publish date")]
        newPillarOneTestsByPublishDate,

        [Description("Cumulative pillar one tests by publish date")]
        cumPillarOneTestsByPublishDate,

        [Description("New pillar two tests by publish date")]
        newPillarTwoTestsByPublishDate,

        [Description("Cumulative pillar two tests by publish date")]
        cumPillarTwoTestsByPublishDate,

        [Description("New pillar three tests by publish date")]
        newPillarThreeTestsByPublishDate,

        [Description("Cumulative pillar three tests by publish date")]
        cumPillarThreeTestsByPublishDate,

        [Description("New pillar four tests by publish date")]
        newPillarFourTestsByPublishDate,

        [Description("Cumulative pillar four tests by publish date")]
        cumPillarFourTestsByPublishDate,

        [Description("New admissions")]
        newAdmissions,

        [Description("Cumulative number of admissions")]
        cumAdmissions,

        [Description("Cumulative admissions by age")]
        cumAdmissionsByAge,

        [Description("Cumulative tests by publish date")]
        cumTestsByPublishDate,

        [Description("New tests by publish date")]
        newTestsByPublishDate,

        [Description("COVID-19 occupied beds with mechanical ventilators")]
        covidOccupiedMVBeds,

        [Description("Hospital cases")]
        hospitalCases,

        [Description("Planned capacity by publish date")]
        plannedCapacityByPublishDate,

        [Description("Deaths within 28 days of positive test")]
        newDeaths28DaysByPublishDate,

        [Description("Cumulative deaths within 28 days of positive test")]
        cumDeaths28DaysByPublishDate,

        [Description("Rate of cumulative deaths within 28 days of positive test per 100k resident population")]
        cumDeaths28DaysByPublishDateRate,

        [Description("Deaths within 28 days of positive test by death date")]
        newDeaths28DaysByDeathDate,

        [Description("Cumulative deaths within 28 days of positive test by death date")]
        cumDeaths28DaysByDeathDate,

        [Description("Rate of cumulative deaths within 28 days of positive test by death date per 100k resident population")]
        cumDeaths28DaysByDeathDateRate 

    }
}
