using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer3
    {
        private IWebService2 _service;
        private ILogger _logger;

        public int MinLenghtFileName
        {
            get;
            set;
        }

        public LogAnalyzer3(IWebService2 service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        public void Analyze(string fileName)
        {
            if(fileName.Length < MinLenghtFileName)
            {
                try
                {
                    _logger.LogError(string.Format("Nazwa pliku jest za krótka {0}", fileName));
                }
                catch (Exception e)
                {
                    _service.Write(e.Message);
                }
            }
        }

    }
}
