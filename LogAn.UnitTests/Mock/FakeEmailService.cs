using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests.Mock
{
    public class FakeEmailService : IEmailService
    {

        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
