using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

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
            Assert.AreEqual(tmp.ToList<string>().Count > 0, true);
            Assert.AreEqual(tmp.ToList<string>()[0].Length > 0, true);
        }
    }
}
