using CoronavirusInTheUKDashboard.Api.Service.Models.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Services;
using CoronavirusInTheUKDashboard.Api.Service.Models.Writers;
using System.Collections.Generic;

namespace CoronavirusInTheUKDashboard.Api.Service
{
    public class Generator : IGenerator
    {
        public IEnumerable<IPostGenerator> Generators { get; set; }
        public IEnumerable<IPostWriter> Writers { get; set; }

        public Generator(IEnumerable<IPostGenerator> generators, IEnumerable<IPostWriter> writers)
        {
            Generators = generators;
            Writers = writers;
        }

        public void Run()
        {
            foreach (var gen in Generators)
            {
                var post = gen.GeneratePost();
                foreach(var writer in Writers)
                {
                    writer.Write(post);
                }
            }
        }
    }
}