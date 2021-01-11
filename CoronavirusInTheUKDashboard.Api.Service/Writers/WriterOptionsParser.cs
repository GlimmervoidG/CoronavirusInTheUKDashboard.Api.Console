using CoronavirusInTheUKDashboard.Api.Service.Models.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Writers
{
    public static class WriterOptionsParser
    {
        public static bool ShouldOutputToConsole(CommandLineOptions options)
        {
            return string.IsNullOrEmpty(options.DirectoryOutput);
        }
        public static bool ShouldOutputToDirectory(CommandLineOptions options)
        {
            return !string.IsNullOrEmpty(options.DirectoryOutput);
        }
         
    }
}
