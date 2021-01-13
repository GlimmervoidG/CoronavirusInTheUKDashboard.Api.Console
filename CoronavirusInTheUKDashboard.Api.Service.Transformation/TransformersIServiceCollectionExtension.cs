using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.AdmissionsByAge;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.AdmissionsQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.ArchiveQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.DailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.NonDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.RegionBreakdownQueries;
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
            services.AddTransient<ILookbackEnglandQueryTransformer, LookbackEnglandQueryTransformer>();
            services.AddTransient<ILookbackWeekendEnglandQueryTransformer, LookbackWeekendEnglandQueryTransformer>();
            services.AddTransient<ILookbackQueryTransformer, LookbackQueryTransformer>();
            services.AddTransient<ILookbackWeekendQueryTransformer, LookbackWeekendQueryTransformer>();
            services.AddTransient<INonDailyQueryTransformer, NonDailyQueryTransformer>();
            services.AddTransient<IRegionBreakdownNationalQueryTransformer, RegionBreakdownNationalQueryTransformer>();
            services.AddTransient<IRegionBreakdownOverviewQueryTransformer, RegionBreakdownOverviewQueryTransformer>();
            services.AddTransient<IRegionBreakdownRegionQueryTransformer, RegionBreakdownRegionQueryTransformer>();
            return services;
        }
    }
}
