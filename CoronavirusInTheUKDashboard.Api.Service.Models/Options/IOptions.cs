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

        string DirectoryOutput { get;}

        string FileName { get; }
    }
}
