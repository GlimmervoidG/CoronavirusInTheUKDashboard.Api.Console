using CoronavirusInTheUKDashboard.Api.Service.Models.Engines;
using Microsoft.Extensions.DependencyInjection;

namespace CoronavirusInTheUKDashboard.Api.Service.Csv
{
     public static class CsvIServiceCollectionExtension
    {
        /// <summary>
        /// Hook up all the transformers
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCsvInternalServices(this IServiceCollection services)
        { 
            services.AddTransient<IAdmissionsByAgePostEngine, CsvEngine>(); 
            return services;
        }
    }
}
