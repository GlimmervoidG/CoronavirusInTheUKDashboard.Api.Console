using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries
{
    public interface IQueryEngine<T> where T : BaseModel
    {
       public QueryOptions Options { get; set; }
       public QueryResponce<T> DoQuery();
    }
}
