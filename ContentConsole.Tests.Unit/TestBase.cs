using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        protected string DefaultInput { get; private set; }
        protected Process ForeignProcess { get; private set; }

        [SetUp]
        public virtual void Setup()
        {
            DefaultInput = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            ForeignProcess = new Process();
            ForeignProcess.StartInfo.RedirectStandardInput = true;
            ForeignProcess.StartInfo.RedirectStandardOutput = true;
            ForeignProcess.StartInfo.FileName = "ContentConsole.exe";
            ForeignProcess.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
        }

        [TearDown]
        public virtual void Teardown()
        {
            ForeignProcess.StandardInput.Dispose();
            ForeignProcess.StandardOutput.Dispose();
            ForeignProcess.Dispose();
            ForeignProcess = null;
        }
    }
}
