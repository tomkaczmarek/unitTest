using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogAn;

namespace LogAnWithSubstitute.UnitTests
{
    public class FakeLogger : IWebService
    {
        public string LastError;

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
