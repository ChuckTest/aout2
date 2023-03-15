using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]

    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager();
            fakeExtensionManager.WillBeValid = true;

            LogAnalyzer log = new LogAnalyzer(fakeExtensionManager);
            bool result = log.IsValidLogFileName("short.ext");

            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager();
            fakeExtensionManager.WillThrow = new Exception("this is fake");

            LogAnalyzer log = new LogAnalyzer(fakeExtensionManager);
            bool result = log.IsValidLogFileName("anything.anyextension");

            Assert.False(result);
        }
    }
}
