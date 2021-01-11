using CoronavirusInTheUKDashboard.Api.Service.Models.Engines;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.PostTextGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.PostGenerators
{
    public class MainPostTextGenerator : IPostTextGenerator<MainPostModel>
    {
        public IMainPostEngine MainPostEngine { get; set; }

        public MainPostTextGenerator(IMainPostEngine mainPostEngine)
        {
            MainPostEngine = mainPostEngine;
        }

        public string GeneratePostText(MainPostModel model)
        {
            var text = MainPostEngine.Run(model).Result; ;
            return text;
        }
    }
}
