using System.Collections.Generic;
using System.Linq;

namespace ContentLibrary
{
    public class NegativeWords : INegativeWords
    {
        public NegativeWords(IEnumerable<string> dataStore)
        {
            Words = dataStore.ToList();
        }

        public IList<string> Words
        {
            get;
            private set;
        }
    }
}
