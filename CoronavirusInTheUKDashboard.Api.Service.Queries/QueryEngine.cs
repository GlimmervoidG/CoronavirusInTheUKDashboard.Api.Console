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
using System.Threading;

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
                    Logger.LogInformation($"Qerying dashboard. Making attempt {i} of {retries}.");
                    var result = DashboardQuery.DoQuery();
                    Logger.LogInformation("Successfully queried dashboard.");
                    return result;
                } 
                catch (Exception ex)
                {
                    if (i < retries)
                    {
                        Logger.LogWarning(ex, $"Problem querying dashboard.");
                        var pauseBeforeRetry = true;
                        if (pauseBeforeRetry)
                        {
                            Logger.LogWarning($"Pausing before retry.");
                            Thread.Sleep(10000);
                        }
                        Logger.LogWarning($" Retrying...");
                    }
                    else
                    {
                        Logger.LogError(ex, $"Problem querying dashboard. Retries exceeded. Skipping query.");
                       // throw new Exception("Fatal Failure in achive");

                    }
                }
            }
            return DashboardQuery.GetEmptyQuery();
        }
    }
}
