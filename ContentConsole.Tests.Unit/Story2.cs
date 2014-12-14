using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Tests.Unit
{
    using Moq;
    using NUnit.Framework;

    public class Story2 : TestBase
    {
        public override void Setup()
        {
            base.Setup();

            NegativeWordMock.Setup(x => x.Words.Add(It.IsAny<string>()));
            Processor.Words = NegativeWordMock.Object;
        }

        [Test]
        public void ShouldChangeNegativeWords()
        {
            Processor.SetNegativeWords(new List<string> { "a", "b", "c" });
            NegativeWordMock.Verify(x => x.Words.Add(It.IsAny<string>()));
        }
    }
}
