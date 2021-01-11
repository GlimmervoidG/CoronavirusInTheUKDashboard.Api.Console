using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.Service.Models.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Queries
{
    public interface IQuery<T> where T : BaseModel
    {
        public DateTime SearchDate { get; set; }
        QueryResponce<T> DoQuery();
    }
}
