using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzer3464Tests
    {
        [Test]
        public void OverrideTest()
        {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;

            //Creates instance of class derived from class under test
            TestableLogAnalyzer logAnalyzer = new TestableLogAnalyzer(stub);
            bool result = logAnalyzer.IsValidLogFileName("file.ext");
            Assert.IsTrue(result);
        }
    }
}
