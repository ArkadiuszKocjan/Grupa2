using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace DataProvider
{
    public class DataProvider
    {

        public IEnumerable<string> DownloadPageContent(string url, bool regexMode) 
        {
            WebClient dowloader = new WebClient();
            try
            {
                string content = dowloader.DownloadString(url);
                if (regexMode)
                    content = Regex.Replace(content, @"\<(.+?)\>", "");
                return  content.Split('\n');
            }
            catch (WebException ex)
            {
                Logger.Logger.Log(ex.Message);
                throw;
            }
        }
    }
}
