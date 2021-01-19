using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries
{
    public class QueryEngine<T> : IQueryEngine<T> where T : BaseModel
    {
        public IDashboardQuery<T> DashboardQuery { get; set; }
        public IOptions ConfigOptions { get; set; }
        public ILogger<QueryEngine<T>> Logger { get; set; }

        public QueryEngine(IDashboardQuery<T> dashboardQuery, IOptions configOptions, ILogger<QueryEngine<T>> logger)
        {
            DashboardQuery = dashboardQuery;
            ConfigOptions = configOptions;
            Logger = logger;
        }

        public QueryOptions Options { get; set; }
        QueryResponce<T> IQueryEngine<T>.DoQuery()
        {
            var retries = ConfigOptions.DashboardRetries;
            DashboardQuery.Options = Options;

            for (var i = 1; i <= retries; i++)
            {
                try {
                    return DashboardQuery.DoQuery(); 
                } 
                catch (Exception ex)
                {
                    if (i < retries)
                    {
                        Logger.LogWarning(ex, $"Problem querying dashboard. Making attempt {i + 1} of {retries}.");
                    }
                    else
                    {
                        Logger.LogError(ex, $"Problem querying dashboard. Retries exceeded. Skipping query.");
                    }
                }
            }
            return DashboardQuery.GetEmptyQuery();
        }
    }
}
