using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogAn.UnitTests.Mock;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests2
    {
        [Test]
        public void Analyzer_WebServiceThrows_SendsEmail()
        {
            FakeWebService2 stubService = new FakeWebService2();
            stubService.ToThrow = new Exception("fake exception");

            FakeEmailService mockEmail = new FakeEmailService();

            LogAnalyzer2 log = new LogAnalyzer2(stubService, mockEmail);

            string tooShortFileName = "abc.abc";

            log.Analyze(tooShortFileName);

            StringAssert.Contains("somone@somwhere.com", mockEmail.To);
            StringAssert.Contains("Brak mozliwosci rejestracji", mockEmail.Subject);
            StringAssert.Contains("fake exception", mockEmail.Body);
        }

        [Test]
        public void Anlyzer_WebServiceThrows_SendEmail_NSubstitute()
        {

        }

        [Test]
        public void Anlyzer_WebServiceThrows_SendEmail_FakeItEasy()
        {

        }

        [Test]
        public void Anlyzer_WebServiceThrows_SendEmail_Moq()
        {

        }

    }
}
