﻿using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Engines;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator.PostTextGenerators;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.PostGenerators
{
    public class AdmissionsByAgePostTextGenerator : IPostTextGenerator<AdmissionsByAgePostModel>
    {
        public IAdmissionsByAgePostEngine PostEngine { get; set; }
        private ILogger<AdmissionsByAgePostTextGenerator> Logger { get; set; }

        public AdmissionsByAgePostTextGenerator(IAdmissionsByAgePostEngine postEngine,
            ILogger<AdmissionsByAgePostTextGenerator> logger)
        {
            PostEngine = postEngine;
            Logger = logger;
        }

        public string GeneratePostText(AdmissionsByAgePostModel model)
        {

            var text = PostEngine.Run(model).Result;
            return text;
        }
    }
}
