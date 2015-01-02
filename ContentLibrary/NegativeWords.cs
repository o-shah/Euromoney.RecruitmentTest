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

        public List<string> Words
        {
            get;
            private set;
        }
    }
}
