using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Options
{
    public interface IOptions
    {
        DateTime TargetDate { get; }
        DateTime TrueDateTime { get; }
        bool UseExternalArchiveSite { get; }
        int ArchiveRetries { get; set; }

        string DirectoryOutput { get;}

        string FileName { get; }
    }
}
