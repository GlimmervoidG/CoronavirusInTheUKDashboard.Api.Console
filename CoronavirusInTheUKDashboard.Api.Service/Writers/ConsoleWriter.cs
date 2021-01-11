using CoronavirusInTheUKDashboard.Api.Service.Models.Generator;
using CoronavirusInTheUKDashboard.Api.Service.Models.Writers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Writers
{
    public class ConsoleWriter : IPostWriter
    {
        public void Write(Post post)
        {
            Console.WriteLine(post.Content);
        }
    }
}
