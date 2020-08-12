using LoggerExercise.Appenders;

namespace LoggerExercise.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Error(string date, string message)
        {
            LogMessages(appenders, date, ReportLevel.Error, message);
        }

        public void Info(string date, string message)
        {
            LogMessages(appenders, date, ReportLevel.Info, message);
        }

        public void Warning(string date, string message)
        {
            LogMessages(appenders, date, ReportLevel.Warning, message);
        }

        public void Critical(string date, string message)
        {
            LogMessages(appenders, date, ReportLevel.Critical, message);
        }

        public void Fatal(string date, string message)
        {
            LogMessages(appenders, date, ReportLevel.Fatal, message);
        }

        private void LogMessages(IAppender[] appenders, string date, ReportLevel level, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(date, level, message);
            }
        }
    }
}
