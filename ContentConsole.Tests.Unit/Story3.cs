
using NUnit.Framework;

namespace ContentConsole.Tests.Unit
{
    public class Story3 : TestBase
    {
        [Test]
        public void ShouldFilterNegativeWords()
        {
            ForeignProcess.StartInfo.Arguments = "/t 3";
            if (!ForeignProcess.Start())
            {
                Assert.Fail("Failed to start process");
            }
            if (!ForeignProcess.WaitForExit(2000))
            {
                Assert.Fail("Process failed to exit on time");
            }
            string result = ForeignProcess.StandardOutput.ReadToEnd();

            Assert.AreEqual(result,
                "Running Story 3\r\nStory 3 result = The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.\r\n");
            Assert.IsEmpty(ForeignProcess.StandardError.ReadToEnd());
        }
    }
}
