using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer3464UsingFactoryMethod
    {
        public bool IsValidLogFileName(string fileName)
        {
            return GetManager().IsValid(fileName);//Uses virtual GetManager() method
        }

        protected virtual IExtensionManager GetManager()
        {
            return new FileExtensionManager();//Returns hardcoded value
        }
    }
}
