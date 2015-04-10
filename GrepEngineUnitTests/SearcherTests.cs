using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrepEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrepEngineUnitTests
{
    [TestClass]
    public class SearcherTests
    {
        private List<string> _listString;
        private List<string> _correctLines;
        private List<string> _emptyList;
        /// <summary>
        /// initializing test vars
        /// </summary>
        [TestInitialize]
        public void LoadTextInput()
        {
            _listString = new List<string>();
            _listString.Add("So, oft it chances in particular men");
            _listString.Add("That for some vicious mole of nature in them,");
            _listString.Add("As, in their birth--wherein they are not guilty, ");
            _listString.Add("Since nature cannot choose his origin-- ");
            _listString.Add("That for some viciousss mole of nature in them,");
            _correctLines = new List<string>();
            _correctLines.Add("That for some vicious mole of nature in them,");
            _correctLines.Add("That for some viciousss mole of nature in them,");
            _emptyList = new List<string>();

        }
        /// <summary>
        /// checks if FindLineWithString returns 2 lines containing searched words
        /// </summary>
        [TestMethod]
        public void FindLineWithStringTest()
        {
            var logger = new Moq.Mock<Ilogger>();
            var searcher = new Searcher(logger.Object);
            CollectionAssert.AreEqual(searcher.FindLineWithString(_listString, "mole of").ToList(), _correctLines);
        }
        /// <summary>
        /// checks if FindLineWithString returns empty IEnumerable if text in where we search is empty
        /// </summary>
        [TestMethod]
        public void EmptyFindLineWithStringTest()
        {
            var logger = new Moq.Mock<Ilogger>();
            var searcher = new Searcher(logger.Object);
            CollectionAssert.AreEqual(searcher.FindLineWithString(_emptyList, "ala").ToList(), _emptyList);
        }
        /// <summary>
        /// checks if FindLineWithString returns empty IEnumerable when searched string isnt there
        /// </summary>
        [TestMethod]
        public void IncorrectFindLineWithStringTest()
        {
            var logger = new Moq.Mock<Ilogger>();
            var searcher = new Searcher(logger.Object);
            CollectionAssert.AreEqual(searcher.FindLineWithString(_listString, "alasad").ToList(), _emptyList);
        }

        /// <summary>
        /// checks if FindLineWithString returns empty IEnumerable based on null input
        /// </summary>
        [TestMethod]
        public void ShouldReturnEmptyIEnumerable()
        {
            var logger = new Moq.Mock<Ilogger>();
            var searcher = new Searcher(logger.Object);
            CollectionAssert.AreEqual(searcher.FindLineWithString(null, null).ToList(), _emptyList);
        }

    }
}
