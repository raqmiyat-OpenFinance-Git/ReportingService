using Microsoft.Extensions.Logging;
using NLog;

namespace ReportingService.Services
{
    public class NLogManagerService
    {
        private readonly Logger _logger = LogManager.GetLogger("ReportingService");
        public void LogError(Exception ex,
        [System.Runtime.CompilerServices.CallerMemberName] string callingMethodName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string filePath = "")
        {
            string callingClassName = Path.GetFileNameWithoutExtension(filePath);
            _logger.Error(FormStructuredLog(callingClassName, callingMethodName, "Exception: " + ex.Message));

            if (ex.InnerException != null)
            {
                _logger.Error(FormStructuredLog(callingClassName, callingMethodName, "InnerException: " + ex.InnerException.Message));
            }
            _logger.Error(FormStructuredLog(callingClassName, callingMethodName, "StackTrace: " + ex.StackTrace));
        }
        public void LogInfo(string InfoText,
        [System.Runtime.CompilerServices.CallerMemberName] string callingMethodName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string filePath = "")
        {
            string callingClassName = Path.GetFileNameWithoutExtension(filePath);
            _logger.Info(FormStructuredLog(callingClassName, callingMethodName, InfoText));
        }
        private static string FormStructuredLog(string parentClassName, string parentMethodName, string message)
        {

            var separator = "-------------------------------------------------------------------------------------";
            var newLine = Environment.NewLine;
            var lineText = $"{newLine}Class Name :{parentClassName}{newLine}Method Name :{parentMethodName}{newLine}Message :{message}{newLine}{separator}";
            return lineText;
        }
    }
    public class NLogReportService
    {
        private readonly Logger _logger = LogManager.GetLogger("ReportService");
        public void LogError(Exception ex, [System.Runtime.CompilerServices.CallerMemberName] string callingMethodName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string filePath = "")
        {
            string callingClassName = Path.GetFileNameWithoutExtension(filePath);
            _logger.Error(FormStructuredLog(callingClassName, callingMethodName, "Exception: " + ex.Message));

            if (ex.InnerException != null)
            {
                _logger.Error(FormStructuredLog(callingClassName, callingMethodName, "InnerException: " + ex.InnerException.Message));
            }
            _logger.Error(FormStructuredLog(callingClassName, callingMethodName, "StackTrace: " + ex.StackTrace));
        }

        public void LogInfo(string InfoText, [System.Runtime.CompilerServices.CallerMemberName] string callingMethodName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string filePath = "")
        {
            string callingClassName = Path.GetFileNameWithoutExtension(filePath);
            _logger.Info(FormStructuredLog(callingClassName, callingMethodName, InfoText));
        }

        private static string FormStructuredLog(string parentClassName, string parentMethodName, string message)
        {

            var separator = "-------------------------------------------------------------------------------------";
            var newLine = Environment.NewLine;
            var lineText = $"{newLine}Class Name :{parentClassName}{newLine}Method Name :{parentMethodName}{newLine}Message :{message}{newLine}{separator}";
            return lineText;
        }
    }


}



