using LoggerExercise.Appenders;
using LoggerExercise.Layouts;
using LoggerExercise.Loggers;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace LoggerExercise.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < n; i++)
            {
                string[] appenderInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string appenderType = appenderInfo[0];
                string layoutType = appenderInfo[1];
                ReportLevel level = ReportLevel.Info;

                if (appenderInfo.Length == 3)
                {
                    string reportLevel = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(appenderInfo[2].ToLower());
                    ReportLevel newLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);
                    level = newLevel;
                }

                IAppender appender = null;

                if (appenderType == "ConsoleAppender")
                {
                    if (layoutType == "SimpleLayout")
                    {
                        appender = new ConsoleAppender(new SimpleLayout());
                        appender.ReportLevel = level;
                        appenders.Add(appender);
                    }
                    else
                    {
                        appender = new ConsoleAppender(new XmlLayout());
                        appender.ReportLevel = level;
                        appenders.Add(appender);
                    }
                }
                else
                {
                    if (layoutType == "SimpleLayout")
                    {
                        appender = new FileAppender(new SimpleLayout(), new LogFile());
                        appender.ReportLevel = level;
                        appenders.Add(appender);
                    }
                    else
                    {
                        appender = new FileAppender(new XmlLayout(), new LogFile());
                        appender.ReportLevel = level;
                        appenders.Add(appender);
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] args = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string reportLevel = args[0];
                string date = args[1];
                string message = args[2];
                Logger logger = new Logger(appenders.ToArray());
                LoggerInterpreter loggerInterpreter = new LoggerInterpreter();
                loggerInterpreter.Execute(logger, reportLevel, date, message);
            }

            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
