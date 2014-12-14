using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Tests.Unit
{
    using NUnit.Framework;

    public class Story3 : TestBase
    {
        [Test]
        public void ShouldFilterNegativeWords()
        {
            string result = Processor.FilterNegativeWords(DefaultInput);

            Assert.AreEqual(result, "some text I'll figure out once the test actually runs");
        }
    }
}
