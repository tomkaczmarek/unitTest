using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        private IExtensionManager mgr;
        private IWebService _service;
        private int _minLenghtFileMame = 8;

        public int MinLenghtFileName
        {
            get { return _minLenghtFileMame; }
            set { _minLenghtFileMame = value; }
        }

        public IExtensionManager ExtensionManager
        {
            get { return mgr; }
            set { mgr = value;}
        }

        public LogAnalyzer()
        {
            mgr = ExtensionManagerFactory.Create();
        }
        public LogAnalyzer(IWebService service)
        {
            _service = service;
        }

        public bool IsValidLogFileName(string fileName)
        {
            return mgr.IsValid(fileName) ? WasLastFileNameValid = true : WasLastFileNameValid = false;
        }

        public void Analyze(string fileName)
        {


            if(fileName.Length < MinLenghtFileName)
            {
                _service.LogError("Too short file name");
            }
        }
    }
}
