using CoronavirusInTheUKDashboard.Api.Service.Models.Engines;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Templating
{
     public static class TemplatingIServiceCollectionExtension
    {
        /// <summary>
        /// Hook up all the transformers
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTemplatingInternalServices(this IServiceCollection services)
        { 
            services.AddTransient<IMainPostEngine, Engine>();
            services.AddTransient<ITrendsPostEngine, Engine>();
            return services;
        }
    }
}
