using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Transformers.MainPost
{
    public interface INonDailyQueryTransformer : IQueryTransformer<IrregularRecord>
    {
    }
}
