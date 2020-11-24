using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.UrlConstruction.Structure
{
    public class StructureBody : StructurePart
    {
        public static StructureBody Create(string name)
        {
            return new StructureBody() { Name = name };
        }

        public string Name { get; set; } 
        public List<StructurePart> Parts { get; set; } = new List<StructurePart>(); 
        public override string ToString()
        {
            var quote = '"';
            return $"{quote}{Name}{quote}:{{{string.Join(",", Parts)}}}";
        }
    }
}
