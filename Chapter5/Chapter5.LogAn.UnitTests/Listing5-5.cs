﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Chapter5.LogAn.UnitTests
{
    public class FakeWebService : IWebService//The fake web service you'll use as a mock
    {
        public string MessageToWebService;

        public void Write(string message)
        {
            MessageToWebService = message;
        }
    }

    public class FakeLogger2 : ILogger//The fake logger you'll use as a stub
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
            FakeWebService mockWebService = new FakeWebService();

            FakeLogger2 stubLogger = new FakeLogger2();
            stubLogger.WillThrow = new Exception("fake exception");

            var analyzer = new LogAnalyzer2(stubLogger, mockWebService);
            analyzer.MinNameLength = 8;

            string tooShortFileName = "abc.ext";
            analyzer.Analyze(tooShortFileName);

            Assert.That(mockWebService.MessageToWebService, Does.Contain("fake exception"));

        }
    }
}
