using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records.Ages;
using CoronavirusInTheUKDashboard.Api.Service.Queries.DataQueries.AdmissionsQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;

namespace CoronavirusInTheUKDashboard.Api.Service.Transformation.Transformers.AdmissionsQueries
{
    public class AdmissionsByAgeQueryTransformer
    {
        public DateTime SearchDate { get; set; }
        public Result<AdmissionsByAgeRecord> QueryAndTransform()
        {
            var query = new AdmissionsByAgeQuery() { SearchDate = SearchDate };
            var result = query.DoQuery();

            var list = new List<AdmissionsByAgeRecord>(); 
            foreach( var item in result.Data)
            {
                list.Add(new AdmissionsByAgeRecord() {
                    Date = item.Date
                    , Records = item.AdmissionsByAge.Select(
                        r => new AdmissionsByAgeItemRecord() { AgeRange = r.Age, Cumulative = r.Value, Rate = r.Rate }
                        ).ToList()
                        });
            }

            list = list.OrderBy(r => r.Date).ToList();

            AdmissionsByAgeRecord last = null;
            foreach(var item in list)
            {
                if( last != null)
                {
                    item.Get0to5().New = item.Get0to5().Cumulative - last.Get0to5().Cumulative;
                    item.Get6To17().New = item.Get6To17().Cumulative - last.Get6To17().Cumulative;
                    item.Get18To64().New = item.Get18To64().Cumulative - last.Get18To64().Cumulative;
                    item.Get65To84().New = item.Get65To84().Cumulative - last.Get65To84().Cumulative;
                    item.Get85OrMore().New = item.Get85OrMore().Cumulative - last.Get85OrMore().Cumulative;
                } else
                {
                    item.Get0to5().New = item.Get0to5().Cumulative;
                    item.Get6To17().New = item.Get6To17().Cumulative;
                    item.Get18To64().New = item.Get18To64().Cumulative;
                    item.Get65To84().New = item.Get65To84().Cumulative;
                    item.Get85OrMore().New = item.Get85OrMore().Cumulative;
                }

                last = item;
            }
            return new Result<AdmissionsByAgeRecord>()
            {
                Records = list,
                QueryRecords = new List<QueryRecord>() {
                    new QueryRecord() { Name = NameConstants.AdmissionsByAge, Url = result.Url }
                }
            }; 
        }
    }
}
