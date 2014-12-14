using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
