using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    //Using properties to inject dependencies. This is much simpler than 
    //using a constructor because each test can set only the properties that it needs to get the test underway
    public class LogAnalyzer345
    {
        private IExtensionManager manager;

        public LogAnalyzer345()
        {
            manager = new FileExtensionManager();
        }

        //Allows setting dependency via a property
        public IExtensionManager ExtensionManager
        {
            get { return manager; }
            set { manager = value; }
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
