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
    }
}
