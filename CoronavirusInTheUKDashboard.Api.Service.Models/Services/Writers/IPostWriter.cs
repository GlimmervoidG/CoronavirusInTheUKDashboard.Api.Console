using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Generator;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Writers
{
    public interface IPostWriter
    {
        public void Write(Post post);
    }
}
