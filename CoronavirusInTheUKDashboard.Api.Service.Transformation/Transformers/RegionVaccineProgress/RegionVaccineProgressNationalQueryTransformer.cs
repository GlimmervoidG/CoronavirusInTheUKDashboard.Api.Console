using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries.Population;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.TrendsPost;
using UkOnsPopulationEstimatesUnofficial;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionVaccineProgress
{
    public class RegionVaccineProgressNationalQueryTransformer : RegionVaccineProgressQueryTransformer, IRegionVaccineProgressNationalQueryTransformer
    {
        public IRegionVaccineProgressNationalQuery QueryToday { get; set; }
        public IRegionVaccineProgressNationalYesterdayQuery QueryYesterday { get; set; }
        public ILogger<RegionVaccineProgressNationalQueryTransformer> Logger { get; set; }
        public RegionVaccineProgressNationalQueryTransformer(IRegionVaccineProgressNationalQuery queryToday, IRegionVaccineProgressNationalYesterdayQuery queryYesterday,
            ILogger<RegionVaccineProgressNationalQueryTransformer> logger)
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

            QueryNameToday = NameConstants.RegionVaccineProgressQuery_National_Today;
            QueryNameYesterday = NameConstants.RegionVaccineProgressQuery_National_Yesterday;



            var list = PopulationDataSet.DataSet().HomeNations().ToList();
            return Transform(list, resultToday, resultYesterday);
        }
 
    }
}
