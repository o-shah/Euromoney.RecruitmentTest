using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Tests.Unit
{
    using System.Diagnostics;
    using ContentLibrary;
    using NUnit.Framework;

    public class Story1 : TestBase
    {
        [Test]
        public void ShouldCountNegativeWords()
        {
            ForeignProcess.StartInfo.Arguments = "/u:reader /t:1";
            ForeignProcess.Start();

            Assert.AreEqual(ForeignProcess.StandardOutput.ReadToEnd(), "Scanned the text:\r\n" + DefaultInput +
                "Total Number of negative words: 2\r\nPress ANY key to exit.");
        }
    }
}
