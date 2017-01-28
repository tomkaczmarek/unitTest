using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogAn;

namespace LogAnWithSubstitute.UnitTests
{
    public class FakeLogger2 : ILogger
    {
        public Exception willThrow = null;
        public string loggerGotMessage;

        public void LogError(string message)
        {
            loggerGotMessage = message;
            if (willThrow != null)
                throw willThrow;
        }
    }
}
