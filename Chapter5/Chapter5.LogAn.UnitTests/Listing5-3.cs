using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace Chapter5.LogAn.UnitTests
{
    [TestFixture]
    public class Listing5_3
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>();//create a mock object that you'll assert against at the end of the test
            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;

            analyzer.Analyze("a.txt");

            logger.Received().LogError("Filename too short: a.txt");//sets expectation using NSub's API
        }
    }
}
