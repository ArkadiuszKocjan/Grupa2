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
        [TestMethod]
        public void FindLineWithStringTest()
        {
            var searcher = new Searcher();
            CollectionAssert.AreEqual(searcher.FindLineWithString(_listString, "mole of").ToList(), _correctLines);
        }

        [TestMethod]
        public void EmptyFindLineWithStringTest()
        {
            var searcher = new Searcher();
            CollectionAssert.AreEqual(searcher.FindLineWithString(_emptyList, "ala").ToList(), _emptyList);
        }

        [TestMethod]
        public void IncorrectFindLineWithStringTest()
        {
            var searcher = new Searcher();
            CollectionAssert.AreEqual(searcher.FindLineWithString(_listString, "alasad").ToList(), _emptyList);
        }

        /// <summary>
        /// checks if FindLineWithString returns empty IEnumerable based on null input
        /// </summary>
        [TestMethod]
        public void ShouldReturnEmptyIEnumerable()
        {
            var searcher = new Searcher();
            CollectionAssert.AreEqual(searcher.FindLineWithString(null, null).ToList(), _emptyList);
        }

    }
}
