using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using LogAn;
using System.Diagnostics;
using FakeItEasy;
using Moq;

namespace LogAnWithSubstitute.UnitTests
{
    [TestFixture]
    public class LogAnWithSubstituteTest
    {

        [Test]
        public void Analyze_TooShortFileName_CallsLogger_NSubstitute()
        {
            IWebService logger = Substitute.For<IWebService>();
            LogAnalyzer analyzer = new LogAnalyzer(logger);

            analyzer.MinLenghtFileName = 8;
            analyzer.Analyze("abc.ab");
            logger.Received().LogError("Too short file name");
        }

        //test with write stub and mock
        [Test]
        public void Analyze_LoggerTrows_CallWebService()
        {
            FakeWebService mockWebService = new FakeWebService();

            FakeLogger2 stublogger = new FakeLogger2();
            stublogger.willThrow = new Exception("fake exception");

            LogAnalyzer3 analyzer = new LogAnalyzer3(mockWebService, stublogger);

            analyzer.MinLenghtFileName = 7;
            analyzer.Analyze("abc.a");

            Assert.That(mockWebService.messageToWebService, Does.Contain("fake exception"));

        }

        //test with NSubstitute framework
        [Test]
        public void Analyzer_LoggerThrows_CallWebservice_NSubstitute()
        {
            IWebService2 mockService = Substitute.For<IWebService2>();
            ILogger stubLogger = Substitute.For<ILogger>();

            stubLogger.When(logger => logger.LogError(Arg.Any<string>())).Do(info => 
            {
                throw new Exception("fake exception");
            });

            LogAnalyzer3 log = new LogAnalyzer3(mockService, stubLogger);

            log.MinLenghtFileName = 7;
            log.Analyze("abc.a");

            mockService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }

        [Test]
        public void Analyzer_LoggerThrows_CallWebService_FakeItEasy()
        {
            IWebService2 mockService = A.Fake<IWebService2>();
            ILogger stubLogger = A.Fake<ILogger>();

            A.CallTo(() => stubLogger.LogError(A<string>.Ignored)).Throws(new Exception("fake exception"));

            LogAnalyzer3 log = new LogAnalyzer3(mockService, stubLogger);

            log.MinLenghtFileName = 7;
            log.Analyze("abc.de");

            A.CallTo(() => mockService.Write(A<string>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void Analyzer_LoggerThrows_CallWebService_Moq()
        {
            var mockService = new Mock<IWebService2>();
            var stubLogger = new Mock<ILogger>();

            stubLogger.Setup(s => s.LogError(It.IsAny<string>())).Throws(new Exception("fake exception"));

            LogAnalyzer3 log = new LogAnalyzer3(mockService.Object, stubLogger.Object);

            log.MinLenghtFileName = 7;
            log.Analyze("abc.de");

            mockService.Verify(s => s.Write(It.IsAny<string>()));

        }

    }
}
