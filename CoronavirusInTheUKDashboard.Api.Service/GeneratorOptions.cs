using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service
{
    public class GeneratorOptions
    {

        [Option('d', "date", Required = false,
        HelpText = "Date to search for (format yyyy-mm-dd). Today is left blank.")]
        public string TargetDate { get; set; }

        [Option('a', "archive", Required = false,
        HelpText = "Save API requests to Archive.org. Warning, this functionality often fails.")]
        public bool UseExternalArchiveSite { get; set; }


        [Option('p', "posts", Separator = ',', HelpText = "Which post should be generated....", Required = true)]
        public IEnumerable<PostTypes>  PostTypes { get; set; }

        [Option('f', "folderoutput", Required = false,
          HelpText = "Directory to output to. If blank, will write to standard output.")]
        public string DirectoryOutput { get; set; }
        
        [Option('n', "filename", Required = false, HelpText = "Name of the outputted file. If blank, will generate name.")]
        public string FileName { get; set; }

    }
}
