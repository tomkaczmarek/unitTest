using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool willBeValid = false;
        public Exception willThrow = null;

        public bool IsValid(string fileName)
        {
            if (willThrow != null)
                return false;
            return willBeValid;
        }
    }
}
