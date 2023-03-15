using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzer346Tests
    {
        [Test]
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            //set up the stub to use, make sure it returns true
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager();
            fakeExtensionManager.WillBeValid = true;

            ExtensionManagerFactory.SetManager(fakeExtensionManager);
            
            //create analyzer and inject stub
            LogAnalyzer346 log = new LogAnalyzer346();//the injection of stub happened in constructor of LogAnalyzer346, which invoke ExtensionManagerFactory.Create();

            //Assert logic assuming extension is supported
            var result = log.IsValidLogFileName("short12.ext");
            Assert.True(result);
        }
    }
}
