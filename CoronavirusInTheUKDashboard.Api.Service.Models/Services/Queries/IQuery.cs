using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries
{
    public interface IQuery<T> where T : BaseModel
    {
        public DateTime TargetDate { get; set; }
        QueryResponce<T> DoQuery();
    }
}
