using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentLibrary;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Tests.Unit
{
    [TestFixture]
    public abstract class TestBase
    {
        protected Mock<INegativeWords> NegativeWordMock { get; set; }
        protected string DefaultInput { get; private set; }
        protected WordProcessor Processor { get; private set; }

        [SetUp]
        public virtual void Setup()
        {
            NegativeWordMock = new Mock<INegativeWords>();
            DefaultInput = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            Processor = new WordProcessor(NegativeWordMock.Object);
        }
    }
}
