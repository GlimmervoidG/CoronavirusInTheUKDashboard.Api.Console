using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction
{
    public class ApiRequest
    {
        public static ApiRequest Create()
        {
            return new ApiRequest();
        }

        public List<ApiRequestPart> Parts { get; set; } = new List<ApiRequestPart>();
        public override string ToString()
        {
            var parts = Parts.Where(p => !string.IsNullOrEmpty(p.ToString())); 
            return $"v1/data?{string.Join("&", parts)}";
        }
    }
}
