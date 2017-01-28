using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzerUsingFactoryMethod
    {
        public bool IsValidLogFileName(string file)
        {
            return this.IsValid(file);
        }

        public virtual IExtensionManager GetManager()
        {
            return new FileExtensionManager();
        }
        
        protected virtual bool IsValid(string file)
        {
            IExtensionManager mgr = new FileExtensionManager();
            return mgr.IsValid(file);
        } 

    }
}
