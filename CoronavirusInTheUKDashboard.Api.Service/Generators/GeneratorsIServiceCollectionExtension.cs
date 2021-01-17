using CoronavirusInTheUKDashboard.Api.Service.Generators.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Generators.PostGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator.PostTextGenerators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators
{
    public static class GeneratorsIServiceCollectionExtension
    {

        /// <summary>
        /// Hook up all the AdmissionsByAgePostGeneratorServices
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAdmissionsByAgePostGeneratorServices(this IServiceCollection services)
        {
            services.AddTransient<IPostGenerator, AdmissionsByAgePostGenerator>();
            services.AddTransient<IModelGenerator<AdmissionsByAgePostModel>, AdmissionsByAgeModelGenerator>();
            services.AddTransient<IPostTextGenerator<AdmissionsByAgePostModel>, AdmissionsByAgePostTextGenerator>();
            return services;
        }

        /// <summary>
        /// Hook up all the MainPostTextGenerator
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMainPostTextGeneratorServices(this IServiceCollection services)
        {
            services.AddTransient<IPostGenerator, MainPostGenerator>();
            services.AddTransient<IModelGenerator<MainPostModel>, MainPostModelGenerator>();
            services.AddTransient<IPostTextGenerator<MainPostModel>, MainPostTextGenerator>();
            return services;
        }

        /// <summary>
        /// Hook up all the TrendsPostGenerator
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTrendsPostGeneratorServices(this IServiceCollection services)
        {
            services.AddTransient<IPostGenerator, TrendsPostGenerator>();
            services.AddTransient<IModelGenerator<TrendsPostModel>, TrendsPostModelGenerator>();
            services.AddTransient<IPostTextGenerator<TrendsPostModel>, TrendsPostTextGenerator>();
            return services;
        }
    }
}
