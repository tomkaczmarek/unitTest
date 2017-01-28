using LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnWithSubstitute.UnitTests
{
    public class FakeWebService : IWebService2
    {
        public string messageToWebService;

        public void Write(string message)
        {
            messageToWebService = message;
        }
    }
}
