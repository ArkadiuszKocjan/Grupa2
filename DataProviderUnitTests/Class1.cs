using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;
using System.Net;

namespace DataProviderUnitTests
{

    [TestClass]
    public class DataProviderTest
    {

        
        [TestMethod]
        public void TestDownloadPageContent()
        {
            DataProvider.DataProvider provider = new DataProvider.DataProvider();
            IEnumerable<string> tmp = provider.DownloadPageContent(@"https://www.google.pl/", false);
            Assert.AreEqual(tmp.ToList<string>().Any(), true);
            Assert.AreEqual(tmp.ToList<string>()[0].Length > 0, true);
        
        }

        [ExpectedException(typeof(WebException))]
        [TestMethod]
        public void TestWrongURL()
        {
            DataProvider.DataProvider provider = new DataProvider.DataProvider();
            IEnumerable<string> tmp = provider.DownloadPageContent(@"https://wssssBww.google.pl/", false);
        }
    }
}
