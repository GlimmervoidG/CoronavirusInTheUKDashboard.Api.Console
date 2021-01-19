using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Queries
{
    public class UnknownDashboardException : Exception
    {
        public UnknownDashboardException(Exception ex) : base(ex.Message, ex) { }
    }
}
