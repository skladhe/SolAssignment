using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAssignment
{
    public class LoggingHelper
    {
        Logger log;
        public LoggingHelper()
        {
            log = NLog.LogManager.GetCurrentClassLogger();
        }
        public void LogInfo(string message)
        {
            log.Info(message);
        }
        public void LogError(string message)
        {
            log.Error(message);
            
        }

        public void LogException(LogLevel level, Exception ex, string message)
        {
            log.Error(ex,message );
        }

    }
}
