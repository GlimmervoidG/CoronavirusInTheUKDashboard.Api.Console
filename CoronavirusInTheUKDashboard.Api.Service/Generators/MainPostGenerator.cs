using CoronavirusInTheUKDashboard.Api.Service.Models.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.ModelGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.PostTextGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators
{
    public class MainPostGenerator : IPostGenerator
    {

        public IModelGenerator<MainPostModel> ModelGenerator { get; set; }
        public IPostTextGenerator<MainPostModel> PostGenerator { get; set; }
        public MainPostGenerator(IModelGenerator<MainPostModel> modelGenerator, IPostTextGenerator<MainPostModel> postGenerator)
        {
            ModelGenerator = modelGenerator;
            PostGenerator = postGenerator;
        }

        public Post GeneratePost()
        {
            var model = ModelGenerator.GenerateModel();
            var postText = PostGenerator.GeneratePostText(model);

            return new Post() { Content = postText, Type = Models.Options.PostTypes.MainPost };
        }
    }
}