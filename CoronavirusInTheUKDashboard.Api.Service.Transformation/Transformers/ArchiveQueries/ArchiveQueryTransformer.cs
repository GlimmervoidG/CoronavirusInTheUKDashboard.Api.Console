using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.DailyQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Queries.GeneralQueries;
using Microsoft.Extensions.Logging;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.Common;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers;
using System.Threading;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.ArchiveQueries
{
    public class ArchiveQueryTransformer : IArchiveTransformer
    { 
        public DateTime ArchiveDate {get;set;}
        public IArchiveQuery ArchiveQuery { get; set; }
        public IOptions Options { get; set; }
        ILogger<ArchiveQueryTransformer> Logger { get; set; }

        public ArchiveQueryTransformer(
            IArchiveQuery archiveQuery,
            IOptions options,
            ILogger<ArchiveQueryTransformer> logger)
        {
            ArchiveQuery = archiveQuery;
            Options = options;
            Logger = logger;
        }

        public void QueryAndTransform(List<QueryRecord> records)
        {
            Logger.LogInformation($"Running Query and transform.");
            var recordIndex = 0;
            var recordCount = records.Count;
            var archiveRetries = Math.Max(1, Options.ArchiveRetries);
       
            foreach (var record in records)
            {
                recordIndex++;
        

                for (int i=1; i <= archiveRetries; i++)
                {
                    try
                    {
                        Logger.LogInformation($"Archiving page {recordIndex} of {recordCount}. Making attempt {i} of {archiveRetries}.");

                        ArchiveQuery.TargetUrl = record.Url;
                        record.ArchiveUrl = ArchiveQuery.DoQuery();
                        record.ArchiveDate = ArchiveDate;

                        Logger.LogInformation($"Successfully archived page {recordIndex}.");

                        break;
                    }
                    catch (ArchiveQueryException ex)
                    {
                        if (i < archiveRetries)
                        {
                            Logger.LogWarning(ex, $"Problem archiving page {recordIndex}.");
                            if (ex.ForcePause)
                            {
                                Logger.LogWarning(ex, $"Pausing before retry.");
                                Thread.Sleep(10000);
                            }
                            Logger.LogWarning(ex, $"Retrying.");
                        } else 
                        {
                            Logger.LogError(ex, $"Problem archiving page {recordIndex}. Retries exceeded. Skipping archive attempt for this page.");
                        } 
                    }
                }

            }
        }
    }
}
