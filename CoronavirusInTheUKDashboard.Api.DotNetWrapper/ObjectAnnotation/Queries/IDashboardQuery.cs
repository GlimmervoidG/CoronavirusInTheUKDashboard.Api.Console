using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries
{
    public interface IDashboardQuery<T>
    {
        QueryOptions Options { get; set; }
        QueryResponce<T> DoQuery();

        QueryResponce<T> GetEmptyQuery();
    }
}
