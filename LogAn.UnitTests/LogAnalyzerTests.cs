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
    public class LogAnalyzerTest
    {

        [SetUp]
        public void SetUp()
        {
            ExtensionManagerFactory.CustomManager = null;
        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnFalse()
        {
            LogAnalyzer log = MakeAnalyzer();

            bool result = log.IsValidLogFileName("testFile.doc");

            Assert.False(result);           
        }

        [TestCase("testFile.slf")]
        [TestCase("testFiles.SLF")]
        public void IsValidLogFileName_ValidExtension_ReturnTrue(string file)
        {
            LogAnalyzer log = MakeAnalyzer();

            bool result = log.IsValidLogFileName(file);

            Assert.True(result);
            //Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_Throws()
        {
            LogAnalyzer log = MakeAnalyzer();

            var ex = Assert.Throws<ArgumentException>(() => log.IsValidLogFileName(""));

            StringAssert.Contains("No file name", ex.Message);
            //Assert.That(ex.Message, Does.Contain("No file name"));
        }

        [Test]
        [TestCase("fileName.slf", true)]
        [TestCase("fileName.boo", false)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            LogAnalyzer log = MakeAnalyzer();

            log.IsValidLogFileName(fileName);

            Assert.AreEqual(expected, log.WasLastFileNameValid);
        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnTrue()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            ExtensionManagerFactory.CustomManager = fakeManager;
            LogAnalyzer log = new LogAnalyzer();
            

            fakeManager.willBeValid = true;

            bool result = log.IsValidLogFileName("short.ext");
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();

            fakeManager.willThrow = new Exception("throw exception");
            fakeManager.willBeValid = true;

            
            LogAnalyzer log = new LogAnalyzer();

            bool result = log.IsValidLogFileName("anything.exp");

            Assert.False(result);
        }

        [Test]
        public void OverrideTest_ReturnTrue()
        {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.willBeValid = true;

            TestableLogAnalyzer log = new TestableLogAnalyzer(stub);
            bool result = log.GetManager().IsValid("file.bx");

            Assert.True(result);


        }

        [Test]
        public void OverrideTest_WithStub_ReturnTrue()
        {
            TestableLogAnalyzerWithStub logan = new TestableLogAnalyzerWithStub();

            logan.IsSupported = true;

            bool result = logan.IsValidLogFileName("test.slf");

            Assert.True(result);

        }

        [Test]
        public void Analyze_ToShortFileName_CallsWebService()
        {
            FakeWebService mock = new FakeWebService();
            LogAnalyzer log = new LogAnalyzer(mock);
            log.Analyze("abc.txt");

            StringAssert.Contains("Too short file name", mock.LastError);
        }

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();          
        }

    }
}
