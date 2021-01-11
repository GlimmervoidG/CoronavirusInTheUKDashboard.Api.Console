using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Engines
{
    public interface IMainPostEngine
    {
        Task<string> Run(MainPostModel model);
    }
}
