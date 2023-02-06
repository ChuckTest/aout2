using NUnit.Framework;

namespace Chapter5.LogAn.UnitTests
{
    //Asserting against a handwritten fake object
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            //Arrange
            FakeLogger logger = new FakeLogger();//creating the fake
            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;

            //Act
            analyzer.Analyze("a.txt");

            //Assert
            //Using the fake as a mock object by asserting on it
            StringAssert.Contains("too short", logger.LastError);
        }
    }

    public class FakeLogger : ILogger
    {
        public string LastError;
        public void LoggerError(string message)
        {
            LastError = message;
        }
    }
}
