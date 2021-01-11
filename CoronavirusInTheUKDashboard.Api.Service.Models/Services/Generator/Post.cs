using CoronavirusInTheUKDashboard.Api.Service.Models.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Models.Generator
{
    public class Post
    {
        public DateTime TargetDate { get; set; }
        public PostTypes Type { get; set; }
        public string Content { get; set; }

    }
}
