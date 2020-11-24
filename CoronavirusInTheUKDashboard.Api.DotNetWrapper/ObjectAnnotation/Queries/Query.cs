using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Response;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Filters;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Formats;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.LatestBys;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Releases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Attributes;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Structure;
using System.Reflection;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries.Url; 
using Newtonsoft.Json;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Queries;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.ObjectAnnotation.Queries
{
    public class Query<T>
    {
        public QueryOptions Options { get; set; }

        public QueryResponce<T> DoQuery()
        {

            var urlGenerator = new UrlGenerator() { Options = Options, StructureType = typeof(T) }; 
            var url = urlGenerator.GetUrl(); 
            var client = new QueryClient() { Url = url };
            var textResult = client.DoQuery();

            var json = JsonConvert.DeserializeObject<QueryResponce<T>>(textResult);

            json.Url = url;

            return json;
        } 

    }
}
