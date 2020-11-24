using CoronavirusInTheUKDashboard.Api.Service;
using System;

namespace CoronavirusInTheUKDashboard.Api.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator.GeneratePosts(args);
        }
    }
}
