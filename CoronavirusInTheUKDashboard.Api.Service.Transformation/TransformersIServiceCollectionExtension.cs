using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.AdmissionsByAge;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.AdmissionsQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.ArchiveQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackEnglandQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackNationalQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.NonDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionVaccineProgress;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation
{
    public static class TransformersIServiceCollectionExtension
    {
        /// <summary>
        /// Hook up all the transformers
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTransformersInternalServices(this IServiceCollection services)
        {
            services.AddTransient<IAdmissionsByAgeQueryTransformer, AdmissionsByAgeQueryTransformer>();
            services.AddTransient<IArchiveTransformer, ArchiveQueryTransformer>();
            services.AddTransient<IDailyQueryTransformer, DailyQueryTransformer>();
            services.AddTransient<ITitleTransformer, TitleTransformer>();
            services.AddTransient<ILookbackEightDayQueryTransformer, LookbackEightDayQueryTransformer>();
            services.AddTransient<ILookbackNationalQueryTransformer, LookbackNationalQueryTransformer>();
            services.AddTransient<ILookbackCatchUpEnglandQueryTransformer, LookbackCatchUpNationalQueryTransformer>();
            services.AddTransient<ILookbackQueryTransformer, LookbackQueryTransformer>();
            services.AddTransient<ILookbackCatchUpQueryTransformer, LookbackCatchUpQueryTransformer>();
            services.AddTransient<INonDailyQueryTransformer, NonDailyQueryTransformer>();
            services.AddTransient<IRegionBreakdownNationalQueryTransformer, RegionBreakdownNationalQueryTransformer>();
            services.AddTransient<IRegionBreakdownOverviewQueryTransformer, RegionBreakdownOverviewQueryTransformer>();
            services.AddTransient<IRegionBreakdownRegionQueryTransformer, RegionBreakdownRegionQueryTransformer>();
            services.AddTransient<ILookbackVaccineQueryTransformer, LookbackVaccineQueryTransformer>();
            services.AddTransient<IRegionVaccineProgressNationalQueryTransformer, RegionVaccineProgressNationalQueryTransformer>();
            services.AddTransient<IRegionVaccineProgressOverviewQueryTransformer, RegionVaccineProgressOverviewQueryTransformer>();
            services.AddTransient<IRegionVaccineProgressRegionQueryTransformer, RegionVaccineProgressRegionQueryTransformer>();
            return services;
        }
    }
}
