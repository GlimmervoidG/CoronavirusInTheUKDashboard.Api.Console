using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Transformers.MainPost
{
    public interface INoneDailyQueryTransformer : IQueryTransformer<IrregularRecord>
    {
    }
}
