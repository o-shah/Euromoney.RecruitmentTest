using System.Collections.Generic;

namespace ContentLibrary
{
    public interface INegativeWords
    {
        IList<string> Words { get; }
    }
}
