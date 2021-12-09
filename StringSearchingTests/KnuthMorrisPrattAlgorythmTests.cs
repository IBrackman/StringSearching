using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringSearching;

namespace StringSearchingTests
{
    [TestClass]
    public class KnuthMorrisPrattAlgorythmTests : SubstringSearchingAlgorythmsTests
    {
        [TestInitialize]
        public void KnuthMorrisPrattAlgorythmInitialization()
        {
            Searcher = new KnuthMorrisPrattAlgorythm();
        }
    }
}