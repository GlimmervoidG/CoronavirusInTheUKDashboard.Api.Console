using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Structure
{
    public class Structure : ApiRequestPart
    {
        public static Structure Create()
        {
            return new Structure();
        }
        public List<StructurePart> Parts { get; set; } = new List<StructurePart>();

        public override string ToString() { 
            return $"structure={{{string.Join(",", Parts)}}}";
        }
    }
}

        