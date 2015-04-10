using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrepEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrepEngineUnitTests
{
    [TestClass]
   public class CounterUnitTest
    {
        private IEnumerable<string> testData;
        private int expected;

        [TestMethod]
        public void ShouldCountNumberOfRepetedWord()
        {
            var testCounter = new Counter();
            expected = 4;
            testData = new List<string> { "test", "My test test", "Thisis test data" };

            var result = testCounter.Count(testData, "test");

            Assert.AreEqual(expected, result);
        }

        //public static IEnumerable<T> Add<T>(this IEnumerable<T> e, T value)
        //{
        //    foreach (var cur in e)
        //    {
        //        yield return cur;
        //    }
        //    yield return value;
        //}
    }
}
