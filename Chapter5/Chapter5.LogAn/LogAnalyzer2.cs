using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5.LogAn
{
    public class LogAnalyzer2
    {
        private ILogger _logger;
        private IWebService _webService;

        public LogAnalyzer2(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string fileName)
        {
            if (fileName.Length < MinNameLength)
            {
                try
                {
                    _logger.LogError($"Filename too short: {fileName}");
                }
                catch (Exception ex)
                {
                    _webService.Write($"Error from logger: {ex}");
                }
            }
        }
    }
}
