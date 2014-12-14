using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentLibrary;
using NUnit.Framework;

namespace ContentConsole.Tests.Unit
{

    public class Story4 : TestBase
    {
        [Test]
        public void ShouldDisableNegativeWordCount()
        {
            ForeignProcess.StartInfo.Arguments = "/t:4 /u:curator /d:1";
            ForeignProcess.Start();

            Assert.AreEqual(ForeignProcess.StandardOutput.ReadToEnd(), "story 4 result = " + this.DefaultInput);
        }
    }
}
