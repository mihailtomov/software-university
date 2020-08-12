using LoggerExercise.Loggers;
using System;

namespace LoggerExercise.Core
{
    public class LoggerInterpreter : ICommandInterpreter
    {
        public void Execute(ILogger logger, string reportLevel, string date, string message)
        {
            if (!Enum.TryParse(reportLevel, true, out ReportLevel level))
            {
                throw new ArgumentException("Invalid input.");
            }

            switch (level)
            {
                case ReportLevel.Info: logger.Info(date, message);
                    break;
                case ReportLevel.Warning: logger.Warning(date, message);
                    break;
                case ReportLevel.Error: logger.Error(date, message);
                    break;
                case ReportLevel.Critical: logger.Critical(date, message);
                    break;
                case ReportLevel.Fatal: logger.Fatal(date, message);
                    break;
            }
        }
    }
}
