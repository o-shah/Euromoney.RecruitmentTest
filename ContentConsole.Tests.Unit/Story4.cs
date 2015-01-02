using NUnit.Framework;

namespace ContentConsole.Tests.Unit
{

    public class Story4 : TestBase
    {
        [Test]
        public void ShouldDisableNegativeWordCount()
        {
            ForeignProcess.StartInfo.Arguments = "/t 4 /u Curator /d 1";
            if (!ForeignProcess.Start())
            {
                Assert.Fail("Failed to start process");
            }
            if (!ForeignProcess.WaitForExit(2000))
            {
                Assert.Fail("Process failed to exit on time");
            }
            string result = ForeignProcess.StandardOutput.ReadToEnd();

            Assert.AreEqual(result, "Running Story 4\r\nStory 4 result = " + this.DefaultInput + "\r\n");
            Assert.IsEmpty(ForeignProcess.StandardError.ReadToEnd());
        }
    }
}
