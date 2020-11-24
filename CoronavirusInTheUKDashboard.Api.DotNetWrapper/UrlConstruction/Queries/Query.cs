using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common;
using CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Queries
{
    public class Query
    {
        public string DoQuery(ApiRequest url)
        { 
            var fullUrl = GetUrl(url);
            var client = new QueryClient() { Url = fullUrl };
            var textResult = client.DoQuery(); 

            return textResult;
        }
        private string GetUrl(ApiRequest urlFull)
        {
            var uri = new Uri(new Uri(UrlConstants.DashboardApiUrl), urlFull.ToString()).ToString();
            var escapedUri = Uri.EscapeUriString(uri);
            return escapedUri;
        }
    }
}
