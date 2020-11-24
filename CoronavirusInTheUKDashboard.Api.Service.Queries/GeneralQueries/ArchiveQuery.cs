using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.Service.Queries.GeneralQueries
{
    public class ArchiveQuery
    {
        public string TargetUrl { get; set; } 
        public string DoQuery()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var archiveUrl = $"https://web.archive.org/save/{TargetUrl}";

                    var html = client.GetAsync(archiveUrl, HttpCompletionOption.ResponseHeadersRead);
                    var result = html.Result;
                    var reletiveUri = result.RequestMessage.RequestUri;
                    var absuluteUri = Uri.EscapeUriString(reletiveUri.ToString()); 

                    return absuluteUri.ToString();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return "UNKNOWN";
            }

        }
    }
}
