using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    public class TestableLogAnalyzerWithStub : LogAnalyzerUsingFactoryMethod
    {
        private bool _supported;

        public bool IsSupported
        {
            get { return _supported; }
            set { _supported = value; }
        }

        protected override bool IsValid(string file)
        {
            return _supported;
        }

    }
}
