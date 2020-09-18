using LoggerExercise.Loggers;

namespace LoggerExercise.Core
{
    public interface ICommandInterpreter
    {
        void Execute(ILogger logger, string reportLevel, string date, string message);
    }
}
