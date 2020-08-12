namespace LoggerExercise.Loggers
{
    public interface IFileLogger
    {
        int Size { get; }
        void Write(string message);
    }
}
