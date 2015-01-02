using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;

namespace ContentConsole.Tests.Unit
{
    [TestFixture]
    public abstract class TestBase
    {
        protected string DefaultInput { get; private set; }
        protected Process ForeignProcess { get; private set; }

        [SetUp]
        public virtual void Setup()
        {
            string startDirectory = @"..\..\..\ContentConsole\bin\debug\";
            DefaultInput = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            ForeignProcess = new Process();
            ForeignProcess.StartInfo.RedirectStandardInput = true;
            ForeignProcess.StartInfo.RedirectStandardOutput = true;
            ForeignProcess.StartInfo.RedirectStandardError = true;
            ForeignProcess.StartInfo.UseShellExecute = false;
            ForeignProcess.StartInfo.FileName = Path.Combine(startDirectory, "ContentConsole.exe");
            ForeignProcess.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
        }

        [TearDown]
        public virtual void Teardown()
        {
            if (ForeignProcess != null)
            {
                if (ForeignProcess.StandardInput != null)
                {
                    ForeignProcess.StandardInput.Dispose();
                }
                if (ForeignProcess.StandardOutput != null)
                {
                    ForeignProcess.StandardOutput.Dispose();
                }

                ForeignProcess.Dispose();
            }
            ForeignProcess = null;
        }
    }
}
