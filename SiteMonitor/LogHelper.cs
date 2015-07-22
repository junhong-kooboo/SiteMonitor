using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace SiteMonitor
{
    public class LogHelper
    {
        public static void WriteLog(string siteName, string message)
        {
            if (String.IsNullOrEmpty(message) || String.IsNullOrEmpty(siteName)) return;

            var directoryPath = String.Format("{0}\\log", AppDomain.CurrentDomain.BaseDirectory);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var path = String.Format("{0}\\{1}.log", directoryPath, siteName);
            using (var fs = File.OpenWrite(path))
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                fs.Position = fs.Length;
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
