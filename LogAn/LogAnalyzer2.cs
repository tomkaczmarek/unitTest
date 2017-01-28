using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer2
    {
        private IWebService _service;
        private IEmailService _email;

        public IWebService WebService
        {
            get { return _service; }
            set { _service = value; }
        }

        public IEmailService EmailService
        {
            get { return _email; }
            set { _email = value; }
        }

        public LogAnalyzer2(IWebService service, IEmailService email)
        {
            WebService = service;
            EmailService = email;
        }

        public void Analyze(string fileName)
        {
            if(fileName.Length < 8)
            {
                try
                {
                    WebService.LogError("Too short file name");
                }
                catch(Exception e)
                {
                    EmailService.SendEmail("somone@somwhere.com", "Brak mozliwosci rejestracji", e.Message);
                }
            }
        }

    }
}
