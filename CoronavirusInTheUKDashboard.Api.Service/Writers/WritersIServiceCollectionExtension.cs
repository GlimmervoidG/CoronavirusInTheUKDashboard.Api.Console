using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Writers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Writers
{
    public static class WritersIServiceCollectionExtension
    {

        public static IServiceCollection AddConsoleWriterInternalServices(this IServiceCollection services)
        {
            services.AddTransient<IPostWriter, ConsoleWriter>();
            return services;
        }
        public static IServiceCollection AddDirectoryWriterInternalServices(this IServiceCollection services)
        {
            services.AddTransient<IPostWriter, DirectoryWriter>();
            return services;
        }
    }
}
