using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service
{
    public class GeneratorOptions
    {
        [Option('f', "folderoutput", Required = true,
          HelpText = "Folder to output to.")]
        public string FileOutput { get; set; }

        [Option('d', "date", Required = false,
        HelpText = "Date to search for (format yyyy-mm-dd). Today is left blank.")]
        public string TargetDate { get; set; }

        [Option('a', "archive", Required = false,
        HelpText = "Save API requests to Archive.org. Warning, this functionality often fails.")]
        public bool UseExternalArchiveSite { get; set; }
    }
}
