using CoronavirusInTheUKDashboard.Api.Service.Models.Generator;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Writers
{
    public interface IPostWriter
    {
        public void Write(Post post);
    }
}
