using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.TrendsPost;
using UkOnsPopulationEstimatesUnofficial;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionVaccineProgress
{
    public class RegionVaccineProgressRegionQueryTransformer : RegionVaccineProgressQueryTransformer, IRegionVaccineProgressRegionQueryTransformer
    {
        public IRegionVaccineProgressRegionalQuery QueryToday { get; set; }
        public IRegionVaccineProgressRegionalYesterdayQuery QueryYesterday { get; set; }

        public ILogger<RegionVaccineProgressRegionQueryTransformer> Logger { get; set; }
        public RegionVaccineProgressRegionQueryTransformer(
            IRegionVaccineProgressRegionalQuery queryToday,
            IRegionVaccineProgressRegionalYesterdayQuery queryYesterday, 
            ILogger<RegionVaccineProgressRegionQueryTransformer> logger)
        {
            QueryToday = queryToday;
            QueryYesterday = queryYesterday;
            Logger = logger;
        }

        public Result<RegionProgressRecord> QueryAndTransform()
        {

            Logger.LogInformation($"Running Query and transform.");
            QueryToday.TargetDate = TargetDate;
            var resultToday = QueryToday.DoQuery();

            QueryYesterday.TargetDate = TargetDate;
            var resultYesterday = QueryYesterday.DoQuery();

            QueryNameToday = NameConstants.RegionVaccineProgressQuery_Region_Today;
            QueryNameYesterday = NameConstants.RegionVaccineProgressQuery_Region_Yesterday;


            var list = PopulationDataSet.DataSet().EnglishRegions().ToList();
            return Transform(list, resultToday, resultYesterday);

        }

    }
}
