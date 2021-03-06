﻿using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Engines;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator.PostTextGenerators;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.PostGenerators
{
    public class MainPostTextGenerator : IPostTextGenerator<MainPostModel>
    {
        public IMainPostEngine MainPostEngine { get; set; }
        private ILogger<MainPostTextGenerator> Logger { get; set; }

        public MainPostTextGenerator(IMainPostEngine mainPostEngine, ILogger<MainPostTextGenerator> logger)
        {
            MainPostEngine = mainPostEngine;
            Logger = logger;
        }

        public string GeneratePostText(MainPostModel model)
        {
            var text = MainPostEngine.Run(model).Result; ;
            return text;
        }
    }
}
