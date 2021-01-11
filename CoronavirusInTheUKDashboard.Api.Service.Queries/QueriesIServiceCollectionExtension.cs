using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.AdmissionsByAge;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Common;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.AdmissionsQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.DailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackLfdTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.LookbackTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.NonDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.AdmissionsQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackLfdTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackTestingQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NonDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NoneDailyQueries.Yesterday;
using CoronavirusInTheUKDashboard.Api.Service.Queries.GeneralQueries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries
{
    public static class QueriesIServiceCollectionExtension
    {
        /// <summary>
        /// Hook up all the Queries
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddQueriesInternalServices(this IServiceCollection services)
        {
            services.AddTransient<IAdmissionsByAgeQuery, AdmissionsByAgeQuery>();
            services.AddTransient<IDailyQuery, DailyQuery>();
            services.AddTransient<ILookbackEightDayQuery, LookbackEightDayQuery>();
            services.AddTransient<ILookbackLfdTestingEnglandQuery, LookbackLfdTestingEnglandQuery>();
            services.AddTransient<ILookbackLfdTestingWeekendEnglandQuery, LookbackLfdTestingWeekendEnglandQuery>();
            services.AddTransient<ILookbackTestingQuery, LookbackTestingQuery>();
            services.AddTransient<ILookbackTestingWeekendQuery, LookbackTestingWeekendQuery>();
            services.AddTransient<INonDailyQuery, NonDailyQuery>();
            services.AddTransient<IRegionBreakdownNationalYesterdayQuery, RegionBreakdownNationalYesterdayQuery>();
            services.AddTransient<IRegionBreakdownOverviewYesterdayQuery, RegionBreakdownOverviewYesterdayQuery>();
            services.AddTransient<IRegionBreakdownRegionalYesterdayQuery, RegionBreakdownRegionalYesterdayQuery>();
            services.AddTransient<IRegionBreakdownNationalQuery, RegionBreakdownNationalQuery>();
            services.AddTransient<IRegionBreakdownOverviewQuery, RegionBreakdownOverviewQuery>();
            services.AddTransient<IRegionBreakdownRegionalQuery, RegionBreakdownRegionalQuery>();
            services.AddTransient<IArchiveQuery, ArchiveQuery>();

            services.AddTransient<IQuery<AdmissionsByAgeModel>, Query<AdmissionsByAgeModel>>();
            services.AddTransient<IQuery<DailyQueryModel>, Query<DailyQueryModel>>();
            services.AddTransient<IQuery<LookbackEightDayQueryModel>, Query<LookbackEightDayQueryModel>>();
            services.AddTransient<IQuery<LookbackLfdTestingQueryModel>, Query<LookbackLfdTestingQueryModel>>();
            services.AddTransient<IQuery<LookbackLfdTestingWeekendEnglandQuery>, Query<LookbackLfdTestingWeekendEnglandQuery>>();
            services.AddTransient<IQuery<LookbackTestingQueryModel>, Query<LookbackTestingQueryModel>>();
            services.AddTransient<IQuery<NonDailyQueryModel>, Query<NonDailyQueryModel>>();
            services.AddTransient<IQuery<RegionBreakdownQueryModel>, Query<RegionBreakdownQueryModel>>();

            return services;
        }
     }
}
