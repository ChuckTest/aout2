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
        [Category("Fast Tests")]//2.6.5 Setting test categories
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

        //2.6.2 Checking for expected exceptions检验预期的异常
        [Test]
        [Category("Slow Tests")]//2.6.5 Setting test categories
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

        //2.6.4 NUnit’s fluent syntax
        [Test]
        [Category("Slow Tests")]
        public void IsValidLogFileName_EmptyFileName_ThrowFluent()
        {
            LogAnalyzer la = MakeAnalyzer();

            var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(string.Empty));
            //https://docs.nunit.org/articles/nunit/release-notes/breaking-changes.html
            //Is.StringContaining (use Does.Contain)
            Assert.That(ex.Message,Does.Contain("filename has to be provided"));
        }

        //Listing 2.5 Testing a class by calling a method and checking the value of a property
        [Test]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid()
        {
            LogAnalyzer la = MakeAnalyzer();
            la.IsValidLogFileName("badname.foo");
            Assert.False(la.WasLastFileNameValid);//Asserts on state of the system
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer la = MakeAnalyzer();
            la.IsValidLogFileName(file);
            Assert.AreEqual(expected, la.WasLastFileNameValid);
        }
    }
}
