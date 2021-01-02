using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Examples;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries;
using System;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper
{
    public class Example1
    {
        public void DoStuff()
        {
            var quary = new Query<DailyStatsQuery>() { 
                Options = new ObjectAnnotation.QueryOptions()
                {
                    Filter = new ObjectAnnotation.Filters.Filter()
                    {
                        AreaType = new ObjectAnnotation.Filters.AreaType(Common.AreaTypeMetrics.overview) 
                    },
                     
                }
            };
            var result = quary.DoQuery(); 

        }

    }
}
