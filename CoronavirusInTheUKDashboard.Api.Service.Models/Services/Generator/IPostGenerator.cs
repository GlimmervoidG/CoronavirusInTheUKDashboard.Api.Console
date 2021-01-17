using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator
{
    public interface IPostGenerator
    {

        PostTypes Type { get; }
        Post GeneratePost();
    }
}
