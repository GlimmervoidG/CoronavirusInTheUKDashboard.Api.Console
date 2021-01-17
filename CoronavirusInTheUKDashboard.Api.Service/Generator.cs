using CoronavirusInTheUKDashboard.Api.Service.Models.Services;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Writers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CoronavirusInTheUKDashboard.Api.Service
{
    public class Generator : IGenerator
    {
        public IEnumerable<IPostGenerator> Generators { get; set; }
        public IEnumerable<IPostWriter> Writers { get; set; }
        private ILogger<Generator> Logger { get; set; }

        public Generator(IEnumerable<IPostGenerator> generators, IEnumerable<IPostWriter> writers, ILogger<Generator> logger)
        {
            Generators = generators;
            Writers = writers;
            Logger = logger;
        }

        public void Run()
        {
            Logger.LogInformation("Starting Run");
            foreach (var gen in Generators)
            {
                var post = gen.GeneratePost();
                foreach(var writer in Writers)
                {
                    writer.Write(post);
                }
            }
            Logger.LogInformation("Finished Run");
        }
    }
}