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
    public class AdmissionsByAgePostGenerator : IPostGenerator
    {
        public PostTypes Type { get; } = PostTypes.AdmissionsByAge;
        public IModelGenerator<AdmissionsByAgePostModel> ModelGenerator { get; set; }
        public IPostTextGenerator<AdmissionsByAgePostModel> PostGenerator { get; set; }
        private ILogger<AdmissionsByAgePostGenerator> Logger { get; set; }
        

        public AdmissionsByAgePostGenerator(
            IModelGenerator<AdmissionsByAgePostModel> modelGenerator,
            IPostTextGenerator<AdmissionsByAgePostModel> postGenerator,
            ILogger<AdmissionsByAgePostGenerator> logger)
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
            return new Post() { Content = postText, Type = Models.Options.PostTypes.AdmissionsByAge };
        }
    }
}
