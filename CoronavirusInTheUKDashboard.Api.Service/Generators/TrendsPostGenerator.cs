using CoronavirusInTheUKDashboard.Api.Service.Models.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.PostTextGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators
{
    public class TrendsPostGenerator : IPostGenerator
    {
        public IModelGenerator<TrendsPostModel> ModelGenerator { get; set; }
        public IPostTextGenerator<TrendsPostModel> PostGenerator { get; set; }
        public TrendsPostGenerator(IModelGenerator<TrendsPostModel> modelGenerator, IPostTextGenerator<TrendsPostModel> postGenerator)
        {
            ModelGenerator = modelGenerator;
            PostGenerator = postGenerator;
        }

        public Post GeneratePost()
        {
            var model = ModelGenerator.GenerateModel();
            var postText = PostGenerator.GeneratePostText(model);

            return new Post() { Content = postText, Type = Models.Options.PostTypes.TrendsPost };
        }
    }
}