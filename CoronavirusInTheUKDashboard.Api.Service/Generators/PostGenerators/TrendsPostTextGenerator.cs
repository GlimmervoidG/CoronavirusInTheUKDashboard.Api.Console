using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Engines;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator.PostTextGenerators;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.PostGenerators
{
    public class TrendsPostTextGenerator : IPostTextGenerator<TrendsPostModel>
    {
        public ITrendsPostEngine PostEngine { get; set; }
        private ILogger<TrendsPostTextGenerator> Logger { get; set; }

        public TrendsPostTextGenerator(ITrendsPostEngine postEngine,
            ILogger<TrendsPostTextGenerator> logger)
        {
            PostEngine = postEngine;
            Logger = logger;
        }

        public string GeneratePostText(TrendsPostModel model)
        {
            var text = PostEngine.Run(model).Result;
            return text;
        }
    }
}
