using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    using NUnit.Framework;

    public class Story4 : TestBase
    {
        [Test]
        public void ShouldDisableNegativeWordCount()
        {
            Processor.User = UserType.Curator;
            Processor.DisableFiltering = true;
            string result = Processor.FilterNegativeWords(DefaultInput);

            Assert.AreEqual(result, "some text I'll figure out once the test actually runs");
        }
    }
}
