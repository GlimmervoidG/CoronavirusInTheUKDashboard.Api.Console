using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.AdmissionsQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.DailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackEnglandQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackNationalQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.NonDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.AdmissionsByAge;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.Common;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.MainPost;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.TrendsPost;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.AdmissionsQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackEightDayQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackNationalQueries.England;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackNationalQueries.NorthernIreland;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.LookbackQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.NonDailyQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.RegionBreakdownQueries;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.RegionBreakdownQueries.Yesterday;
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
            services.AddTransient<ILookbackEnglandQuery, LookbackEnglandQuery>();
            services.AddTransient<ILookbackCatchUpEnglandQuery, LookbackCatchUpEnglandQuery>();
            services.AddTransient<ILookbackQuery, LookbackQuery>();
            services.AddTransient<ILookbackCatchUpQuery, LookbackCatchUpQuery>();
            services.AddTransient<INonDailyQuery, NonDailyQuery>();
            services.AddTransient<IRegionBreakdownNationalYesterdayQuery, RegionBreakdownNationalYesterdayQuery>();
            services.AddTransient<IRegionBreakdownOverviewYesterdayQuery, RegionBreakdownOverviewYesterdayQuery>();
            services.AddTransient<IRegionBreakdownRegionalYesterdayQuery, RegionBreakdownRegionalYesterdayQuery>();
            services.AddTransient<IRegionBreakdownNationalQuery, RegionBreakdownNationalQuery>();
            services.AddTransient<IRegionBreakdownOverviewQuery, RegionBreakdownOverviewQuery>();
            services.AddTransient<IRegionBreakdownRegionalQuery, RegionBreakdownRegionalQuery>();
            services.AddTransient<IArchiveQuery, ArchiveQuery>();
            services.AddTransient<ILookbackWeekendEnglandQuery, LookbackWeekendEnglandQuery>();
            services.AddTransient<ILookbackWeekendNorthernIrelandQuery, LookbackWeekendNorthernIrelandQuery>();

            services.AddTransient(typeof(IDashboardQuery<>), typeof(DashboardQuery<>));
            services.AddTransient(typeof(IQueryEngine<>), typeof(QueryEngine<>));

            //services.AddTransient<IDashboardQuery<AdmissionsByAgeModel>, DashboardQuery<AdmissionsByAgeModel>>();
            //services.AddTransient<IDashboardQuery<DailyQueryModel>, DashboardQuery<DailyQueryModel>>();
            //services.AddTransient<IDashboardQuery<LookbackEightDayQueryModel>, DashboardQuery<LookbackEightDayQueryModel>>();
            //services.AddTransient<IDashboardQuery<LookbackEnglandQueryModel>, DashboardQuery<LookbackEnglandQueryModel>>();
            //services.AddTransient<IDashboardQuery<LookbackCatchUpEnglandQuery>, DashboardQuery<LookbackCatchUpEnglandQuery>>();
            //services.AddTransient<IDashboardQuery<LookbackQueryModel>, DashboardQuery<LookbackQueryModel>>();
            //services.AddTransient<IDashboardQuery<NonDailyQueryModel>, DashboardQuery<NonDailyQueryModel>>();
            //services.AddTransient<IDashboardQuery<RegionBreakdownQueryModel>, DashboardQuery<RegionBreakdownQueryModel>>();
            //services.AddTransient<IDashboardQuery<LookbackWeekendModel>, DashboardQuery<LookbackWeekendModel>>();


            return services;
        }
     }
}
