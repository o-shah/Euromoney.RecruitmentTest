using NUnit.Framework;

namespace ContentConsole.Tests.Unit
{
    public class Story1 : TestBase
    {
        [Test]
        public void ShouldCountNegativeWords()
        {
            ForeignProcess.StartInfo.Arguments = "/u Reader /t 1";
            if (!ForeignProcess.Start())
            {
                Assert.Fail("Failed to start process");
            }
            if (!ForeignProcess.WaitForExit(2000))
            {
                Assert.Fail("Process failed to exit on time");
            }
            string result = ForeignProcess.StandardOutput.ReadToEnd();

            Assert.AreEqual(result, "Scanned the text:\r\n" + DefaultInput +
                "\r\nTotal Number of negative words: 2\r\n");
            Assert.IsEmpty(ForeignProcess.StandardError.ReadToEnd());
        }
    }
}
