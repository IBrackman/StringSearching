using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringSearching;

namespace StringSearchingTests
{
    [TestClass]
    public class RabinKarpAlghrythmTests : SubstringSearchingAlgorythmsTests
    {
        [TestInitialize]
        public void RabinKarpAlghrythmInitialization()
        {
            Searcher = new RabinKarpAlghrythm();
        }
    }
}