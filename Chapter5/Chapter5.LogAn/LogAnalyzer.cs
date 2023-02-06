namespace Chapter5.LogAn
{
    public class LogAnalyzer
    {
        private ILogger _logger;

        public LogAnalyzer(ILogger logger)
        {
            _logger = logger;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string fileName)
        {
            if (fileName.Length < MinNameLength)
            {
                _logger.LogError($"Filename too short: {fileName}");
            }
        }
    }
}
