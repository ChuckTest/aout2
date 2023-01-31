namespace Chapter2.LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (!fileName.EndsWith(".SLF"))
            {
                return false;
            }

            return true;
        }
    }
}
