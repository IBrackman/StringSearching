using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringSearching;

namespace StringSearchingTests
{
    public class SubstringSearchingAlgorythmsTests
    {
        public ISubstringSearchingAlgorythms Searcher;

        private static string ReadFile(string path) 
        {
            return File.ReadAllText(path, Encoding.Default).Replace("\n", " ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StringAndSubstringAreNull_Should_ThrowException()
        {
            Searcher.Search(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubstringIsNull_Should_ThrowException()
        {
            Searcher.Search("dgasdgwe57qfdgadr ", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StringIsNull_Should_ThrowException()
        {
            Searcher.Search(null, "dfhrdhjhj");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StringAndSubstringAreEmpty_Should_ThrowException()
        {
            Searcher.Search("", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StringIsEmpty_Should_ThrowException()
        {
            Searcher.Search("", "xfheh");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubstringIsEmpty_Should_ThrowException()
        {
            Searcher.Search("sdfhdf", "");
        }

        [TestMethod]
        public void OffsetsCount_Should_BeEq0()
        {
            var Text = "JBilbtheLKvhL Jhvtheljk Vjkv the kHJVJv cKJhV kjthe";

            var offsets = Searcher.Search(Text, "are");

            Assert.AreEqual(0, offsets.Length);
        }

        [TestMethod]
        public void OffsetsCount_Should_BeEq4()
        {
            var Text = "JBilbtheLKvhL Jhvtheljk Vjkv the kHJVJv cKJhV kjthe";

            var offsets = Searcher.Search(Text, "the");

            Assert.AreEqual(4, offsets.Length);
        }

        [TestMethod]
        public void FirstOffset_Should_BeEq5()
        {
            var Text = "JBilbtheLKvhL Jhvtheljk Vjkv the kHJVJv cKJhV kjthe";

            var offsets = Searcher.Search(Text, "the");

            Assert.AreEqual(5, offsets[0]);
        }

        [TestMethod]
        public void ThirdOffset_Should_BeEq20()
        {
            var Text = "JBilbtheLKvhL Jhvthetheljk Vjkv the kHJVJv cKJhV kjthe";

            var offsets = Searcher.Search(Text, "the");

            Assert.AreEqual(20, offsets[2]);
        }

        [TestMethod]
        public void LastOffset_Should_BeEq48()
        {
            var Text = "JBilbtheLKvhL Jhvtheljk Vjkv the kHJVJv cKJhV kjthe";

            var offsets = Searcher.Search(Text, "the");

            Assert.AreEqual(48, offsets[3]);
        }
    }
}