using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Writers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Writers
{
    public class ConsoleWriter : IPostWriter
    {
        private ILogger<ConsoleWriter> Logger { get; set; }
        public ConsoleWriter(ILogger<ConsoleWriter> logger)
        {
            Logger = logger;
        }
        public void Write(Post post)
        {
            Logger.LogInformation($"Writing output to console.");
            Console.WriteLine(post.Content);
        }
    }
}
