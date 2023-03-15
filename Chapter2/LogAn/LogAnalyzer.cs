using System;

namespace Chapter2.LogAn
{
    public class LogAnalyzer
    {
        //2.7 Testing results that are system state changes instead of return values
        public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;//changes the state of the system

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("filename has to be provided");
            }

            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            WasLastFileNameValid = true;//changes the state of the system
            return true;
        }
    }
}
