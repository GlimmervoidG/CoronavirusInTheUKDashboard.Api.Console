using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.Queries
{
    public class QueryClient
    {
        public string Url { get; set; }

        public string DoQuery()
        {
            var req = WebRequest.CreateHttp(Url);

            req.Timeout = 300000;

            /*
             * Headers
             */
            req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";

            /*
             * Execute
             */
            try
            {
                using (var resp = req.GetResponse())
                {
                    using (var str = resp.GetResponseStream())
                    using (var gsr = new GZipStream(str, CompressionMode.Decompress))
                    using (var sr = new StreamReader(gsr))

                    {
                        string s = sr.ReadToEnd();
                        return s;
                    }
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string respStr = sr.ReadToEnd();
                        int statusCode = (int)response.StatusCode;

                        string errorMsh = $"Request ({Url}) failed ({statusCode}) on, with error: {respStr}";
                        throw new Exception(errorMsh);
                    }
                }
            }

        }

    }
}
