using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringSearching;

namespace StringSearchingTests
{
    [TestClass]
    public class KnuthMorrisPrattAlgorythmTestsInitializator : SubstringSearchingAlgorythmsTests
    {
        [TestInitialize]
        public void KnuthMorrisPrattAlgorythmInitialization()
        {
            Searcher = new KnuthMorrisPrattAlgorythm();
        }
    }
}
