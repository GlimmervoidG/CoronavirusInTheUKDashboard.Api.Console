using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common
{
    public enum FormatOptions
    {
        [Description("Comma separated values")]
        csv,
        [Description("Standard json.")]
        json,
        [Description("Extensible Markup Language")]
        xml,
        [Description("Json but only the data.")]
        jsonl
    }
}
