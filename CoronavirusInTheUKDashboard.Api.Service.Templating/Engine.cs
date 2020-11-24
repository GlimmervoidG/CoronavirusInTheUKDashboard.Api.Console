using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RazorLight;
using System.Linq; 
using CoronavirusInTheUKDashboard.Api.Service.Models.Models;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;

namespace CoronavirusInTheUKDashboard.Api.Service.Templating
{
    public static class Engine
    {
        public static async Task<string> Run(TrendsPostModel model)
        {
            var razorEngine = new RazorLightEngineBuilder()
             .UseEmbeddedResourcesProject(typeof(Root).Assembly, GetEmbeddedResourceNamespace("SearchTargetEmbeddedTrendsPost.txt"))
             .UseMemoryCachingProvider()
             .Build();
            var result = await razorEngine.CompileRenderAsync("TrendsPost.cshtml", model);
            return result;
        }

        public static async Task<string> Run(MainPostModel model)
        {
            var razorEngine = new RazorLightEngineBuilder()
             .UseEmbeddedResourcesProject(typeof(Root).Assembly, GetEmbeddedResourceNamespace("SearchTargetEmbeddedMainPost.txt"))
             .UseMemoryCachingProvider()
             .Build();
            var result = await razorEngine.CompileRenderAsync("OrginalPost.cshtml", model);
            return result;
        }   
        private static string GetEmbeddedResourceNamespace(string searchTarget)
        {
            var listOfEmbeddedResources = new List<string>(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames());
            var target = listOfEmbeddedResources.First(r => r.Contains(searchTarget));
            target = target.Replace(searchTarget, string.Empty);
            target = target.Trim('.');
            return target;
        }
    } 
}
