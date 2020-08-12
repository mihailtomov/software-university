using LoggerExercise.Layouts;
using System;

namespace LoggerExercise.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;
        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; private set; }

        public void Append(string date, ReportLevel level, string message)
        {
            if (level >= ReportLevel)
            {
                Console.WriteLine(string.Format(layout.Template, date, level.ToString().ToUpper(), message));
                MessagesCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesCount}";
        }
    }
}
