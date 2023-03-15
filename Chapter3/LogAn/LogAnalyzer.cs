using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    //3.2 Identifying a filesystem dependency in LogAn
    public class LogAnalyzer
    {
        // let’s assume that the allowed filenames are stored somewhere on disk as a configuration setting for the application
        //: the code has some dependency on an external resource, which might break the test even though the code’s logic is perfectly valid
        public bool IsValidLogFileName(string fileName)
        {
            //read through the configuration file
            //return true if configuration says extension is supported.
        }
    }
}
