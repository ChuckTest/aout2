using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter2.LogAn;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer analyzer = null;

        [SetUp]
        public void Setup()
        {
            analyzer = new LogAnalyzer();
        }

        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            bool result = analyzer.IsValidLogFileName("filewithgoodextension.slf");
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            bool result = analyzer.IsValidLogFileName("filewithbadextension.SLF");
            Assert.True(result);
        }
        
        [TestCase("filewithbadextension.SLF")]
        [TestCase("filewithgoodextension.slf")]
        public void IsValidFileName_ValidExtensions_ReturnsTrue(string file)
        {
            bool result = analyzer.IsValidLogFileName(file);
            Assert.True(result);
        }
        
        [TestCase("filewithbadextension.SLF", true)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithbadextension.foo", false)]
        public void IsValidFileName_VariousExtensions_ChecksThem(string file, bool expected)
        {
            bool result = analyzer.IsValidLogFileName(file);
            Assert.AreEqual(expected, result);
        }

        [TearDown]
        public void TearDown()
        {
            analyzer = null;
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_Throws()
        {
            LogAnalyzer la = MakeAnalyzer();

            var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(string.Empty));
            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}
