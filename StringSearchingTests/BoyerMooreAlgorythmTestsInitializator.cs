using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringSearching;

namespace StringSearchingTests
{
    [TestClass]
    public class BoyerMooreAlgorythmTestsInitializator : SubstringSearchingAlgorythmsTests
    {
        [TestInitialize]
        public void BoyerMooreAlgorythmInitialization()
        {
            Searcher = new BoyerMooreAlgorythm();
        }
    }
}
