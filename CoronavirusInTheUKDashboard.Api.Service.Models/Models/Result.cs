using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Models
{
    public class Result<R> : BaseResult
    {
        public List<R> Records { get; set; }

    }
}
