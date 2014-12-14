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
        [Test]
        public void ShouldChangeNegativeWords()
        {
            ForeignProcess.StartInfo.Arguments = "/u:administrator /n:\"a,b,c\" /t:1";
            ForeignProcess.Start();

            Assert.AreEqual(ForeignProcess.StandardOutput.ReadToEnd(), "Negative Words Set");
        }
    }
}
