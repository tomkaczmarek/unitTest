using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests.Mock
{
    public class FakeWebService2 : IWebService
    {
        private Exception _exception;
        
        public Exception ToThrow
        {
            get { return _exception; }
            set { _exception = value; }
        } 

        public void LogError(string message)
        {
            if (ToThrow != null)
                throw ToThrow;
        }
    }
}
