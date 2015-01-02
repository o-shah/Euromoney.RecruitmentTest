using NUnit.Framework;

namespace ContentConsole.Tests.Unit
{
    public class Story2 : TestBase
    {
        [Test]
        public void ShouldChangeNegativeWords()
        {
            ForeignProcess.StartInfo.Arguments = "/u Administrator /n \"a,b,c\" /t 2";
            if (!ForeignProcess.Start())
            {
                Assert.Fail("Failed to start process");
            }
            if (!ForeignProcess.WaitForExit(2000))
            {
                Assert.Fail("Process failed to exit on time");
            }
            string result = ForeignProcess.StandardOutput.ReadToEnd();

            Assert.AreEqual(result, "Negative Words Set\r\n");
            Assert.IsEmpty(ForeignProcess.StandardError.ReadToEnd());
        }
    }
}
