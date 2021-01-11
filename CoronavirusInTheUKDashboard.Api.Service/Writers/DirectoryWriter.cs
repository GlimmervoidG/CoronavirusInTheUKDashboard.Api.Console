using CoronavirusInTheUKDashboard.Api.Service.Models.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using CoronavirusInTheUKDashboard.Api.Service.Models.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Writers
{
    public class DirectoryWriter : IPostWriter
    {
        public IOptions Options { get; set; }
        public DirectoryWriter(IOptions options)
        {
            Options = options;
        }

        public void Write(Post post)
        {
            var fileName = string.Empty;
            if (String.IsNullOrWhiteSpace(Options.FileName))
            {
                fileName = string.Format($"uk-covid-{Options.TrueDateTime:yyyy-MM-dd_HH-mm-ss}_{post.Type}.txt");
            }
            else
            {
                fileName = Options.FileName;
            }

            var fullOutput = Path.Join(Options.DirectoryOutput, fileName);
            Directory.CreateDirectory(Options.DirectoryOutput);
            System.IO.File.WriteAllText(fullOutput, post.Content);
        }
    }
}
