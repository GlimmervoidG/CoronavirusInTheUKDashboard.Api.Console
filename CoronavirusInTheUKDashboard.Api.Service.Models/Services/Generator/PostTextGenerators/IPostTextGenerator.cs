using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator.PostTextGenerators
{
    public interface IPostTextGenerator<T> where T : PostModel
    {
        string GeneratePostText(T model);
    }
}
