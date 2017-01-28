using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests.Mock
{
    public class FakeWebService : IWebService
    {
        private string _lastError;

        public string LastError
        {
            get { return _lastError; }
            set { _lastError = value; }
        }


        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
