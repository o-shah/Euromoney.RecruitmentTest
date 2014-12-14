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
            ForeignProcess.StartInfo.Arguments = "/t:3";
            ForeignProcess.Start();

            Assert.AreEqual(ForeignProcess.StandardOutput.ReadToEnd(),
                "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.");
        }
    }
}
