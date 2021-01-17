using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Engines
{
    public interface ITrendsPostEngine
    {
        Task<string> Run(TrendsPostModel model);
    }
}
