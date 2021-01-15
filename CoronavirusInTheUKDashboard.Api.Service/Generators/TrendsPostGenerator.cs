using CoronavirusInTheUKDashboard.Api.Service.Models.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.PostTextGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators
{
    public class TrendsPostGenerator : IPostGenerator
    {
        public PostTypes Type { get; } = PostTypes.TrendsPost;
        public IModelGenerator<TrendsPostModel> ModelGenerator { get; set; }
        public IPostTextGenerator<TrendsPostModel> PostGenerator { get; set; }
        private ILogger<TrendsPostGenerator> Logger { get; set; }
        public TrendsPostGenerator(IModelGenerator<TrendsPostModel> modelGenerator,
            IPostTextGenerator<TrendsPostModel> postGenerator,
            ILogger<TrendsPostGenerator> logger)
        {
            ModelGenerator = modelGenerator;
            PostGenerator = postGenerator;
            Logger = logger;
        }

        public Post GeneratePost()
        {
            Logger.LogInformation($"Starting {Type} generation.");
            var model = ModelGenerator.GenerateModel();
            var postText = PostGenerator.GeneratePostText(model);

            Logger.LogInformation($"Starting {Type} generation.");
            return new Post() { Content = postText, Type = Type };
        }
    }
}