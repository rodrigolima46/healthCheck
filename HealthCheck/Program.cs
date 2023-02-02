using System;
using System.Net;

namespace HealthCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the URL of the site you want to check:");
            string url = Console.ReadLine();

            //verify if the protocol was typed by the user
            url = VerifyProtocolTyped(url);

            if (CheckWebsite(url))
            {
                Console.WriteLine("Website is available.");
            }
            else
            {
                Console.WriteLine("Website is not available.");
            }

            Console.ReadKey();
        }

        static bool CheckWebsite(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 3000;
                request.Method = "HEAD";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch(Exception ex)
            {                
                return false;
            }
        }
        static string VerifyProtocolTyped(string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }
            return url;
        }
    }
}