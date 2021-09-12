using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Services.Queries.Common
{
    public class ArchiveQueryException : Exception
    {
        public ArchiveQueryException(string message) : base(message)
        {
        }
        public ArchiveQueryException  (string message, Exception innerException) : base(message, innerException)
        {
        }

        public bool ForcePause { get; set; }
    }
}
