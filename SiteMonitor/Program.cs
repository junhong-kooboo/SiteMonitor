using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            foreach (var site in SiteConfig.Sites)
            {
                try
                {
                    Uri uri = !site.StartsWith("http") ? new Uri(String.Format("http://{0}", site)) : new Uri(site);
                    client.DownloadData(uri);
                }
                catch
                {
                    string message = String.Format("{0}:{1} {2}", DateTime.Now.ToString(CultureInfo.InvariantCulture), site, "无法访问");
                    Console.WriteLine(message);
                    LogHelper.WriteLog(site, message);
                }
            }
            Thread.Sleep(60 * 1000);
            Console.Read();
        }
    }
}
