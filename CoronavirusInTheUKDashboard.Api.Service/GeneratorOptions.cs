using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service
{
    public class GeneratorOptions
    {
        [Option('f', "fileoutput", Required = true,
          HelpText = "Output to file")]
        public string FileOutput { get; set; }

        [Option('d', "date", Required = false,
        HelpText = "Date to search for (format yyyy-mm-dd). Today is left blank.")]
        public string TargetDate { get; set; }
    }
}
