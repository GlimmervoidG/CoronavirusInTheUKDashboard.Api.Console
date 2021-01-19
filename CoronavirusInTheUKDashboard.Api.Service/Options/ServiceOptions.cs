using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Options
{
    public class ServiceOptions : IOptions
    {
        public DateTime TargetDate { get; set; }

        public DateTime TrueDateTime { get; set; }

        public bool UseExternalArchiveSite { get; set; }

        public int ArchiveRetries { get; set; }
        public int DashboardRetries { get; set; }

        public string DirectoryOutput { get; set; }

        public string FileName { get; set; }
       
    }
}
