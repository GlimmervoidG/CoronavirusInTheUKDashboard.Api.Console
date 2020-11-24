using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common
{
    public enum AreaTypeMetrics
    {
        [Description("Overview data for the United Kingdom")]
        overview,

        [Description("Nation data (England, Northern Ireland, Scotland, and Wales)")]
        nation,

        [Description("Region data")]
        region,

        [Description("NHS Region data")]
        nhsRegion,

        [Description("Upper-tier local authority data")]
        utla,

        [Description("Lower-tier local authority data")]
        ltla

    }
}
