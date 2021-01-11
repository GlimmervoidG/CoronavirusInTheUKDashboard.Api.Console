using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Transformers
{
    public interface IQueryTransformer<T> where T : BaseRecord
    {
        DateTime TargetDate { get; set; }
        public Result<T> QueryAndTransform();
    }
}
