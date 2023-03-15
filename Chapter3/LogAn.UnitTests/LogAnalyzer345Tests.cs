using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzer345Tests
    {
        [Test] 
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            //set up the stub to use, make sure it returns true
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager();
            fakeExtensionManager.WillBeValid = true;

            //create analyzer and inject stub
            LogAnalyzer345 log = new LogAnalyzer345();
            log.ExtensionManager = fakeExtensionManager;
            
            //Assert logic assuming extension is supported
            log.IsValidLogFileName("short.ext");
        }
    }
}
