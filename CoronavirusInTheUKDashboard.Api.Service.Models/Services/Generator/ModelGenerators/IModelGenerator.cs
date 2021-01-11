using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Generator.ModelGenerators
{
    public interface IModelGenerator<T> where T : PostModel
    {
        T GenerateModel();
    }
}
