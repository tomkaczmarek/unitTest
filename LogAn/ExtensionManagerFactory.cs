using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public static class ExtensionManagerFactory
    {
        private static IExtensionManager customManager = null;

        public  static IExtensionManager CustomManager
        {
            get { return customManager; }
            set { customManager = value; }
        }

        public  static IExtensionManager Create()
        {
            if (CustomManager != null)
                return CustomManager;
            return new FileExtensionManager();
        }

        public static void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }
    }
}
