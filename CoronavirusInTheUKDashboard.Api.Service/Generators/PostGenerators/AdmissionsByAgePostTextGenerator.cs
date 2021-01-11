using CoronavirusInTheUKDashboard.Api.Service.Models.Engines;
using CoronavirusInTheUKDashboard.Api.Service.Models.Generator.PostTextGenerators;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Generators.PostGenerators
{
    public class AdmissionsByAgePostTextGenerator : IPostTextGenerator<AdmissionsByAgePostModel>
    {
        public IAdmissionsByAgePostEngine PostEngine { get; set; }

        public AdmissionsByAgePostTextGenerator(IAdmissionsByAgePostEngine postEngine)
        {
            PostEngine = postEngine;
        }

        public string GeneratePostText(AdmissionsByAgePostModel model)
        {
            var text = PostEngine.Run(model).Result;
            return text;
        }
    }
}
