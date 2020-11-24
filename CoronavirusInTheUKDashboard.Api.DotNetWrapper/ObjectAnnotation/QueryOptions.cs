using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Formats;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.LatestBys;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Releases;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation
{
   public class QueryOptions
   {
        public Filter Filter { get; set; }
        public LatestBy LatestBy { get; set; }
        internal Format Format { get; } = new Format(Common.FormatOptions.json);
        public Release Release { get; set; } 

        public static QueryOptions Default()
        {
            return new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(Common.AreaTypeMetrics.overview)
                }
            };
        }
        public static QueryOptions UkOverviewForToday()
        {
            return new QueryOptions()
            {
                Filter = new Filter()
                {
                    AreaType = new AreaType(Common.AreaTypeMetrics.overview) ,
                    Date = new Filters.FilterElements.DateFilter(DateTime.Now.Date)
                },
                
            };
        }

    }
}
