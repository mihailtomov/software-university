using LoggerExercise.Layouts;
using LoggerExercise.Loggers;
using System;

namespace LoggerExercise.Appenders
{
    public class FileAppender : IAppender
    {
        private ILayout layout;
        private IFileLogger logger;

        public FileAppender(ILayout layout, IFileLogger logger)
        {
            this.layout = layout;
            this.logger = logger;
        }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; private set; }

        public void Append(string date, ReportLevel level, string message)
        {
            if (level >= ReportLevel)
            {
                string result = string.Format(layout.Template, date, level.ToString().ToUpper(), message) + Environment.NewLine;
                logger.Write(result);
                MessagesCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesCount}, File size {logger.Size}";
        }
    }
}
