using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    public class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
    {
        private IExtensionManager _manager;

        public IExtensionManager ExtensionManager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        public TestableLogAnalyzer(IExtensionManager mgr)
        {
            ExtensionManager = mgr;
        }

        public override IExtensionManager GetManager()
        {
            return ExtensionManager; 
        }
    }
}
