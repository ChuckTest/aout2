using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Chapter5.LogAn.UnitTests
{
    public class FakeWebService : IWebService
    {
        public string MessageToWebService;

        public void Write(string message)
        {
            MessageToWebService = message;
        }
    }

    public class FakeLogger2 : ILogger
    {
        public Exception WillThrow = null;
        public string LoggerGotMessage = null;

        public void LogError(string message)
        {
            LoggerGotMessage = message;
            if (WillThrow != null)
            {
                throw WillThrow;
            }
        }
    }

    [TestFixture]
    public class Listing5_5
    {
        [Test]
        public void Analyze_LoggerThrows_CallWebService()
        {

        }
    }
}
