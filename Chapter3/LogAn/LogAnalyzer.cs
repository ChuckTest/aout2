using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    //3.2 Identifying a filesystem dependency in LogAn
    public class LogAnalyzer
    {
        private IExtensionManager manager;

        public LogAnalyzer(IExtensionManager mgr)
        {
            manager = mgr;
        }

        // let’s assume that the allowed filenames are stored somewhere on disk as a configuration setting for the application
        //: the code has some dependency on an external resource, which might break the test even though the code’s logic is perfectly valid
        public bool IsValidLogFileName(string fileName)
        {
            //read through the configuration file
            //return true if configuration says extension is supported.

            //Introducing a layer of indirection to avoid a direct dependency on the filesystem.The code that calls the filesystem is separated into a FileExtensionManager class, which will later be replaced with a stub in your test
            try
            {
                return manager.IsValid(fileName);
            }
            catch
            {
                return false;
            }
        }
    }
}
