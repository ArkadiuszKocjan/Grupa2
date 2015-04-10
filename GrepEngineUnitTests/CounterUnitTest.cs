using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrepEngineUnitTests
{
    [TestClass]
    class CounterUnitTest
    {
        private IEnumerable<string> testData;
        [TestMethod()]
        public void ShouldCountNumberOfRepetedWord()
        {

        }

        //CounterUnitTest()
        //{
        //    var data = new[] {"test", "Mytest test", "Thisistestdata"};
        //    foreach (var s in data)
        //    {
        //        testData = testData.Add(s);
        //    }
        //}

        //public static IEnumerable<T> Add<T>(this IEnumerable<T> e, T value) 
        //{
        //    foreach ( var cur in e) 
        //    {
        //        yield return cur;
        //    }
        //    yield return value;
        //}
    }
}
