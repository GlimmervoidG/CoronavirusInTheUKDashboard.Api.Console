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
    public class MainPostGenerator : IPostGenerator
    {

        public PostTypes Type { get; } = PostTypes.MainPost;
        public IModelGenerator<MainPostModel> ModelGenerator { get; set; }
        public IPostTextGenerator<MainPostModel> PostGenerator { get; set; }
        private ILogger<MainPostGenerator> Logger { get; set; }
        public MainPostGenerator(
            IModelGenerator<MainPostModel> modelGenerator,
            IPostTextGenerator<MainPostModel> postGenerator,
            ILogger<MainPostGenerator> logger)
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

            Logger.LogInformation($"Finished {Type} generation.");
            return new Post() { Content = postText, Type = Type };
        }
    }
}