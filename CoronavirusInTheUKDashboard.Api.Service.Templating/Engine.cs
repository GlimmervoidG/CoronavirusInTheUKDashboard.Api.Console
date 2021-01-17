using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RazorLight;
using System.Linq;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Records;
using CoronavirusInTheUKDashboard.Api.Service.Models.Models.Posts;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services.Engines;

namespace CoronavirusInTheUKDashboard.Api.Service.Templating
{
    public  class Engine : IMainPostEngine, ITrendsPostEngine
    {
        public async Task<string> Run(TrendsPostModel model)
        {
            var razorEngine = new RazorLightEngineBuilder()
             .UseEmbeddedResourcesProject(typeof(Root).Assembly, GetEmbeddedResourceNamespace("SearchTargetEmbeddedTrendsPost.txt"))
             .UseMemoryCachingProvider()
             .Build();
            var result = await razorEngine.CompileRenderAsync("TrendsPost.cshtml", model);
            return result;
        }

        public async Task<string> Run(MainPostModel model)
        {
            var razorEngine = new RazorLightEngineBuilder()
             .UseEmbeddedResourcesProject(typeof(Root).Assembly, GetEmbeddedResourceNamespace("SearchTargetEmbeddedMainPost.txt"))
             .UseMemoryCachingProvider()
             .Build();
            var result = await razorEngine.CompileRenderAsync("OrginalPost.cshtml", model);
            return result;
        }

        private string GetEmbeddedResourceNamespace(string searchTarget)
        {
            var listOfEmbeddedResources = new List<string>(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames());
            var target = listOfEmbeddedResources.First(r => r.Contains(searchTarget));
            target = target.Replace(searchTarget, string.Empty);
            target = target.Trim('.');
            return target;
        }
    } 
}
