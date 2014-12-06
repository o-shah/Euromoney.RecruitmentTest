using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    using NUnit.Framework;

    public class Story1 : TestBase
    {
        public override void Setup()
        {
            base.Setup();

            Processor.SetNegativeWords(new List<string> { "swine", "bad", "nasty", "horrible" });
        }

        [Test]
        public void ShouldCountNegativeWords([Values(UserType.Reader, UserType.Curator, UserType.Administrator)] UserType userType)
        {
            Processor.User = userType;

            int result = Processor.CountNegativeWords(DefaultInput);

            Assert.AreEqual(result, 3);
        }
    }
}
